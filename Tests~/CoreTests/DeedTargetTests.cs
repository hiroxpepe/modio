// Copyright (c) STUDIO MeowToon. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

#nullable enable

using NUnit.Framework;

using Modio.Core;

namespace Modio.Tests.Core {
    ///////////////////////////////////////////////////////////////////////////////////////////////////
    // public Classes

    /// <summary>
    /// Unit tests for a Deed holding on to what it reached for (modio P-04).
    ///
    /// A deed that lands writes a row, and a row names what was done to
    /// (§4.1). **So a deed must carry the id of what it found**, from the
    /// moment seeking hands it over to the moment the row goes down — or there
    /// is nothing to write.
    ///
    /// It carries what the row keeps beside the id, too: the kind, how far off
    /// it stood, how far up or down it sat. Those three are what let the same
    /// table be faced the other way (§4.7).
    ///
    /// See docs/modio_spec.md 4.1 and 5.
    /// </summary>
    /// <author>h.adachi (STUDIO MeowToon)</author>
    [TestFixture]
    public class DeedTargetTests {

        ///////////////////////////////////////////////////////////////////////////////////////////////
        // private static Methods [verb]

        static Deed walkTo() {
            return new Deed(motion: "walk", act: "", until: Until.Near(within: 2f), lock_for: 30f);
        }

        static Choice found(string id) {
            return Choice.Of(found: new Found(kind: "Ground", id: id,
                angle: 20f, distance: 12f, height: -0.5f));
        }

        ///////////////////////////////////////////////////////////////////////////////////////////////
        // Taking hold of what was found

        [Test, Description("A deed begun with nothing found holds nothing")]
        public void Begin_NothingFound_HoldsNothing() {
            Deed deed = walkTo();
            deed.Begin(taken: Choice.None());

            Assert.That(deed.Holding.Taken, Is.False);
        }

        [Test, Description("A deed begun with something found holds its id")]
        public void Begin_SomethingFound_HoldsItsID() {
            Deed deed = walkTo();
            deed.Begin(taken: found(id: "g_1042"));

            Assert.That(deed.Holding.ID, Is.EqualTo("g_1042"));
        }

        [Test, Description("A deed holds what the row will keep beside the id")]
        public void Begin_HoldsWhatARowKeeps() {
            Deed deed = walkTo();
            deed.Begin(taken: found(id: "g_1042"));

            Assert.That(deed.Holding.Kind, Is.EqualTo("Ground"));
            Assert.That(deed.Holding.Distance, Is.EqualTo(12f));
            Assert.That(deed.Holding.Height, Is.EqualTo(-0.5f));
        }

        [Test, Description("A deed with something found begins by turning to face it")]
        public void Begin_SomethingFound_BeginsByFacing() {
            Deed deed = walkTo();
            deed.Begin(taken: found(id: "g_1042"));

            Assert.That(deed.Step, Is.EqualTo(DeedStep.Face));
        }

        [Test, Description("A deed with nothing found begins moving straight away")]
        public void Begin_NothingFound_BeginsMoving() {
            Deed deed = new Deed(motion: "idle", act: "",
                until: Until.TimeUp(seconds: 4f), lock_for: 30f);
            deed.Begin(taken: Choice.None());

            Assert.That(deed.Step, Is.EqualTo(DeedStep.Move),
                "Rest holds nothing, so there is nothing to turn toward.");
        }

        ///////////////////////////////////////////////////////////////////////////////////////////////
        // It still holds it when the deed is done

        [Test, Description("A deed that lands still knows what it reached for")]
        public void Done_StillKnowsWhatItReachedFor() {
            Deed deed = walkTo();
            deed.Begin(taken: found(id: "g_1042"));
            deed.Tick(delta_time: 0.1f, facing: true, distance: 12f, acted: false);
            deed.Tick(delta_time: 0.1f, facing: true, distance: 1.5f, acted: false);

            Assert.That(deed.End, Is.EqualTo(DeedEnd.Done));
            Assert.That(deed.Holding.ID, Is.EqualTo("g_1042"),
                "The row about to go down names what was done to. Without this, there is nothing to write.");
        }

        ///////////////////////////////////////////////////////////////////////////////////////////////
        // The whole round: seek, carry, write

        [Test, Description("What seeking found is what the row names")]
        public void WholeRound_WhatWasFoundIsWhatIsWritten() {
            var memory = new Memory(actor: "place_curious_01", holds: 16);
            Choice taken = found(id: "g_1042");

            Deed deed = walkTo();
            deed.Begin(taken: taken);
            deed.Tick(delta_time: 0.1f, facing: true, distance: 12f, acted: false);
            deed.Tick(delta_time: 0.1f, facing: true, distance: 1.5f, acted: false);

            if (deed.MayWrite) {
                memory.Write(at: 12.4f, place: "p_1", deed: "met",
                    thing: deed.Holding.ID, other: "",
                    kind: deed.Holding.Kind, reach: deed.Holding.Distance,
                    height: deed.Holding.Height);
            }

            Assert.That(memory.Holds(deed: "met", thing: "g_1042"), Is.True);
            Assert.That(memory.HoldsLike(deed: "met", kind: "Ground", reach: 12f, height: -0.5f), Is.True,
                "Both ways of asking find it: by name, and by what it was like.");
        }

        [Test, Description("A deed that fails writes nothing, for all it still holds")]
        public void WholeRound_Failed_WritesNothing() {
            var memory = new Memory(actor: "place_curious_01", holds: 16);
            Deed deed = walkTo();
            deed.Begin(taken: found(id: "g_1042"));
            deed.Lost();

            if (deed.MayWrite) {
                memory.Write(at: 12.4f, place: "p_1", deed: "met", thing: deed.Holding.ID, other: "");
            }

            Assert.That(memory.Count, Is.EqualTo(0),
                "Done is the one gate into memory. It still knows what it reached for; "
                + "it simply never got there.");
        }

        ///////////////////////////////////////////////////////////////////////////////////////////////
        // Nothing made anew

        [Test, Description("Taking hold of what was found makes nothing new")]
        public void Begin_MakesNothingNew() {
            Choice taken = found(id: "g_1042");
            Deed deed = walkTo();
            for (int i = 0; i < 2000; i++) { deed.Begin(taken: taken); }

            long before = System.GC.GetAllocatedBytesForCurrentThread();
            for (int i = 0; i < 10000; i++) { deed.Begin(taken: taken); }
            long after = System.GC.GetAllocatedBytesForCurrentThread();

            Assert.That(after - before, Is.EqualTo(0));
        }
    }
}
