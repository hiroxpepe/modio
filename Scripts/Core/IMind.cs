// Copyright (c) STUDIO MeowToon. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

#nullable enable

namespace Modio.Core {
    ///////////////////////////////////////////////////////////////////////////////////////////////////
    // public Interfaces

    /// <summary>
    /// What Modio needs of a mind, and nothing more.
    ///
    /// `animo` is what stands here in a real game, but **Modio does not name
    /// it**. Four things are asked of a mind: what it wants now, a way to hold
    /// that steady, and a way to tell it a want was met. Nothing else.
    ///
    /// Set out this way, a test may stand a plain mind in place of the real
    /// engine and run a whole round with no engine at all — and `modio` stays
    /// free of a build it need not know.
    ///
    /// See docs/modio_spec.md 5.3.
    /// </summary>
    /// <author>h.adachi (STUDIO MeowToon)</author>
    public interface IMind {
        ///////////////////////////////////////////////////////////////////////////////////////////////
        // Properties [noun, adjective]

        /// <summary>What is wanted now, as a plain word.</summary>
        string Behavior { get; }

        ///////////////////////////////////////////////////////////////////////////////////////////////
        // private Methods [verb]

        /// <summary>
        /// Holds what is given back steady, for so long.
        /// </summary>
        /// <param name="duration">How long to hold it.</param>
        /// <param name="soft">
        /// True to let a sudden want break in. Modio always asks for soft: a
        /// deed wants steady, not deaf.
        /// </param>
        void Lock(float duration, bool soft);

        /// <summary>
        /// Tells the mind a want was met, and by how much it moved.
        /// </summary>
        void Affect(string need, float delta);
    }
}
