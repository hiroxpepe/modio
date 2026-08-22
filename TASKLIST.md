# TASKLIST

Work items still open for this repository. Any person may put in a new
item; the person who does the work marks it done (`+ [x]`) and puts the
change in as a commit.

<!-- format: v1 | fields: status, id, title, phase -->

+ [x] TASK-001 [P-01]: Wait on germio TASK-015 to TASK-018, then fold the older plan in
+ [x] TASK-002 [P-01]: Set a fading rate against the count, not a fixed number
+ [x] TASK-003 [P-01]: Work out the whole set of forward-facing questions
+ [x] TASK-004 [P-01]: Find a home in germio for a line said over a head
+ [x] TASK-005 [P-01]: Put the spec through a hard-questioning G review
+ [x] TASK-006 [P-02]: Build seeking, by type and reach, against memory
+ [x] TASK-007 [P-03]: Build the memory table, and the three depths of meeting
+ [x] TASK-008 [P-03]: Build fading, to the rate TASK-002 settles
+ [x] TASK-009 [P-03]: Prove no garbage is made on the hot path
+ [x] TASK-010 [P-04]: Build the Deed, ending Done, Failed, or Dropped
+ [x] TASK-011 [P-04]: Hold a Deed together with animo Lock, in Soft mode
+ [xx] TASK-012 [P-04]: Build the DSL reader — dropped, there is no modio.json
+ [x] TASK-013 [P-05]: Build the far look, matching a found thing against like ones
+ [x] TASK-017 [P-05]: Hold the reach and the height of every remembered meeting
+ [x] TASK-014 [P-05]: Build a runner, proving same input, same answer
+ [ ] TASK-015 [P-06]: Join Modio to stemic, and check it by real play
+ [x] TASK-018 [P-XX]: Put the questions in the target, not in a condition
+ [ ] TASK-016 [P-XX]: Put the rest of the docs into Basic English

## Detail

### TASK-001

`germio`'s own `docs/sensor_spec.md` and TASK-014 planned a sensor
built there. Held up against what Modio truly asks, that plan broke
in three places (`docs/modio_spec.md` §3.3), all from one cause:
seeking had been cut off from remembering. Even the drop-off check
belongs here — knowing an edge is dangerous is remembering it.

**Every part on the `germio` side landed 2026-08-22.**

| Owed there                         | How it came out                                                                                                                                                          |
| ---------------------------------- | ------------------------------------------------------------------------------------------------------------------------------------------------------------------------ |
| a way to name the same thing twice | **Nothing was needed.** Unity's own `GetInstanceID()` names one thing while it stands, and that is the whole of what Perceive asks. `germio`'s own TASK-015 was dropped. |
| `actor` on a Rule                  | done, with 6 tests there                                                                                                                                                 |
| `update_need`                      | done, with 5 tests there                                                                                                                                                 |
| `request_deed`                     | done, with 6 tests there                                                                                                                                                 |

What the older plan got right is brought over: **the two stages** (a
cheap wide check every tick, a straight line only where the cheap one
finds something) now sit in `Scripts/Core/StageGate.cs`, checked away
from Unity where they are cheap. The drop-off check came over as
`edge` in memory, and is asked through `Seek.KeepFrom` (§4.7).

`germio` holds no part of the seeking itself: Modio calls Unity's own
`Physics` straight, from its own `Runtime`.

### TASK-002

Counted, 2026-08-21: `stemic`'s own `Level_1` holds 12 blocks.

| Fade  | Held in memory | Left new  |
| ----- | -------------- | --------- |
| 30 s  | 4              | 8         |
| 60 s  | 8              | 4         |
| 90 s  | 11             | 1 or none |
| 120 s | 12 (all)       | **none**  |

**At 120 seconds the want for new places dies flat out.** 30 to 60
seconds works on this level — but the right rate turns on how many
things there are, so any fixed number will break on another level.

