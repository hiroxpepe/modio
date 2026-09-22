// Copyright (c) STUDIO MeowToon. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

#nullable enable

#if UNITY_5_3_OR_NEWER
using UnityEngine;

namespace Modio.Runtime {
    /// <summary>
    /// The thin Unity edge (TASK-028): one call, Physics.OverlapSphereNonAlloc,
    /// with triggers dropped outright (settled 2026-09-19, against
    /// stemic's own Level_1: only Despawn, RayBox and MainCamera are
    /// triggers there, and none of them is a thing ever sought). No logic
    /// of its own stands here — the hand-off into the wedge check is
    /// BroadPhaseLogic's own work (TASK-034, already built and Green).
    /// </summary>
    /// <author>h.adachi (STUDIO MeowToon)</author>
    public class BroadPhaseEdge : MonoBehaviour, Modio.Core.IBroadPhaseSource {
        ///////////////////////////////////////////////////////////////////////////////////////////////
        // Fields

        readonly Collider[] _colliders = new Collider[16];

        ///////////////////////////////////////////////////////////////////////////////////////////////
        // Methods [verb]

        public int Find(Modio.Core.Vector3 origin, float radius, Modio.Core.RawHit[] buffer) {
            var unity_origin = new Vector3(x: origin.X, y: origin.Y, z: origin.Z);
            int count = Physics.OverlapSphereNonAlloc(unity_origin, radius, _colliders,
                ~0, QueryTriggerInteraction.Ignore);

            if (Modio.Core.EdgeMath.ReachedCapacity(found_count: count, buffer_length: _colliders.Length)) {
                Debug.LogWarning($"BroadPhaseEdge: the sphere reached its own buffer of {_colliders.Length}; "
                    + "more may have stood there, silently left out. Widen the buffer if this is seen often.");
            }

            int written = 0;
            for (int i = 0; i < count && written < buffer.Length; i++) {
                Collider c = _colliders[i];
                Vector3 closest = c.ClosestPoint(unity_origin);
                buffer[written] = new Modio.Core.RawHit(
                    id_value: c.gameObject.GetInstanceID(),
                    closest_point: new Modio.Core.Vector3(x: closest.x, y: closest.y, z: closest.z));
                written++;
            }
            return written;
        }
    }
}
#endif
