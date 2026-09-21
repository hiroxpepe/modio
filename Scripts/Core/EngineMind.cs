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
        // Fields

        readonly IEngineFacing _engine;

        ///////////////////////////////////////////////////////////////////////////////////////////////
        // Constructor

        public EngineMind(IEngineFacing engine) {
            if (engine == null) { throw new ArgumentNullException(nameof(engine)); }
            _engine = engine;
        }

        ///////////////////////////////////////////////////////////////////////////////////////////////
        // public Properties [noun, adjective]

        public string Behavior => _engine.Behavior;

        ///////////////////////////////////////////////////////////////////////////////////////////////
        // public Methods [verb]

        public void Lock(float duration, bool soft) {
            _engine.Lock(duration: duration, mode: soft ? LockMode.Soft : LockMode.Hard);
        }

        public void Affect(string need, float delta) {
            _engine.Affect(need: need, delta: delta, force_reset: false);
        }
    }
}