**Settled 2026-08-22: hold half, leave half new.**
`Memory.RoomFor(things)` gives back half the count, and never less
than 1.

| Things there | Held | Left new |
| ------------ | ---- | -------- |
| 4            | 2    | 2        |
| 12           | 6    | 6        |
| 48           | 24   | 24       |

Half stays new **however long a character walks**, so it can neither
run out of somewhere to go nor turn straight back to where it came
from. A test walks a level of 12 over 10 times and finds 6 still new
at the end; another explores 50 times over and is never once left with
nowhere to go.

Where the count is odd, the odd one is left new: better a place too
many new than too few.

### TASK-003

**Done 2026-08-22**, with 8 tests. `seek.before` is long gone; what
stands in its place is worked out here, counted against the 10 the two given
personas hold.

**There are three questions, and no fourth.**

| Asked                                | By            | Matched on               |
| ------------------------------------ | ------------- | ------------------------ |
| have I had to do with **that one**?  | `NotInMemory` | the id itself            |
| have I done that **with them**?      | `NotGivenTo`  | the other one's own name |
| how did it go with **ones like it**? | `KeepFrom`    | kind, reach and height   |

Counted deed by deed: `Rest` and `Call` ask nothing of the world at
all; `GoHome` has its one place to be. The other seven each ask one of
the three, or none.

**A character has no "like it".** `place_curious_01` and
`company_seeking_01` are two, not two of a kind — so a question about
another is always put by name, where a question about a thing may be
put about its sort. That is why there are three and not four.

A test puts all three to one table at once: met, given to, and like a
fall all fall away, and what is left is the one nothing is remembered
of.

### TASK-004

`super-nekokun`'s own `Enemy.cs` gave a line over a character's head
(`say()`), which showed what the character had in mind. `germio` has
no such thing: `Store.NotifyRequested` shows a line for the whole
screen. A Behavior that cannot be seen cannot be checked by eye.

**A home was found 2026-08-22: `germio` itself**, and the work is
split in two there.

| Part        | Where                                  | Done?                           |
| ----------- | -------------------------------------- | ------------------------------- |
| the sums    | `germio`'s own `Scripts/SpeechSize.cs` | **yes** — 11 tests, no Unity    |
| the drawing | `germio`'s own TASK-059                | no — Unity only, checked by eye |

Why there and not here: `germio` is handed out as a package, and every
game taking it would otherwise write the same thing again. Why not in
Modio: this build holds no Unity drawing at all (§3.6), and must not
start.

`WorthDrawing` is asked first, and asked away from Unity where it is
cheap — with 64 characters running, most lines are not worth drawing.

### TASK-005

**Done, over and over, 2026-08-21 and 2026-08-22.** The spec was put
through hard questioning many times over, at Master's own asking —
5 hard looks at a time, 10 rounds at a time — and 41 holes came
out of it. Every one is closed, and the reasoning kept where it was
found.

The heaviest of them:

| Found                                                                                                                         | Put right by                                                         |
| ----------------------------------------------------------------------------------------------------------------------------- | -------------------------------------------------------------------- |
| `GetInstanceID()` will not parse: `ExprLexer` reads an Identifier as `[a-zA-Z_][a-zA-Z0-9_-]*`, and 1042 starts with a number | a letter in front: `g_1042`                                          |
| working a Need forward cannot be done, would not help, and is not what Tulving said                                           | one table, faced two ways (§4.7)                                     |
| four checks in `germio` would warn on every deed ever written                                                                 | held back where a rule names an actor (its own TASK-051 to TASK-053) |
| `ShowFind` and `Tend` could not be written at all                                                                             | `act` grew from three to five                                        |
| a written-in fading time kills the want for new places                                                                        | held against the count instead (§4.6)                                |

**And once the code stood, the spec was checked against it.** Three
things built — `StageGate`, `Trace`, `Seen` — were named nowhere in
the spec at all; §3.6.1 now lists everything that stands in
`Scripts/`, so the two may be set side by side.

