// Copyright (c) STUDIO MeowToon. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

#nullable enable

using NUnit.Framework;

using Modio.Core;

namespace Modio.Tests.Core {
    ///////////////////////////////////////////////////////////////////////////////////////////////////
    // public Classes

    /// <summary>
    /// Unit tests for how deep a meeting sits, and what that means when a row
    /// must go (modio P-03).
    ///
    /// Master's own word: seeing, touching and holding are three depths of one
    /// meeting, not three separate things. So when the ring is full, the least
    /// deep goes before the deepest — as it does in a person.
    ///
    /// See docs/modio_spec.md 4.4 and 4.6.
    /// </summary>
    /// <author>h.adachi (STUDIO MeowToon)</author>
    [TestFixture]
    public class MemoryDepthTests {

        ///////////////////////////////////////////////////////////////////////////////////////////////
        // private static Methods [verb]

        /// <summary>Runs both hot paths once, to draw the runtime's own work in early.</summary>
        static void warm(Memory memory) {
            memory.Write(at: 0f, place: "p_1", deed: "met", thing: "g_warm", other: "");
            memory.Holds(deed: "met", thing: "g_warm");
        }

        ///////////////////////////////////////////////////////////////////////////////////////////////
        // How deep each deed sits

        [Test, Description("Seeing is the least deep of the three")]
        public void Depth_Seen_IsLeastDeep() {
            Assert.That(Depth.Of(deed: "seen"), Is.LessThan(Depth.Of(deed: "met")));
        }

        [Test, Description("Touching sits deeper than seeing")]
        public void Depth_Met_IsDeeperThanSeen() {
            Assert.That(Depth.Of(deed: "met"), Is.GreaterThan(Depth.Of(deed: "seen")));
        }

        [Test, Description("Holding is the deepest of the three")]
        public void Depth_Held_IsDeepest() {
            Assert.That(Depth.Of(deed: "held"), Is.GreaterThan(Depth.Of(deed: "met")));
        }

        [Test, Description("Keeping away sits as deep as holding: it is worth as much")]
        public void Depth_Edge_SitsWithHeld() {
            Assert.That(Depth.Of(deed: "edge"), Is.EqualTo(Depth.Of(deed: "held")),
                "Forgetting where a fall is costs a character dear; it must go last, "
                + "with the deepest.");
        }

        [Test, Description("Giving and showing sit with holding: each was a whole deed done")]
        public void Depth_GaveAndShown_SitWithHeld() {
            Assert.That(Depth.Of(deed: "gave"), Is.EqualTo(Depth.Of(deed: "held")));
            Assert.That(Depth.Of(deed: "shown"), Is.EqualTo(Depth.Of(deed: "held")));
        }

        [Test, Description("A deed with no depth set sits with seeing, the least deep")]
        public void Depth_Unknown_SitsWithSeen() {
            Assert.That(Depth.Of(deed: "something_else"), Is.EqualTo(Depth.Of(deed: "seen")),
                "A deed nobody set a depth for must not outstay one that was.");
        }

        ///////////////////////////////////////////////////////////////////////////////////////////////
        // Which row goes, when the ring is full

        [Test, Description("The least deep row goes first, even where it is not the oldest")]
        public void Write_RingFull_DropsTheLeastDeepFirst() {
            var memory = new Memory(actor: "npc_01", holds: 3);
            memory.Write(at: 1f, place: "p_1", deed: "held", thing: "i_a", other: "");
            memory.Write(at: 2f, place: "p_1", deed: "seen", thing: "g_b", other: "");
            memory.Write(at: 3f, place: "p_1", deed: "met",  thing: "g_c", other: "");

            memory.Write(at: 4f, place: "p_1", deed: "met", thing: "g_d", other: "");

            Assert.That(memory.Holds(deed: "seen", thing: "g_b"), Is.False,
                "seen is the least deep, so it goes first — even though held came in before it.");
            Assert.That(memory.Holds(deed: "held", thing: "i_a"), Is.True);
            Assert.That(memory.Holds(deed: "met", thing: "g_c"), Is.True);
        }

