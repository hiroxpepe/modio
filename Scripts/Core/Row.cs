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
    /// Three more are kept beside the four posts — what the thing was, how far
    /// off, how far up or down — and they are not another post. **They are what
    /// lets the same table be faced the other way** (4.7): facing back matches
    /// on the thing itself, and facing forward on what it was like.
    ///
    /// See docs/modio_spec.md 4.1.
    /// </summary>
    /// <author>h.adachi (STUDIO MeowToon)</author>
    public readonly struct Row {
        ///////////////////////////////////////////////////////////////////////////////////////////////
        // Constructor

        public Row(float at, string place, string deed, string thing, string other,
            string kind, float reach, float height) {
            At = at;
            Place = place;
            Deed = deed;
            Thing = thing;
            Other = other;
            Kind = kind;
            Reach = reach;
            Height = height;
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

        /// <summary>
        /// What the thing was, as Perceive handed it back. Empty where the deed
        /// was done to another character, which has no reach or height worth
        /// keeping. Facing forward matches on this and the two below.
        /// </summary>
        public string Kind { get; }

        /// <summary>How far off it stood, when the deed was done.</summary>
        public float Reach { get; }

        /// <summary>How far up or down it sat, when the deed was done.</summary>
        public float Height { get; }
    }
}
