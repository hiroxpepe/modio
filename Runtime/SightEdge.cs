// Copyright (c) STUDIO MeowToon. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

#nullable enable

#if UNITY_5_3_OR_NEWER
using UnityEngine;
using Germio;

namespace Modio.Runtime {
    /// <summary>
    /// The thin Unity edge (TASK-026): reads germio's own Sight, once at
    /// start, and hands its four plain numbers on through ISightSource.
    /// No logic of its own stands here.
    /// </summary>
    /// <author>h.adachi (STUDIO MeowToon)</author>
    [RequireComponent(typeof(Sight))]
    public class SightEdge : MonoBehaviour, Modio.Core.ISightSource {
        ///////////////////////////////////////////////////////////////////////////////////////////////
        // Fields

        Sight? _sight;

        ///////////////////////////////////////////////////////////////////////////////////////////////
        // public Properties [noun, adjective]

        public float Reach => _sight != null ? _sight.Reach : 0f;

        public float HalfYaw => _sight != null ? _sight.HalfYaw : 0f;

        public float HalfPitch => _sight != null ? _sight.HalfPitch : 0f;

        public float EyeHeight => _sight != null ? _sight.EyeHeight : 0f;

        ///////////////////////////////////////////////////////////////////////////////////////////////
        // Methods [verb]

        void Awake() {
            _sight = GetComponent<Sight>();
        }
    }
}
#endif
