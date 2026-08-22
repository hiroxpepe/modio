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
    /// Unit tests for deciding which hits are worth a straight line (modio P-02).
    ///
    /// Seeking runs in two stages: a wide cheap check every tick, and a straight
    /// line thrown only where the cheap one finds something. **Throwing a line is
    /// what costs**, and with 64 characters running, throwing one at everything
    /// every tick would cost for nothing.
    ///
    /// Which hits are worth a line is a plain judgement, and is made here, away
    /// from Unity, where it is cheap. See docs/modio_spec.md 3.7.
    /// </summary>
    /// <author>h.adachi (STUDIO MeowToon)</author>
    [TestFixture]
    public class StageGateTests {

        ///////////////////////////////////////////////////////////////////////////////////////////////
        // private static Methods [verb]

        static Near near(string kind, string id, float angle, float distance) {
            return new Near(kind: kind, id: id, angle: angle, distance: distance);
        }

        ///////////////////////////////////////////////////////////////////////////////////////////////
        // public Methods [verb]

        [Test, Description("Nothing near gives back nothing worth a line")]
        public void Worth_NothingNear_GivesBackNothing() {
            var found = new List<Near>();
            var seek = new Seek(kind: "Ground");
            var worth = new List<Near>();

            StageGate.Worth(near: found, seek: seek, into: worth);

            Assert.That(worth, Is.Empty);
        }

        [Test, Description("A thing of the right kind is worth a line")]
        public void Worth_RightKind_IsWorthALine() {
            var found = new List<Near> { near(kind: "Ground", id: "g_1042", angle: 20f, distance: 8.5f) };
            var seek = new Seek(kind: "Ground");
            var worth = new List<Near>();

            StageGate.Worth(near: found, seek: seek, into: worth);

            Assert.That(worth, Has.Count.EqualTo(1));
            Assert.That(worth[0].ID, Is.EqualTo("g_1042"));
        }

        [Test, Description("A thing of another kind is not worth a line")]
        public void Worth_WrongKind_IsNotWorthALine() {
            var found = new List<Near> { near(kind: "Human", id: "h_2001", angle: 20f, distance: 8.5f) };
            var seek = new Seek(kind: "Ground");
            var worth = new List<Near>();

            StageGate.Worth(near: found, seek: seek, into: worth);

            Assert.That(worth, Is.Empty,
                "A wide check catches every kind; only the kind sought is worth a line.");
        }

        [Test, Description("A thing further off than the reach is not worth a line")]
        public void Worth_FurtherThanReach_IsNotWorthALine() {
            var found = new List<Near> { near(kind: "Ground", id: "g_1042", angle: 20f, distance: 40f) };
            var seek = new Seek(kind: "Ground", reach: 15.0f);
            var worth = new List<Near>();

            StageGate.Worth(near: found, seek: seek, into: worth);

            Assert.That(worth, Is.Empty);
        }

        [Test, Description("A thing further round than the spread is not worth a line")]
        public void Worth_FurtherRoundThanSpread_IsNotWorthALine() {
            var found = new List<Near> { near(kind: "Ground", id: "g_1042", angle: 120f, distance: 8.5f) };
            var seek = new Seek(kind: "Ground", spread: 90.0f);
            var worth = new List<Near>();

            StageGate.Worth(near: found, seek: seek, into: worth);

            Assert.That(worth, Is.Empty);
        }

        ///////////////////////////////////////////////////////////////////////////////////////////////
        // Nearest first, so a line is thrown where it counts

        [Test, Description("What comes back is ordered nearest first")]
        public void Worth_ManyNear_ComeBackNearestFirst() {
            var found = new List<Near> {
                near(kind: "Ground", id: "g_far",  angle: 10f, distance: 20f),
                near(kind: "Ground", id: "g_near", angle: 20f, distance: 5f),
                near(kind: "Ground", id: "g_mid",  angle: 30f, distance: 12f)
            };
            var seek = new Seek(kind: "Ground");
            var worth = new List<Near>();

            StageGate.Worth(near: found, seek: seek, into: worth);

            Assert.That(worth[0].ID, Is.EqualTo("g_near"));
            Assert.That(worth[1].ID, Is.EqualTo("g_mid"));
            Assert.That(worth[2].ID, Is.EqualTo("g_far"));
        }

        [Test, Description("Two at the same distance keep the order they came in")]
        public void Worth_SameDistance_KeepTheOrderTheyCameIn() {
            var found = new List<Near> {
                near(kind: "Ground", id: "g_first",  angle: 10f, distance: 8f),
                near(kind: "Ground", id: "g_second", angle: 20f, distance: 8f)
            };
            var seek = new Seek(kind: "Ground");
            var worth = new List<Near>();

            StageGate.Worth(near: found, seek: seek, into: worth);

            Assert.That(worth[0].ID, Is.EqualTo("g_first"),
                "The same list must always give back the same order.");
        }

        ///////////////////////////////////////////////////////////////////////////////////////////////
        // The list given to fill is used again, tick after tick

        [Test, Description("The list to fill is emptied first, so nothing carries over")]
        public void Worth_FillsAListAlreadyHoldingSomething_EmptiesItFirst() {
            var worth = new List<Near> { near(kind: "Ground", id: "g_old", angle: 0f, distance: 1f) };
            var found = new List<Near> { near(kind: "Ground", id: "g_new", angle: 20f, distance: 8.5f) };
            var seek = new Seek(kind: "Ground");

            StageGate.Worth(near: found, seek: seek, into: worth);

            Assert.That(worth, Has.Count.EqualTo(1));
            Assert.That(worth[0].ID, Is.EqualTo("g_new"),
                "Runtime fills the same list again each tick; what was there before must go.");
        }

        [Test, Description("What was found is left as it was")]
        public void Worth_LeavesWhatWasFoundAsItWas() {
            var found = new List<Near> {
                near(kind: "Ground", id: "g_far",  angle: 10f, distance: 20f),
                near(kind: "Ground", id: "g_near", angle: 20f, distance: 5f)
            };
            var seek = new Seek(kind: "Ground");
            var worth = new List<Near>();

            StageGate.Worth(near: found, seek: seek, into: worth);

            Assert.That(found[0].ID, Is.EqualTo("g_far"),
                "Sorting what was found in place would surprise whoever holds it.");
        }

        ///////////////////////////////////////////////////////////////////////////////////////////////
        // What this saves, with 64 characters running

        [Test, Description("Most of what a wide check turns up is not worth a line")]
        public void Worth_AWholeLevel_LeavesMostOfItAlone() {
            // stemic's own Level_1 holds 24 pieces, of 8 kinds. A wide check at
            // 30 reach catches every one of them near the middle of the field.
            var found = new List<Near>();
            string[] kinds = { "Ground", "Block", "Wall", "Item", "Coin", "Balloon", "Human", "Home" };
            for (int i = 0; i < 24; i++) {
                found.Add(item: near(kind: kinds[i % 8], id: $"g_{i}", angle: i * 15f - 180f, distance: i + 1f));
            }
            var seek = new Seek(kind: "Ground", reach: 15.0f, spread: 90.0f);
            var worth = new List<Near>();

            StageGate.Worth(near: found, seek: seek, into: worth);

            Assert.That(worth.Count, Is.LessThan(24),
                "Throwing a line at all 24, for each of 64 characters, every tick, "
                + "would cost 1,536 lines a tick for nothing.");
        }
    }
}
