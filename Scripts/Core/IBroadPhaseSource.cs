// Copyright (c) STUDIO MeowToon. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

#nullable enable

namespace Modio.Core {
    ///////////////////////////////////////////////////////////////////////////////////////////////////
    // public Classes

    /// <summary>
    /// One hit stage one's own broad sphere turned up, told in two fields —
    /// never a real Unity Collider past the thin edge (TASK-028) that fills
    /// this.
    /// </summary>
    /// <author>h.adachi (STUDIO MeowToon)</author>
    public readonly struct RawHit {
        ///////////////////////////////////////////////////////////////////////////////////////////////
        // Constructor

        public RawHit(int id_value, Vector3 closest_point) {
            ID = id_value;
            ClosestPoint = closest_point;
        }

        ///////////////////////////////////////////////////////////////////////////////////////////////
        // public Properties [noun, adjective]

        /// <summary>GetInstanceID(), at the real edge. A plain int here.</summary>
        public int ID { get; }

        /// <summary>A world point — Collider.ClosestPoint, at the real edge.</summary>
        public Vector3 ClosestPoint { get; }
    }

    ///////////////////////////////////////////////////////////////////////////////////////////////////
    // public Interfaces

    /// <summary>
    /// The thin Unity edge (TASK-028): one call, Physics.OverlapSphereNonAlloc,
    /// handed back as a plain RawHit array — never a real Collider past it.
    /// </summary>
    /// <author>h.adachi (STUDIO MeowToon)</author>
    public interface IBroadPhaseSource {
        ///////////////////////////////////////////////////////////////////////////////////////////////
        // private Methods [verb]

        /// <summary>
        /// Fills buffer with what the wide sphere, centered on origin, out
        /// to radius, truly holds. Returns the count truly found, always
        /// in [0, buffer.Length]. Indices at or past the count are left
        /// unspecified. No order is promised.
        /// </summary>
        int Find(Vector3 origin, float radius, RawHit[] buffer);
    }
}
