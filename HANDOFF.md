# HANDOFF

Where things stand right now, for whoever picks this up next.

## State

**Built and tested, 2026-09-13. Never "design only" any more — that
line stood here three weeks past the true build date.**

`Scripts/Modio.csproj` holds real, working code: `Seek`, `Memory`,
`Deed`, `Hand`, `IMind`, and the rest. 150 `CoreTests` and 106
`ConventionTests` are green today. A real, live run against `Seek`,
`Deed`, and `Hand` together (not `PlainMind` alone) checked one full
chase pattern end to end, call stack printed whole.

`docs/modio_spec.md` (v0.0.3) still holds the whole real design this
build follows.

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
+ `animo`'s own `Engine` already holds almost every member `IMind`
  asks for (`Behavior`, `Lock`, `Affect`) — a thin bridge class
  (`EngineMind`, TASK-021) is drafted, not yet built, held back by
  two real type gaps (`Lock`'s own soft/hard argument, `Affect`'s
  own third argument).
+ No game (`stemic`, `tropika`, `flugi`) holds a real `Need` yet —
  `Persona` data lives only in `animo`'s own `examples/` folder
  today. TASK-015's own three long-owed pieces (`animo`'s personas,
  `germio`'s Rule work, Modio's own build) all stand done — the one
  real gap left is the bridge itself.

## What is not settled

A fading rate set against the count (a fixed number breaks —
`Level_1` holds 12 blocks, and fading at 120 seconds leaves nothing
new), the whole set of forward-facing questions, a home for a line
said over a head, word to `germio` that its own sensor plan should be
cut back, and a hard-questioning G review.

The bridge (`EngineMind`, TASK-021) is the one true block left
before `stemic` can be joined and checked by real play (TASK-015).

## The one rule to hold to

**Nothing goes in on a guess.** `animo` stands on 605 tests, zero
garbage, and five rounds of hard questioning. Modio meets the same
bar, or it does not ship.
