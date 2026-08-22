// Copyright (c) STUDIO MeowToon. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

#nullable enable

using NUnit.Framework;

using Modio.Core;

namespace Modio.Tests.Core {
    ///////////////////////////////////////////////////////////////////////////////////////////////////
    // public Classes

    /// <summary>
    /// Unit tests for facing the other way: asking how it went with things of a
    /// sort with this one (modio P-05, TASK-013 and TASK-017).
    ///
    /// Facing back matches on the thing — one id, one row. **Facing forward
    /// matches on what Perceive handed back about it**: its kind, how far off,
    /// how far up or down. So a row must keep those three, or nothing can be
    /// judged of a sort with anything else.
    ///
    /// One table, faced two ways. Only the question changes.
    ///
    /// See docs/modio_spec.md 4.7.
    /// </summary>
    /// <author>h.adachi (STUDIO MeowToon)</author>
    [TestFixture]
    public class MemoryLikeTests {

        ///////////////////////////////////////////////////////////////////////////////////////////////
        // A row keeps what it was like

        [Test, Description("A row keeps the kind, the reach and the height it was met at")]
        public void Write_KeepsWhatItWasLike() {
            var memory = new Memory(actor: "npc_01", holds: 16);

            memory.Write(at: 12.4f, place: "p_3", deed: "edge", thing: "g_1042", other: "",
                kind: "Ground", reach: 12.0f, height: -3.0f);

            Row row = memory.At(index: 0);
            Assert.That(row.Kind, Is.EqualTo("Ground"));
            Assert.That(row.Reach, Is.EqualTo(12.0f));
            Assert.That(row.Height, Is.EqualTo(-3.0f));
        }

        [Test, Description("A row written the old way keeps nothing of what it was like")]
        public void Write_TheOldWay_KeepsNoLikeness() {
            var memory = new Memory(actor: "npc_01", holds: 16);

            memory.Write(at: 12.4f, place: "p_3", deed: "met", thing: "g_1042", other: "");

            Row row = memory.At(index: 0);
            Assert.That(row.Kind, Is.EqualTo(string.Empty),
                "Meeting another character has no reach or height worth keeping.");
        }

        ///////////////////////////////////////////////////////////////////////////////////////////////
        // Asking how it went with ones like this

        [Test, Description("With nothing remembered, nothing is of a sort with anything")]
        public void HoldsLike_NothingRemembered_IsFalse() {
            var memory = new Memory(actor: "npc_01", holds: 16);

            bool like = memory.HoldsLike(deed: "edge", kind: "Ground", reach: 13.0f, height: -3.1f);

            Assert.That(like, Is.False);
        }

        [Test, Description("A thing near enough in every way is of a sort")]
        public void HoldsLike_NearEnoughInEveryWay_IsTrue() {
            var memory = new Memory(actor: "npc_01", holds: 16);
            memory.Write(at: 12.4f, place: "p_3", deed: "edge", thing: "g_1042", other: "",
                kind: "Ground", reach: 12.0f, height: -3.0f);

            bool like = memory.HoldsLike(deed: "edge", kind: "Ground", reach: 13.0f, height: -3.1f);

            Assert.That(like, Is.True,
                "It does not know this one. It expects, because it stood on ones like it.");
        }

        [Test, Description("A thing of another kind is not of a sort")]
        public void HoldsLike_AnotherKind_IsFalse() {
            var memory = new Memory(actor: "npc_01", holds: 16);
            memory.Write(at: 12.4f, place: "p_3", deed: "edge", thing: "g_1042", other: "",
                kind: "Ground", reach: 12.0f, height: -3.0f);

            bool like = memory.HoldsLike(deed: "edge", kind: "Block", reach: 12.0f, height: -3.0f);

            Assert.That(like, Is.False, "A drop off a Block is not a drop off the Ground.");
        }

        [Test, Description("A thing far off in reach is not of a sort")]
        public void HoldsLike_FarOffInReach_IsFalse() {
            var memory = new Memory(actor: "npc_01", holds: 16);
            memory.Write(at: 12.4f, place: "p_3", deed: "edge", thing: "g_1042", other: "",
                kind: "Ground", reach: 12.0f, height: -3.0f);

            bool like = memory.HoldsLike(deed: "edge", kind: "Ground", reach: 40.0f, height: -3.0f);

            Assert.That(like, Is.False);
        }

        [Test, Description("A thing far off in height is not of a sort")]
        public void HoldsLike_FarOffInHeight_IsFalse() {
            var memory = new Memory(actor: "npc_01", holds: 16);
            memory.Write(at: 12.4f, place: "p_3", deed: "edge", thing: "g_1042", other: "",
                kind: "Ground", reach: 12.0f, height: -3.0f);

            bool like = memory.HoldsLike(deed: "edge", kind: "Ground", reach: 12.0f, height: 2.0f);

            Assert.That(like, Is.False,
                "A step up is not a drop down, however alike they stand otherwise.");
        }

