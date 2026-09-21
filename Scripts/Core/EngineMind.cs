// Copyright (c) STUDIO MeowToon. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

#nullable enable

using System;

namespace Modio.Core {
    ///////////////////////////////////////////////////////////////////////////////////////////////////
    // public Classes

    /// <summary>
    /// A thin, given pass-through: turns Modio's own IMind ask into a real
    /// IEngineFacing call. Behavior/Lock/Affect translation only — no
    /// Need-name checking of its own at all (that whole job stands with
    /// germio's own future V037).
    ///
    /// Not yet built. See TASK-021 in TASKLIST.md.
    /// </summary>
    /// <author>h.adachi (STUDIO MeowToon)</author>
    public sealed class EngineMind : IMind {
        ///////////////////////////////////////////////////////////////////////////////////////////////
        // Constructor

        public EngineMind(IEngineFacing engine) {
            throw new NotImplementedException();
        }

        ///////////////////////////////////////////////////////////////////////////////////////////////
        // Properties [noun, adjective]

        public string Behavior => throw new NotImplementedException();

        ///////////////////////////////////////////////////////////////////////////////////////////////
        // Methods [verb]

        public void Lock(float duration, bool soft) {
            throw new NotImplementedException();
        }

        public void Affect(string need, float delta) {
            throw new NotImplementedException();
        }
    }
}
