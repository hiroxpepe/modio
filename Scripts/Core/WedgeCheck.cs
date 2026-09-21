// Copyright (c) STUDIO MeowToon. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

#nullable enable

using System;
using System.Collections.Generic;

namespace Modio.Core {
    ///////////////////////////////////////////////////////////////////////////////////////////////////
    // public Classes

    /// <summary>
    /// Says which of the things stage one turned up truly fall inside the
    /// wedge a character sees.
    ///
    /// See docs/modio_spec.md 3.7.3.
    /// </summary>
    /// <author>h.adachi (STUDIO MeowToon)</author>
    public static class WedgeCheck {
        ///////////////////////////////////////////////////////////////////////////////////////////////
        // public static Methods [verb]

        /// <summary>
        /// Fills the given list with what falls inside the wedge, dropping the
        /// character's own id and a repeated id along the way.
        /// </summary>
        /// <param name="self">Which way the character faces.</param>
        /// <param name="sight_reach">Sight's own reach, before Seek is weighed against it.</param>
        /// <param name="sight_half_yaw">Sight's own halfYaw, before Seek is weighed against it.</param>
        /// <param name="sight_half_pitch">Sight's own halfPitch, before Seek is weighed against it.</param>
        /// <param name="seek">What the deed is looking for.</param>
        /// <param name="own_id">
        /// The character's own id. Never held back to itself — an empty
        /// own_id never counts as a match for an unresolved thing's own
        /// empty id.
        /// </param>
        /// <param name="near">What stage one turned up. Left as it was.</param>
        /// <param name="into">
        /// The list to fill. Emptied first. **Given a true `new
        /// List&lt;Found&gt;(16)` once, at start** — a list still at its own
        /// starting size of 0 still makes new, once, the first time
        /// anything is ever added to it.
        /// </param>
        public static void Worth(Self self, float sight_reach, float sight_half_yaw, float sight_half_pitch,
            Seek seek, string own_id, IReadOnlyList<Place> near, List<Found> into) {
            into.Clear();

            float half_spread = seek.Spread / 2f;
            float reach = MathF.Min(sight_reach, seek.Reach);
            float half_yaw = MathF.Min(sight_half_yaw, half_spread);
            float half_pitch = MathF.Min(sight_half_pitch, half_spread);

            // A wedge with no width, or no height, holds nothing at all — and
            // dividing by either below would give NaN, which a plain ">"
            // check never catches (NaN compares false against everything).
            if (half_yaw <= 0f || half_pitch <= 0f) { return; }

            for (int i = 0; i < near.Count; i++) {
                Place one = near[i];

                if (one.Kind != seek.Kind) { continue; }
                if (!string.IsNullOrEmpty(own_id) && one.ID == own_id) { continue; }
                if (one.Distance > reach) { continue; }
                if (alreadyHolds(into: into, id: one.ID)) { continue; }

                float yaw = wrapToTurn(degrees: one.Bearing - self.Heading);
                float pitch = MathF.Atan2(one.Height, one.Distance) * (180f / MathF.PI);

                float normalized_yaw = yaw / half_yaw;
                float normalized_pitch = pitch / half_pitch;
                // A small, given error, so a point held dead on the bound (an
                // exact 1.0) is never dropped by a hair of floating-point noise.
                if (normalized_yaw * normalized_yaw + normalized_pitch * normalized_pitch > 1f + 0.0001f) {
                    continue;
                }

                into.Add(new Found(kind: one.Kind, id: one.ID, angle: yaw, distance: one.Distance,
                    height: one.Height));
            }
        }

        ///////////////////////////////////////////////////////////////////////////////////////////////
        // private static Methods [verb]

        static bool alreadyHolds(List<Found> into, string id) {
            for (int i = 0; i < into.Count; i++) {
                if (into[i].ID == id) { return true; }
            }
            return false;
        }

        static float wrapToTurn(float degrees) {
            while (degrees > 180f) { degrees -= 360f; }
            while (degrees <= -180f) { degrees += 360f; }
            return degrees;
        }
    }
}
