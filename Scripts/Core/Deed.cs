// Copyright (c) STUDIO MeowToon. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

#nullable enable

namespace Modio.Core {
    ///////////////////////////////////////////////////////////////////////////////////////////////////
    // public Enums [noun]

    /// <summary>Which step of a deed is running.</summary>
    /// <author>h.adachi (STUDIO MeowToon)</author>
    public enum DeedStep {
        /// <summary>Turning toward what was found.</summary>
        Face,

        /// <summary>Doing what the motion says. This is the step that is watched.</summary>
        Move,

        /// <summary>Doing what the act says, on its own clock.</summary>
        Act,

        /// <summary>Nothing is running: the deed has ended.</summary>
        Over
    }

    /// <summary>How a deed ended, or that it has not yet.</summary>
    /// <author>h.adachi (STUDIO MeowToon)</author>
    public enum DeedEnd {
        /// <summary>Still going.</summary>
        Running,

        /// <summary>It reached its end. The one gate into memory.</summary>
        Done,

        /// <summary>Nothing was found, what was found left, or the time ran out.</summary>
        Failed,

        /// <summary>It was let go part way: another Behavior came, or the Node changed.</summary>
        Dropped
    }

    ///////////////////////////////////////////////////////////////////////////////////////////////////
    // public Classes

    /// <summary>
    /// One Behavior, carried through over time.
    ///
    /// Up to three steps run, in order: face, move, act. **Only the middle one
    /// is watched** — facing ends when the turn is finished, and an act ends on
    /// its own clock.
    ///
    /// A deed ends one of three ways, and **only Done writes anything at all**:
    /// Failed and Dropped leave `animo` untouched, memory untouched, and the
    /// world untouched.
    ///
    /// Nothing here calls Unity. What the body is doing — whether it faces yet,
    /// how far off the target is, whether the act was carried out — is handed in
    /// each tick, so a whole deed may be run through in a test with no waiting.
    ///
    /// See docs/modio_spec.md 5.
    /// </summary>
    /// <author>h.adachi (STUDIO MeowToon)</author>
    public sealed class Deed {
        ///////////////////////////////////////////////////////////////////////////////////////////////
        // Fields

        readonly Until _until;
        readonly string _act;
        readonly float _lock_for;
        float _run_for;

        ///////////////////////////////////////////////////////////////////////////////////////////////
        // Constructor

        /// <param name="motion">How the body moves, while getting there.</param>
        /// <param name="act">What is done once there. Empty where none is needed.</param>
        /// <param name="until">When the deed is done.</param>
        /// <param name="lock_for">How long it may run before it ends Failed.</param>
        public Deed(string motion, string act, Until until, float lock_for) {
            Motion = motion;
            _act = act;
            _until = until;
            _lock_for = lock_for;
            _run_for = 0f;
            Step = DeedStep.Face;
            End = DeedEnd.Running;
            Holding = Choice.None();
        }

        ///////////////////////////////////////////////////////////////////////////////////////////////
        // public Properties [noun, adjective]

        /// <summary>How the body moves, while getting there.</summary>
        public string Motion { get; }

        /// <summary>
        /// What seeking found, and what this deed is reaching for.
        ///
        /// **A deed that lands writes a row, and a row names what was done to.**
        /// So this is carried from the moment seeking hands it over to the
        /// moment the row goes down — with the kind, the reach and the height
        /// beside it, which are what let the table be faced the other way.
        /// </summary>
        public Choice Holding { get; private set; }

        /// <summary>Which step is running.</summary>
        public DeedStep Step { get; private set; }

        /// <summary>How it ended, or that it has not yet.</summary>
        public DeedEnd End { get; private set; }

        /// <summary>
        /// Whether this deed may be written down. Done is the one gate into
        /// memory: nothing else may write there.
        /// </summary>
        public bool MayWrite => End == DeedEnd.Done;

        ///////////////////////////////////////////////////////////////////////////////////////////////
        // public Methods [verb]

        /// <summary>
        /// Starts the deed, taking hold of what seeking found. A deed holding
        /// something turns to face it first; one holding nothing has nothing to
        /// turn toward, and moves straight away.
        /// </summary>
        /// <param name="taken">What seeking found. None where a deed seeks nothing.</param>
        public void Begin(Choice taken) {
            Holding = taken;
            Step = taken.Taken ? DeedStep.Face : DeedStep.Move;
        }

        /// <summary>
        /// Carries the deed on by one tick.
        /// </summary>
        /// <param name="delta_time">How long since the last tick.</param>
        /// <param name="facing">Whether the body now faces the target.</param>
        /// <param name="distance">How far off the target stands.</param>
        /// <param name="acted">Whether the act has been carried out.</param>
        public void Tick(float delta_time, bool facing, float distance, bool acted) {
            if (End != DeedEnd.Running) { return; }

            _run_for += delta_time;
            if (_run_for >= _lock_for) {
                End = DeedEnd.Failed;
                Step = DeedStep.Over;
                return;
            }

            switch (Step) {
                case DeedStep.Face:
                    if (facing) { Step = DeedStep.Move; }
                    return;

                case DeedStep.Move:
                    if (!watchedStepIsOver(distance: distance)) { return; }
                    if (_act.Length > 0) { Step = DeedStep.Act; return; }
                    finish();
                    return;

                case DeedStep.Act:
                    if (acted) { finish(); }
                    return;

                default:
                    return;
            }
        }

        /// <summary>
        /// Tells the deed what it was reaching for is gone: taken by another, or
        /// out of the world. The deed ends Failed.
        /// </summary>
        public void Lost() {
            if (End != DeedEnd.Running) { return; }
            End = DeedEnd.Failed;
            Step = DeedStep.Over;
        }

        /// <summary>
        /// Lets the deed go part way: another Behavior came, or the Node changed.
        /// Nothing is written.
        /// </summary>
        public void Drop() {
            if (End != DeedEnd.Running) { return; }
            End = DeedEnd.Dropped;
            Step = DeedStep.Over;
        }

        ///////////////////////////////////////////////////////////////////////////////////////////////
        // private Methods [verb]

        /// <summary>Tells whether the watched step has reached its end.</summary>
        bool watchedStepIsOver(float distance) {
            switch (_until.Kind) {
                case UntilKind.Near:
                    return distance <= _until.Number;

                case UntilKind.Meets:
                    // Meeting is told by two bodies touching, which the world says,
                    // and it comes in as a distance of nothing.
                    return distance <= 0f;

                case UntilKind.TimeUp:
                    return _run_for >= _until.Number;

                default:
                    // While: never done of itself. It runs until its lock gives
                    // out, and so ends Failed, never Done.
                    return false;
            }
        }

        /// <summary>Brings the deed to its end, Done.</summary>
        void finish() {
            End = DeedEnd.Done;
            Step = DeedStep.Over;
        }
    }
}
