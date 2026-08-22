// Copyright (c) STUDIO MeowToon. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

#nullable enable

using Modio.Core;

namespace Modio.Tools {
    ///////////////////////////////////////////////////////////////////////////////////////////////////
    // public Classes

    /// <summary>
    /// One thing, seen at one time.
    ///
    /// A world written out by hand: what stood where, and when. Fed to the
    /// Runner tick by tick, so a whole round may be run through with no Unity
    /// and no waiting.
    ///
    /// This mirrors animo's own TimedAffectEvent: a happening, with a time on
    /// it. The shape is the same because the need is the same — **same input,
    /// same answer, every run.**
    /// </summary>
    /// <author>h.adachi (STUDIO MeowToon)</author>
    public readonly struct Seen {
        ///////////////////////////////////////////////////////////////////////////////////////////////
        // Constructor

        public Seen(float at, Found found) {
            At = at;
            Found = found;
        }

        ///////////////////////////////////////////////////////////////////////////////////////////////
        // public Properties [noun, adjective]

        /// <summary>When it was seen.</summary>
        public float At { get; }

        /// <summary>What was seen.</summary>
        public Found Found { get; }
    }
}
