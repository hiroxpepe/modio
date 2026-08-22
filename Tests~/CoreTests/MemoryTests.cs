// Copyright (c) STUDIO MeowToon. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

#nullable enable

using NUnit.Framework;

using Modio.Core;

namespace Modio.Tests.Core {
    ///////////////////////////////////////////////////////////////////////////////////////////////////
    // public Classes

    /// <summary>
    /// Unit tests for the memory one character keeps (modio P-03).
    ///
    /// Four posts: who, when, where, what. A row is written only where a deed
    /// ends Done. Rows are let go of by count, oldest first, so the table cannot
    /// grow with no end.
    ///
    /// See docs/modio_spec.md 4.
    /// </summary>
    /// <author>h.adachi (STUDIO MeowToon)</author>
    [TestFixture]
    public class MemoryTests {

        ///////////////////////////////////////////////////////////////////////////////////////////////
        // private static Methods [verb]

        /// <summary>Runs both hot paths once, to draw the runtime's own work in early.</summary>
        static void warm(Memory memory) {
            memory.Write(at: 0f, place: "p_1", deed: "met", thing: "g_warm", other: "");
            memory.Holds(deed: "met", thing: "g_warm");
        }

        ///////////////////////////////////////////////////////////////////////////////////////////////
        // Writing a row

        [Test, Description("A new memory holds nothing at all")]
        public void New_HoldsNothing() {
            var memory = new Memory(actor: "npc_01", holds: 16);

            Assert.That(memory.Count, Is.EqualTo(0));
        }

        [Test, Description("A memory knows whose it is")]
        public void New_KnowsWhoseItIs() {
            var memory = new Memory(actor: "place_curious_01", holds: 16);

            Assert.That(memory.Actor, Is.EqualTo("place_curious_01"));
        }

        [Test, Description("A row written is a row held")]
        public void Write_OneRow_IsHeld() {
            var memory = new Memory(actor: "npc_01", holds: 16);

            memory.Write(at: 12.4f, place: "p_3", deed: "met", thing: "g_1042", other: "");

            Assert.That(memory.Count, Is.EqualTo(1));
        }

        [Test, Description("A row holds every one of its four posts")]
        public void Write_OneRow_HoldsEveryPost() {
            var memory = new Memory(actor: "npc_01", holds: 16);

            memory.Write(at: 12.4f, place: "p_3", deed: "gave", thing: "i_7", other: "npc_02");

            Row row = memory.At(index: 0);
            Assert.That(row.At, Is.EqualTo(12.4f));
            Assert.That(row.Place, Is.EqualTo("p_3"));
            Assert.That(row.Deed, Is.EqualTo("gave"));
            Assert.That(row.Thing, Is.EqualTo("i_7"));
            Assert.That(row.Other, Is.EqualTo("npc_02"));
        }

        ///////////////////////////////////////////////////////////////////////////////////////////////
        // Asking after a thing

        [Test, Description("A thing never met is not held")]
        public void Holds_NeverMet_IsFalse() {
            var memory = new Memory(actor: "npc_01", holds: 16);

            Assert.That(memory.Holds(deed: "met", thing: "g_1042"), Is.False);
        }

        [Test, Description("A thing met is held")]
        public void Holds_Met_IsTrue() {
            var memory = new Memory(actor: "npc_01", holds: 16);
            memory.Write(at: 12.4f, place: "p_3", deed: "met", thing: "g_1042", other: "");

            Assert.That(memory.Holds(deed: "met", thing: "g_1042"), Is.True);
        }

        [Test, Description("A thing met is not held under another deed")]
        public void Holds_AnotherDeed_IsFalse() {
            var memory = new Memory(actor: "npc_01", holds: 16);
            memory.Write(at: 12.4f, place: "p_3", deed: "met", thing: "g_1042", other: "");

            Assert.That(memory.Holds(deed: "edge", thing: "g_1042"), Is.False,
                "met says 'no longer new'; edge says 'keep away'. They are opposite uses.");
        }

        [Test, Description("Another thing is not held")]
        public void Holds_AnotherThing_IsFalse() {
            var memory = new Memory(actor: "npc_01", holds: 16);
            memory.Write(at: 12.4f, place: "p_3", deed: "met", thing: "g_1042", other: "");

            Assert.That(memory.Holds(deed: "met", thing: "g_1055"), Is.False);
        }

        ///////////////////////////////////////////////////////////////////////////////////////////////
        // Asking after another character

        [Test, Description("A character never given to is not held")]
        public void HoldsWith_NeverGaveTo_IsFalse() {
            var memory = new Memory(actor: "npc_01", holds: 16);

            Assert.That(memory.HoldsWith(deed: "gave", other: "npc_02"), Is.False);
        }

        [Test, Description("A character given to is held")]
        public void HoldsWith_GaveTo_IsTrue() {
            var memory = new Memory(actor: "npc_01", holds: 16);
            memory.Write(at: 31.8f, place: "p_3", deed: "gave", thing: "i_7", other: "npc_02");

            Assert.That(memory.HoldsWith(deed: "gave", other: "npc_02"), Is.True,
                "This is what keeps a character from giving to the same one for ever.");
        }

        [Test, Description("Another character is not held")]
        public void HoldsWith_AnotherCharacter_IsFalse() {
            var memory = new Memory(actor: "npc_01", holds: 16);
            memory.Write(at: 31.8f, place: "p_3", deed: "gave", thing: "i_7", other: "npc_02");

            Assert.That(memory.HoldsWith(deed: "gave", other: "npc_03"), Is.False);
        }

