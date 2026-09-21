// Copyright (c) STUDIO MeowToon. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

#nullable enable

using System;
using NUnit.Framework;

using Modio.Core;

namespace Modio.Tests.Core {
    ///////////////////////////////////////////////////////////////////////////////////////////////////
    // private Classes

    /// <summary>
    /// A stand-in of the true shape of animo's own Engine, for testing
    /// EngineMind with no tie to animo at all.
    /// </summary>
    sealed class FakeEngine : IEngineFacing {
        public string Behavior { get; set; } = "";
        public float LastLockDuration { get; private set; }
        public LockMode LastLockMode { get; private set; }
        public string LastAffectNeed { get; private set; } = "";
        public float LastAffectDelta { get; private set; }
        public bool LastAffectForceReset { get; private set; }

        public void Lock(float duration, LockMode mode = LockMode.Hard) {
            LastLockDuration = duration;
            LastLockMode = mode;
        }

        public void Affect(string need, float delta, bool force_reset = false) {
            LastAffectNeed = need;
            LastAffectDelta = delta;
            LastAffectForceReset = force_reset;
        }
    }

    ///////////////////////////////////////////////////////////////////////////////////////////////////
    // public Classes

    /// <summary>
    /// Unit tests for the thin pass-through between IMind and a real engine
    /// (modio TASK-021, docs/modio_spec.md 9.2-7).
    /// </summary>
    /// <author>h.adachi (STUDIO MeowToon)</author>
    [TestFixture]
    public class EngineMindTests {

        [Test, Description("Behavior reads back whatever the true engine holds, whole")]
        public void Behavior_ReadsBackWhatTheEngineHolds() {
            var engine = new FakeEngine { Behavior = "SearchFood" };
            var mind = new EngineMind(engine: engine);

            Assert.That(mind.Behavior, Is.EqualTo("SearchFood"));
        }

        [Test, Description("Lock(true) calls Engine.Lock(LockMode.Soft)")]
        public void Lock_GivenTrue_CallsEngineLockWithSoft() {
            var engine = new FakeEngine();
            var mind = new EngineMind(engine: engine);

            mind.Lock(duration: 3f, soft: true);

            Assert.That(engine.LastLockMode, Is.EqualTo(LockMode.Soft));
            Assert.That(engine.LastLockDuration, Is.EqualTo(3f));
        }

        [Test, Description("Lock(false) calls Engine.Lock(LockMode.Hard)")]
        public void Lock_GivenFalse_CallsEngineLockWithHard() {
            var engine = new FakeEngine();
            var mind = new EngineMind(engine: engine);

            mind.Lock(duration: 3f, soft: false);

            Assert.That(engine.LastLockMode, Is.EqualTo(LockMode.Hard));
        }

        [Test, Description("Affect, through IMind's own two-argument shape, calls Engine.Affect with force_reset false")]
        public void Affect_GivenTwoArguments_CallsEngineAffectWithForceResetFalse() {
            var engine = new FakeEngine();
            var mind = new EngineMind(engine: engine);

            mind.Affect(need: "hunger", delta: -10f);

            Assert.That(engine.LastAffectNeed, Is.EqualTo("hunger"));
            Assert.That(engine.LastAffectDelta, Is.EqualTo(-10f));
            Assert.That(engine.LastAffectForceReset, Is.False);
        }

        [Test, Description("Building an EngineMind around a null engine throws ArgumentNullException")]
        public void Constructor_GivenNullEngine_ThrowsAtOnce() {
            Assert.Throws<ArgumentNullException>(() => new EngineMind(engine: null!));
        }
    }
}
