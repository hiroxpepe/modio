// Copyright (c) STUDIO MeowToon. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

#nullable enable

namespace Modio.Core {
    ///////////////////////////////////////////////////////////////////////////////////////////////////
    // public Enums [noun]

    /// <summary>
    /// Which of the four ways a deed may be done.
    /// </summary>
    /// <author>h.adachi (STUDIO MeowToon)</author>
    public enum UntilKind {
        /// <summary>Done once within so far of the target.</summary>
        Near,

        /// <summary>Done once the bodies touch.</summary>
        Meets,

        /// <summary>Done once so many seconds have gone by.</summary>
        TimeUp,

        /// <summary>Never done of itself: held while a state holds.</summary>
        While
    }

    ///////////////////////////////////////////////////////////////////////////////////////////////////
    // public Classes

    /// <summary>
    /// When a deed is done.
    ///
    /// Exactly one of the four ways holds; the rest are empty. A deed with no
    /// way at all would never end, and one with two would leave no telling
    /// which ended it.
    ///
    /// See docs/modio_spec.md 7.6.
    /// </summary>
    /// <author>h.adachi (STUDIO MeowToon)</author>
    public readonly struct Until {
        ///////////////////////////////////////////////////////////////////////////////////////////////
        // Constructor

        Until(UntilKind kind, float number, string state) {
            Kind = kind;
            Number = number;
            State = state;
        }

        ///////////////////////////////////////////////////////////////////////////////////////////////
        // public Properties [noun, adjective]

        /// <summary>Which of the four ways this is.</summary>
        public UntilKind Kind { get; }

        /// <summary>How far, or how long, where the way asks for a number.</summary>
        public float Number { get; }

        /// <summary>Which state holds it, where the way asks for one.</summary>
        public string State { get; }

        ///////////////////////////////////////////////////////////////////////////////////////////////
        // public static Methods [verb]

        /// <summary>Done once within this far of the target.</summary>
        public static Until Near(float within) {
            return new Until(kind: UntilKind.Near, number: within, state: string.Empty);
        }

        /// <summary>Done once the bodies touch.</summary>
        public static Until Meets() {
            return new Until(kind: UntilKind.Meets, number: 0f, state: string.Empty);
        }

        /// <summary>Done once this many seconds have gone by.</summary>
        public static Until TimeUp(float seconds) {
            return new Until(kind: UntilKind.TimeUp, number: seconds, state: string.Empty);
        }

        /// <summary>Held while the named state holds. Ends Failed, never Done.</summary>
        public static Until While(string state) {
            return new Until(kind: UntilKind.While, number: 0f, state: state);
        }
    }
}