        [Test, Description("Of two at the same depth, the one longest past goes")]
        public void Write_SameDepth_DropsTheOneLongestPast() {
            var memory = new Memory(actor: "npc_01", holds: 2);
            memory.Write(at: 1f, place: "p_1", deed: "met", thing: "g_old", other: "");
            memory.Write(at: 2f, place: "p_1", deed: "met", thing: "g_new", other: "");

            memory.Write(at: 3f, place: "p_1", deed: "met", thing: "g_newest", other: "");

            Assert.That(memory.Holds(deed: "met", thing: "g_old"), Is.False);
            Assert.That(memory.Holds(deed: "met", thing: "g_new"), Is.True);
        }

        [Test, Description("A held row outstays every seen row, however old it is")]
        public void Write_ManySeen_DoNotPushOutAHeld() {
            var memory = new Memory(actor: "npc_01", holds: 4);
            memory.Write(at: 1f, place: "p_1", deed: "held", thing: "i_a", other: "");

            for (int i = 0; i < 20; i++) {
                memory.Write(at: 10f + i, place: "p_1", deed: "seen", thing: $"g_{i}", other: "");
            }

            Assert.That(memory.Holds(deed: "held", thing: "i_a"), Is.True,
                "What a character took up stays with it, however much it has since laid eyes on.");
        }

        [Test, Description("An edge outstays every seen row too")]
        public void Write_ManySeen_DoNotPushOutAnEdge() {
            var memory = new Memory(actor: "npc_01", holds: 4);
            memory.Write(at: 1f, place: "p_1", deed: "edge", thing: "g_cliff", other: "");

            for (int i = 0; i < 20; i++) {
                memory.Write(at: 10f + i, place: "p_1", deed: "seen", thing: $"g_{i}", other: "");
            }

            Assert.That(memory.Holds(deed: "edge", thing: "g_cliff"), Is.True,
                "A character that forgets where the fall is walks off it again.");
        }

        [Test, Description("Where every row is as deep, the one longest past goes")]
        public void Write_AllSameDepth_DropsTheOneLongestPast() {
            var memory = new Memory(actor: "npc_01", holds: 3);
            for (int i = 0; i < 5; i++) {
                memory.Write(at: i, place: "p_1", deed: "held", thing: $"i_{i}", other: "");
            }

            Assert.That(memory.Holds(deed: "held", thing: "i_0"), Is.False);
            Assert.That(memory.Holds(deed: "held", thing: "i_1"), Is.False);
            Assert.That(memory.Holds(deed: "held", thing: "i_4"), Is.True);
        }

        ///////////////////////////////////////////////////////////////////////////////////////////////
        // A want for new places still comes right, even with depth at work

        [Test, Description("Seen rows still go, so a place seen long ago becomes new again")]
        public void Write_ManySeen_StillMakeAPlaceNewAgain() {
            var memory = new Memory(actor: "npc_01", holds: 3);
            memory.Write(at: 1f, place: "p_1", deed: "seen", thing: "g_old", other: "");

            for (int i = 0; i < 5; i++) {
                memory.Write(at: 10f + i, place: "p_1", deed: "seen", thing: $"g_{i}", other: "");
            }

            Assert.That(memory.Holds(deed: "seen", thing: "g_old"), Is.False,
                "Letting go is what keeps a want for new places alive.");
        }

        ///////////////////////////////////////////////////////////////////////////////////////////////
        // Still nothing made anew

        [Test, Description("Writing with depth at work still makes nothing new")]
        public void Write_WithDepth_MakesNothingNew() {
            var memory = new Memory(actor: "npc_01", holds: 16);
            for (int i = 0; i < 16; i++) {
                memory.Write(at: i, place: "p_1", deed: "met", thing: $"g_{i}", other: "");
            }

            // Warm the path first: the very first runs draw in work from the
            // runtime itself (compiling the method, and compiling it again once
            // it turns out to be hot), and that work is not this code's own.
            for (int i = 0; i < 2000; i++) { warm(memory: memory); }

            long before = System.GC.GetAllocatedBytesForCurrentThread();
            for (int i = 0; i < 10000; i++) {
                memory.Write(at: i, place: "p_1", deed: i % 3 == 0 ? "seen" : "met",
                    thing: "g_x", other: "");
            }
            long after = System.GC.GetAllocatedBytesForCurrentThread();

            Assert.That(after - before, Is.EqualTo(0),
                "Looking through the ring for the least deep row must make nothing new.");
        }
    }
}
