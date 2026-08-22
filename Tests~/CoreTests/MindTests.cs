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
    /// Unit tests for holding a Behavior steady while a deed plays out
    /// (modio P-04).
    ///
    /// animo already holds what a deed needs: Lock(duration, Soft). Soft is what
    /// a deed wants — scores still work on the inside, and only what is given
    /// back is held, so a sudden want may still break in and drop the deed.
    ///
    /// **Modio does not name animo here.** What it needs of a mind is four
    /// things, and they are set out as a way in, so a test may stand a plain
    /// one in place of the real engine and run a whole round with nothing else
    /// at all.
    ///
    /// See docs/modio_spec.md 5.3.
    /// </summary>
    /// <author>h.adachi (STUDIO MeowToon)</author>
    [TestFixture]
    public class MindTests {

        ///////////////////////////////////////////////////////////////////////////////////////////////
        // public Classes

        /// <summary>A mind that says whatever it is told to say.</summary>
        sealed class PlainMind : IMind {
            public string Behavior { get; set; } = "Explore";
            public float LockedFor { get; private set; }
            public bool LockedSoft { get; private set; }
            public List<string> Quieted { get; } = new List<string>();
            public List<float> ByHowMuch { get; } = new List<float>();

            public void Lock(float duration, bool soft) {
                LockedFor = duration;
                LockedSoft = soft;
            }

            public void Affect(string need, float delta) {
                Quieted.Add(item: need);
                ByHowMuch.Add(item: delta);
            }
        }

        ///////////////////////////////////////////////////////////////////////////////////////////////
        // Holding a Behavior steady

        [Test, Description("Starting a deed holds the mind for as long as the deed may run")]
        public void Begin_HoldsTheMind() {
            var mind = new PlainMind();
            var hand = new Hand(mind: mind);

            hand.Begin(hold_for: 30f);

            Assert.That(mind.LockedFor, Is.EqualTo(30f));
        }

        [Test, Description("The hold is soft, so a sudden want may still break in")]
        public void Begin_HoldsSoftly() {
            var mind = new PlainMind();
            var hand = new Hand(mind: mind);

            hand.Begin(hold_for: 30f);

            Assert.That(mind.LockedSoft, Is.True,
                "Hard would shut out fear itself. A deed wants steady, not deaf.");
        }

        ///////////////////////////////////////////////////////////////////////////////////////////////
        // Telling when the mind has moved on

        [Test, Description("A mind saying the same thing has not moved on")]
        public void HasMovedOn_SameBehavior_IsFalse() {
            var mind = new PlainMind { Behavior = "Explore" };
            var hand = new Hand(mind: mind);
            hand.Begin(hold_for: 30f);

            Assert.That(hand.HasMovedOn(), Is.False);
        }

        [Test, Description("A mind saying another thing has moved on")]
        public void HasMovedOn_AnotherBehavior_IsTrue() {
            var mind = new PlainMind { Behavior = "Explore" };
            var hand = new Hand(mind: mind);
            hand.Begin(hold_for: 30f);

            mind.Behavior = "Flee";

            Assert.That(hand.HasMovedOn(), Is.True,
                "A soft hold lets fear break in, and when it does, the deed is Dropped.");
        }

        [Test, Description("What the mind said at the start is what is held to")]
        public void Begin_KeepsWhatWasSaid() {
            var mind = new PlainMind { Behavior = "Give" };
            var hand = new Hand(mind: mind);

            hand.Begin(hold_for: 30f);

            Assert.That(hand.Holding, Is.EqualTo("Give"));
        }

        ///////////////////////////////////////////////////////////////////////////////////////////////
        // Giving back what a deed landed

        [Test, Description("A deed that lands quiets the want it was for")]
        public void Landed_QuietsOneWant() {
            var mind = new PlainMind();
            var hand = new Hand(mind: mind);
            hand.Begin(hold_for: 30f);

            hand.Landed(need: "curiosity", delta: -25f);

            Assert.That(mind.Quieted, Has.Count.EqualTo(1));
            Assert.That(mind.Quieted[0], Is.EqualTo("curiosity"));
            Assert.That(mind.ByHowMuch[0], Is.EqualTo(-25f));
        }

        [Test, Description("One arrival may quiet more than one want")]
        public void Landed_MayQuietTwoWants() {
            var mind = new PlainMind();
            var hand = new Hand(mind: mind);
            hand.Begin(hold_for: 30f);

            hand.Landed(need: "loneliness", delta: -30f);
            hand.Landed(need: "separation", delta: -40f);

            Assert.That(mind.Quieted, Is.EqualTo(new List<string> { "loneliness", "separation" }),
                "Approach landing quiets both, or Call would win for ever.");
        }

        ///////////////////////////////////////////////////////////////////////////////////////////////
        // The whole round, with a plain mind standing in

        [Test, Description("A deed that lands holds, runs, and quiets its want")]
        public void WholeRound_DeedLands() {
            var mind = new PlainMind { Behavior = "Explore" };
            var hand = new Hand(mind: mind);
            hand.Begin(hold_for: 30f);

            var deed = new Deed(motion: "walk", act: "",
                until: Until.Near(within: 2f), lock_for: 30f);
            deed.Begin(has_target: true);
            deed.Tick(delta_time: 0.1f, facing: true, distance: 12f, acted: false);
            deed.Tick(delta_time: 0.1f, facing: true, distance: 1.5f, acted: false);

            if (deed.MayWrite) { hand.Landed(need: "curiosity", delta: -25f); }

            Assert.That(deed.End, Is.EqualTo(DeedEnd.Done));
            Assert.That(mind.Quieted, Has.Count.EqualTo(1));
        }

        [Test, Description("A deed that fails quiets nothing at all")]
        public void WholeRound_DeedFails_QuietsNothing() {
            var mind = new PlainMind { Behavior = "Explore" };
            var hand = new Hand(mind: mind);
            hand.Begin(hold_for: 30f);

            var deed = new Deed(motion: "walk", act: "",
                until: Until.Near(within: 2f), lock_for: 30f);
            deed.Begin(has_target: true);
            deed.Lost();

            if (deed.MayWrite) { hand.Landed(need: "curiosity", delta: -25f); }

            Assert.That(mind.Quieted, Is.Empty,
                "The want does not fall, so the mind asks for the same thing again next tick. "
                + "That is how a character keeps trying.");
        }

        [Test, Description("A deed dropped because the mind moved on quiets nothing")]
        public void WholeRound_MindMovedOn_QuietsNothing() {
            var mind = new PlainMind { Behavior = "Explore" };
            var hand = new Hand(mind: mind);
            hand.Begin(hold_for: 30f);

            var deed = new Deed(motion: "walk", act: "",
                until: Until.Near(within: 2f), lock_for: 30f);
            deed.Begin(has_target: true);
            deed.Tick(delta_time: 0.1f, facing: true, distance: 12f, acted: false);

            mind.Behavior = "Flee";
            if (hand.HasMovedOn()) { deed.Drop(); }
            if (deed.MayWrite) { hand.Landed(need: "curiosity", delta: -25f); }

            Assert.That(deed.End, Is.EqualTo(DeedEnd.Dropped));
            Assert.That(mind.Quieted, Is.Empty);
        }

        ///////////////////////////////////////////////////////////////////////////////////////////////
        // Nothing made anew, tick after tick

        [Test, Description("Asking whether the mind has moved on makes nothing new")]
        public void HasMovedOn_MakesNothingNew() {
            var mind = new PlainMind { Behavior = "Explore" };
            var hand = new Hand(mind: mind);
            hand.Begin(hold_for: 30f);
            for (int i = 0; i < 2000; i++) { hand.HasMovedOn(); }

            long before = System.GC.GetAllocatedBytesForCurrentThread();
            for (int i = 0; i < 10000; i++) { hand.HasMovedOn(); }
            long after = System.GC.GetAllocatedBytesForCurrentThread();

            Assert.That(after - before, Is.EqualTo(0),
                "This is asked every tick, for every character.");
        }
    }
}
