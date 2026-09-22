// Copyright (c) STUDIO MeowToon. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

#nullable enable

namespace Modio.Core {
    ///////////////////////////////////////////////////////////////////////////////////////////////////
    // public Interfaces

    /// <summary>
    /// The true shape of germio's own WorldNames, held here so
    /// NameSourceAdapter may be built and tested with no tie to germio at
    /// all.
    ///
    /// A test stand-in implements this directly. The real germio.WorldNames
    /// is wired in later, through this same shape — held open, out of
    /// scope for this split (chosen: TASK-037, the same option B as
    /// EngineMind, TASK-021).
    /// </summary>
    /// <author>h.adachi (STUDIO MeowToon)</author>
    public interface IWorldNamesFacing {
        ///////////////////////////////////////////////////////////////////////////////////////////////
        // private Methods [verb]

        (string Kind, string ID) NameOf(int instance_id);
    }
}
