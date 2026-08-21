# HANDOFF

Where things stand right now, for whoever picks this up next.

## State

**Design only. No code at all yet.**

`docs/modio_spec.md` (v0.0.3), 2026-08-21.

v0.0.1 had let a meeting stand in where the sensor was missing.
Master threw that out — it is the very move that left `animo` missing
a whole side of itself. v0.0.2 was written again from nothing.

v0.0.3 moved seeking itself into Modio. Three breaks in the `germio`
sensor plan all came from one cause: seeking had been cut off from
remembering. Every part of it was
found by reading real code in `germio`, `animo`, `tropika`, and
`super-nekokun` — not by guessing.

## What is settled

+ Modio is the HOW layer: it turns one Behavior into one Deed.
+ A Deed ends Done, Failed, or Dropped. Only Done writes anything.
+ The memory holds four columns: `when`, `what`, `object`, `with`.
+ `Recall` is one road, two ways: back to memory, ahead to what comes.
+ Modio holds three powers, and may drop none: Perceive (seeking),
  Remember (a past), Enact (a Deed over time).
+ Modio never picks what to want, never moves a body itself, never
  writes into `animo`, and never lets a want quietly fall away.

## What is not settled

**Nothing blocks work now.** Seeking moved into Modio (v0.0.3), so
no other build must make a thing first.

Open: a fading rate set against the count (a fixed number breaks —
`Level_1` holds 12 blocks, and fading at 120 seconds leaves nothing
new), the whole set of forward-facing questions, a home for a line
said over a head, word to `germio` that its own sensor plan should be
cut back, and a hard-questioning G review.

## The one rule to hold to

**Nothing goes in on a guess.** `animo` stands on 452 tests, zero
garbage, and five rounds of hard questioning. Modio meets the same
bar, or it does not ship.
