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
        // public Methods [verb]

        /// <summary>
        /// Writes one row. Where the ring is full, the row longest past goes.
        /// </summary>
        public void Write(float at, string place, string deed, string thing, string other) {
            if (_count < _rows.Length) {
                int put = (_first + _count) % _rows.Length;
                _rows[put] = new Row(at: at, place: place, deed: deed, thing: thing, other: other);
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
            _rows[(_first + _count - 1) % _rows.Length] =
                new Row(at: at, place: place, deed: deed, thing: thing, other: other);
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
