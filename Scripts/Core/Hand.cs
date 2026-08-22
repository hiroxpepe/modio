// Copyright (c) STUDIO MeowToon. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

#nullable enable

namespace Modio.Core {
    ///////////////////////////////////////////////////////////////////////////////////////////////////
    // public Classes

    /// <summary>
    /// Modio's own hold on a mind, while a deed plays out.
    ///
    /// Starting a deed holds the mind softly, so that what it wants stays steady
    /// while the deed runs — and a sudden want may still break in and drop it.
    /// Where the deed lands, what it met is handed back.
    ///
    /// This is the only place Modio speaks to a mind at all.
    ///
    /// See docs/modio_spec.md 5.3.
    /// </summary>
    /// <author>h.adachi (STUDIO MeowToon)</author>
    public sealed class Hand {
        ///////////////////////////////////////////////////////////////////////////////////////////////
        // Fields

        readonly IMind _mind;

        ///////////////////////////////////////////////////////////////////////////////////////////////
        // Constructor

        public Hand(IMind mind) {
            _mind = mind;
            Holding = string.Empty;
        }

        ///////////////////////////////////////////////////////////////////////////////////////////////
        // public Properties [noun, adjective]

        /// <summary>What the mind said when the deed began.</summary>
        public string Holding { get; private set; }

        ///////////////////////////////////////////////////////////////////////////////////////////////
        // public Methods [verb]

        /// <summary>
        /// Takes hold: keeps what the mind wants now, and asks it to hold that
        /// steady while the deed runs.
        /// </summary>
        /// <param name="hold_for">How long the deed may run.</param>
        public void Begin(float hold_for) {
            Holding = _mind.Behavior;
            _mind.Lock(duration: hold_for, soft: true);
        }

        /// <summary>
        /// Tells whether the mind now wants something other than what the deed
        /// was begun for. Where it does, the deed is Dropped.
        /// </summary>
        public bool HasMovedOn() {
            return _mind.Behavior != Holding;
        }

        /// <summary>
        /// Hands back what a deed met. Called only where a deed ends Done: a
        /// deed that failed leaves the want where it was, so the mind asks for
        /// the same thing again next tick.
        /// </summary>
        public void Landed(string need, float delta) {
            _mind.Affect(need: need, delta: delta);
        }
    }
}
