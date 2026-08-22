// Copyright (c) STUDIO MeowToon. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

#nullable enable

using NUnit.Framework;

using Modio.Core;

namespace Modio.Tests.Core {
    ///////////////////////////////////////////////////////////////////////////////////////////////////
    // public Classes

    /// <summary>
    /// Unit tests for carrying one Behavior through over time (modio P-04).
    ///
    /// A Deed runs up to three steps — face, move, act — and ends one of three
    /// ways. **Done is the one gate into memory**; Failed and Dropped write
    /// nothing at all.
    ///
    /// The clock is handed in, so a whole deed may be run through in a test with
    /// no Unity and no waiting. See docs/modio_spec.md 5.
    /// </summary>
    /// <author>h.adachi (STUDIO MeowToon)</author>
    [TestFixture]
    public class DeedTests {

        ///////////////////////////////////////////////////////////////////////////////////////////////
        // private static Methods [verb]

        /// <summary>A deed that walks to a thing and is done once near it.</summary>
        static Deed walkTo(float near = 2.0f, string act = "") {
            return new Deed(motion: "walk", act: act, until: Until.Near(within: near), lock_for: 30f);
        }

        ///////////////////////////////////////////////////////////////////////////////////////////////
        // Where it begins

        [Test, Description("A deed begins running, with nothing yet settled")]
        public void New_BeginsRunning() {
            Deed deed = walkTo();

            Assert.That(deed.End, Is.EqualTo(DeedEnd.Running));
        }

        [Test, Description("A deed with a target begins by turning to face it")]
        public void New_WithTarget_BeginsByFacing() {
            Deed deed = walkTo();
            deed.Begin(taken: Choice.Of(found: new Found(kind: "Ground", id: "g_1", angle: 0f, distance: 12f, height: 0f)));

            Assert.That(deed.Step, Is.EqualTo(DeedStep.Face));
        }

        [Test, Description("A deed with no target begins moving straight away")]
        public void New_WithNoTarget_BeginsMoving() {
            Deed deed = new Deed(motion: "idle", act: "",
                until: Until.TimeUp(seconds: 4.0f), lock_for: 30f);
            deed.Begin(taken: Choice.None());

            Assert.That(deed.Step, Is.EqualTo(DeedStep.Move),
                "Rest holds no target, so there is nothing to turn toward.");
        }

        ///////////////////////////////////////////////////////////////////////////////////////////////
        // Facing, then moving

        [Test, Description("Once it faces, it moves")]
        public void Tick_OnceFacing_Moves() {
            Deed deed = walkTo();
            deed.Begin(taken: Choice.Of(found: new Found(kind: "Ground", id: "g_1", angle: 0f, distance: 12f, height: 0f)));

            deed.Tick(delta_time: 0.1f, facing: true, distance: 12f, acted: false);

            Assert.That(deed.Step, Is.EqualTo(DeedStep.Move));
        }

        [Test, Description("While it is still turning, it does not move")]
        public void Tick_StillTurning_DoesNotMove() {
            Deed deed = walkTo();
            deed.Begin(taken: Choice.Of(found: new Found(kind: "Ground", id: "g_1", angle: 0f, distance: 12f, height: 0f)));

            deed.Tick(delta_time: 0.1f, facing: false, distance: 12f, acted: false);

            Assert.That(deed.Step, Is.EqualTo(DeedStep.Face));
        }

        ///////////////////////////////////////////////////////////////////////////////////////////////
        // Done

        [Test, Description("Once near enough, a deed with no act is Done")]
        public void Tick_NearEnough_NoAct_IsDone() {
            Deed deed = walkTo(near: 2.0f);
            deed.Begin(taken: Choice.Of(found: new Found(kind: "Ground", id: "g_1", angle: 0f, distance: 12f, height: 0f)));
            deed.Tick(delta_time: 0.1f, facing: true, distance: 12f, acted: false);

            deed.Tick(delta_time: 0.1f, facing: true, distance: 1.5f, acted: false);

            Assert.That(deed.End, Is.EqualTo(DeedEnd.Done));
        }

