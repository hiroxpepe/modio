// Copyright (c) STUDIO MeowToon. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

#nullable enable

using System;
using System.Collections.Generic;

namespace Modio.Core {
    ///////////////////////////////////////////////////////////////////////////////////////////////////
    // public Classes

    /// <summary>
    /// Turns what a real IBroadPhaseSource hands back into Places, and
    /// hands each on into the wedge check (WedgeCheck, TASK-024) — needs no
    /// Unity at all, split from the old TASK-025.
    ///
    /// Not yet built. See TASK-034 in TASKLIST.md.
    /// </summary>
    /// <author>h.adachi (STUDIO MeowToon)</author>
    public static class BroadPhaseLogic {
        ///////////////////////////////////////////////////////////////////////////////////////////////
        // public static Methods [verb]

        /// <summary>
        /// Fills into with what falls inside the wedge, once each RawHit is
        /// turned into a Place (bearing/distance/height, against own_position)
        /// and named through names.
        /// </summary>
        /// <param name="own_position">Where the character's own eyes stand.</param>
        /// <param name="hits">What the edge truly found, this tick.</param>
        /// <param name="hit_count">How many of hits are truly filled.</param>
        public static void Gather(Self self, float sight_reach, float sight_half_yaw, float sight_half_pitch,
            Seek seek, string own_id, Vec3 own_position, IReadOnlyList<RawHit> hits, int hit_count,
            INameSource names, List<Found> into) {
            throw new NotImplementedException();
        }
    }
}
