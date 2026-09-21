// Copyright (c) STUDIO MeowToon. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

#nullable enable

using System;

namespace Modio.Core {
    ///////////////////////////////////////////////////////////////////////////////////////////////////
    // public Classes

    /// <summary>
    /// Turns a RawRay into whether the thing stage one already held is
    /// still confirmed, at stage two — needs no Unity at all.
    ///
    /// Not yet built. See TASK-035 in TASKLIST.md.
    /// </summary>
    /// <author>h.adachi (STUDIO MeowToon)</author>
    public static class RayResultLogic {
        ///////////////////////////////////////////////////////////////////////////////////////////////
        // public static Methods [verb]

        /// <summary>
        /// True where the ray truly struck the same id stage one already
        /// held. Never reads ray.Id where ray.Hit is false.
        /// </summary>
        public static bool Confirms(RawRay ray, int expected_id) {
            throw new NotImplementedException();
        }
    }
}
