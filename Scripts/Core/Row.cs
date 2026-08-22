// Copyright (c) STUDIO MeowToon. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

#nullable enable

namespace Modio.Core {
    ///////////////////////////////////////////////////////////////////////////////////////////////////
    // public Classes

    /// <summary>
    /// One thing a character remembers doing.
    ///
    /// Tulving set out what a memory of living is made of: who, when, where,
    /// what. Whose it is belongs to the whole table, so a row holds the other
    /// three — and what takes three columns of its own, since a doing has a
    /// shape: what was done, to what, and with which other.
    ///
    /// A row is written only where a deed ends Done.
    ///
    /// See docs/modio_spec.md 4.1.
    /// </summary>
    /// <author>h.adachi (STUDIO MeowToon)</author>
    public readonly struct Row {
        ///////////////////////////////////////////////////////////////////////////////////////////////
        // Constructor

        public Row(float at, string place, string deed, string thing, string other) {
            At = at;
            Place = place;
            Deed = deed;
            Thing = thing;
            Other = other;
        }

        ///////////////////////////////////////////////////////////////////////////////////////////////
        // public Properties [noun, adjective]

        /// <summary>When it happened.</summary>
        public float At { get; }

        /// <summary>The stretch of world it happened in.</summary>
        public string Place { get; }

        /// <summary>What was done: met, held, gave, shown, asked, edge.</summary>
        public string Deed { get; }

        /// <summary>What it was done to. May be empty.</summary>
        public string Thing { get; }

        /// <summary>Who it was done with. May be empty.</summary>
        public string Other { get; }
    }
}
