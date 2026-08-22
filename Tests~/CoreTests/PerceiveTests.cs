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
    /// Unit tests for choosing which found thing to reach for (modio P-02).
    ///
    /// Runtime asks Unity's own Physics and hands back a plain list; this part
    /// takes that list, weighs it against memory, and picks one. **No Unity at
    /// all** — see docs/modio_spec.md 3.6.
    /// </summary>
    /// <author>h.adachi (STUDIO MeowToon)</author>
    [TestFixture]
    public class PerceiveTests {

        ///////////////////////////////////////////////////////////////////////////////////////////////
        // private static Methods [verb]

        static Found ground(string id, float angle, float distance, float height = 0f) {
            return new Found(kind: "Ground", id: id, angle: angle, distance: distance, height: height);
        }

        static Memory remembering(params string[] ids) {
            var memory = new Memory(actor: "npc_01", holds: 16);
            foreach (string id in ids) {
                memory.Write(at: 1f, place: "p_1", deed: "met", thing: id, other: "");
            }
            return memory;
        }

        static Found human(string id, float angle, float distance) {
            return new Found(kind: "Human", id: id, angle: angle, distance: distance, height: 0f);
        }

        ///////////////////////////////////////////////////////////////////////////////////////////////
        // public Methods [verb]

        [Test, Description("Nothing found gives back nothing taken")]
        public void Choose_NothingFound_TakesNothing() {
            var found = new List<Found>();
            var seek = new Seek(kind: "Ground");

            Choice choice = Perceive.Choose(found: found, seek: seek, memory: null);

            Assert.That(choice.Taken, Is.False);
        }

        [Test, Description("One thing of the right kind is taken")]
        public void Choose_OneOfTheRightKind_IsTaken() {
            var found = new List<Found> { ground(id: "g_1042", angle: 20f, distance: 8.5f) };
            var seek = new Seek(kind: "Ground");

            Choice choice = Perceive.Choose(found: found, seek: seek, memory: null);

            Assert.That(choice.Taken, Is.True);
            Assert.That(choice.ID, Is.EqualTo("g_1042"));
            Assert.That(choice.Angle, Is.EqualTo(20f));
            Assert.That(choice.Distance, Is.EqualTo(8.5f));
        }

        [Test, Description("A thing of another kind is passed over")]
        public void Choose_WrongKind_IsPassedOver() {
            var found = new List<Found> { human(id: "h_2001", angle: 20f, distance: 8.5f) };
            var seek = new Seek(kind: "Ground");

            Choice choice = Perceive.Choose(found: found, seek: seek, memory: null);

            Assert.That(choice.Taken, Is.False);
        }

        [Test, Description("Of two of the right kind, the nearer is taken")]
        public void Choose_TwoOfTheRightKind_TakesTheNearer() {
            var found = new List<Found> {
                ground(id: "g_1042", angle: 20f, distance: 12.0f),
                ground(id: "g_1055", angle: -45f, distance: 8.5f)
            };
            var seek = new Seek(kind: "Ground");

            Choice choice = Perceive.Choose(found: found, seek: seek, memory: null);

            Assert.That(choice.ID, Is.EqualTo("g_1055"));
        }

        [Test, Description("A thing further off than the reach is passed over")]
        public void Choose_FurtherThanReach_IsPassedOver() {
            var found = new List<Found> { ground(id: "g_1042", angle: 20f, distance: 40.0f) };
            var seek = new Seek(kind: "Ground", reach: 15.0f);

            Choice choice = Perceive.Choose(found: found, seek: seek, memory: null);

            Assert.That(choice.Taken, Is.False);
        }

        [Test, Description("A thing further round than the spread is passed over")]
        public void Choose_FurtherRoundThanSpread_IsPassedOver() {
            var found = new List<Found> { ground(id: "g_1042", angle: 120f, distance: 8.5f) };
            var seek = new Seek(kind: "Ground", spread: 90.0f);

            Choice choice = Perceive.Choose(found: found, seek: seek, memory: null);

            Assert.That(choice.Taken, Is.False,
                "A spread of 90 reaches 45 either way from straight ahead.");
        }

        [Test, Description("A thing round the other way is weighed the same")]
        public void Choose_RoundTheOtherWay_IsWeighedTheSame() {
            var found = new List<Found> { ground(id: "g_1042", angle: -30f, distance: 8.5f) };
            var seek = new Seek(kind: "Ground", spread: 90.0f);

            Choice choice = Perceive.Choose(found: found, seek: seek, memory: null);

            Assert.That(choice.Taken, Is.True, "30 either way is within a spread of 90.");
        }

        [Test, Description("A thing already in memory is passed over")]
        public void Choose_AlreadyInMemory_IsPassedOver() {
            var found = new List<Found> { ground(id: "g_1042", angle: 20f, distance: 8.5f) };
            var seek = new Seek(kind: "Ground", not_in_memory: "met");
            var memory = remembering("g_1042");

            Choice choice = Perceive.Choose(found: found, seek: seek, memory: memory);

            Assert.That(choice.Taken, Is.False,
                "A want for new places must not settle for one it has already met.");
        }

        [Test, Description("Of two, the one memory does not hold is taken")]
        public void Choose_OneKnownOneNot_TakesTheUnknown() {
            var found = new List<Found> {
                ground(id: "g_1042", angle: 20f, distance: 8.5f),
                ground(id: "g_1055", angle: -45f, distance: 12.0f)
            };
            var seek = new Seek(kind: "Ground", not_in_memory: "met");
            var memory = remembering("g_1042");

            Choice choice = Perceive.Choose(found: found, seek: seek, memory: memory);

            Assert.That(choice.ID, Is.EqualTo("g_1055"),
                "The nearer one is known, so the further one is taken.");
        }

        [Test, Description("Memory is passed over where the seek does not name one")]
        public void Choose_NoMemoryAsked_TakesEvenAKnownOne() {
            var found = new List<Found> { ground(id: "g_1042", angle: 20f, distance: 8.5f) };
            var seek = new Seek(kind: "Ground");
            var memory = remembering("g_1042");

            Choice choice = Perceive.Choose(found: found, seek: seek, memory: memory);

            Assert.That(choice.Taken, Is.True,
                "Approach does not care whether it has met the other one before.");
        }

        [Test, Description("Every one being known gives back nothing taken")]
        public void Choose_EveryOneKnown_TakesNothing() {
            var found = new List<Found> {
                ground(id: "g_1042", angle: 20f, distance: 8.5f),
                ground(id: "g_1055", angle: -45f, distance: 12.0f)
            };
            var seek = new Seek(kind: "Ground", not_in_memory: "met");
            var memory = remembering("g_1042", "g_1055");

            Choice choice = Perceive.Choose(found: found, seek: seek, memory: memory);

            Assert.That(choice.Taken, Is.False,
                "This is how 'south is done' comes about: nothing new is in sight, "
                + "the deed ends Failed, and the character turns another way.");
        }

        ///////////////////////////////////////////////////////////////////////////////////////////////
        // Same in, same out

        [Test, Description("The same list gives back the same choice, every time")]
        public void Choose_SameList_SameChoice() {
            var found = new List<Found> {
                ground(id: "g_1042", angle: 20f, distance: 8.5f),
                ground(id: "g_1055", angle: -45f, distance: 8.5f)
            };
            var seek = new Seek(kind: "Ground");

            Choice first = Perceive.Choose(found: found, seek: seek, memory: null);
            Choice second = Perceive.Choose(found: found, seek: seek, memory: null);

            Assert.That(second.ID, Is.EqualTo(first.ID),
                "Two at the very same distance must not be picked between at random.");
        }

        [Test, Description("Choosing leaves the list it was given as it was")]
        public void Choose_LeavesTheListAsItWas() {
            var found = new List<Found> {
                ground(id: "g_1042", angle: 20f, distance: 12.0f),
                ground(id: "g_1055", angle: -45f, distance: 8.5f)
            };
            var seek = new Seek(kind: "Ground");

            Perceive.Choose(found: found, seek: seek, memory: null);

            Assert.That(found[0].ID, Is.EqualTo("g_1042"),
                "Runtime fills the same list again each tick; sorting it in place would "
                + "cost, and would surprise whoever holds it.");
        }
    }
}
