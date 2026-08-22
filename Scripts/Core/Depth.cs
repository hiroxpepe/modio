// Copyright (c) STUDIO MeowToon. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

#nullable enable

namespace Modio.Core {
    ///////////////////////////////////////////////////////////////////////////////////////////////////
    // public Classes

    /// <summary>
    /// How deep a meeting sits.
    ///
    /// Master's own word: seeing, touching and holding are three depths of one
    /// meeting, not three separate things. So when a row must go, the least deep
    /// goes before the deepest — as it does in a person.
    ///
    /// This mirrors animo's own five stages: animo holds want in layers, and
    /// Modio holds meeting in layers.
    ///
    /// See docs/modio_spec.md 4.4 and 4.6.
    /// </summary>
    /// <author>h.adachi (STUDIO MeowToon)</author>
    public static class Depth {
        ///////////////////////////////////////////////////////////////////////////////////////////////
        // Const [nouns]

        /// <summary>Seeking found it, and no more than that. Goes first.</summary>
        public const int SEEN = 0;

        /// <summary>The bodies touched. Goes after seeing.</summary>
        public const int MET = 1;

        /// <summary>A whole deed was carried through. Goes last.</summary>
        public const int HELD = 2;

        ///////////////////////////////////////////////////////////////////////////////////////////////
        // public static Methods [verb]

        /// <summary>
        /// Tells how deep a deed sits. A deed nobody set a depth for sits with
        /// seeing, the least deep: it must not outstay one that was set.
        /// </summary>
        public static int Of(string deed) {
            switch (deed) {
                case "met":
                    return MET;

                // Each of these was a whole deed carried through, or a thing worth
                // keeping away from. Forgetting where a fall is costs a character
                // dear, so edge goes last, with the deepest.
                case "held":
                case "gave":
                case "shown":
                case "edge":
                    return HELD;

                default:
                    return SEEN;
            }
        }
    }
}