        ///////////////////////////////////////////////////////////////////////////////////////////////
        // How long since

        [Test, Description("Time since something never done is below zero")]
        public void Since_NeverDone_IsBelowZero() {
            var memory = new Memory(actor: "npc_01", holds: 16);

            Assert.That(memory.Since(deed: "met", thing: "g_1042", now: 60f), Is.LessThan(0f),
                "Below zero says 'never', which no true count of seconds can say.");
        }

        [Test, Description("Time since tells how long ago it was")]
        public void Since_Done_TellsHowLongAgo() {
            var memory = new Memory(actor: "npc_01", holds: 16);
            memory.Write(at: 12.4f, place: "p_3", deed: "met", thing: "g_1042", other: "");

            Assert.That(memory.Since(deed: "met", thing: "g_1042", now: 72.4f), Is.EqualTo(60f));
        }

        [Test, Description("Time since counts from the latest, not the first")]
        public void Since_DoneTwice_CountsFromTheLatest() {
            var memory = new Memory(actor: "npc_01", holds: 16);
            memory.Write(at: 12.4f, place: "p_3", deed: "met", thing: "g_1042", other: "");
            memory.Write(at: 50.0f, place: "p_3", deed: "met", thing: "g_1042", other: "");

            Assert.That(memory.Since(deed: "met", thing: "g_1042", now: 60f), Is.EqualTo(10f));
        }

        ///////////////////////////////////////////////////////////////////////////////////////////////
        // Letting go, by count

        [Test, Description("A memory holds no more rows than it was made to")]
        public void Write_PastWhatItHolds_HoldsNoMore() {
            var memory = new Memory(actor: "npc_01", holds: 4);

            for (int i = 0; i < 10; i++) {
                memory.Write(at: i, place: "p_1", deed: "met", thing: $"g_{i}", other: "");
            }

            Assert.That(memory.Count, Is.EqualTo(4),
                "With no letting go, the table would grow with no end at all.");
        }

        [Test, Description("The row longest past goes first")]
        public void Write_PastWhatItHolds_DropsTheOldest() {
            var memory = new Memory(actor: "npc_01", holds: 4);

            for (int i = 0; i < 6; i++) {
                memory.Write(at: i, place: "p_1", deed: "met", thing: $"g_{i}", other: "");
            }

            Assert.That(memory.Holds(deed: "met", thing: "g_0"), Is.False, "g_0 was first, so it goes first");
            Assert.That(memory.Holds(deed: "met", thing: "g_1"), Is.False);
            Assert.That(memory.Holds(deed: "met", thing: "g_5"), Is.True, "g_5 is the newest, and stays");
        }

        [Test, Description("A place met long ago becomes new again once its row goes")]
        public void Write_PastWhatItHolds_MakesAPlaceNewAgain() {
            var memory = new Memory(actor: "npc_01", holds: 3);
            memory.Write(at: 1f, place: "p_1", deed: "met", thing: "g_old", other: "");

            for (int i = 0; i < 3; i++) {
                memory.Write(at: 10f + i, place: "p_1", deed: "met", thing: $"g_{i}", other: "");
            }

            Assert.That(memory.Holds(deed: "met", thing: "g_old"), Is.False,
                "Letting go is what keeps a want for new places alive: "
                + "once every place has been met, nothing is new any more.");
        }

        ///////////////////////////////////////////////////////////////////////////////////////////////
        // Reading it back in order

        [Test, Description("Rows come back in the order they were written")]
        public void At_ComesBackInOrder() {
            var memory = new Memory(actor: "npc_01", holds: 8);
            memory.Write(at: 1f, place: "p_1", deed: "met", thing: "g_a", other: "");
            memory.Write(at: 2f, place: "p_1", deed: "met", thing: "g_b", other: "");

            Assert.That(memory.At(index: 0).Thing, Is.EqualTo("g_a"));
            Assert.That(memory.At(index: 1).Thing, Is.EqualTo("g_b"));
        }

        [Test, Description("Rows come back in order even once the oldest have gone")]
        public void At_AfterDropping_ComesBackInOrder() {
            var memory = new Memory(actor: "npc_01", holds: 3);
            for (int i = 0; i < 5; i++) {
                memory.Write(at: i, place: "p_1", deed: "met", thing: $"g_{i}", other: "");
            }

            Assert.That(memory.At(index: 0).Thing, Is.EqualTo("g_2"));
            Assert.That(memory.At(index: 1).Thing, Is.EqualTo("g_3"));
            Assert.That(memory.At(index: 2).Thing, Is.EqualTo("g_4"));
        }

        ///////////////////////////////////////////////////////////////////////////////////////////////
        // Nothing is made anew on the hot path

        [Test, Description("Writing many rows makes nothing new, once the table is full")]
        public void Write_ManyRows_MakesNothingNew() {
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
                memory.Write(at: i, place: "p_1", deed: "met", thing: "g_x", other: "");
            }
            long after = System.GC.GetAllocatedBytesForCurrentThread();

            Assert.That(after - before, Is.EqualTo(0),
                "animo proved zero garbage over 100,000 runs of Live(). "
                + "A ring held at a fixed size meets the same bar; a List with "
                + "RemoveAt(0) would not.");
        }

        [Test, Description("Asking after a thing makes nothing new")]
        public void Holds_MakesNothingNew() {
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
                memory.Holds(deed: "met", thing: "g_8");
            }
            long after = System.GC.GetAllocatedBytesForCurrentThread();

            Assert.That(after - before, Is.EqualTo(0));
        }
    }
}
