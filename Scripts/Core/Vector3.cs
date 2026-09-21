// Copyright (c) STUDIO MeowToon. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

#nullable enable

namespace Modio.Core {
    ///////////////////////////////////////////////////////////////////////////////////////////////////
    // public Classes

    /// <summary>
    /// A plain three-float place or line, holding no Unity type at all.
    ///
    /// Every logic piece behind a thin Unity edge (TASK-032, 034, 035) reads
    /// this, never UnityEngine.Vector3 — so each stays open to a plain
    /// dotnet test, with no Unity behind it. The edge itself turns a real
    /// Vector3 into this, and back, at the one line where Unity is touched.
    /// </summary>
    /// <author>h.adachi (STUDIO MeowToon)</author>
    public readonly struct Vector3 {
        ///////////////////////////////////////////////////////////////////////////////////////////////
        // Constructor

        public Vector3(float x, float y, float z) {
            X = x;
            Y = y;
            Z = z;
        }

        ///////////////////////////////////////////////////////////////////////////////////////////////
        // public Properties [noun, adjective]

        public float X { get; }
        public float Y { get; }
        public float Z { get; }
    }
}
