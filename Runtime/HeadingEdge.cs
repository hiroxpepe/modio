// Copyright (c) STUDIO MeowToon. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

#nullable enable

#if UNITY_5_3_OR_NEWER
using UnityEngine;

namespace Modio.Runtime {
    /// <summary>
    /// The thin Unity edge (TASK-027): reads this body's own
    /// transform.forward, once a tick, and hands it on through
    /// IHeadingSource. No logic of its own stands here — the turn from
    /// this line into one flat heading is HeadingLogic's own work
    /// (TASK-032, already built and Green), never this type's.
    /// </summary>
    /// <author>h.adachi (STUDIO MeowToon)</author>
    public class HeadingEdge : MonoBehaviour, Modio.Core.IHeadingSource {
        ///////////////////////////////////////////////////////////////////////////////////////////////
        // public Properties [noun, adjective]

        public Modio.Core.Vector3 Forward {
            get {
                Vector3 f = transform.forward;
                return new Modio.Core.Vector3(x: f.x, y: f.y, z: f.z);
            }
        }
    }
}
#endif
