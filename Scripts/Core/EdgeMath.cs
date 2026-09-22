// Copyright (c) STUDIO MeowToon. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

#nullable enable

using System;

namespace Modio.Core {
    ///////////////////////////////////////////////////////////////////////////////////////////////////
    // public Classes

    /// <summary>
    /// The plain arithmetic behind a thin Unity edge — held apart from
    /// Unity itself outright, so it may be checked by a plain dotnet
    /// test, matching quyno's own oboe_stub (its C++ native layer, held
    /// apart from a real Oboe the same way).
    ///
    /// Not yet built. See TASK-028 in TASKLIST.md.
    /// </summary>
    /// <author>h.adachi (STUDIO MeowToon)</author>
    public static class EdgeMath {
        ///////////////////////////////////////////////////////////////////////////////////////////////
        // public static Methods [verb]

        /// <summary>
        /// True where a real edge's own found_count reached (or, in a
        /// contract broken elsewhere, passed) buffer_length — the one true
        /// signal a real Unity call (Physics.OverlapSphereNonAlloc never
        /// hands back more than the buffer it was given) can offer that
        /// more may have stood there, silently left out.
        /// </summary>
        public static bool ReachedCapacity(int found_count, int buffer_length) {
            return found_count >= buffer_length;
        }
    }
}
