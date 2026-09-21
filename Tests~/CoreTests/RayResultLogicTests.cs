// Copyright (c) STUDIO MeowToon. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

#nullable enable

using NUnit.Framework;

using Modio.Core;

namespace Modio.Tests.Core {
    ///////////////////////////////////////////////////////////////////////////////////////////////////
    // public Classes

    /// <summary>
    /// Unit tests for turning a RawRay into whether stage two truly
    /// confirms what stage one held (modio TASK-035, split from TASK-025).
    /// </summary>
    /// <author>h.adachi (STUDIO MeowToon)</author>
    [TestFixture]
    public class RayResultLogicTests {

        [Test, Description("Hit == false reads as nothing found, whole")]
        public void Confirms_HitFalse_ReadsAsNothingFound() {
            var ray = new RawRay(hit: false, id: 0);

            bool confirmed = RayResultLogic.Confirms(ray: ray, expected_id: 1);

            Assert.That(confirmed, Is.False);
        }

        [Test, Description("Hit == true, Id matching what stage one held, reads as that same thing found")]
        public void Confirms_HitTrueMatchingId_ReadsAsFound() {
            var ray = new RawRay(hit: true, id: 1);

            bool confirmed = RayResultLogic.Confirms(ray: ray, expected_id: 1);

            Assert.That(confirmed, Is.True);
        }

        [Test, Description("Hit == true, Id matching neither the sought thing nor the wall, is dropped")]
        public void Confirms_HitTrueWrongId_IsDropped() {
            var ray = new RawRay(hit: true, id: 99);

            bool confirmed = RayResultLogic.Confirms(ray: ray, expected_id: 1);

            Assert.That(confirmed, Is.False, "A thing not asked after is dropped, not held as a false true.");
        }

        [Test, Description("Hit == false, with Id handed in as a real given value, still reads as nothing found")]
        public void Confirms_HitFalseWithGarbageId_StillReadsAsNothingFound() {
            // As if the edge broke its own contract and handed back a non-zero
            // Id anyway. The logic must check Hit first, and never read Id on
            // its own.
            var ray = new RawRay(hit: false, id: 1);

            bool confirmed = RayResultLogic.Confirms(ray: ray, expected_id: 1);

            Assert.That(confirmed, Is.False);
        }
    }
}