### TASK-006

**Done 2026-08-22**, with 13 tests.

`Scripts/Core/` now holds four small things, and no Unity at all:

| What       | Holds                                                      |
| ---------- | ---------------------------------------------------------- |
| `Found`    | one thing seeking found: kind, id, angle, distance, height |
| `Self`     | which way the character faces, against the world           |
| `Seek`     | what a deed looks for: kind, reach, spread, memory mark    |
| `Perceive` | weighs the list against memory, and takes one              |

**`Perceive.Choose` takes the nearest thing that answers to the seek
and is not held in memory**, and leaves the list it was given as it
was — Runtime fills the same list again each tick, so sorting it in
place would cost, and would surprise whoever holds it.

Where two stand at the very same distance, the one given first wins:
**the same list must always give back the same choice.**

Where nothing answers, nothing is taken, and the deed that asked will
end Failed. **This is how "south is done" comes about** (§5.5).

**The two stages are gated here too**, in `StageGate`. Seeking runs a
wide cheap check every tick, and throws a straight line only where the
cheap one finds something — **throwing a line is what costs**. Which
hits are worth one is a plain judgement, and it is made away from
Unity, where it is cheap.

Checked by real sums: `stemic`'s own `Level_1` holds 24 pieces of 8
kinds. Throwing a line at all 24, for each of 64 characters, every
tick, would come to **1,536 lines a tick for nothing**.

What is left for P-02: `Runtime/`, which asks Unity's own `Physics`
and fills these lists. **That part cannot be checked by `dotnet
test`** — check it by eye, in a running game.

Pick things **by name** (`germio`'s own `Env.cs` type marks, read
through `Like()`), never by layer: `stemic` holds only Unity's own
five stock layers, with no Block, Ground or Player layer at all.

Give back **every** thing found, near to far — one thing back leaves
no second try where the first sits in memory already.

**Meeting is not seeking** — it belongs to TASK-010, as proof of
arrival.

### TASK-007

**The table is built, 2026-08-22**, with 21 tests: `Scripts/Core/Row.cs`
and `Scripts/Core/Memory.cs`.

Four posts, six columns (§4.1): `actor` belongs to the whole table, and
each row holds `at`, `place`, `deed`, `thing`, `other`.

It answers three questions:

| Asked                     | Gives back                           |
| ------------------------- | ------------------------------------ |
| `Holds(deed, thing)`      | have I ever done that, to that one   |
| `HoldsWith(deed, other)`  | have I ever done that, with that one |
| `Since(deed, thing, now)` | how long since, or NEVER             |

**The three depths are in too**, in `Scripts/Core/Depth.cs`:

| Depth  | Deeds                                  | When a row must go |
| ------ | -------------------------------------- | ------------------ |
| `SEEN` | `seen`, and any deed with no depth set | goes first         |
| `MET`  | `met`                                  | goes next          |
| `HELD` | `held`, `gave`, `shown`, `edge`        | goes last          |

Where the ring is full, **the least deep row goes, and of two as deep,
the one longest past.** So a thing taken up stays with a character
however much it has since laid eyes on, and `edge` — where a fall is —
stays with the deepest, because forgetting it costs dear.

Seen rows still go, and that is what keeps a want for new places
alive: once a place is let go of, it is new again.

### TASK-008

**Done 2026-08-22**, with 8 tests: `Memory.RoomFor(things)`.

Letting go is by count and by depth together (§4.4, §4.6), and how
many rows a memory holds at all is now set against the world it stands
in — see TASK-002 above.

No time was written in anywhere. **A row is let go of because another
came, not because a clock ran out**, and that is what keeps the rate
right on a level of 4 and a level of 48 alike.

### TASK-009

`animo` proved zero garbage with a test running `Live()` 100,000
times. Modio must meet the same bar.

