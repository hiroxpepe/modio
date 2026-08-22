// Copyright (c) STUDIO MeowToon. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

#nullable enable

using System.Collections.Generic;
using NUnit.Framework;

using Modio.Core;
using Modio.Tools;

namespace Modio.Tests.Tools {
    ///////////////////////////////////////////////////////////////////////////////////////////////////
    // public Classes

    /// <summary>
    /// Unit tests for running a whole round through, with no Unity (modio P-05).
    ///
    /// `animo` has a runner of its own, proving same input, same answer. Modio
    /// needs one too, and of the same shape: a list of what was seen, at what
    /// time, fed in tick by tick.
    ///
    /// **It is Modio's own, not `animo`'s.** The shape is copied; the code is
    /// not, and neither build leans on the other.
    ///
    /// See docs/modio_spec.md 3.6 and 9.
    /// </summary>
    /// <author>h.adachi (STUDIO MeowToon)</author>
    [TestFixture]
    public class RunnerTests {

        ///////////////////////////////////////////////////////////////////////////////////////////////
        // private static Methods [verb]

        static Found ground(string id, float distance) {
            return new Found(kind: "Ground", id: id, angle: 0f, distance: distance, height: 0f);
        }

        /// <summary>A world where one thing stands, and comes nearer as time goes on.</summary>
        static List<Seen> walkingUpToIt() {
            var seen = new List<Seen>();
            for (int i = 0; i < 20; i++) {
                seen.Add(item: new Seen(at: i * 0.1f, found: ground(id: "g_1042", distance: 12f - i * 0.6f)));
            }
            return seen;
        }

        ///////////////////////////////////////////////////////////////////////////////////////////////
        // Running a round

        [Test, Description("A run gives back a tick for every step")]
        public void Run_GivesBackATickForEveryStep() {
            var runner = new Runner(seen: walkingUpToIt());
            var deed = new Deed(motion: "walk", act: "", until: Until.Near(within: 2f), lock_for: 30f);

            Trace trace = runner.Run(deed: deed, duration: 2.0f, delta_time: 0.1f);

            Assert.That(trace.Steps.Count, Is.GreaterThan(0));
        }

        [Test, Description("A deed that walks up to a thing ends Done")]
        public void Run_WalkingUpToIt_EndsDone() {
            var runner = new Runner(seen: walkingUpToIt());
            var deed = new Deed(motion: "walk", act: "", until: Until.Near(within: 2f), lock_for: 30f);

            Trace trace = runner.Run(deed: deed, duration: 2.0f, delta_time: 0.1f);

            Assert.That(trace.End, Is.EqualTo(DeedEnd.Done));
        }

        [Test, Description("The trace says at what time the deed ended")]
        public void Run_SaysWhenItEnded() {
            var runner = new Runner(seen: walkingUpToIt());
            var deed = new Deed(motion: "walk", act: "", until: Until.Near(within: 2f), lock_for: 30f);

            Trace trace = runner.Run(deed: deed, duration: 2.0f, delta_time: 0.1f);

            Assert.That(trace.EndedAt, Is.GreaterThan(0f));
            Assert.That(trace.EndedAt, Is.LessThanOrEqualTo(2.0f));
        }

        ///////////////////////////////////////////////////////////////////////////////////////////////
        // Same in, same out

        [Test, Description("The same world gives back the same answer, every run")]
        public void Run_SameWorld_SameAnswer() {
            var seen = walkingUpToIt();

            Trace first = new Runner(seen: seen).Run(
                deed: new Deed(motion: "walk", act: "", until: Until.Near(within: 2f), lock_for: 30f),
                duration: 2.0f, delta_time: 0.1f);
            Trace second = new Runner(seen: seen).Run(
                deed: new Deed(motion: "walk", act: "", until: Until.Near(within: 2f), lock_for: 30f),
                duration: 2.0f, delta_time: 0.1f);

            Assert.That(second.End, Is.EqualTo(first.End));
            Assert.That(second.EndedAt, Is.EqualTo(first.EndedAt));
            Assert.That(second.Steps.Count, Is.EqualTo(first.Steps.Count));
        }

