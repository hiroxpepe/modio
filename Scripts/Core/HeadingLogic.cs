// Copyright (c) STUDIO MeowToon. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

#nullable enable

using System;

namespace Modio.Core {
    ///////////////////////////////////////////////////////////////////////////////////////////////////
    // public Classes

    /// <summary>
    /// Turns a body's own forward line into Self.Heading, one flat float.
    ///
    /// Holds its own last true Heading: where the flat X/Z left after
    /// dropping Forward's own Y falls under a small mark, Heading is held
    /// unmoved, rather than turned from a shaking, near-zero line.
    ///
    /// Not yet built. See TASK-032 in TASKLIST.md.
    /// </summary>
    /// <author>h.adachi (STUDIO MeowToon)</author>
    public sealed class HeadingLogic {
        ///////////////////////////////////////////////////////////////////////////////////////////////
        // public Properties [noun, adjective]

        /// <summary>The last true heading this logic turned Forward into.</summary>
        public float Heading { get; private set; }

        ///////////////////////////////////////////////////////////////////////////////////////////////
        // public Methods [verb]

        /// <summary>Reads Forward, and turns Heading toward it.</summary>
        /// <param name="forward">A unit vector, never Vector3.zero.</param>
        public void Turn(Vector3 forward) {
            throw new NotImplementedException();
        }
    }
}
