// Copyright (c) STUDIO MeowToon. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

#nullable enable

using System.Collections.Generic;

namespace Modio.Core {
    ///////////////////////////////////////////////////////////////////////////////////////////////////
    // public Classes

    /// <summary>
    /// What a deed takes, out of everything seeking found.
    /// </summary>
    /// <author>h.adachi (STUDIO MeowToon)</author>
    public readonly struct Choice {
        ///////////////////////////////////////////////////////////////////////////////////////////////
        // Constructor

        Choice(bool taken, string id, float angle, float distance, float height) {
            Taken = taken;
            ID = id;
            Angle = angle;
            Distance = distance;
            Height = height;
        }

        ///////////////////////////////////////////////////////////////////////////////////////////////
        // public Properties [noun, adjective]

        /// <summary>Whether anything at all was taken.</summary>
        public bool Taken { get; }

        /// <summary>Which one was taken.</summary>
        public string ID { get; }

        /// <summary>How far round to turn, to face it.</summary>
        public float Angle { get; }

        /// <summary>How far off it stands.</summary>
        public float Distance { get; }

        /// <summary>How far up or down it sits.</summary>
        public float Height { get; }

        ///////////////////////////////////////////////////////////////////////////////////////////////
        // public static Methods [verb]

        /// <summary>Gives back a choice holding one thing found.</summary>
        public static Choice Of(Found found) {
            return new Choice(taken: true, id: found.ID, angle: found.Angle,
                distance: found.Distance, height: found.Height);
        }

        /// <summary>Gives back a choice holding nothing at all.</summary>
        public static Choice None() {
            return new Choice(taken: false, id: string.Empty, angle: 0f, distance: 0f, height: 0f);
        }
    }

    ///////////////////////////////////////////////////////////////////////////////////////////////////
    // public Classes

    /// <summary>
    /// Weighs what seeking found against what memory holds, and takes one.
    ///
    /// Runtime asks Unity's own Physics and hands back a plain list; this part
    /// judges it, and knows no Unity at all. So a test may write the list by
    /// hand, and the same list always gives back the same choice.
    ///
    /// See docs/modio_spec.md 3.5 and 3.6.
    /// </summary>
    /// <author>h.adachi (STUDIO MeowToon)</author>
    public static class Perceive {
        ///////////////////////////////////////////////////////////////////////////////////////////////
        // public static Methods [verb]

        /// <summary>
        /// Takes the nearest thing that answers to the seek and is not held in
        /// memory. Where nothing answers, nothing is taken, and the deed that
        /// asked will end Failed.
        /// </summary>
        /// <param name="found">What seeking found. Left as it was.</param>
        /// <param name="seek">What the deed is looking for.</param>
        /// <param name="memory">
        /// The ids memory holds under the mark the seek names. Null asks nothing
        /// of memory.
        /// </param>
        public static Choice Choose(IReadOnlyList<Found> found, Seek seek, IReadOnlyList<string>? memory) {
            bool weigh_memory = memory != null && seek.NotInMemory.Length > 0;
            float half_spread = seek.Spread / 2f;

            bool taken = false;
            Found nearest = default;

            for (int i = 0; i < found.Count; i++) {
                Found one = found[i];

                if (one.Kind != seek.Kind) { continue; }
                if (one.Distance > seek.Reach) { continue; }

                float round = one.Angle < 0f ? -one.Angle : one.Angle;
                if (round > half_spread) { continue; }

                if (weigh_memory && holds(memory: memory!, id: one.ID)) { continue; }

                // Nearest first. Where two stand at the very same distance, the
                // one given first wins — so the same list always gives back the
                // same choice, and nothing is picked between at random.
                if (!taken || one.Distance < nearest.Distance) {
                    nearest = one;
                    taken = true;
                }
            }

            return taken ? Choice.Of(found: nearest) : Choice.None();
        }

        ///////////////////////////////////////////////////////////////////////////////////////////////
        // private static Methods [verb]

        static bool holds(IReadOnlyList<string> memory, string id) {
            for (int i = 0; i < memory.Count; i++) {
                if (memory[i] == id) { return true; }
            }
            return false;
        }
    }
}
