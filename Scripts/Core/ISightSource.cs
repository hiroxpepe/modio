// Copyright (c) STUDIO MeowToon. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

#nullable enable

namespace Modio.Core {
    ///////////////////////////////////////////////////////////////////////////////////////////////////
    // public Interfaces

    /// <summary>
    /// The thin Unity edge (TASK-026): reads germio's own Sight, once at
    /// start, and hands its four plain numbers on. No logic of its own
    /// stands here.
    /// </summary>
    /// <author>h.adachi (STUDIO MeowToon)</author>
    public interface ISightSource {
        ///////////////////////////////////////////////////////////////////////////////////////////////
        // private Properties [noun, adjective]

        float Reach { get; }
        float HalfYaw { get; }
        float HalfPitch { get; }
        float EyeHeight { get; }
    }
}
