// Copyright (c) STUDIO MeowToon. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

#nullable enable

using System;

namespace Modio.Core {
    ///////////////////////////////////////////////////////////////////////////////////////////////////
    // public Interfaces

    /// <summary>
    /// Reads a real Tag string, keyed by an id — for the one true moment a
    /// pickup Deed lands (Enact), never from inside Perceive's own loop.
    /// </summary>
    /// <author>h.adachi (STUDIO MeowToon)</author>
    public interface IEnactTagLookup {
        ///////////////////////////////////////////////////////////////////////////////////////////////
        // private Methods [verb]

        string TagOf(string id);
    }

    ///////////////////////////////////////////////////////////////////////////////////////////////////
    // public Classes

    /// <summary>
    /// Builds a TargetMark for the thing a Deed truly holds, read once, at
    /// Enact — needs no Unity at all.
    ///
    /// Not yet built. See TASK-022 in TASKLIST.md.
    /// </summary>
    /// <author>h.adachi (STUDIO MeowToon)</author>
    public static class TargetMarkLogic {
        ///////////////////////////////////////////////////////////////////////////////////////////////
        // public static Methods [verb]

        /// <summary>Builds a TargetMark for holding.ID, through lookup and TagLogic.Mark.</summary>
        public static TargetMark From(Choice holding, IEnactTagLookup lookup) {
            throw new NotImplementedException();
        }
    }
}