        [Test, Description("Another deed is not asked after")]
        public void HoldsLike_AnotherDeed_IsFalse() {
            var memory = new Memory(actor: "npc_01", holds: 16);
            memory.Write(at: 12.4f, place: "p_3", deed: "met", thing: "g_1042", other: "",
                kind: "Ground", reach: 12.0f, height: -3.0f);

            bool like = memory.HoldsLike(deed: "edge", kind: "Ground", reach: 12.0f, height: -3.0f);

            Assert.That(like, Is.False,
                "Having met ones like it says nothing of whether they went badly.");
        }

        ///////////////////////////////////////////////////////////////////////////////////////////////
        // How near counts as of a sort

        [Test, Description("A thing right at the bound of reach is of a sort")]
        public void HoldsLike_RightAtTheBoundOfReach_IsTrue() {
            var memory = new Memory(actor: "npc_01", holds: 16);
            memory.Write(at: 1f, place: "p_1", deed: "edge", thing: "g_a", other: "",
                kind: "Ground", reach: 12.0f, height: -3.0f);

            bool like = memory.HoldsLike(deed: "edge", kind: "Ground",
                reach: 12.0f + Memory.SORT_BY_REACH, height: -3.0f);

            Assert.That(like, Is.True);
        }

        [Test, Description("A thing just past the bound of reach is not of a sort")]
        public void HoldsLike_JustPastTheBoundOfReach_IsFalse() {
            var memory = new Memory(actor: "npc_01", holds: 16);
            memory.Write(at: 1f, place: "p_1", deed: "edge", thing: "g_a", other: "",
                kind: "Ground", reach: 12.0f, height: -3.0f);

            bool like = memory.HoldsLike(deed: "edge", kind: "Ground",
                reach: 12.0f + Memory.SORT_BY_REACH + 0.1f, height: -3.0f);

            Assert.That(like, Is.False);
        }

        [Test, Description("A thing right at the bound of height is of a sort")]
        public void HoldsLike_RightAtTheBoundOfHeight_IsTrue() {
            var memory = new Memory(actor: "npc_01", holds: 16);
            memory.Write(at: 1f, place: "p_1", deed: "edge", thing: "g_a", other: "",
                kind: "Ground", reach: 12.0f, height: -3.0f);

            bool like = memory.HoldsLike(deed: "edge", kind: "Ground",
                reach: 12.0f, height: -3.0f + Memory.SORT_BY_HEIGHT);

            Assert.That(like, Is.True);
        }

        ///////////////////////////////////////////////////////////////////////////////////////////////
        // The whole of it, as a character would live it

        [Test, Description("Two falls off like drops make a third of a sort with them")]
        public void HoldsLike_TwoFallsMakeAThirdKnown() {
            var memory = new Memory(actor: "place_curious_01", holds: 16);
            memory.Write(at: 10f, place: "p_south", deed: "edge", thing: "g_1", other: "",
                kind: "Ground", reach: 12.0f, height: -3.0f);
            memory.Write(at: 25f, place: "p_south", deed: "edge", thing: "g_2", other: "",
                kind: "Ground", reach: 14.0f, height: -2.8f);

            bool like = memory.HoldsLike(deed: "edge", kind: "Ground", reach: 13.0f, height: -3.1f);

            Assert.That(like, Is.True,
                "This is the whole of facing forward: a character keeps away from a drop "
                + "it has never stood on, because it stood on ones like it.");
        }

        [Test, Description("A gentle step is still taken, for all the falls remembered")]
        public void HoldsLike_AGentleStep_IsStillTaken() {
            var memory = new Memory(actor: "place_curious_01", holds: 16);
            memory.Write(at: 10f, place: "p_south", deed: "edge", thing: "g_1", other: "",
                kind: "Ground", reach: 12.0f, height: -3.0f);

            bool like = memory.HoldsLike(deed: "edge", kind: "Ground", reach: 12.0f, height: -0.4f);

            Assert.That(like, Is.False,
                "Keeping away from every drop would leave a character standing still for ever.");
        }

        ///////////////////////////////////////////////////////////////////////////////////////////////
        // Nothing made anew

        [Test, Description("Asking how ones like it went makes nothing new")]
        public void HoldsLike_MakesNothingNew() {
            var memory = new Memory(actor: "npc_01", holds: 16);
            for (int i = 0; i < 16; i++) {
                memory.Write(at: i, place: "p_1", deed: "edge", thing: $"g_{i}", other: "",
                    kind: "Ground", reach: 12f + i, height: -3f);
            }
            for (int i = 0; i < 2000; i++) {
                memory.HoldsLike(deed: "edge", kind: "Ground", reach: 13f, height: -3f);
            }

            long before = System.GC.GetAllocatedBytesForCurrentThread();
            for (int i = 0; i < 10000; i++) {
                memory.HoldsLike(deed: "edge", kind: "Ground", reach: 13f, height: -3f);
            }
            long after = System.GC.GetAllocatedBytesForCurrentThread();

            Assert.That(after - before, Is.EqualTo(0),
                "This is asked before every seek, for every character.");
        }
    }
}
