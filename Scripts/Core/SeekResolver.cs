// Copyright (c) STUDIO MeowToon. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

#nullable enable

using System.Collections.Generic;

namespace Modio.Core {
    ///////////////////////////////////////////////////////////////////////////////////////////////////
    // public Classes

    /// <summary>
    /// Picks out of a list of Found, with no Unity at all (modio TASK-038).
    /// </summary>
    /// <author>h.adachi (STUDIO MeowToon)</author>
    public static class SeekResolver {
        ///////////////////////////////////////////////////////////////////////////////////////////////
        // public static Methods [verb]

        /// <summary>
        /// The one Found whose Distance is the smallest, or null where the list
        /// holds nothing at all. Two at the same Distance: either one.
        /// </summary>
        public static Found? Nearest(IReadOnlyList<Found> found) {
            if (found.Count == 0) {
                return null;
            }
            int nearest = 0;
            for (int i = 1; i < found.Count; i++) {
                if (found[i].Distance < found[nearest].Distance) {
                    nearest = i;
                }
            }
            return found[nearest];
        }
    }
}
