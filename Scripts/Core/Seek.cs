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

        /// <summary>
        /// Set where a deed asks only whether a thing was met at all, and never
        /// how long ago. Below zero, so no true count of seconds can reach it.
        /// </summary>
        public const float NEVER_NEW_AGAIN = -1f;

        ///////////////////////////////////////////////////////////////////////////////////////////////
        // Constructor

        public Seek(string kind, float reach = REACH_BY_DEFAULT, float spread = SPREAD_BY_DEFAULT,
            string not_in_memory = "", string not_given_to = "", string keep_from = "",
            float new_again_after = NEVER_NEW_AGAIN) {
            Kind = kind;
            Reach = reach;
            Spread = spread;
            NotInMemory = not_in_memory;
            NotGivenTo = not_given_to;
            KeepFrom = keep_from;
            NewAgainAfter = new_again_after;
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

        /// <summary>
        /// Which memory mark to leave out, asked of another character rather
        /// than of a thing: gave, shown, tended. Empty asks nothing.
        ///
        /// **A character has no "like it".** One is not of a sort with another,
        /// so this question is always put by name — where a thing may be judged
        /// like another thing (KeepFrom), a character may not.
        /// </summary>
        public string NotGivenTo { get; }

        /// <summary>
        /// Which memory mark to keep away from, in things of a sort with what is
        /// found: met, gave, shown, edge. Empty asks nothing of what is to come.
        ///
        /// **This is the forward-facing question** (4.7): where NotInMemory asks
        /// after that one thing, this asks after every row of a sort with it.
        /// </summary>
        public string KeepFrom { get; }

        /// <summary>
        /// How long must pass before a thing already met counts as new again.
        ///
        /// **The row is never touched**: how long since is weighed each time the
        /// question is put. This is the other way of letting go, beside letting
        /// go by count — a place met once and then never thought of again would
        /// otherwise sit in memory for ever.
        ///
        /// NEVER_NEW_AGAIN asks only whether it happened at all.
        /// </summary>
        public float NewAgainAfter { get; }
    }
}
