// Copyright (c) STUDIO MeowToon. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

#nullable enable

using System.Collections.Generic;
using NUnit.Framework;

using Modio.Core;

namespace Modio.Tests.Core {
    ///////////////////////////////////////////////////////////////////////////////////////////////////
    // public Classes

    /// <summary>
    /// Unit tests for the wedge check (modio TASK-024, docs/modio_spec.md 3.7.3).
    ///
    /// Bearing, on a Place, is held against the world's own +Z — never against
    /// the character's own heading. WedgeCheck turns Bearing and Self.Heading
    /// together into the yaw a wedge asks after, so turning Self.Heading turns
    /// the wedge itself, with no Place read again.
    /// </summary>
    /// <author>h.adachi (STUDIO MeowToon)</author>
    [TestFixture]
    public class WedgeCheckTests {

        ///////////////////////////////////////////////////////////////////////////////////////////////
        // private static Methods [verb]

        static Place place(string kind, string id, float bearing, float distance, float height = 0f) {
            return new Place(kind: kind, id: id, bearing: bearing, distance: distance, height: height);
        }

        static void worth(Self self, float sight_reach, float sight_half_yaw, float sight_half_pitch,
            Seek seek, string own_id, IReadOnlyList<Place> near, List<Found> into) {
            WedgeCheck.Worth(self: self, sight_reach: sight_reach, sight_half_yaw: sight_half_yaw,
                sight_half_pitch: sight_half_pitch, seek: seek, own_id: own_id, near: near, into: into);
        }

        ///////////////////////////////////////////////////////////////////////////////////////////////
        // public Methods [verb]

        [Test, Description("Straight ahead (yaw 0, pitch 0) is always inside")]
        public void Worth_StraightAhead_IsInside() {
            var near = new List<Place> { place(kind: "Ground", id: "g_1", bearing: 0f, distance: 8f) };
            var into = new List<Found>();

            worth(self: new Self(heading: 0f), sight_reach: 30f, sight_half_yaw: 90f, sight_half_pitch: 45f,
                seek: new Seek(kind: "Ground"), own_id: "h_self", near: near, into: into);

            Assert.That(into, Has.Count.EqualTo(1));
        }

        [Test, Description("Straight behind is always outside")]
        public void Worth_StraightBehind_IsOutside() {
            var near = new List<Place> { place(kind: "Ground", id: "g_1", bearing: 180f, distance: 8f) };
            var into = new List<Found>();

            worth(self: new Self(heading: 0f), sight_reach: 30f, sight_half_yaw: 90f, sight_half_pitch: 45f,
                seek: new Seek(kind: "Ground"), own_id: "h_self", near: near, into: into);

            Assert.That(into, Is.Empty);
        }

        [Test, Description("Dead on the side bound (yaw = halfYaw, pitch 0) is inside")]
        public void Worth_DeadOnSideBound_IsInside() {
            var near = new List<Place> { place(kind: "Ground", id: "g_1", bearing: 90f, distance: 8f) };
            var into = new List<Found>();

            worth(self: new Self(heading: 0f), sight_reach: 30f, sight_half_yaw: 90f, sight_half_pitch: 45f,
                seek: new Seek(kind: "Ground"), own_id: "h_self", near: near, into: into);

            Assert.That(into, Has.Count.EqualTo(1), "Dead on the bound is held inside, not outside.");
        }

        [Test, Description("One degree past the side bound is outside")]
        public void Worth_OneDegreePastSideBound_IsOutside() {
            var near = new List<Place> { place(kind: "Ground", id: "g_1", bearing: 91f, distance: 8f) };
            var into = new List<Found>();

            worth(self: new Self(heading: 0f), sight_reach: 30f, sight_half_yaw: 90f, sight_half_pitch: 45f,
                seek: new Seek(kind: "Ground"), own_id: "h_self", near: near, into: into);

            Assert.That(into, Is.Empty);
        }

        [Test, Description("Dead on the up bound (pitch = halfPitch) is inside")]
        public void Worth_DeadOnUpBound_IsInside() {
            // distance 10, height 10 gives a pitch of 45 degrees (atan2(10, 10)).
            var near = new List<Place> { place(kind: "Ground", id: "g_1", bearing: 0f, distance: 10f, height: 10f) };
            var into = new List<Found>();

            worth(self: new Self(heading: 0f), sight_reach: 30f, sight_half_yaw: 90f, sight_half_pitch: 45f,
                seek: new Seek(kind: "Ground"), own_id: "h_self", near: near, into: into);

            Assert.That(into, Has.Count.EqualTo(1), "Dead on the bound is held inside, not outside.");
        }

        [Test, Description("At 45 degrees, the ellipse gives a different answer than a round cap would")]
        public void Worth_At45Degrees_TheEllipseDiffersFromARoundCap() {
            // halfYaw 90, halfPitch 20. At yaw 60, pitch 14: a round cap sized to
            // the smaller half-angle (20) would drop this (its own combined angle
            // runs well past 20). The true ellipse holds it: (60/90)^2 + (14/20)^2
            // = 0.444 + 0.49 = 0.934, at or under 1.
            var near = new List<Place> {
                place(kind: "Ground", id: "g_1", bearing: 60f, distance: 10f, height: 10f * 0.25f)
            };
            var into = new List<Found>();

            worth(self: new Self(heading: 0f), sight_reach: 30f, sight_half_yaw: 90f, sight_half_pitch: 20f,
                seek: new Seek(kind: "Ground"), own_id: "h_self", near: near, into: into);

            Assert.That(into, Has.Count.EqualTo(1),
                "A round cap sized to the smaller half-angle would drop this; the true ellipse holds it.");
        }

