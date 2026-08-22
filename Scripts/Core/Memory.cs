// Copyright (c) STUDIO MeowToon. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

#nullable enable

namespace Modio.Core {
    ///////////////////////////////////////////////////////////////////////////////////////////////////
    // public Classes

    /// <summary>
    /// The memory one character keeps of what it has done.
    ///
    /// animo holds the state of now, and germio holds the world's own past, one
    /// for the whole game. **This is the only past that belongs to one
    /// character**, and that is what Tulving's own memory of living means: what
    /// I did, when, where.
    ///
    /// Held in a ring of a fixed size, so nothing is made anew once it is full,
    /// and the table cannot grow with no end. Where a new row comes in and the
    /// ring is full, the row longest past goes — and that letting go is what
    /// keeps a want for new places alive, since a place met long ago becomes new
    /// again once its row is gone.
    ///
    /// See docs/modio_spec.md 4.
    /// </summary>
    /// <author>h.adachi (STUDIO MeowToon)</author>
    public sealed class Memory {
        ///////////////////////////////////////////////////////////////////////////////////////////////
        // Const [nouns]

        /// <summary>Given back where a deed was never done at all.</summary>
        public const float NEVER = -1f;

        /// <summary>
        /// How near in reach two things must stand to count as of a sort.
        ///
        /// Taken off stemic's own build: a Ground piece there is 10 by 10, so 3
        /// is under a third of one — near enough that a character would call two
        /// such things "about as far off", and far enough that 12 and 25 are
        /// not, since walking to the second takes twice as long.
        /// </summary>
        public const float SORT_BY_REACH = 3.0f;

        /// <summary>
        /// How near in height two things must sit to count as of a sort.
        ///
        /// A Ground piece in stemic stands 0.5 high, so 1.0 is two of them —
        /// about the most a character may drop and walk on. Below that mark a
        /// fall is a step down; above it, it is a fall.
        /// </summary>
        public const float SORT_BY_HEIGHT = 1.0f;

        ///////////////////////////////////////////////////////////////////////////////////////////////
        // Fields

        readonly Row[] _rows;
        int _first;
        int _count;

        ///////////////////////////////////////////////////////////////////////////////////////////////
        // Constructor

        /// <param name="actor">Whose memory this is: animo's own agent_id.</param>
        /// <param name="holds">How many rows it may hold at once.</param>
        public Memory(string actor, int holds) {
            Actor = actor;
            _rows = new Row[holds];
            _first = 0;
            _count = 0;
        }

        ///////////////////////////////////////////////////////////////////////////////////////////////
        // public Properties [noun, adjective]

        /// <summary>Whose memory this is.</summary>
        public string Actor { get; }

        /// <summary>How many rows it holds right now.</summary>
        public int Count => _count;

        ///////////////////////////////////////////////////////////////////////////////////////////////
        // public static Methods [verb]

        /// <summary>
        /// Tells how many rows a memory should hold, for a world holding so many
        /// things worth meeting.
        ///
        /// **A written-in number breaks.** Counted on `stemic`'s own `Level_1`,
        /// which holds 12 blocks: a memory holding every one leaves nothing new,
        /// and the want for new places dies flat out. A memory holding 4 leaves 8
        /// new, which is well enough — but move to a level of 48 and 4 is next to
        /// nothing. **The right size turns on how many things there are.**
        ///
        /// So: hold half, and leave half new. Half stays new however long a
        /// character walks, so it can neither run out of somewhere to go nor turn
        /// straight back to where it came from.
        ///
        /// Where the count is odd, the odd one is left new: better a place too
        /// many new than too few.
        /// </summary>
        /// <param name="things">How many things in this world are worth meeting.</param>
        public static int RoomFor(int things) {
            int room = things / 2;
            return room < 1 ? 1 : room;
        }

        ///////////////////////////////////////////////////////////////////////////////////////////////
        // public Methods [verb]

