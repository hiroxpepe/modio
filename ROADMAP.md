# ROADMAP

<!-- format: v1 | fields: status, phase, title -->

+ [~] P-01: Settle the spec, and every real-world limit, first
+ [ ] P-02: Build the Deed core, with a test written first
+ [ ] P-03: Build the memory, and its own fading
+ [ ] P-04: Build Recall, both ways — back, and ahead
+ [ ] P-05: Join Modio to a real Germio game, and check it by real play
+ [~] P-XX: Work that does not fit the phases above

## Detail

### P-01

`docs/modio_spec.md` holds the first true draft. Still owed: real
sums for how fast memory fades, a true measure behind `limit`, and a
full working out of every forward-facing question. See `TASKLIST.md`.

### P-02

Build `Deed`: one Behavior, carried out over time, ending Done,
Failed, or Dropped. Every test written first, the same true way
`animo` was built.

### P-03

Build the memory table (`when`/`what`/`object`/`with`), and its own
fading. Must make no garbage on the hot path — the same bar `animo`
met with a test running `Live()` 100,000 times.

### P-04

Build `Recall`. Facing back reads the memory. Facing ahead reads the
memory's own shape, plus `animo`'s own `rates`. **One road, two
ways** — Tulving's own claim, put to work.

### P-05

Put Modio into `stemic`, driving the two given personas
(`place_curious`, `company_seeking`), and check by real play that
each one truly acts on what it remembers.

### P-XX

Work that does not fit any of the phases above is tracked here
instead. See `TASKLIST.md` for the open work under this phase.
