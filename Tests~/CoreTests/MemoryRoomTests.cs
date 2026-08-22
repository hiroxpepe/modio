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
    /// Unit tests for how much room a memory is given (modio P-01, TASK-002).
    ///
    /// A written-in number breaks: counted on stemic's own Level_1, which holds
    /// 12 blocks, a memory that holds every one leaves nothing new, and the want
    /// for new places dies flat out. **The right size turns on how many things
    /// there are**, which no written-in number can know.
    ///
    /// So the size is set against the count: hold no more than half of what
    /// stands there. Half is left new, always, and a character can neither run
    /// out of new places nor walk back to where it just came from.
    ///
    /// See docs/modio_spec.md 4.6.
    /// </summary>
    /// <author>h.adachi (STUDIO MeowToon)</author>
    [TestFixture]
    public class MemoryRoomTests {

        ///////////////////////////////////////////////////////////////////////////////////////////////
        // How much room, for how many things

        [Test, Description("A memory holds half of what stands in the world")]
        public void Room_HoldsHalfOfWhatIsThere() {
            Assert.That(Memory.RoomFor(things: 12), Is.EqualTo(6),
                "stemic's own Level_1 holds 12 blocks, so 6 are held and 6 stay new.");
        }

        [Test, Description("A bigger world gives a bigger memory")]
        public void Room_MoreThings_MoreRoom() {
            Assert.That(Memory.RoomFor(things: 48), Is.GreaterThan(Memory.RoomFor(things: 12)));
        }

        [Test, Description("An odd count leaves the odd one new")]
        public void Room_OddCount_LeavesTheOddOneNew() {
            Assert.That(Memory.RoomFor(things: 11), Is.EqualTo(5),
                "5 held out of 11 leaves 6 new: better a place too many new than too few.");
        }

        [Test, Description("A world holding almost nothing still leaves room for one row")]
        public void Room_AlmostNothing_StillHoldsOne() {
            Assert.That(Memory.RoomFor(things: 1), Is.GreaterThanOrEqualTo(1),
                "A memory of no rows at all could remember nothing ever done.");
        }

        [Test, Description("A world holding nothing still leaves room for one row")]
        public void Room_Nothing_StillHoldsOne() {
            Assert.That(Memory.RoomFor(things: 0), Is.GreaterThanOrEqualTo(1));
        }

        ///////////////////////////////////////////////////////////////////////////////////////////////
        // Half stays new, however long a character walks

        [Test, Description("However many places are met, half of them stay new")]
        public void Room_HalfStaysNew_HoweverLongItWalks() {
            const int there = 12;
            var memory = new Memory(actor: "place_curious_01", holds: Memory.RoomFor(things: there));

            // Walk the whole level over and over, meeting every place in turn.
            for (int round = 0; round < 10; round++) {
                for (int i = 0; i < there; i++) {
                    memory.Write(at: round * there + i, place: "p_1", deed: "met",
                        thing: $"g_{i}", other: "");
                }
            }

            int still_new = 0;
            for (int i = 0; i < there; i++) {
                if (!memory.Holds(deed: "met", thing: $"g_{i}")) { still_new++; }
            }

            Assert.That(still_new, Is.GreaterThanOrEqualTo(there / 2),
                "**A want for new places must never die.** Half the level is always new, "
                + "however long a character has walked it.");
        }

        [Test, Description("What was just met is not new again straight away")]
        public void Room_WhatWasJustMet_IsNotNewAgain() {
            const int there = 12;
            var memory = new Memory(actor: "place_curious_01", holds: Memory.RoomFor(things: there));
            for (int i = 0; i < 6; i++) {
                memory.Write(at: i, place: "p_1", deed: "met", thing: $"g_{i}", other: "");
            }

            Assert.That(memory.Holds(deed: "met", thing: "g_5"), Is.True,
                "Walking straight back to where it just came from would look witless.");
        }

        ///////////////////////////////////////////////////////////////////////////////////////////////
        // The whole of it, as a character would live it

        [Test, Description("Exploring a level never runs out of somewhere to go")]
        public void Room_ExploringNeverRunsOut() {
            const int there = 12;
            var memory = new Memory(actor: "place_curious_01", holds: Memory.RoomFor(things: there));
            var found = new List<Found>();
            for (int i = 0; i < there; i++) {
                found.Add(item: new Found(kind: "Ground", id: $"g_{i}",
                    angle: i * 10f - 60f, distance: 5f + i, height: 0f));
            }
            var seek = new Seek(kind: "Ground", not_in_memory: "met");

            // Explore, over and over. Every time it lands, it writes a row.
            for (int step = 0; step < 50; step++) {
                Choice choice = Perceive.Choose(found: found, seek: seek, memory: memory);
                Assert.That(choice.Taken, Is.True,
                    $"At step {step} there was nowhere new to go. A want for new places "
                    + "that cannot be met is a character standing still.");
                memory.Write(at: step, place: "p_1", deed: "met", thing: choice.ID, other: "");
            }
        }
    }
}
