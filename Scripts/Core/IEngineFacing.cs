// Copyright (c) STUDIO MeowToon. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

#nullable enable

namespace Modio.Core {
    ///////////////////////////////////////////////////////////////////////////////////////////////////
    // public Enums [noun]

    /// <summary>
    /// Mirrors Animo.Core.LockMode's own shape, held here so EngineMind need
    /// not depend on animo directly. Once a real cross-repo wiring is
    /// settled (TASK-021's own still-open point), a wrapper over the real
    /// Animo.Core.Engine implements IEngineFacing below, and this enum is
    /// looked at again.
    /// </summary>
    public enum LockMode { Hard, Soft }

    ///////////////////////////////////////////////////////////////////////////////////////////////////
    // public Interfaces

    /// <summary>
    /// The true shape of animo's own Engine, held here so EngineMind may be
    /// built and tested with no tie to animo at all.
    ///
    /// A test stand-in implements this directly. The real animo.Engine is
    /// wired in later, through a thin wrapper not yet built — held open,
    /// out of scope for this split (chosen: TASK-021, option B, 2026-09-20).
    /// </summary>
    /// <author>h.adachi (STUDIO MeowToon)</author>
    public interface IEngineFacing {
        ///////////////////////////////////////////////////////////////////////////////////////////////
        // Properties [noun, adjective]

        string Behavior { get; }

        ///////////////////////////////////////////////////////////////////////////////////////////////
        // private Methods [verb]

        void Lock(float duration, LockMode mode = LockMode.Hard);

        void Affect(string need, float delta, bool force_reset = false);
    }
}
