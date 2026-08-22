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
        /// What this character remembers. Null asks nothing of memory at all.
        /// </param>
        public static Choice Choose(IReadOnlyList<Found> found, Seek seek, Memory? memory) {
            bool facing_back = memory != null && seek.NotInMemory.Length > 0;
            bool by_name = memory != null && seek.NotGivenTo.Length > 0;
            bool facing_forward = memory != null && seek.KeepFrom.Length > 0;
            float half_spread = seek.Spread / 2f;

            bool taken = false;
            Found nearest = default;

            for (int i = 0; i < found.Count; i++) {
                Found one = found[i];

                if (one.Kind != seek.Kind) { continue; }
                if (one.Distance > seek.Reach) { continue; }

                float round = one.Angle < 0f ? -one.Angle : one.Angle;
                if (round > half_spread) { continue; }

                // Facing back: have I already had to do with that very one?
                if (facing_back && memory!.Holds(deed: seek.NotInMemory, thing: one.ID)) { continue; }

                // Asked of another character, and always by name: one is not of
                // a sort with another, so there is no "like it" to ask after.
                if (by_name && memory!.HoldsWith(deed: seek.NotGivenTo, other: one.ID)) { continue; }

                // Facing forward: how did it go with ones like it? The same
                // table, read the other way.
                if (facing_forward && memory!.HoldsLike(deed: seek.KeepFrom, kind: one.Kind,
                    reach: one.Distance, height: one.Height)) { continue; }

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

    }
}