        [Test, Description("Every step of the second run matches the first")]
        public void Run_SameWorld_EveryStepMatches() {
            var seen = walkingUpToIt();

            Trace first = new Runner(seen: seen).Run(
                deed: new Deed(motion: "walk", act: "", until: Until.Near(within: 2f), lock_for: 30f),
                duration: 2.0f, delta_time: 0.1f);
            Trace second = new Runner(seen: seen).Run(
                deed: new Deed(motion: "walk", act: "", until: Until.Near(within: 2f), lock_for: 30f),
                duration: 2.0f, delta_time: 0.1f);

            for (int i = 0; i < first.Steps.Count; i++) {
                Assert.That(second.Steps[i].Step, Is.EqualTo(first.Steps[i].Step), $"step {i}");
                Assert.That(second.Steps[i].At, Is.EqualTo(first.Steps[i].At), $"time {i}");
            }
        }

        ///////////////////////////////////////////////////////////////////////////////////////////////
        // A world where nothing is ever near enough

        [Test, Description("A deed that never arrives ends Failed once its lock gives out")]
        public void Run_NeverArrives_EndsFailed() {
            var seen = new List<Seen>();
            for (int i = 0; i < 400; i++) {
                seen.Add(item: new Seen(at: i * 0.1f, found: ground(id: "g_1042", distance: 40f)));
            }
            var runner = new Runner(seen: seen);
            var deed = new Deed(motion: "walk", act: "", until: Until.Near(within: 2f), lock_for: 30f);

            Trace trace = runner.Run(deed: deed, duration: 40.0f, delta_time: 0.1f);

            Assert.That(trace.End, Is.EqualTo(DeedEnd.Failed));
            Assert.That(trace.EndedAt, Is.EqualTo(30f).Within(0.2f),
                "Half a minute is the most a deed may run.");
        }

        [Test, Description("A world holding nothing at all leaves a deed Failed")]
        public void Run_NothingSeen_EndsFailed() {
            var runner = new Runner(seen: new List<Seen>());
            var deed = new Deed(motion: "walk", act: "", until: Until.Near(within: 2f), lock_for: 30f);

            Trace trace = runner.Run(deed: deed, duration: 40.0f, delta_time: 0.1f);

            Assert.That(trace.End, Is.EqualTo(DeedEnd.Failed));
        }

        ///////////////////////////////////////////////////////////////////////////////////////////////
        // A deed held for a set time

        [Test, Description("A deed resting for four seconds ends Done at four seconds")]
        public void Run_RestingForFourSeconds_EndsDoneThen() {
            var runner = new Runner(seen: new List<Seen>());
            var deed = new Deed(motion: "idle", act: "",
                until: Until.TimeUp(seconds: 4.0f), lock_for: 30f);

            Trace trace = runner.Run(deed: deed, duration: 10.0f, delta_time: 0.1f);

            Assert.That(trace.End, Is.EqualTo(DeedEnd.Done));
            Assert.That(trace.EndedAt, Is.EqualTo(4.0f).Within(0.15f));
        }

        ///////////////////////////////////////////////////////////////////////////////////////////////
        // Reading a run back

        [Test, Description("A run may be written out as plain lines")]
        public void Trace_WritesOutAsPlainLines() {
            var runner = new Runner(seen: walkingUpToIt());
            var deed = new Deed(motion: "walk", act: "", until: Until.Near(within: 2f), lock_for: 30f);

            Trace trace = runner.Run(deed: deed, duration: 2.0f, delta_time: 0.1f);
            string written = trace.Write();

            Assert.That(written, Is.Not.Empty);
            Assert.That(written, Does.Contain("time"),
                "A person must be able to read a run through with their own eyes.");
        }
    }
}
