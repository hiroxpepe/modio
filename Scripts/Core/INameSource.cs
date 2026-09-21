// Copyright (c) STUDIO MeowToon. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

#nullable enable

namespace Modio.Core {
    ///////////////////////////////////////////////////////////////////////////////////////////////////
    // public Interfaces

    /// <summary>
    /// Modio asks germio's own world table for a kind and an id string, by
    /// a plain int id (GetInstanceID(), no boxing).
    ///
    /// An id the table has never held answers with an empty Kind and an
    /// empty ID — never null, never thrown. The same standing shape
    /// Choice.None() already holds for "nothing found".
    ///
    /// Not yet built. See TASK-029 in TASKLIST.md.
    /// </summary>
    /// <author>h.adachi (STUDIO MeowToon)</author>
    public interface INameSource {
        ///////////////////////////////////////////////////////////////////////////////////////////////
        // public Methods [verb]

        (string Kind, string ID) NameOf(int instance_id);
    }
}
