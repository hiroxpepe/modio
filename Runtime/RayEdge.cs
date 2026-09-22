// Copyright (c) STUDIO MeowToon. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

#nullable enable

#if UNITY_5_3_OR_NEWER
using UnityEngine;

namespace Modio.Runtime {
    /// <summary>
    /// The thin Unity edge (TASK-030): one call, Physics.Raycast. No logic
    /// of its own stands here — reading what came back is RayResultLogic's
    /// own work (TASK-035, already built and Green).
    /// </summary>
    /// <author>h.adachi (STUDIO MeowToon)</author>
    public class RayEdge : MonoBehaviour, Modio.Core.IRaySource {
        ///////////////////////////////////////////////////////////////////////////////////////////////
        // Methods [verb]

        public Modio.Core.RawRay Cast(Modio.Core.Vector3 from, Modio.Core.Vector3 direction, float reach) {
            var unity_from = new Vector3(x: from.X, y: from.Y, z: from.Z);
            var unity_direction = new Vector3(x: direction.X, y: direction.Y, z: direction.Z);

            bool hit_found = Physics.Raycast(unity_from, unity_direction, out RaycastHit hit, reach,
                ~0, QueryTriggerInteraction.Ignore);

            return new Modio.Core.RawRay(
                hit: hit_found,
                id_value: hit_found ? hit.collider.gameObject.GetInstanceID() : 0);
        }
    }
}
#endif
