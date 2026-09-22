// Copyright (c) STUDIO MeowToon. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

#nullable enable

using System;

namespace Modio.Core {
    ///////////////////////////////////////////////////////////////////////////////////////////////////
    // public Classes

    /// <summary>
    /// A thin, given pass-through: turns Modio's own INameSource ask into a
    /// real IWorldNamesFacing call — the same shape EngineMind already
    /// holds toward IEngineFacing (TASK-021).
    ///
    /// Not yet built. See TASK-037 in TASKLIST.md.
    /// </summary>
    /// <author>h.adachi (STUDIO MeowToon)</author>
    public sealed class NameSourceAdapter : INameSource {
        ///////////////////////////////////////////////////////////////////////////////////////////////
        // Fields

        readonly IWorldNamesFacing _table;

        ///////////////////////////////////////////////////////////////////////////////////////////////
        // Constructor

        public NameSourceAdapter(IWorldNamesFacing table) {
            if (table == null) { throw new ArgumentNullException(nameof(table)); }
            _table = table;
        }

        ///////////////////////////////////////////////////////////////////////////////////////////////
        // public Methods [verb]

        public (string Kind, string ID) NameOf(int instance_id) {
            return _table.NameOf(instance_id: instance_id);
        }
    }
}
