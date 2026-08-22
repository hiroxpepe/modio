// Copyright (c) STUDIO MeowToon. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

#nullable enable

using System.Collections.Generic;

namespace Modio.Core {
    ///////////////////////////////////////////////////////////////////////////////////////////////////
    // public Classes

    /// <summary>
    /// Decides which of the things a wide check turned up are worth a straight
    /// line.
    ///
    /// Seeking runs in two stages: a wide cheap check every tick, and a line
    /// thrown only where the cheap one finds something. **Throwing a line is what
    /// costs.** With 64 characters running, throwing one at everything every tick
    /// would cost for nothing.
    ///
    /// This judgement knows no Unity at all, so it is cheap, and may be checked
    /// with a list written by hand. See docs/modio_spec.md 3.7.
    /// </summary>
    /// <author>h.adachi (STUDIO MeowToon)</author>
    public static class StageGate {
        ///////////////////////////////////////////////////////////////////////////////////////////////
        // public static Methods [verb]

        /// <summary>
        /// Fills the given list with what is worth a straight line, nearest first.
        ///
        /// The list is emptied before it is filled: Runtime holds one list and
        /// fills it again each tick, so what was there before must go.
        /// </summary>
        /// <param name="near">What the wide check turned up. Left as it was.</param>
        /// <param name="seek">What the deed is looking for.</param>
        /// <param name="into">The list to fill. Emptied first.</param>
        public static void Worth(IReadOnlyList<Near> near, Seek seek, List<Near> into) {
            into.Clear();

            float half_spread = seek.Spread / 2f;

            for (int i = 0; i < near.Count; i++) {
                Near one = near[i];

                if (one.Kind != seek.Kind) { continue; }
                if (one.Distance > seek.Reach) { continue; }

                float round = one.Angle < 0f ? -one.Angle : one.Angle;
                if (round > half_spread) { continue; }

                // Nearest first, and steady: where two stand at the very same
                // distance, the one that came in first stays first. So the same
                // list always gives back the same order.
                int at = into.Count;
                while (at > 0 && into[at - 1].Distance > one.Distance) { at--; }
                into.Insert(index: at, item: one);
            }
        }
    }
}
