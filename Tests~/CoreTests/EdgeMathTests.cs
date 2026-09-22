// Copyright (c) STUDIO MeowToon. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

#nullable enable

using NUnit.Framework;

using Modio.Core;

namespace Modio.Tests.Core {
    ///////////////////////////////////////////////////////////////////////////////////////////////////
    // public Classes

    /// <summary>
    /// Unit tests for the plain arithmetic behind BroadPhaseEdge (modio
    /// TASK-028's own glue, held apart from Unity itself, the same way
    /// quyno's own oboe_stub holds its C++ logic apart from a real Oboe).
    /// </summary>
    /// <author>h.adachi (STUDIO MeowToon)</author>
    [TestFixture]
    public class EdgeMathTests {

        [Test, Description("Fewer things found than the buffer holds: never reached capacity")]
        public void ReachedCapacity_FewerThanBufferLength_ReadsFalse() {
            Assert.That(EdgeMath.ReachedCapacity(found_count: 3, buffer_length: 16), Is.False);
        }

        [Test, Description("Nothing found at all: never reached capacity")]
        public void ReachedCapacity_NothingFound_ReadsFalse() {
            Assert.That(EdgeMath.ReachedCapacity(found_count: 0, buffer_length: 16), Is.False);
        }

        [Test, Description("Exactly the buffer length found — Unity's own real edge never hands back more than this — reads true: more may have stood there, silently left out")]
        public void ReachedCapacity_ExactlyBufferLength_ReadsTrue() {
            Assert.That(EdgeMath.ReachedCapacity(found_count: 16, buffer_length: 16), Is.True);
        }

        [Test, Description("A found_count past buffer_length (never true from a real edge, a broken contract) still reads true, never throws")]
        public void ReachedCapacity_PastBufferLength_StillReadsTrue() {
            Assert.That(EdgeMath.ReachedCapacity(found_count: 20, buffer_length: 16), Is.True);
        }
    }
}