**Done 2026-08-22.** The table is a ring of a fixed size: writing past
what it holds moves one mark and writes over the row longest past,
making nothing new at all. Two tests hold it there, each running
10,000 times and asking `GC.GetTotalAllocatedBytes` for the difference
— which must be **0**.

`germio`'s own history uses a `List` with `RemoveAt(0)`, which shifts
every row and grows its backing store. **That was not copied.**

**One thing taken in, in the doing.** The first form of this test used
`GC.GetTotalAllocatedBytes`, which counts the whole process, and it
passed alone but failed in a full run — 123,464 bytes out of nowhere.
That was the runtime's own work, not this code's: compiling the
method, then compiling it again once it turned out to be hot. The test
now warms the path first, and counts on its own thread alone
(`GC.GetAllocatedBytesForCurrentThread`). **Run three times over, it
gives the same answer each time.**

### TASK-010

**Done 2026-08-22**, with 19 tests: `Scripts/Core/Deed.cs` and
`Scripts/Core/Until.cs`.

Up to three steps run, in order — **and only the middle one is
watched**:

| Step   | Runs when         | Ends when                 |
| ------ | ----------------- | ------------------------- |
| `Face` | there is a target | it faces — of itself      |
| `Move` | always            | `Until` says so           |
| `Act`  | there is an act   | the act's own clock is up |

Three ends, and **only Done writes anything at all**:

| End       | Comes about                                              |
| --------- | -------------------------------------------------------- |
| `Done`    | it reached its end                                       |
| `Failed`  | nothing found, what was found left, or the lock gave out |
| `Dropped` | another Behavior came, or the Node changed               |

`MayWrite` is true for Done alone. **Done is the one gate into
memory.**

**Nothing here calls Unity.** What the body is doing — whether it
faces yet, how far off the target stands, whether the act was carried
out — is handed in each tick. So a whole deed, lock and all, runs
through in a test in a moment, with no waiting: 320 ticks of 0.1 seconds
each is half a minute of play.

`{ "while": ... }` ends Failed, never Done, and a test holds it there:
a call is not an answer.

### TASK-011

**Done 2026-08-22**, with 11 tests: `Scripts/Core/IMind.cs` and
`Scripts/Core/Hand.cs`.

**Modio does not name `animo` at all.** What it asks of a mind is
three things, and they are set out as a way in:

| Asked                  | For                                   |
| ---------------------- | ------------------------------------- |
| `Behavior`             | what is wanted now                    |
| `Lock(duration, soft)` | holding that steady while a deed runs |
| `Affect(need, delta)`  | telling it a want was met             |

`animo`'s own `Engine` answers to all three already, so a thin piece
in `Runtime/` joins them; nothing here needs changing for it.

**The hold is always soft.** Scores still work on the inside, and only
what is given back is held — so a sudden want, fear say, may still
break in. Where it does, `Hand.HasMovedOn()` says so, and the deed is
Dropped.

**What this buys:** a test may stand a plain mind in place of the real
engine and run a whole round with no engine at all. Three such rounds
are held here — a deed that lands and quiets its want, one that fails
and quiets nothing, and one dropped because the mind moved on.

### TASK-012

**Dropped 2026-08-22.** This asked for a reader for `modio.json`, and
a check to catch a bad one before play.

**There is no `modio.json`.** A DSL of Modio's own was weighed and let
go part way through the design: a writer would have had to hold two
files in mind at once, and two ways of saying the same thing. A deed is
written in `germio.json`, with `actor`, `request_deed` and
`update_need` (§7).

**The checking went with it.** `germio`'s own Validator gained 9
checks for exactly this — V028 to V034 and V036 — and they run before
play, as every check there does. Nothing is owed here.

### TASK-013

Build the far look: read the memory facing the other way, plus
`animo`'s own `rates` and `GetNeed(need)`. A Need climbing at +1.2 a
second sits 36 points higher in 30 seconds — **worked out, never
guessed.**

### TASK-014

