// Copyright (c) STUDIO MeowToon. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

#nullable enable

namespace Modio.Core {
    ///////////////////////////////////////////////////////////////////////////////////////////////////
    // public Classes

    /// <summary>
    /// What a deed is looking for.
    ///
    /// Read off a request_deed in germio.json: a kind, how far out to look, how
    /// far round, and which memory mark to leave out.
    ///
    /// See docs/modio_spec.md 3.5 and 7.4.
    /// </summary>
    /// <author>h.adachi (STUDIO MeowToon)</author>
    public readonly struct Seek {
        ///////////////////////////////////////////////////////////////////////////////////////////////
        // Const [nouns]

        /// <summary>How far out to look, where a deed names no reach of its own.</summary>
        public const float REACH_BY_DEFAULT = 30.0f;

        /// <summary>How far round to look, where a deed names no spread of its own.</summary>
        public const float SPREAD_BY_DEFAULT = 360.0f;

        ///////////////////////////////////////////////////////////////////////////////////////////////
        // Constructor

        public Seek(string kind, float reach = REACH_BY_DEFAULT, float spread = SPREAD_BY_DEFAULT,
            string not_in_memory = "") {
            Kind = kind;
            Reach = reach;
            Spread = spread;
            NotInMemory = not_in_memory;
        }

        ///////////////////////////////////////////////////////////////////////////////////////////////
        // public Properties [noun, adjective]

        /// <summary>Which of germio's own type marks to look for.</summary>
        public string Kind { get; }

        /// <summary>How far out to look.</summary>
        public float Reach { get; }

        /// <summary>
        /// How far round to look, in degrees, taken whole: a spread of 90 reaches
        /// 45 either way from straight ahead.
        /// </summary>
        public float Spread { get; }

        /// <summary>
        /// Which memory mark to leave out: met, gave, shown, edge. Empty asks
        /// nothing of memory at all.
        /// </summary>
        public string NotInMemory { get; }
    }
}