        /// <summary>
        /// Writes one row. Where the ring is full, the row longest past goes.
        /// </summary>
        /// <param name="kind">What the thing was. Empty where it was another character.</param>
        /// <param name="reach">How far off it stood.</param>
        /// <param name="height">How far up or down it sat.</param>
        public void Write(float at, string place, string deed, string thing, string other,
            string kind = "", float reach = 0f, float height = 0f) {
            if (_count < _rows.Length) {
                int put = (_first + _count) % _rows.Length;
                _rows[put] = new Row(at: at, place: place, deed: deed, thing: thing,
                    other: other, kind: kind, reach: reach, height: height);
                _count++;
                return;
            }

            // The ring is full, so a row must go: the least deep first, and of
            // two as deep, the one longest past. Rows are held in order, so the
            // first row met at the least depth is also the one longest past at
            // that depth.
            int drop = 0;
            int least_deep = int.MaxValue;
            for (int i = 0; i < _count; i++) {
                int deep = Depth.Of(deed: _rows[(_first + i) % _rows.Length].Deed);
                if (deep < least_deep) {
                    least_deep = deep;
                    drop = i;
                }
            }

            // Close the gap the dropped row leaves, so what is left stays in the
            // order it was written, and the new row goes on the end.
            for (int i = drop; i < _count - 1; i++) {
                _rows[(_first + i) % _rows.Length] = _rows[(_first + i + 1) % _rows.Length];
            }
            _rows[(_first + _count - 1) % _rows.Length] = new Row(at: at, place: place,
                deed: deed, thing: thing, other: other, kind: kind, reach: reach, height: height);
        }

        /// <summary>Gives back one row, counting from the one longest past.</summary>
        public Row At(int index) {
            return _rows[(_first + index) % _rows.Length];
        }

        /// <summary>Tells whether this thing was ever done to.</summary>
        public bool Holds(string deed, string thing) {
            for (int i = 0; i < _count; i++) {
                Row row = _rows[(_first + i) % _rows.Length];
                if (row.Deed == deed && row.Thing == thing) { return true; }
            }
            return false;
        }

        /// <summary>Tells whether this was ever done with that other one.</summary>
        public bool HoldsWith(string deed, string other) {
            for (int i = 0; i < _count; i++) {
                Row row = _rows[(_first + i) % _rows.Length];
                if (row.Deed == deed && row.Other == other) { return true; }
            }
            return false;
        }

        /// <summary>
        /// Tells whether this was ever done to anything of a sort with the one
        /// named — the same kind, standing about as far off, sitting about as
        /// far up or down.
        ///
        /// **This is the same table, faced the other way.** Asking after a thing
        /// says what has been; asking after ones like it says what is likely to
        /// come. A character keeps away from a drop it has never stood on,
        /// because it stood on ones like it. It does not know. It expects.
        ///
        /// See docs/modio_spec.md 4.7.
        /// </summary>
        public bool HoldsLike(string deed, string kind, float reach, float height) {
            for (int i = 0; i < _count; i++) {
                Row row = _rows[(_first + i) % _rows.Length];
                if (row.Deed != deed) { continue; }
                if (row.Kind != kind) { continue; }

                float by_reach = row.Reach - reach;
                if (by_reach < 0f) { by_reach = -by_reach; }
                if (by_reach > SORT_BY_REACH) { continue; }

                float by_height = row.Height - height;
                if (by_height < 0f) { by_height = -by_height; }
                if (by_height > SORT_BY_HEIGHT) { continue; }

                return true;
            }
            return false;
        }

        /// <summary>
        /// Tells how long since this was last done to that thing, or NEVER where
        /// it was never done at all.
        /// </summary>
        public float Since(string deed, string thing, float now) {
            float latest = NEVER;
            for (int i = 0; i < _count; i++) {
                Row row = _rows[(_first + i) % _rows.Length];
                if (row.Deed == deed && row.Thing == thing) { latest = row.At; }
            }
            return latest < 0f ? NEVER : now - latest;
        }
    }
}