**Done 2026-08-22**, with 9 tests: `Scripts/Tools/Seen.cs`,
`Scripts/Tools/Trace.cs` and `Scripts/Tools/Runner.cs`.

A world is written out by hand — what stood where, and when — and fed
in tick by tick. **No Unity, and no waiting**: 400 ticks of 0.1
seconds each is 40 seconds of play, run through in a moment.

| What     | Holds                                      |
| -------- | ------------------------------------------ |
| `Seen`   | one thing, seen at one time                |
| `Trace`  | every tick of a run, and how it ended      |
| `Runner` | carries a deed through a written-out world |

Two runs of one world give back the very same answer, tick for tick,
and a test holds them side by side to say so.

`Trace.Write()` puts a run out as plain lines, so **a person may read
one through with their own eyes**.

This mirrors `animo`'s own runner: the shape is the same because the
need is the same. **The code is Modio's own**, and neither build leans
on the other.

### TASK-015

Put Modio into `stemic`, driving `place_curious` and
`company_seeking`, and check by real play that each truly seeks,
remembers, and acts on both.

**Three things must stand first:**

| Owed by  | What                                                                                                                                                                |
| -------- | ------------------------------------------------------------------------------------------------------------------------------------------------------------------- |
| `animo`  | the two personas, written out as a real `animo.json` file (its own TASK-013). They are worked out in full in `docs/persona_design_spec.md` §6, and not yet written. |
| `germio` | `Rule.actor`, `request_deed`, `update_need` (its own TASK-016 to TASK-039)                                                                                          |
| Modio    | everything in P-02 to P-05 here                                                                                                                                     |

### TASK-016

`docs/modio_spec.md` is written to the family rule already. The rest
of the docs, once written, must follow.

### TASK-017

**Done 2026-08-22**, with 13 tests.

A row now keeps three things beside the four posts: **what the thing
was, how far off it stood, how far up or down it sat.** These are what
Perceive handed back, and they are what lets the same table be faced
the other way.

`Memory.HoldsLike(deed, kind, reach, height)` asks after every row of a
sort with the one named. How near counts as of a sort was settled off
`stemic`'s own build:

| Bound            | Value | Why                                                                                             |
| ---------------- | ----- | ----------------------------------------------------------------------------------------------- |
| `SORT_BY_REACH`  | 3.0   | a Ground piece there is 10 by 10, so 3 is under a third of one                                  |
| `SORT_BY_HEIGHT` | 1.0   | a Ground piece stands 0.5 high, so 1.0 is two — about the most a character may drop and walk on |

Below the height bound a fall is a step down; above it, it is a fall.

`germio`'s own `HistoryEntry` keeps none of the three, and should not:
it holds the **world's** past, not a character's own (§4.2).

### TASK-018

**Done 2026-08-22**, with 8 tests, and it closes a break that ran the
whole length of the spec.

**`condition` cannot carry the questions a deed puts to its own past.**
Three reasons, each on its own enough:

| Why not                              | Measured                                                                                 |
| ------------------------------------ | ---------------------------------------------------------------------------------------- |
| read too late                        | `germio`'s Evaluator reads it, and it holds `$target` — known only once Modio has looked |
| reads the wrong past                 | `history.*` reads the world's own record, one for the whole game (§4.2)                  |
| `keep_from` cannot be written at all | it matches on kind, reach and height, and `HistoryEntry` holds none of the three         |

So the four questions are written in `target` instead:
`not_in_memory`, `not_given_to`, `keep_from`, `new_again_after`.

**And one more thing came out of it.** The spec used
`history.time_since(...) > 60` in four places to mean "new again, if it
has been a while". Checked against `germio`'s own code:
`history.time_since` gives back **the time mark on the latest matching
row**, not how long since. So that line read "written down later than
the 60 second mark" — another thing altogether.

`Memory.Since(deed, thing, now)` is the one that gives how long since,
and `Seek.NewAgainAfter` is how a deed asks it. **The row is never
touched**: age is weighed each time the question is put.
