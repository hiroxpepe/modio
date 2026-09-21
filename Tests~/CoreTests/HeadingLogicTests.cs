// Copyright (c) STUDIO MeowToon. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

#nullable enable

using NUnit.Framework;

using Modio.Core;

namespace Modio.Tests.Core {
    ///////////////////////////////////////////////////////////////////////////////////////////////////
    // public Classes

    /// <summary>
    /// Unit tests for turning a body's own forward line into Self.Heading
    /// (modio TASK-032, docs/modio_spec.md 3.7.5).
    /// </summary>
    /// <author>h.adachi (STUDIO MeowToon)</author>
    [TestFixture]
    public class HeadingLogicTests {

        const float ERROR = 0.5f;

        [Test, Description("Straight down the world's own +Z reads 0")]
        public void Turn_StraightAheadPlusZ_Reads0() {
            var logic = new HeadingLogic();

            logic.Turn(forward: new Vec3(x: 0f, y: 0f, z: 1f));

            Assert.That(logic.Heading, Is.EqualTo(0f).Within(ERROR));
        }

        [Test, Description("Turned a quarter reads 90")]
        public void Turn_AQuarterTurn_Reads90() {
            var logic = new HeadingLogic();

            logic.Turn(forward: new Vec3(x: 1f, y: 0f, z: 0f));

            Assert.That(logic.Heading, Is.EqualTo(90f).Within(ERROR));
        }

        [Test, Description("Turned by half reads 180")]
        public void Turn_HalfATurn_Reads180() {
            var logic = new HeadingLogic();

            logic.Turn(forward: new Vec3(x: 0f, y: 0f, z: -1f));

            Assert.That(logic.Heading, Is.EqualTo(180f).Within(ERROR));
        }

        [Test, Description("Turned three-quarters reads 270")]
        public void Turn_ThreeQuartersOfATurn_Reads270() {
            var logic = new HeadingLogic();

            logic.Turn(forward: new Vec3(x: -1f, y: 0f, z: 0f));

            Assert.That(logic.Heading, Is.EqualTo(270f).Within(ERROR));
        }

        [Test, Description("A small given Vector3 noise still reads within a small error")]
        public void Turn_ASmallNoise_StillReadsCloseToTrue() {
            var logic = new HeadingLogic();

            // Unit length, off by a hair from straight +Z.
            logic.Turn(forward: new Vec3(x: 0.01f, y: 0f, z: 0.99995f));

            Assert.That(logic.Heading, Is.EqualTo(0f).Within(1.0f));
        }

        [Test, Description("A Forward leaning well up still reads the same flat heading")]
        public void Turn_LeaningWellUp_ReadsTheSameFlatHeading() {
            var flat = new HeadingLogic();
            flat.Turn(forward: new Vec3(x: 1f, y: 0f, z: 0f));

            var leaning = new HeadingLogic();
            // A steep, real slope: as much Y as X/Z combined.
            leaning.Turn(forward: new Vec3(x: 0.7f, y: 0.7f, z: 0f));

            Assert.That(leaning.Heading, Is.EqualTo(flat.Heading).Within(ERROR),
                "The body may lean, but Self.Heading stays level.");
        }

        [Test, Description("Forward given straight up leaves Heading unchanged")]
        public void Turn_GivenStraightUp_LeavesHeadingUnchanged() {
            var logic = new HeadingLogic();
            logic.Turn(forward: new Vec3(x: 1f, y: 0f, z: 0f));
            float before = logic.Heading;

            // Flat X/Z length near zero: dropping Y leaves almost nothing.
            logic.Turn(forward: new Vec3(x: 0f, y: 1f, z: 0f));

            Assert.That(logic.Heading, Is.EqualTo(before),
                "A near-zero flat line holds the last true Heading, rather than turning unstably.");
        }
    }
}
