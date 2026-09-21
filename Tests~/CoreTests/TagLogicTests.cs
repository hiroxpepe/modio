// Copyright (c) STUDIO MeowToon. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

#nullable enable

using NUnit.Framework;

using Modio.Core;

namespace Modio.Tests.Core {
    ///////////////////////////////////////////////////////////////////////////////////////////////////
    // public Classes

    /// <summary>
    /// Unit tests for turning a raw Tag string into a TargetMark (modio
    /// TASK-036, split from TASK-022).
    /// </summary>
    /// <author>h.adachi (STUDIO MeowToon)</author>
    [TestFixture]
    public class TagLogicTests {

        [Test, Description("A known Tag reads back as that same string, whole")]
        public void Mark_AKnownTag_ReadsBackWhole() {
            var mark = TagLogic.Mark(tag: "GoldenKey");

            Assert.That(mark.Tag, Is.EqualTo("GoldenKey"));
        }

        [Test, Description("An empty Tag reads as no Tag held at all")]
        public void Mark_AnEmptyTag_ReadsAsNoTagHeld() {
            var mark = TagLogic.Mark(tag: "Untagged");

            Assert.That(mark.Tag, Is.EqualTo(""));
        }

        [Test, Description("Two ids handed the same Tag string both read back that one Tag")]
        public void Mark_TwoGivenIds_BothReadBackTheOneTag() {
            var first = TagLogic.Mark(tag: "GoldenKey");
            var second = TagLogic.Mark(tag: "GoldenKey");

            Assert.That(first.Tag, Is.EqualTo(second.Tag),
                "More than one given key may share one real Tag.");
        }

        [Test, Description("A Tag with the case changed reads as a different Tag")]
        public void Mark_ACaseChangedTag_ReadsAsADifferentTag() {
            var lower = TagLogic.Mark(tag: "goldenkey");
            var proper = TagLogic.Mark(tag: "GoldenKey");

            Assert.That(lower.Tag, Is.Not.EqualTo(proper.Tag), "No folding of case, ever.");
        }
    }
}
