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
    /// Unit tests for keeping away from what ones like it did (modio P-05).
    ///
    /// The forward-facing question is not put to a mind, and not worked out from
    /// any rate. **It is put to the seek**: which of the found things to reach
    /// for. A character keeps away from a drop it has never stood on, because it
    /// stood on ones like it.
    ///
    /// See docs/modio_spec.md 4.7.3.
    /// </summary>
    /// <author>h.adachi (STUDIO MeowToon)</author>
    [TestFixture]
    public class PerceiveLikeTests {

        ///////////////////////////////////////////////////////////////////////////////////////////////
        // private static Methods [verb]

        static Found ground(string id, float distance, float height) {
            return new Found(kind: "Ground", id: id, angle: 0f, distance: distance, height: height);
        }

        /// <summary>A memory holding two falls off like drops.</summary>
        static Memory hasFallenTwice() {
            var memory = new Memory(actor: "place_curious_01", holds: 16);
            memory.Write(at: 10f, place: "p_south", deed: "edge", thing: "g_1", other: "",
                kind: "Ground", reach: 12.0f, height: -3.0f);
            memory.Write(at: 25f, place: "p_south", deed: "edge", thing: "g_2", other: "",
                kind: "Ground", reach: 14.0f, height: -2.8f);
            return memory;
        }

        ///////////////////////////////////////////////////////////////////////////////////////////////
        // Keeping away from ones like it

        [Test, Description("A thing of a sort with a fall is passed over")]
        public void Choose_LikeAFall_IsPassedOver() {
            var found = new List<Found> { ground(id: "g_new", distance: 13.0f, height: -3.1f) };
            var seek = new Seek(kind: "Ground", keep_from: "edge");

            Choice choice = Perceive.Choose(found: found, seek: seek, memory: hasFallenTwice());

            Assert.That(choice.Taken, Is.False,
                "It does not know this one. It expects.");
        }

        [Test, Description("A gentle step is still taken, for all the falls remembered")]
        public void Choose_AGentleStep_IsStillTaken() {
            var found = new List<Found> { ground(id: "g_step", distance: 12.0f, height: -0.4f) };
            var seek = new Seek(kind: "Ground", keep_from: "edge");

            Choice choice = Perceive.Choose(found: found, seek: seek, memory: hasFallenTwice());

            Assert.That(choice.Taken, Is.True,
                "Keeping away from every drop would leave a character standing still for ever.");
        }

        [Test, Description("Of two, the one unlike any fall is taken")]
        public void Choose_OneLikeAFall_TakesTheOther() {
            var found = new List<Found> {
                ground(id: "g_drop", distance: 13.0f, height: -3.1f),
                ground(id: "g_step", distance: 20.0f, height: -0.4f)
            };
            var seek = new Seek(kind: "Ground", keep_from: "edge");

            Choice choice = Perceive.Choose(found: found, seek: seek, memory: hasFallenTwice());

            Assert.That(choice.ID, Is.EqualTo("g_step"),
                "The nearer one is like a fall, so the further one is taken.");
        }

        [Test, Description("With nothing remembered, a drop is walked to like any other")]
        public void Choose_NothingRemembered_TakesTheDrop() {
            var found = new List<Found> { ground(id: "g_drop", distance: 13.0f, height: -3.1f) };
            var seek = new Seek(kind: "Ground", keep_from: "edge");
            var memory = new Memory(actor: "place_curious_01", holds: 16);

            Choice choice = Perceive.Choose(found: found, seek: seek, memory: memory);

            Assert.That(choice.Taken, Is.True,
                "A character must fall once before it can expect to fall.");
        }

        [Test, Description("A seek that keeps from nothing takes a drop even so")]
        public void Choose_KeepingFromNothing_TakesTheDrop() {
            var found = new List<Found> { ground(id: "g_drop", distance: 13.0f, height: -3.1f) };
            var seek = new Seek(kind: "Ground");

            Choice choice = Perceive.Choose(found: found, seek: seek, memory: hasFallenTwice());

            Assert.That(choice.Taken, Is.True,
                "GoHome does not weigh a drop: it has somewhere to be.");
        }

        ///////////////////////////////////////////////////////////////////////////////////////////////
        // Facing back and facing forward, in one seek

        [Test, Description("A seek may ask both questions of one table at once")]
        public void Choose_BothQuestions_AreAsked() {
            var memory = hasFallenTwice();
            memory.Write(at: 30f, place: "p_south", deed: "met", thing: "g_known", other: "",
                kind: "Ground", reach: 8.0f, height: 0f);

            var found = new List<Found> {
                ground(id: "g_known", distance: 5.0f, height: 0f),
                ground(id: "g_drop", distance: 13.0f, height: -3.1f),
                ground(id: "g_new", distance: 20.0f, height: 0f)
            };
            var seek = new Seek(kind: "Ground", not_in_memory: "met", keep_from: "edge");

            Choice choice = Perceive.Choose(found: found, seek: seek, memory: memory);

            Assert.That(choice.ID, Is.EqualTo("g_new"),
                "The nearest was met before; the next is like a fall. **One table, faced two ways.**");
        }

        ///////////////////////////////////////////////////////////////////////////////////////////////
        // Nothing made anew

        [Test, Description("Weighing what ones like it did makes nothing new")]
        public void Choose_WithKeepFrom_MakesNothingNew() {
            var found = new List<Found> { ground(id: "g_new", distance: 13.0f, height: -3.1f) };
            var seek = new Seek(kind: "Ground", keep_from: "edge");
            var memory = hasFallenTwice();
            for (int i = 0; i < 2000; i++) {
                Perceive.Choose(found: found, seek: seek, memory: memory);
            }

            long before = System.GC.GetAllocatedBytesForCurrentThread();
            for (int i = 0; i < 10000; i++) {
                Perceive.Choose(found: found, seek: seek, memory: memory);
            }
            long after = System.GC.GetAllocatedBytesForCurrentThread();

            Assert.That(after - before, Is.EqualTo(0));
        }
    }
}