        [Test, Description("Once near enough, a deed with an act goes on to act")]
        public void Tick_NearEnough_WithAct_GoesOnToAct() {
            Deed deed = walkTo(near: 1.5f, act: "hand_over");
            deed.Begin(taken: Choice.Of(found: new Found(kind: "Ground", id: "g_1", angle: 0f, distance: 12f, height: 0f)));
            deed.Tick(delta_time: 0.1f, facing: true, distance: 12f, acted: false);

            deed.Tick(delta_time: 0.1f, facing: true, distance: 1.0f, acted: false);

            Assert.That(deed.Step, Is.EqualTo(DeedStep.Act));
            Assert.That(deed.End, Is.EqualTo(DeedEnd.Running), "The act has not been carried out yet.");
        }

        [Test, Description("Once the act is carried out, the deed is Done")]
        public void Tick_ActCarriedOut_IsDone() {
            Deed deed = walkTo(near: 1.5f, act: "hand_over");
            deed.Begin(taken: Choice.Of(found: new Found(kind: "Ground", id: "g_1", angle: 0f, distance: 12f, height: 0f)));
            deed.Tick(delta_time: 0.1f, facing: true, distance: 12f, acted: false);
            deed.Tick(delta_time: 0.1f, facing: true, distance: 1.0f, acted: false);

            deed.Tick(delta_time: 0.1f, facing: true, distance: 1.0f, acted: true);

            Assert.That(deed.End, Is.EqualTo(DeedEnd.Done));
        }

        [Test, Description("A deed held for a set time is Done once the time is up")]
        public void Tick_TimeUp_IsDone() {
            Deed deed = new Deed(motion: "idle", act: "",
                until: Until.TimeUp(seconds: 4.0f), lock_for: 30f);
            deed.Begin(taken: Choice.None());

            for (int i = 0; i < 41; i++) {
                deed.Tick(delta_time: 0.1f, facing: true, distance: 0f, acted: false);
            }

            Assert.That(deed.End, Is.EqualTo(DeedEnd.Done));
        }

        [Test, Description("A deed held for a set time is still running before then")]
        public void Tick_TimeNotUp_IsStillRunning() {
            Deed deed = new Deed(motion: "idle", act: "",
                until: Until.TimeUp(seconds: 4.0f), lock_for: 30f);
            deed.Begin(taken: Choice.None());

            for (int i = 0; i < 20; i++) {
                deed.Tick(delta_time: 0.1f, facing: true, distance: 0f, acted: false);
            }

            Assert.That(deed.End, Is.EqualTo(DeedEnd.Running));
        }

        ///////////////////////////////////////////////////////////////////////////////////////////////
        // Failed

        [Test, Description("A deed that runs past its lock ends Failed")]
        public void Tick_PastItsLock_IsFailed() {
            Deed deed = walkTo();
            deed.Begin(taken: Choice.Of(found: new Found(kind: "Ground", id: "g_1", angle: 0f, distance: 12f, height: 0f)));

            for (int i = 0; i < 320; i++) {
                deed.Tick(delta_time: 0.1f, facing: true, distance: 12f, acted: false);
            }

            Assert.That(deed.End, Is.EqualTo(DeedEnd.Failed),
                "Half a minute walking and never arriving is a deed that will not land.");
        }

        [Test, Description("A deed whose target is gone ends Failed")]
        public void Lost_IsFailed() {
            Deed deed = walkTo();
            deed.Begin(taken: Choice.Of(found: new Found(kind: "Ground", id: "g_1", angle: 0f, distance: 12f, height: 0f)));
            deed.Tick(delta_time: 0.1f, facing: true, distance: 12f, acted: false);

            deed.Lost();

            Assert.That(deed.End, Is.EqualTo(DeedEnd.Failed));
        }

        [Test, Description("A deed that holds while a state holds ends Failed, never Done")]
        public void Tick_WhileKind_EndsFailed() {
            Deed deed = new Deed(motion: "idle", act: "",
                until: Until.While(state: "other_near"), lock_for: 30f);
            deed.Begin(taken: Choice.None());

            for (int i = 0; i < 320; i++) {
                deed.Tick(delta_time: 0.1f, facing: true, distance: 0f, acted: false);
            }

            Assert.That(deed.End, Is.EqualTo(DeedEnd.Failed),
                "Call goes on until something else brings it down. A call is not an answer.");
        }

        ///////////////////////////////////////////////////////////////////////////////////////////////
        // Dropped

        [Test, Description("A deed let go part way is Dropped")]
        public void Drop_IsDropped() {
            Deed deed = walkTo();
            deed.Begin(taken: Choice.Of(found: new Found(kind: "Ground", id: "g_1", angle: 0f, distance: 12f, height: 0f)));
            deed.Tick(delta_time: 0.1f, facing: true, distance: 12f, acted: false);

            deed.Drop();

            Assert.That(deed.End, Is.EqualTo(DeedEnd.Dropped));
        }

