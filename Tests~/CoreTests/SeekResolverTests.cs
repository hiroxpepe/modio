// Copyright (c) STUDIO MeowToon. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

#nullable enable

using System;
using System.Collections.Generic;
using NUnit.Framework;

using Modio.Core;

namespace Modio.Tests.Core {
    ///////////////////////////////////////////////////////////////////////////////////////////////////
    // public Classes

    /// <summary>
    /// Unit tests for SeekResolver.Nearest (modio TASK-038). No Unity needed.
    /// </summary>
    /// <author>h.adachi (STUDIO MeowToon)</author>
    [TestFixture]
    public class SeekResolverTests {
        ///////////////////////////////////////////////////////////////////////////////////////////////
        // private static Methods [verb]

        static Found found_at(string id, float distance) {
            return new Found(kind: "item", id: id, angle: 0f, distance: distance, height: 0f);
        }

        ///////////////////////////////////////////////////////////////////////////////////////////////
        // public Methods [verb]

        [Test, Description("Three Found at 8, 3 and 12 read back the one at 3, whole")]
        public void Nearest_ThreeFound_ReadsBackTheOneAtTheSmallestDistance() {
            var list = new List<Found> { found_at(id: "a", distance: 8f), found_at(id: "b", distance: 3f), found_at(id: "c", distance: 12f) };

            var nearest = SeekResolver.Nearest(found: list);

            Assert.That(nearest, Is.Not.Null);
            Assert.That(nearest!.Value.ID, Is.EqualTo("b"));
            Assert.That(nearest.Value.Distance, Is.EqualTo(3f));
        }

        [Test, Description("One Found alone reads back as that one, whichever its own distance")]
        public void Nearest_OneFoundAlone_ReadsThatOneBack() {
            var list = new List<Found> { found_at(id: "far", distance: 999f) };

            var nearest = SeekResolver.Nearest(found: list);

            Assert.That(nearest, Is.Not.Null);
            Assert.That(nearest!.Value.ID, Is.EqualTo("far"));
        }

        [Test, Description("An empty list reads null, and never throws")]
        public void Nearest_AnEmptyList_ReadsNullAndNeverThrows() {
            var list = new List<Found>();

            Found? nearest = null;
            Assert.DoesNotThrow(() => nearest = SeekResolver.Nearest(found: list));

            Assert.That(nearest, Is.Null);
        }

        [Test, Description("Two Found at the exact same distance read back one of the two, never null, never thrown")]
        public void Nearest_TwoAtTheSameDistance_ReadsBackOneOfTheTwo() {
            var list = new List<Found> { found_at(id: "x", distance: 5f), found_at(id: "y", distance: 5f) };

            Found? nearest = null;
            Assert.DoesNotThrow(() => nearest = SeekResolver.Nearest(found: list));

            Assert.That(nearest, Is.Not.Null);
            Assert.That(nearest!.Value.ID, Is.AnyOf("x", "y"));
        }

        [Test, Description("Reading a fixed list of 16 for the smallest makes no garbage at all")]
        public void Nearest_AFixedListOfSixteen_AllocatesNothing() {
            var list = new List<Found>();
            for (int i = 0; i < 16; i++) {
                list.Add(found_at(id: "f" + i, distance: 16f - i));
            }
            SeekResolver.Nearest(found: list);   // warm up: the first call may load the type

            long before = GC.GetAllocatedBytesForCurrentThread();
            for (int i = 0; i < 64; i++) {
                SeekResolver.Nearest(found: list);
            }
            long after = GC.GetAllocatedBytesForCurrentThread();

            Assert.That(after - before, Is.EqualTo(0L));
        }
    }
}
