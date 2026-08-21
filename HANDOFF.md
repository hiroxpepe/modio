# HANDOFF

Where things stand right now, for whoever picks this up next.

## State

**Design only. No code at all yet.**

`docs/modio_spec.md` (v0.0.1) holds the first true draft, written
2026-08-20 in a long plan talk with Master. Every part of it was
found by reading real code in `germio`, `animo`, `tropika`, and
`super-nekokun` — not by guessing.

## What is settled

+ Modio is the HOW layer: it turns one Behavior into one Deed.
+ A Deed ends Done, Failed, or Dropped. Only Done writes anything.
+ The memory holds four columns: `when`, `what`, `object`, `with`.
+ `Recall` is one road, two ways: back to memory, ahead to what comes.
+ Modio never picks what to want, never moves a body itself, and
  never writes into `animo`.

## What is not settled

See `TASKLIST.md`, TASK-001 through TASK-004. In short: how fast
memory fades, what stands behind the 30-second limit, the whole set
of forward-facing questions, and a real G review of the spec itself.

## The one rule to hold to

**Nothing goes in on a guess.** `animo` stands on 452 tests, zero
garbage, and five rounds of hard questioning. Modio meets the same
bar, or it does not ship.
