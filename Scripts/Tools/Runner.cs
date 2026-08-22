// Copyright (c) STUDIO MeowToon. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

#nullable enable

using System.Collections.Generic;
using Modio.Core;

namespace Modio.Tools {
    ///////////////////////////////////////////////////////////////////////////////////////////////////
    // public Classes

    /// <summary>
    /// Runs a whole deed through a world written out by hand.
    ///
    /// `animo` has a runner of its own, proving same input, same answer. **This
    /// is Modio's own**, of the same shape but leaning on nothing: a list of
    /// what was seen, at what time, fed in tick by tick.
    ///
    /// No Unity, no waiting: half a minute of play runs through in a moment, and
    /// two runs of one world give back the very same answer.
    ///
    /// See docs/modio_spec.md 3.6 and 9.
    /// </summary>
    /// <author>h.adachi (STUDIO MeowToon)</author>
    public sealed class Runner {
        ///////////////////////////////////////////////////////////////////////////////////////////////
        // Const [nouns]

        /// <summary>Given where nothing at all was seen at a tick.</summary>
        public const float NOTHING_SEEN = float.MaxValue;

        ///////////////////////////////////////////////////////////////////////////////////////////////
        // Fields

        readonly IReadOnlyList<Seen> _seen;

        ///////////////////////////////////////////////////////////////////////////////////////////////
        // Constructor

        /// <param name="seen">What stood where, and when. Left as it was.</param>
        public Runner(IReadOnlyList<Seen> seen) {
            _seen = seen;
        }

        ///////////////////////////////////////////////////////////////////////////////////////////////
        // public Methods [verb]

        /// <summary>
        /// Runs the deed through, tick by tick, and writes down every one.
        /// </summary>
        /// <param name="deed">The deed to carry through.</param>
        /// <param name="duration">How long to run, at most.</param>
        /// <param name="delta_time">How long each tick is.</param>
        public Trace Run(Deed deed, float duration, float delta_time) {
            var trace = new Trace();
            deed.Begin(has_target: _seen.Count > 0);

            float at = 0f;
            while (at < duration && deed.End == DeedEnd.Running) {
                at += delta_time;
                float distance = distanceAt(at: at);

                // Turning is taken as done in one tick: how long a body takes to
                // turn is the body's own doing, and belongs to Runtime.
                deed.Tick(delta_time: delta_time, facing: true, distance: distance, acted: true);
                trace.Steps.Add(item: new TraceStep(at: at, step: deed.Step, distance: distance));
            }

            trace.End = deed.End;
            trace.EndedAt = at;
            return trace;
        }

        ///////////////////////////////////////////////////////////////////////////////////////////////
        // private Methods [verb]

        /// <summary>
        /// Gives back how far off the thing stood at this time: the latest sight
        /// of it at or before now. Where nothing was ever seen, it stands beyond
        /// any reach at all.
        /// </summary>
        float distanceAt(float at) {
            float distance = NOTHING_SEEN;
            for (int i = 0; i < _seen.Count; i++) {
                if (_seen[i].At <= at) { distance = _seen[i].Found.Distance; }
            }
            return distance;
        }
    }
}
