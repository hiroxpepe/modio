// Copyright (c) STUDIO MeowToon. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

#nullable enable

namespace Modio.Core {
    ///////////////////////////////////////////////////////////////////////////////////////////////////
    // public Classes

    /// <summary>
    /// What Perceive tells of the character itself, rather than of a thing found.
    ///
    /// Two jobs need it: writing down where a thing was (angle and distance are
    /// told from where the character stands, and must be turned into a place in
    /// the world), and saying which way is which, so that south may be told from
    /// north.
    ///
    /// See docs/modio_spec.md 3.3.2.
    /// </summary>
    /// <author>h.adachi (STUDIO MeowToon)</author>
    public readonly struct Self {
        ///////////////////////////////////////////////////////////////////////////////////////////////
        // Constructor

        public Self(float heading) {
            Heading = heading;
        }

        ///////////////////////////////////////////////////////////////////////////////////////////////
        // public Properties [noun, adjective]

        /// <summary>Which way the character faces, against the world.</summary>
        public float Heading { get; }
    }
}
