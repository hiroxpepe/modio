// Copyright (c) STUDIO MeowToon. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

#nullable enable

namespace Modio.Core {
    ///////////////////////////////////////////////////////////////////////////////////////////////////
    // public Classes

    /// <summary>
    /// One thing stage one turned up, told in five fields, before the wedge
    /// check ever runs.
    ///
    /// Bearing is held against the world's own +Z, never against the
    /// character's own heading — so turning the character does not, of
    /// itself, change a Place already read this tick. WedgeCheck turns
    /// Bearing and Self.Heading together into the yaw a wedge asks after.
    ///
    /// See docs/modio_spec.md 3.7.3.
    /// </summary>
    /// <author>h.adachi (STUDIO MeowToon)</author>
    public readonly struct Place {
        ///////////////////////////////////////////////////////////////////////////////////////////////
        // Constructor

        public Place(string kind, string id, float bearing, float distance, float height) {
            Kind = kind;
            ID = id;
            Bearing = bearing;
            Distance = distance;
            Height = height;
        }

        ///////////////////////////////////////////////////////////////////////////////////////////////
        // public Properties [noun, adjective]

        /// <summary>What it is: one of germio's own type marks.</summary>
        public string Kind { get; }

        /// <summary>Which one it is.</summary>
        public string ID { get; }

        /// <summary>Which way it stands, against the world's own +Z. Never against heading.</summary>
        public float Bearing { get; }

        /// <summary>How far off.</summary>
        public float Distance { get; }

        /// <summary>How far up or down, from where the feet are.</summary>
        public float Height { get; }
    }
}
