// Copyright (c) STUDIO MeowToon. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

#nullable enable

namespace Modio.Core {
    ///////////////////////////////////////////////////////////////////////////////////////////////////
    // public Classes

    /// <summary>
    /// One ray's own answer, told in two fields. ID is meaningful only when
    /// Hit is true; a real edge always hands back 0 for ID when Hit is
    /// false, and no logic behind this may read ID without checking Hit
    /// first.
    /// </summary>
    /// <author>h.adachi (STUDIO MeowToon)</author>
    public readonly struct RawRay {
        ///////////////////////////////////////////////////////////////////////////////////////////////
        // Constructor

        public RawRay(bool hit, int id_value) {
            Hit = hit;
            ID = id_value;
        }

        ///////////////////////////////////////////////////////////////////////////////////////////////
        // public Properties [noun, adjective]

        public bool Hit { get; }
        public int ID { get; }
    }

    ///////////////////////////////////////////////////////////////////////////////////////////////////
    // public Interfaces

    /// <summary>
    /// The thin Unity edge (TASK-030): one call, Physics.Raycast, handed
    /// back as a plain RawRay.
    /// </summary>
    /// <author>h.adachi (STUDIO MeowToon)</author>
    public interface IRaySource {
        ///////////////////////////////////////////////////////////////////////////////////////////////
        // private Methods [verb]

        /// <summary>
        /// direction: a unit vector, the ray's own line. reach: greater
        /// than 0, the ray's own most far reach, held true up to and
        /// including this distance.
        /// </summary>
        RawRay Cast(Vector3 from, Vector3 direction, float reach);
    }
}
