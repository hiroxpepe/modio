# HANDOFF

Where things stand right now, for whoever picks this up next.

## State

State on 2026-11-07, checked against the code.

| # | Part | State |
| --- | --- | --- |
| 1 | Phases | `P-01`, `P-03`, `P-04`, and `P-05` are done; `P-02` (seeking) is in progress for the thin Unity edges alone; `P-06` (the join to `stemic`) is not begun |
| 2 | The code | `Scripts/Modio.csproj` holds the real, working code: `Seek`, `Memory`, `Deed`, `Hand`, `IMind`, `EngineMind`, the source windows, and `NameSourceAdapter` |
| 3 | The tests | 199 in `Tests~/CoreTests` and 106 in `Tests~/ConventionTests`, all pass |
| 4 | The thin edges | `Runtime/` holds `SightEdge`, `HeadingEdge`, `BroadPhaseEdge`, and `RayEdge` (built 2026-09-22); none has been run in a real Unity |
| 5 | Open work | 11 tasks: `TASK-015` (the join to `stemic`), `020`, `022`, `026` to `031` (the Unity edges and their one check by eye), `038`, `039` (`DeedRunner`) |
| 6 | The design | `docs/modio_spec.md` holds the whole design this build follows |

## What is settled

+ Modio is the HOW layer: it turns one Behavior into one Deed.
+ A Deed ends Done, Failed, or Dropped. Only Done writes anything.
+ The memory holds four columns: `when`, `what`, `object`, `with`.
+ `Recall` is one road, two ways: back to memory, ahead to what comes.
+ Modio holds three powers, and may drop none: Perceive (seeking),
  Remember (a past), Enact (a Deed over time).
+ Modio never picks what to want, never moves a body itself, never
  writes into `animo`, and never lets a want quietly fall away.
+ `animo`'s own `Engine` already holds almost every member `IMind` asks for (`Behavior`, `Lock`, `Affect`). `EngineMind` stands, built against the
  stand-in shape `IEngineFacing` (5 tests, `TASK-021`); its true tie to `animo`'s own `Engine` waits on a thin piece, not yet built.
+ No game (`stemic`, `tropika`, `flugi`) holds a real `Need` yet -- `Persona` data lives only in `animo`'s own `examples/` folder today.
  The three long-owed pieces of `TASK-015` (`animo`'s personas, `germio`'s Rule work, Modio's own build) all stand done -- the one real gap left is the
  true tie of `EngineMind` to `animo`'s own `Engine`.

## What is not settled

A fading rate set against the count (a fixed number breaks —
`Level_1` holds 12 blocks, and fading at 120 seconds leaves nothing
new), the whole set of forward-facing questions, a home for a line
said over a head, word to `germio` that its own sensor plan should be
cut back, and a hard-questioning G review.

The true tie of `EngineMind` to `animo`'s own `Engine` (a thin piece, not yet built) is the one block left before `stemic` can be joined and
checked by real play (`TASK-015`). The other is the real Unity check of the thin edges (`TASK-031`, by eye, with the Profiler).

## The one rule to hold to

**Nothing goes in on a guess.** `animo` stands on 605 tests, zero
garbage, and five rounds of hard questioning. Modio meets the same
bar, or it does not ship.
