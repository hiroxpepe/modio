// Copyright (c) STUDIO MeowToon. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

#nullable enable

using System.Collections.Generic;
using NUnit.Framework;

using Modio.Core;

namespace Modio.Tests.Core {
    ///////////////////////////////////////////////////////////////////////////////////////////////////
    // private Classes

    /// <summary>A stand-in Tag table, keyed by id, for testing with no tie to Unity at all.</summary>
    sealed class FakeEnactTags : IEnactTagLookup {
        readonly Dictionary<string, string> _table = new();

        public void Add(string id, string tag) {
            _table[id] = tag;
        }

        public string TagOf(string id) {
            return _table.TryGetValue(id, out var tag) ? tag : "Untagged";
        }
    }

    ///////////////////////////////////////////////////////////////////////////////////////////////////
    // public Classes

    /// <summary>
    /// Unit tests for building a TargetMark for the thing a Deed truly
    /// holds (modio TASK-022's own new work, split off through TASK-036).
    /// </summary>
    /// <author>h.adachi (STUDIO MeowToon)</author>
    [TestFixture]
    public class TargetMarkLogicTests {

        [Test, Description("A Deed.Holding truly taken reads back the true Tag its own id holds")]
        public void From_ATrulyTakenHolding_ReadsBackTheTrueTag() {
            var holding = Choice.Of(new Found(kind: "Item", id: "g_1", angle: 0f, distance: 1f, height: 0f));
            var lookup = new FakeEnactTags();
            lookup.Add(id: "g_1", tag: "GoldenKey");

            var mark = TargetMarkLogic.From(holding: holding, lookup: lookup);

            Assert.That(mark.Tag, Is.EqualTo("GoldenKey"),
                "update_inventory.key reads this Tag, never the plain id string g_1.");
        }

        [Test, Description("A Deed.Holding holding nothing at all reads back no Tag held")]
        public void From_AHoldingOfNothing_ReadsBackNoTagHeld() {
            var holding = Choice.None();
            var lookup = new FakeEnactTags();

            var mark = TargetMarkLogic.From(holding: holding, lookup: lookup);

            Assert.That(mark.Tag, Is.EqualTo(""));
        }
    }
}
