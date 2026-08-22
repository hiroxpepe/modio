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
    /// Unit tests for asking after another character, rather than a thing
    /// (modio P-01, TASK-003).
    ///
    /// Counted against the 10 deeds the two given personas hold, a character has
    /// only two forward-facing questions to put:
    ///
    ///   about a place or a thing : how did ones like this go?
    ///   about another character  : how did it go with that very one?
    ///
    /// **The second has no "like it".** One character is not of a sort with
    /// another: place_curious_01 and company_seeking_01 are two, not two of a
    /// kind. So that question is always put by name.
    ///
    /// See docs/modio_spec.md 4.7.
    /// </summary>
    /// <author>h.adachi (STUDIO MeowToon)</author>
    [TestFixture]
    public class PerceiveOtherTests {

        ///////////////////////////////////////////////////////////////////////////////////////////////
        // private static Methods [verb]

        static Found human(string id, float distance) {
            return new Found(kind: "Human", id: id, angle: 0f, distance: distance, height: 0f);
        }

        static Memory hasGivenTo(string other) {
            var memory = new Memory(actor: "company_seeking_01", holds: 16);
            memory.Write(at: 31.8f, place: "p_3", deed: "gave", thing: "i_7", other: other);
            return memory;
        }

        ///////////////////////////////////////////////////////////////////////////////////////////////
        // Asking after another character

        [Test, Description("A character already given to is passed over")]
        public void Choose_AlreadyGivenTo_IsPassedOver() {
            var found = new List<Found> { human(id: "npc_02", distance: 8.5f) };
            var seek = new Seek(kind: "Human", not_given_to: "gave");

            Choice choice = Perceive.Choose(found: found, seek: seek, memory: hasGivenTo("npc_02"));

            Assert.That(choice.Taken, Is.False,
                "Giving to the same one for ever would look witless, and would leave "
                + "every other character never given to at all.");
        }

        [Test, Description("Of two, the one never given to is taken")]
        public void Choose_OneGivenToOneNot_TakesTheOther() {
            var found = new List<Found> {
                human(id: "npc_02", distance: 5.0f),
                human(id: "npc_03", distance: 12.0f)
            };
            var seek = new Seek(kind: "Human", not_given_to: "gave");

            Choice choice = Perceive.Choose(found: found, seek: seek, memory: hasGivenTo("npc_02"));

            Assert.That(choice.ID, Is.EqualTo("npc_03"),
                "The nearer one has been given to, so the further one is taken.");
        }

        [Test, Description("A character never given to is taken")]
        public void Choose_NeverGivenTo_IsTaken() {
            var found = new List<Found> { human(id: "npc_03", distance: 8.5f) };
            var seek = new Seek(kind: "Human", not_given_to: "gave");

            Choice choice = Perceive.Choose(found: found, seek: seek, memory: hasGivenTo("npc_02"));

            Assert.That(choice.Taken, Is.True);
        }

        [Test, Description("Another deed done with that one does not stand in the way")]
        public void Choose_MetButNotGivenTo_IsTaken() {
            var memory = new Memory(actor: "company_seeking_01", holds: 16);
            memory.Write(at: 10f, place: "p_3", deed: "met", thing: "", other: "npc_02");
            var found = new List<Found> { human(id: "npc_02", distance: 8.5f) };
            var seek = new Seek(kind: "Human", not_given_to: "gave");

            Choice choice = Perceive.Choose(found: found, seek: seek, memory: memory);

            Assert.That(choice.Taken, Is.True,
                "Having met someone is no reason not to give to them.");
        }

        [Test, Description("A seek asking nothing of another takes whoever is nearest")]
        public void Choose_AskingNothing_TakesTheNearest() {
            var found = new List<Found> { human(id: "npc_02", distance: 8.5f) };
            var seek = new Seek(kind: "Human");

            Choice choice = Perceive.Choose(found: found, seek: seek, memory: hasGivenTo("npc_02"));

            Assert.That(choice.Taken, Is.True,
                "Approach does not care whether it has given to them before.");
        }

        ///////////////////////////////////////////////////////////////////////////////////////////////
        // Every one given to

        [Test, Description("Every one given to leaves nothing taken, and the deed ends Failed")]
        public void Choose_EveryOneGivenTo_TakesNothing() {
            var memory = new Memory(actor: "company_seeking_01", holds: 16);
            memory.Write(at: 10f, place: "p_3", deed: "gave", thing: "i_1", other: "npc_02");
            memory.Write(at: 20f, place: "p_3", deed: "gave", thing: "i_2", other: "npc_03");
            var found = new List<Found> {
                human(id: "npc_02", distance: 5.0f),
                human(id: "npc_03", distance: 12.0f)
            };
            var seek = new Seek(kind: "Human", not_given_to: "gave");

            Choice choice = Perceive.Choose(found: found, seek: seek, memory: memory);

            Assert.That(choice.Taken, Is.False,
                "Nothing left to give to, so the deed ends Failed, and animo asks again. "
                + "In time a row is let go of, and someone becomes new to give to.");
        }

        ///////////////////////////////////////////////////////////////////////////////////////////////
        // All three questions, in one seek

        [Test, Description("A seek may put all three questions to one table")]
        public void Choose_AllThreeQuestions_AreAsked() {
            var memory = new Memory(actor: "npc_01", holds: 16);
            memory.Write(at: 10f, place: "p_1", deed: "met", thing: "h_met", other: "");
            memory.Write(at: 20f, place: "p_1", deed: "gave", thing: "i_1", other: "h_given");
            memory.Write(at: 30f, place: "p_1", deed: "edge", thing: "h_drop", other: "",
                kind: "Human", reach: 12.0f, height: -3.0f);

            var found = new List<Found> {
                human(id: "h_met", distance: 3.0f),
                human(id: "h_given", distance: 6.0f),
                new Found(kind: "Human", id: "h_like_drop", angle: 0f, distance: 13.0f, height: -3.1f),
                human(id: "h_new", distance: 20.0f)
            };
            var seek = new Seek(kind: "Human", not_in_memory: "met",
                not_given_to: "gave", keep_from: "edge");

            Choice choice = Perceive.Choose(found: found, seek: seek, memory: memory);

            Assert.That(choice.ID, Is.EqualTo("h_new"),
                "Met, given to, and like a fall — all three fall away, and what is left "
                + "is the one nothing is remembered of.");
        }

        ///////////////////////////////////////////////////////////////////////////////////////////////
        // Nothing made anew

        [Test, Description("Asking after another character makes nothing new")]
        public void Choose_AskingAfterAnother_MakesNothingNew() {
            var found = new List<Found> { human(id: "npc_02", distance: 8.5f) };
            var seek = new Seek(kind: "Human", not_given_to: "gave");
            var memory = hasGivenTo("npc_02");
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
