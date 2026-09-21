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
    /// Not yet built. See TASK-024 in TASKLIST.md.
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
        /// <param name="own_id">The character's own id. Never held back to itself.</param>
        /// <param name="near">What stage one turned up. Left as it was.</param>
        /// <param name="into">The list to fill. Emptied first.</param>
        public static void Worth(Self self, float sight_reach, float sight_half_yaw, float sight_half_pitch,
            Seek seek, string own_id, IReadOnlyList<Place> near, List<Found> into) {
            throw new NotImplementedException();
        }
    }
}
