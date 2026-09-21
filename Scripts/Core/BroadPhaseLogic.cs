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
        /// <param name="places">
        /// A list the caller owns and reuses, tick after tick — filled here,
        /// read straight into WedgeCheck, and made new by no one. **Given a
        /// true `new List&lt;Place&gt;(16)` once, at start — not fresh, empty,
        /// each tick.** A list still at its own starting size of 0 still
        /// makes new, once, the first time anything is ever added to it; only
        /// a list already grown to hold what a tick needs stays truly
        /// GC-free from that tick on.
        /// </param>
        /// <param name="own_id">
        /// The character's own id. Never held back to itself — but an empty
        /// own_id (a caller not yet wired to a real id) is never read as a
        /// match for an unresolved thing's own empty id; empty never counts
        /// as "the same as itself".
        /// </param>
        public static void Gather(Self self, float sight_reach, float sight_half_yaw, float sight_half_pitch,
            Seek seek, string own_id, Vector3 own_position, IReadOnlyList<RawHit> hits, int hit_count,
            INameSource names, List<Place> places, List<Found> into) {
            places.Clear();

            for (int i = 0; i < hit_count; i++) {
                RawHit hit = hits[i];
                (string kind, string id) = names.NameOf(instance_id: hit.ID);

                float away_x = hit.ClosestPoint.X - own_position.X;
                float away_y = hit.ClosestPoint.Y - own_position.Y;
                float away_z = hit.ClosestPoint.Z - own_position.Z;
                float distance = MathF.Sqrt(away_x * away_x + away_z * away_z);
                float bearing = MathF.Atan2(away_x, away_z) * (180f / MathF.PI);
                if (bearing < 0f) { bearing += 360f; }

                places.Add(new Place(kind: kind, id: id, bearing: bearing, distance: distance,
                    height: away_y));
            }

            WedgeCheck.Worth(self: self, sight_reach: sight_reach, sight_half_yaw: sight_half_yaw,
                sight_half_pitch: sight_half_pitch, seek: seek, own_id: own_id, near: places, into: into);
        }
    }
}