        [Test, Description("Dropped is not Failed: they are told apart")]
        public void Drop_IsNotFailed() {
            Deed deed = walkTo();
            deed.Begin(taken: Choice.Of(found: new Found(kind: "Ground", id: "g_1", angle: 0f, distance: 12f, height: 0f)));

            deed.Drop();

            Assert.That(deed.End, Is.Not.EqualTo(DeedEnd.Failed),
                "Failed says the world would not have it; Dropped says the mind moved on.");
        }

        ///////////////////////////////////////////////////////////////////////////////////////////////
        // Only Done writes anything

        [Test, Description("Only a deed that is Done may be written down")]
        public void MayWrite_OnlyWhenDone() {
            Deed done = walkTo(near: 2.0f);
            done.Begin(taken: Choice.Of(found: new Found(kind: "Ground", id: "g_1", angle: 0f, distance: 12f, height: 0f)));
            done.Tick(delta_time: 0.1f, facing: true, distance: 12f, acted: false);
            done.Tick(delta_time: 0.1f, facing: true, distance: 1.5f, acted: false);

            Deed failed = walkTo();
            failed.Begin(taken: Choice.Of(found: new Found(kind: "Ground", id: "g_1", angle: 0f, distance: 12f, height: 0f)));
            failed.Lost();

            Deed dropped = walkTo();
            dropped.Begin(taken: Choice.Of(found: new Found(kind: "Ground", id: "g_1", angle: 0f, distance: 12f, height: 0f)));
            dropped.Drop();

            Assert.That(done.MayWrite, Is.True);
            Assert.That(failed.MayWrite, Is.False);
            Assert.That(dropped.MayWrite, Is.False);
        }

        ///////////////////////////////////////////////////////////////////////////////////////////////
        // Once it has ended, it stays ended

        [Test, Description("A deed already Done does not go back to running")]
        public void Tick_AfterDone_StaysDone() {
            Deed deed = walkTo(near: 2.0f);
            deed.Begin(taken: Choice.Of(found: new Found(kind: "Ground", id: "g_1", angle: 0f, distance: 12f, height: 0f)));
            deed.Tick(delta_time: 0.1f, facing: true, distance: 12f, acted: false);
            deed.Tick(delta_time: 0.1f, facing: true, distance: 1.5f, acted: false);

            deed.Tick(delta_time: 0.1f, facing: true, distance: 40f, acted: false);

            Assert.That(deed.End, Is.EqualTo(DeedEnd.Done));
        }

        [Test, Description("A deed already Failed is not made Done by anything after")]
        public void Tick_AfterFailed_StaysFailed() {
            Deed deed = walkTo(near: 2.0f);
            deed.Begin(taken: Choice.Of(found: new Found(kind: "Ground", id: "g_1", angle: 0f, distance: 12f, height: 0f)));
            deed.Lost();

            deed.Tick(delta_time: 0.1f, facing: true, distance: 1.0f, acted: false);

            Assert.That(deed.End, Is.EqualTo(DeedEnd.Failed));
        }

        ///////////////////////////////////////////////////////////////////////////////////////////////
        // Nothing made anew, tick after tick

        [Test, Description("Running a deed through makes nothing new")]
        public void Tick_MakesNothingNew() {
            Deed warm_deed = new Deed(motion: "walk", act: "",
                until: Until.Near(within: 0.001f), lock_for: 1e9f);
            warm_deed.Begin(taken: Choice.Of(found: new Found(kind: "Ground", id: "g_1", angle: 0f, distance: 12f, height: 0f)));
            for (int i = 0; i < 2000; i++) {
                warm_deed.Tick(delta_time: 0.001f, facing: true, distance: 12f, acted: false);
            }

            long before = System.GC.GetAllocatedBytesForCurrentThread();
            for (int i = 0; i < 10000; i++) {
                warm_deed.Tick(delta_time: 0.001f, facing: true, distance: 12f, acted: false);
            }
            long after = System.GC.GetAllocatedBytesForCurrentThread();

            Assert.That(after - before, Is.EqualTo(0),
                "A deed runs every tick, for every character. It must cost nothing to keep going.");
        }
    }
}
