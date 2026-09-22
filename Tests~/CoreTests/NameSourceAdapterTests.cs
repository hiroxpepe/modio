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
    /// A stand-in of the true shape of germio's own WorldNames, for
    /// testing NameSourceAdapter with no tie to germio at all.
    /// </summary>
    sealed class FakeWorldNames : IWorldNamesFacing {
        public (string Kind, string ID) NameOf(int instance_id) {
            return instance_id == 1 ? ("Ground", "g_1") : ("", "");
        }
    }

    ///////////////////////////////////////////////////////////////////////////////////////////////////
    // public Classes

    /// <summary>
    /// Unit tests for the thin pass-through between INameSource and a real
    /// germio world table (modio TASK-037, docs/modio_spec.md 9.2-7's own
    /// second true hole, found and closed the same way as TASK-021).
    /// </summary>
    /// <author>h.adachi (STUDIO MeowToon)</author>
    [TestFixture]
    public class NameSourceAdapterTests {

        [Test, Description("NameOf reads back exactly what the given table itself answers, whole")]
        public void NameOf_ReadsBackWhatTheTableAnswers() {
            var table = new FakeWorldNames();
            var adapter = new NameSourceAdapter(table: table);

            Assert.That(adapter.NameOf(instance_id: 1), Is.EqualTo(("Ground", "g_1")));
            Assert.That(adapter.NameOf(instance_id: 99), Is.EqualTo(("", "")));
        }

        [Test, Description("Building a NameSourceAdapter around a null table throws ArgumentNullException")]
        public void Constructor_GivenNullTable_ThrowsAtOnce() {
            Assert.Throws<ArgumentNullException>(() => new NameSourceAdapter(table: null!));
        }
    }
}
