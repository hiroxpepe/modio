// Copyright (c) STUDIO MeowToon. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

#nullable enable

namespace Modio.Core {
    ///////////////////////////////////////////////////////////////////////////////////////////////////
    // public Classes

    /// <summary>
    /// One thing a wide, cheap check turned up.
    ///
    /// Less than a Found: no height, since a wide check cannot tell how high a
    /// thing sits — only a straight line can. What comes back from stage one is
    /// weighed here, and only what is worth a line gets one.
    ///
    /// See docs/modio_spec.md 3.7.
    /// </summary>
    /// <author>h.adachi (STUDIO MeowToon)</author>
    public readonly struct Near {
        ///////////////////////////////////////////////////////////////////////////////////////////////
        // Constructor

        public Near(string kind, string id, float angle, float distance) {
            Kind = kind;
            ID = id;
            Angle = angle;
            Distance = distance;
        }

        ///////////////////////////////////////////////////////////////////////////////////////////////
        // public Properties [noun, adjective]

        /// <summary>What it is: one of germio's own type marks.</summary>
        public string Kind { get; }

        /// <summary>Which one it is.</summary>
        public string ID { get; }

        /// <summary>How far round, from straight ahead.</summary>
        public float Angle { get; }

        /// <summary>How far off.</summary>
        public float Distance { get; }
    }
}
