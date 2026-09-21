// Copyright (c) STUDIO MeowToon. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

#nullable enable

using System;

namespace Modio.Core {
    ///////////////////////////////////////////////////////////////////////////////////////////////////
    // public Classes

    /// <summary>
    /// Turns a Unity Tag string into a TargetMark, the same true shape a
    /// pickup Rule reads through "$target".
    ///
    /// Not yet built. See TASK-036 in TASKLIST.md.
    /// </summary>
    /// <author>h.adachi (STUDIO MeowToon)</author>
    public readonly struct TargetMark {
        ///////////////////////////////////////////////////////////////////////////////////////////////
        // Constructor

        public TargetMark(string tag) {
            Tag = tag;
        }

        ///////////////////////////////////////////////////////////////////////////////////////////////
        // public Properties [noun, adjective]

        /// <summary>Never null. Read once, at Enact, keyed by Choice.ID.</summary>
        public string Tag { get; }
    }

    ///////////////////////////////////////////////////////////////////////////////////////////////////
    // public Classes

    /// <summary>Turns a raw Tag string, at Enact, into a TargetMark.</summary>
    /// <author>h.adachi (STUDIO MeowToon)</author>
    public static class TagLogic {
        ///////////////////////////////////////////////////////////////////////////////////////////////
        // public static Methods [verb]

        public static TargetMark Mark(string tag) {
            if (tag == "Untagged") { return new TargetMark(tag: ""); }
            return new TargetMark(tag: tag);
        }
    }
}
