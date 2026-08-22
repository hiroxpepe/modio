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
    /// Unit tests for "new again, if it has been a while" (modio P-03).
    ///
    /// Letting go by count keeps a table small, but it turns on how many rows
    /// come after — a place met once and then never thought of again sits there
    /// for ever. **Age is the other way**: the row is never touched, and how
    /// long since is weighed each time the question is put.
    ///
    /// Both ways are wanted, and Modio takes both.
    ///
    /// See docs/modio_spec.md 4.6.
    /// </summary>
    /// <author>h.adachi (STUDIO MeowToon)</author>
    [TestFixture]
    public class PerceiveAgainTests {

        ///////////////////////////////////////////////////////////////////////////////////////////////
        // private static Methods [verb]

        static Found ground(string id, float distance) {
            return new Found(kind: "Ground", id: id, angle: 0f, distance: distance, height: 0f);
        }

        static Memory metAt(string id, float at) {
            var memory = new Memory(actor: "place_curious_01", holds: 16);
            memory.Write(at: at, place: "p_1", deed: "met", thing: id, other: "");
            return memory;
        }

        ///////////////////////////////////////////////////////////////////////////////////////////////
        // A place met a while ago is new again

        [Test, Description("A place met a moment ago is not new")]
        public void Choose_MetAMomentAgo_IsPassedOver() {
            var found = new List<Found> { ground(id: "g_1042", distance: 8.5f) };
            var seek = new Seek(kind: "Ground", not_in_memory: "met", new_again_after: 60f);

            Choice choice = Perceive.Choose(found: found, seek: seek,
                memory: metAt(id: "g_1042", at: 50f), now: 55f);

            Assert.That(choice.Taken, Is.False, "5 seconds is no while at all.");
        }

        [Test, Description("A place met a good while ago is new again")]
        public void Choose_MetAWhileAgo_IsNewAgain() {
            var found = new List<Found> { ground(id: "g_1042", distance: 8.5f) };
            var seek = new Seek(kind: "Ground", not_in_memory: "met", new_again_after: 60f);

            Choice choice = Perceive.Choose(found: found, seek: seek,
                memory: metAt(id: "g_1042", at: 10f), now: 90f);

            Assert.That(choice.Taken, Is.True,
                "80 seconds on, a place is worth another look. The row is never touched.");
        }

        [Test, Description("Right at the mark, a place is new again")]
        public void Choose_RightAtTheMark_IsNewAgain() {
            var found = new List<Found> { ground(id: "g_1042", distance: 8.5f) };
            var seek = new Seek(kind: "Ground", not_in_memory: "met", new_again_after: 60f);

            Choice choice = Perceive.Choose(found: found, seek: seek,
                memory: metAt(id: "g_1042", at: 10f), now: 70f);

            Assert.That(choice.Taken, Is.True);
        }

        [Test, Description("With no while set, a place met once is never new again")]
        public void Choose_NoWhileSet_IsNeverNewAgain() {
            var found = new List<Found> { ground(id: "g_1042", distance: 8.5f) };
            var seek = new Seek(kind: "Ground", not_in_memory: "met");

            Choice choice = Perceive.Choose(found: found, seek: seek,
                memory: metAt(id: "g_1042", at: 10f), now: 10000f);

            Assert.That(choice.Taken, Is.False,
                "A deed that names no while asks only whether it happened at all.");
        }

        ///////////////////////////////////////////////////////////////////////////////////////////////
        // The row is never touched

        [Test, Description("Asking does not take the row away")]
        public void Choose_Asking_LeavesTheRowWhereItIs() {
            var memory = metAt(id: "g_1042", at: 10f);
            var found = new List<Found> { ground(id: "g_1042", distance: 8.5f) };
            var seek = new Seek(kind: "Ground", not_in_memory: "met", new_again_after: 60f);

            Perceive.Choose(found: found, seek: seek, memory: memory, now: 90f);

            Assert.That(memory.Holds(deed: "met", thing: "g_1042"), Is.True,
                "Age is weighed each time the question is put; the row stands.");
        }

        ///////////////////////////////////////////////////////////////////////////////////////////////
        // Of two, the one longer past is taken

        [Test, Description("Of two met, the one longer past is taken")]
        public void Choose_TwoMet_TakesTheOneLongerPast() {
            var memory = new Memory(actor: "place_curious_01", holds: 16);
            memory.Write(at: 10f, place: "p_1", deed: "met", thing: "g_old", other: "");
            memory.Write(at: 85f, place: "p_1", deed: "met", thing: "g_new", other: "");
            var found = new List<Found> {
                ground(id: "g_new", distance: 5.0f),
                ground(id: "g_old", distance: 12.0f)
            };
            var seek = new Seek(kind: "Ground", not_in_memory: "met", new_again_after: 60f);

            Choice choice = Perceive.Choose(found: found, seek: seek, memory: memory, now: 90f);

            Assert.That(choice.ID, Is.EqualTo("g_old"),
                "The nearer one was met 5 seconds ago; the further one, 80.");
        }

        ///////////////////////////////////////////////////////////////////////////////////////////////
        // What stood before goes on standing

        [Test, Description("A seek with no while at all works as it did")]
        public void Choose_WithoutNow_WorksAsBefore() {
            var found = new List<Found> { ground(id: "g_1042", distance: 8.5f) };
            var seek = new Seek(kind: "Ground", not_in_memory: "met");

            Choice choice = Perceive.Choose(found: found, seek: seek,
                memory: metAt(id: "g_1042", at: 10f));

            Assert.That(choice.Taken, Is.False);
        }

        ///////////////////////////////////////////////////////////////////////////////////////////////
        // Nothing made anew

        [Test, Description("Weighing how long since makes nothing new")]
        public void Choose_WeighingAge_MakesNothingNew() {
            var found = new List<Found> { ground(id: "g_1042", distance: 8.5f) };
            var seek = new Seek(kind: "Ground", not_in_memory: "met", new_again_after: 60f);
            var memory = metAt(id: "g_1042", at: 10f);
            for (int i = 0; i < 2000; i++) {
                Perceive.Choose(found: found, seek: seek, memory: memory, now: 90f);
            }

            long before = System.GC.GetAllocatedBytesForCurrentThread();
            for (int i = 0; i < 10000; i++) {
                Perceive.Choose(found: found, seek: seek, memory: memory, now: 90f);
            }
            long after = System.GC.GetAllocatedBytesForCurrentThread();

            Assert.That(after - before, Is.EqualTo(0));
        }
    }
}
