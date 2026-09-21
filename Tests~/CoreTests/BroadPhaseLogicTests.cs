// Copyright (c) STUDIO MeowToon. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

#nullable enable

using System.Collections.Generic;
using NUnit.Framework;

using Modio.Core;

namespace Modio.Tests.Core {
    ///////////////////////////////////////////////////////////////////////////////////////////////////
    // private Classes

    /// <summary>A stand-in world table, for testing with no tie to germio at all.</summary>
    sealed class FakeNames : INameSource {
        readonly Dictionary<int, (string Kind, string ID)> _table = new();

        public void Add(int id, string kind, string id_string) {
            _table[id] = (kind, id_string);
        }

        public (string Kind, string ID) NameOf(int instance_id) {
            return _table.TryGetValue(instance_id, out var found) ? found : ("", "");
        }
    }

    ///////////////////////////////////////////////////////////////////////////////////////////////////
    // public Classes

    /// <summary>
    /// Unit tests for turning raw broad-phase hits into Places, and on into
    /// the wedge check (modio TASK-034, split from TASK-025).
    /// </summary>
    /// <author>h.adachi (STUDIO MeowToon)</author>
    [TestFixture]
    public class BroadPhaseLogicTests {

        [Test, Description("A full, 16-hit buffer is still gathered with none of the valid ones lost")]
        public void Gather_ASixteenHitBuffer_LosesNoneOfTheValidOnes() {
            var names = new FakeNames();
            var hits = new List<RawHit>();
            for (int i = 0; i < 16; i++) {
                names.Add(id: i, kind: "Ground", id_string: $"g_{i}");
                hits.Add(new RawHit(id: i, closest_point: new Vec3(x: 0f, y: 0f, z: 8f)));
            }
            var into = new List<Found>();

            BroadPhaseLogic.Gather(self: new Self(heading: 0f), sight_reach: 30f, sight_half_yaw: 90f,
                sight_half_pitch: 45f, seek: new Seek(kind: "Ground"), own_id: "h_self",
                own_position: new Vec3(x: 0f, y: 0f, z: 0f), hits: hits, hit_count: 16, names: names, into: into);

            Assert.That(into, Has.Count.EqualTo(16));
        }

        [Test, Description("A wide collider's own closest point, outside the wedge center, is still found")]
        public void Gather_AWideColliderOffCenter_IsStillFound() {
            var names = new FakeNames();
            names.Add(id: 1, kind: "Ground", id_string: "g_1");
            // Closest point at x=8.66, z=5 (bearing 60 from own_position at the
            // world's own zero) — matches WedgeCheck's own already-proven
            // ellipse case at yaw 60, halfYaw 90, halfPitch 20, height 2.5.
            var hits = new List<RawHit> { new RawHit(id: 1, closest_point: new Vec3(x: 8.66f, y: 2.5f, z: 5f)) };
            var into = new List<Found>();

            BroadPhaseLogic.Gather(self: new Self(heading: 0f), sight_reach: 30f, sight_half_yaw: 90f,
                sight_half_pitch: 20f, seek: new Seek(kind: "Ground"), own_id: "h_self",
                own_position: new Vec3(x: 0f, y: 0f, z: 0f), hits: hits, hit_count: 1, names: names, into: into);

            Assert.That(into, Has.Count.EqualTo(1),
                "own_position must be subtracted before the wedge check ever runs.");
        }

        [Test, Description("The character's own id, among the hits, is dropped")]
        public void Gather_TheCharactersOwnId_IsDropped() {
            var names = new FakeNames();
            names.Add(id: 1, kind: "Human", id_string: "h_self");
            var hits = new List<RawHit> { new RawHit(id: 1, closest_point: new Vec3(x: 0f, y: 0f, z: 1f)) };
            var into = new List<Found>();

            BroadPhaseLogic.Gather(self: new Self(heading: 0f), sight_reach: 30f, sight_half_yaw: 90f,
                sight_half_pitch: 45f, seek: new Seek(kind: "Human"), own_id: "h_self",
                own_position: new Vec3(x: 0f, y: 0f, z: 0f), hits: hits, hit_count: 1, names: names, into: into);

            Assert.That(into, Is.Empty);
        }

        [Test, Description("One id, found through two hits, is read once")]
        public void Gather_OneIdThroughTwoHits_IsReadOnce() {
            var names = new FakeNames();
            names.Add(id: 1, kind: "Ground", id_string: "g_1");
            names.Add(id: 2, kind: "Ground", id_string: "g_1");
            var hits = new List<RawHit> {
                new RawHit(id: 1, closest_point: new Vec3(x: 0f, y: 0f, z: 8f)),
                new RawHit(id: 2, closest_point: new Vec3(x: 0.1f, y: 0f, z: 8f))
            };
            var into = new List<Found>();

            BroadPhaseLogic.Gather(self: new Self(heading: 0f), sight_reach: 30f, sight_half_yaw: 90f,
                sight_half_pitch: 45f, seek: new Seek(kind: "Ground"), own_id: "h_self",
                own_position: new Vec3(x: 0f, y: 0f, z: 0f), hits: hits, hit_count: 2, names: names, into: into);

            Assert.That(into, Has.Count.EqualTo(1));
        }
    }
}