        [Test, Description("Where Sight.reach is the smaller, it is the one that holds")]
        public void Worth_SightReachIsSmaller_SightReachHolds() {
            var near = new List<Place> { place(kind: "Ground", id: "g_1", bearing: 0f, distance: 20f) };
            var into = new List<Found>();

            // Sight.reach 15 is smaller than Seek.reach 30, so a thing at 20 —
            // inside Seek's own reach, past Sight's own — is dropped.
            worth(self: new Self(heading: 0f), sight_reach: 15f, sight_half_yaw: 90f, sight_half_pitch: 45f,
                seek: new Seek(kind: "Ground", reach: 30f), own_id: "h_self", near: near, into: into);

            Assert.That(into, Is.Empty, "Sight's own, smaller reach must hold, not Seek's own, wider one.");
        }

        [Test, Description("Where Seek.spread is the smaller, it is the one that holds")]
        public void Worth_SeekSpreadIsSmaller_SeekSpreadHolds() {
            var near = new List<Place> { place(kind: "Ground", id: "g_1", bearing: 60f, distance: 8f) };
            var into = new List<Found>();

            // Sight.halfYaw 90 alone would hold this at yaw 60. Seek.spread 40
            // (half-spread 20) is the smaller, and must hold instead — dropping it.
            worth(self: new Self(heading: 0f), sight_reach: 30f, sight_half_yaw: 90f, sight_half_pitch: 45f,
                seek: new Seek(kind: "Ground", spread: 40f), own_id: "h_self", near: near, into: into);

            Assert.That(into, Is.Empty, "Seek's own, smaller spread must hold, not Sight's own, wider one.");
        }

        [Test, Description("A character with weak sight finds nothing where a keen one finds a thing")]
        public void Worth_WeakSight_FindsNothingAKeenOneWouldFind() {
            var near = new List<Place> { place(kind: "Ground", id: "g_1", bearing: 30f, distance: 8f) };

            var keen = new List<Found>();
            worth(self: new Self(heading: 0f), sight_reach: 30f, sight_half_yaw: 90f, sight_half_pitch: 45f,
                seek: new Seek(kind: "Ground"), own_id: "h_self", near: near, into: keen);

            var weak = new List<Found>();
            worth(self: new Self(heading: 0f), sight_reach: 30f, sight_half_yaw: 10f, sight_half_pitch: 45f,
                seek: new Seek(kind: "Ground"), own_id: "h_self", near: near, into: weak);

            Assert.That(keen, Has.Count.EqualTo(1));
            Assert.That(weak, Is.Empty,
                "The same Rule, given to two characters: the keen-sighted one finds the thing, "
                + "the weak-sighted one does not — with no line of code telling it to.");
        }

        [Test, Description("Turn heading by 90 degrees and the wedge turns with it")]
        public void Worth_HeadingTurnedBy90_TheWedgeTurnsWithIt() {
            var near = new List<Place> { place(kind: "Ground", id: "g_1", bearing: 90f, distance: 8f) };

            var facing_world_ahead = new List<Found>();
            worth(self: new Self(heading: 0f), sight_reach: 30f, sight_half_yaw: 30f, sight_half_pitch: 45f,
                seek: new Seek(kind: "Ground"), own_id: "h_self", near: near, into: facing_world_ahead);

            var facing_toward_it = new List<Found>();
            worth(self: new Self(heading: 90f), sight_reach: 30f, sight_half_yaw: 30f, sight_half_pitch: 45f,
                seek: new Seek(kind: "Ground"), own_id: "h_self", near: near, into: facing_toward_it);

            Assert.That(facing_world_ahead, Is.Empty,
                "Bearing 90, heading 0: the thing sits at the world's own side, outside a narrow wedge.");
            Assert.That(facing_toward_it, Has.Count.EqualTo(1),
                "Bearing 90, heading 90: the character now faces the thing outright, and finds it.");
        }

        [Test, Description("The character's own id is never given back")]
        public void Worth_TheCharactersOwnID_IsNeverGivenBack() {
            var near = new List<Place> { place(kind: "Ground", id: "h_self", bearing: 0f, distance: 1f) };
            var into = new List<Found>();

            worth(self: new Self(heading: 0f), sight_reach: 30f, sight_half_yaw: 90f, sight_half_pitch: 45f,
                seek: new Seek(kind: "Ground"), own_id: "h_self", near: near, into: into);

            Assert.That(into, Is.Empty, "A character never finds itself.");
        }

        [Test, Description("The same id twice comes back once")]
        public void Worth_TheSameIDTwice_ComesBackOnce() {
            var near = new List<Place> {
                place(kind: "Ground", id: "g_1", bearing: 0f, distance: 8f),
                place(kind: "Ground", id: "g_1", bearing: 1f, distance: 8f)
            };
            var into = new List<Found>();

            worth(self: new Self(heading: 0f), sight_reach: 30f, sight_half_yaw: 90f, sight_half_pitch: 45f,
                seek: new Seek(kind: "Ground"), own_id: "h_self", near: near, into: into);

            Assert.That(into, Has.Count.EqualTo(1), "One thing, seen through two colliders, is held once.");
        }
    }
}
