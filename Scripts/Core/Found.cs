// Copyright (c) STUDIO MeowToon. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

#nullable enable

namespace Modio.Core {
    ///////////////////////////////////////////////////////////////////////////////////////////////////
    // public Classes

    /// <summary>
    /// One thing seeking found, told in five fields and no more.
    ///
    /// Runtime asks Unity's own Physics and turns each hit into one of these.
    /// Nothing here is a Vector3, a Transform or a GameObject: what judges this
    /// list must be open to a check with no Unity at all.
    ///
    /// See docs/modio_spec.md 3.3.
    /// </summary>
    /// <author>h.adachi (STUDIO MeowToon)</author>
    public readonly struct Found {
        ///////////////////////////////////////////////////////////////////////////////////////////////
        // Constructor

        public Found(string kind, string id, float angle, float distance, float height) {
            Kind = kind;
            ID = id;
            Angle = angle;
            Distance = distance;
            Height = height;
        }

        ///////////////////////////////////////////////////////////////////////////////////////////////
        // public Properties [noun, adjective]

        /// <summary>What it is: one of germio's own type marks.</summary>
        public string Kind { get; }

        /// <summary>Which one it is. Memory names the same thing twice by this.</summary>
        public string ID { get; }

        /// <summary>How far round, from straight ahead. Below zero is the other way.</summary>
        public float Angle { get; }

        /// <summary>How far off.</summary>
        public float Distance { get; }

        /// <summary>How far up or down, from where the feet are.</summary>
        public float Height { get; }
    }
}
