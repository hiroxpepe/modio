// Copyright (c) STUDIO MeowToon. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

#nullable enable

namespace Modio.Core {
    ///////////////////////////////////////////////////////////////////////////////////////////////////
    // public Interfaces

    /// <summary>
    /// The thin Unity edge (TASK-027): reads this body's own
    /// transform.forward, once a tick, and hands it on. No logic of its
    /// own stands here — the turn from this line into one flat heading is
    /// HeadingLogic's own work (TASK-032, already built and Green).
    /// </summary>
    /// <author>h.adachi (STUDIO MeowToon)</author>
    public interface IHeadingSource {
        ///////////////////////////////////////////////////////////////////////////////////////////////
        // Properties [noun, adjective]

        /// <summary>A unit vector, never Vector3.zero — real for a live Transform.</summary>
        Vector3 Forward { get; }
    }
}
