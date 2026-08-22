// Copyright (c) STUDIO MeowToon. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

#nullable enable

using System.Collections.Generic;
using System.Text;
using Modio.Core;

namespace Modio.Tools {
    ///////////////////////////////////////////////////////////////////////////////////////////////////
    // public Classes

    /// <summary>One tick of a run: what step was running, and when.</summary>
    /// <author>h.adachi (STUDIO MeowToon)</author>
    public readonly struct TraceStep {
        ///////////////////////////////////////////////////////////////////////////////////////////////
        // Constructor

        public TraceStep(float at, DeedStep step, float distance) {
            At = at;
            Step = step;
            Distance = distance;
        }

        ///////////////////////////////////////////////////////////////////////////////////////////////
        // public Properties [noun, adjective]

        /// <summary>When this tick was.</summary>
        public float At { get; }

        /// <summary>Which step of the deed was running.</summary>
        public DeedStep Step { get; }

        /// <summary>How far off the target stood.</summary>
        public float Distance { get; }
    }

    ///////////////////////////////////////////////////////////////////////////////////////////////////
    // public Classes

    /// <summary>
    /// A whole run, written down: every tick, and how it ended.
    ///
    /// Kept so a person may read a run through with their own eyes, and so that
    /// two runs of one world may be set side by side and found the same.
    /// </summary>
    /// <author>h.adachi (STUDIO MeowToon)</author>
    public sealed class Trace {
        ///////////////////////////////////////////////////////////////////////////////////////////////
        // Constructor

        public Trace() {
            Steps = new List<TraceStep>();
            End = DeedEnd.Running;
            EndedAt = 0f;
        }

        ///////////////////////////////////////////////////////////////////////////////////////////////
        // public Properties [noun, adjective]

        /// <summary>Every tick of the run, in order.</summary>
        public List<TraceStep> Steps { get; }

        /// <summary>How the deed ended.</summary>
        public DeedEnd End { get; set; }

        /// <summary>At what time it ended.</summary>
        public float EndedAt { get; set; }

        ///////////////////////////////////////////////////////////////////////////////////////////////
        // public Methods [verb]

        /// <summary>Writes the whole run out as plain lines, one to a tick.</summary>
        public string Write() {
            var built = new StringBuilder();
            built.AppendLine(value: "time,step,distance");
            for (int i = 0; i < Steps.Count; i++) {
                TraceStep step = Steps[i];
                built.AppendLine(value: $"{step.At:F2},{step.Step},{step.Distance:F2}");
            }
            built.AppendLine(value: $"# ended {End} at {EndedAt:F2}");
            return built.ToString();
        }
    }
}
