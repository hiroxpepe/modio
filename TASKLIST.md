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
+ [x] TASK-019 [P-04]: Carry what was found, from the seek to the row
+ [ ] TASK-015 [P-06]: Join Modio to stemic, and check it by real play
+ [x] TASK-018 [P-XX]: Put the questions in the target, not in a condition
+ [ ] TASK-016 [P-XX]: Put the rest of the docs into Basic English
+ [ ] TASK-020 [P-XX]: Hold real, given classic console-era AI patterns, for seeking to check against
+ [x] TASK-021 [P-XX]: Wire animo's own true Engine to Modio's own real IMind
+ [ ] TASK-022 [P-XX]: Add a draft plan, a real Unity Tag for one named item
+ [x] TASK-023 [P-02]: Add an asmdef of Modio's own, so a Unity project can take it in
+ [x] TASK-024 [P-02]: Build the wedge check in Scripts, with no Unity in it at all
+ [ ] TASK-026 [P-02]: The thin Unity edge, reading Sight's five numbers from germio
+ [ ] TASK-027 [P-02]: The thin Unity edge, reading transform.forward
+ [ ] TASK-028 [P-02]: The thin Unity edge, the broad sphere call alone
+ [ ] TASK-029 [P-02]: The name interface, asking germio for a kind and an id
+ [ ] TASK-030 [P-02]: The thin Unity edge, one ray call alone
+ [ ] TASK-031 [P-02]: Prove zero garbage across a whole tick, by a real Play Mode test
+ [x] TASK-032 [P-02]: The heading logic behind TASK-027, no Unity at all
+ [xx] TASK-033 [P-02]: The Sight-data logic behind TASK-026 — dropped, no real logic stood in it
+ [x] TASK-034 [P-02]: The broad-phase logic behind TASK-028, no Unity at all
+ [x] TASK-035 [P-02]: The ray-result logic behind TASK-030, no Unity at all
+ [x] TASK-036 [P-XX]: The Tag logic behind TASK-022's own third path, no Unity at all
+ [ ] TASK-037 [P-XX]: The adapter joining germio's world table to Modio's own name interface

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
test`** — check it by eye, in a running game. **It now stands as its
own task, TASK-024, with TASK-023 (the `.asmdef`) and `germio`'s own
TASK-067 (the world table) in front of it.** What follows below is the
design record that led there, kept as it was written.

**A real, given question found, this same session, never yet
settled, held here as a matter still to weigh:** how `Runtime`
itself should read what stands ahead — a real, given field of view,
built from `reach` and `spread` together (a cone shape, not a plain
sphere alone), rather than a wide sphere check first, with `spread`
weighed against each found thing only after. `Physics.OverlapSphere`
itself, checked live against Unity's own real docs, returns every
collider inside a sphere, height included — a real, true 3D check,
never a flat one. Whether `Runtime` should call it once for a wide,
cheap first pass, then weigh `spread` by a plain angle check
(`Vector3.Angle`) against each thing found, or some other real,
given shape entirely, stands open — a real, given design question,
not yet settled, not yet built.

**Settled, this same session: which way the cone itself points.**
`Runtime` reads the found thing's own real `transform.forward` —
never a fixed value held from the moment a prefab was made, since
`germio`'s own `Human.cs` already turns it true, moment to moment,
as a real character truly moves (`Quaternion.Slerp` against the way
it walks). Once `place_curious` and `company_seeking` turn the same
true way, `Runtime` reads their own real, given facing straight off
`transform.forward`, with no call at all to `animo`'s own `IMind`
(which holds no `heading` field of its own — checked live).

Pick things **by name** (`germio`'s own `Env.cs` type marks, read
through `Like()`), never by layer: `stemic` holds only Unity's own
five stock layers, with no Block, Ground or Player layer at all.

**Checked live, this same session, a true 3D model (Three.js),
given a real pass at last — a whole shape, never one piece alone.**
Two parts, built and kept apart on purpose:

+ **The dome.** A curved patch lying on the sphere throughout, never
  once leaving it. Given `halfYaw`, `halfPitch` (half of the whole
  horizontal/vertical spread), and a ring index `ri` from `0` to
  `nRing`, `rScale = ri / nRing`:
  `yaw = rScale * halfYaw * cos(theta)`,
  `pitch = rScale * halfPitch * sin(theta)`,
  `dir = (sin(yaw)*cos(pitch), sin(pitch), cos(yaw)*cos(pitch))`
  (a true unit vector, checked live — its own length is always `1`),
  `point = dir * reach`. Every point at every `ri` sits exactly on
  the sphere; only the angle itself shrinks toward the middle. This
  gives a true ellipse, checked hard against three real, given
  wrong turns first (a flat plane that stuck out past `reach`; a
  normalized plane that bent the true ellipse out of shape) before
  this one held.
+ **The straight walls.** A real, given triangle fan from the
  character's own true position (the origin) straight to the dome's
  own outer rim (`ri = nRing`) alone — never the shrunk middle
  point. A first, given try wired the fan to the wrong ring (the
  shrunk one), leaving a thin, real spike instead of a true wedge;
  wiring it to the true outer rim fixed it outright. Viewed from
  the side or from above, every wall reads as one straight line, the
  same real shape a plain cone would give.

**A real, given single `spread` value (`Vector3.Angle`) can never
give this ellipse at all — checked hard, three real rounds run,
`Vector3.Angle` returns one true angle alone, always a full, given
circle. A true ellipse asks for `halfYaw` and `halfPitch` apart, two
real fields where `Seek` (and `germio`'s own `Target`) hold one
today.**

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

**Checked live, this same session: three of four things owed here
now stand, not "not yet written" as this whole task once read:**

| Owed by                   | What                                                                                                                                                                                 | State                                                                      |
| ------------------------- | ------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------ | -------------------------------------------------------------------------- |
| `animo`                   | the two personas — checked live, `examples/poc_pair.json` names both `place_curious` and `company_seeking` outright (its own TASK-013, closed).                                      | Done                                                                       |
| `germio`                  | `Rule.actor`, `request_deed`, `update_need` (its own TASK-016 to TASK-039).                                                                                                          | Done — every one closed `[x]`, or dropped `[xx]` for a real, given reason. |
| Modio                     | everything in P-02 to P-05 here.                                                                                                                                                     | Done                                                                       |
| Bridge                    | a real, given `IMind` wired to `animo.Engine` — no such wiring exists yet at all (see TASK-021 below). Without it, all three of the above stand apart, never joined.                 | Not started — the one true, real gap left                                  |
| `Runtime/`                | asking Unity's own real `Physics`, filling the seek list each tick (`docs/modio_spec.md` §3.7, §3.7.3). Now its own task, TASK-024, standing on TASK-023 and `germio`'s TASK-067.    | Not started — this whole task's own second real gap                        |
| `stemic`, not code at all | two given models, an Animator Controller, both `germio` Rule sets, two given prefabs, placed in a real level, checked to play — its own TASK-018 to TASK-026, every one `[ ]` still. | Not started                                                                |

**So this whole task's own true block is never `animo`, `germio`, or
Modio's own build alone — three real, given gaps stand together:
the `EngineMind` bridge (TASK-021, below), `Runtime/` (`Physics`
itself, never yet built), and `stemic`'s own whole given set of
real assets (TASK-018 to TASK-026, not one line of code among
them). Real play still needs a real Windows Unity open for the
last two, but `EngineMind` is buildable on this whole machine right
now, `dotnet test` and all.**

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

### TASK-019

**Done 2026-08-22**, with 9 tests.

A `Deed` knew its motion, its step and its end — **and not the id of
what it reached for.** So a deed that landed had nothing to write down:
a row names what was done to (§4.1), and there was nothing to name.

`Deed.Holding` now carries what seeking found, from `Begin` through to
the row that goes down at the end. It carries the kind, the reach and
the height beside the id, since a row keeps those too, and they are
what let the table be faced the other way (§4.7).

**The whole round is held by a test**: what seeking found is what the
row names, and both ways of asking after it — by name, and by what it
was like — find it there.

A deed that fails still knows what it reached for. **It simply never
got there**, and Done is the one gate into memory.

### TASK-020

**A real, given memo, held here for real testing to check against once
`stemic` play begins (TASK-015).** Fifteen real, given AI patterns,
each one drawn from a real, named classic console-era game, each written as
one whole real Rule, the same true shape as `germio`'s own
`deed_rule.json` fixture — `actor` names a real `animo` Persona,
`request_deed` is `Modio`'s own true domain, and the inner `command`'s
own `update_need` spends (or, once, raises) that same real Persona's
own Need, closing the whole real loop in one, given JSON shape:

**1. Ghost gives chase once seen (Pac-Man).**

```json
{
    "id": "rule_chase",
    "actor": "ghost_01",
    "command": {
        "request_deed": {
            "target": {
                "kind": "Player",
                "reach": 8.0,
                "spread": 360.0
            },
            "motion": "walk",
            "until": {
                "meets": "$target"
            },
            "command": {
                "update_need": [
                    {
                        "key": "hunger",
                        "delta": -30.0
                    }
                ]
            }
        }
    }
}
```

**2. A hint given once, never twice (The Legend of Zelda).**

```json
{
    "id": "rule_hint",
    "actor": "oldman_01",
    "command": {
        "request_deed": {
            "target": {
                "kind": "Player",
                "reach": 3.0
            },
            "condition": "history.count(kind=told, target_id=$target) == 0",
            "act": "give_hint",
            "command": {
                "update_need": [
                    {
                        "key": "duty",
                        "delta": -40.0
                    }
                ],
                "record_event": {
                    "kind": "told",
                    "target_id": "$target"
                }
            }
        }
    }
}
```

**3. A merchant's own true sale, once a real day (Dragon Quest).**

```json
{
    "id": "rule_sale",
    "actor": "merchant_01",
    "command": {
        "request_deed": {
            "condition": "history.time_since(kind=discounted) > 86400",
            "act": "sell_discount",
            "command": {
                "update_need": [
                    {
                        "key": "generosity",
                        "delta": -20.0
                    }
                ],
                "record_event": {
                    "kind": "discounted"
                }
            }
        }
    }
}
```

**4. A guard's own true alert (Metal Gear).**

```json
{
    "id": "rule_alert",
    "actor": "guard_01",
    "command": {
        "request_deed": {
            "target": {
                "kind": "Player",
                "reach": 20.0,
                "spread": 60.0
            },
            "act": "alert",
            "command": {
                "update_need": [
                    {
                        "key": "vigilance",
                        "delta": -25.0
                    }
                ],
                "set_flag": {
                    "key": "spotted_player",
                    "value": true
                }
            }
        }
    }
}
```

**5. Turn at a wall, back and forth (Super Mario Bros.).**

```json
{
    "id": "rule_patrol",
    "actor": "goomba_01",
    "command": {
        "request_deed": {
            "target": {
                "kind": "Wall",
                "reach": 1.0
            },
            "motion": "walk",
            "until": {
                "meets": "$target"
            },
            "act": "turn_around",
            "command": {
                "update_need": [
                    {
                        "key": "wander",
                        "delta": -10.0
                    }
                ]
            }
        }
    }
}
```

**6. Never step the same floor twice running (Ice Climber).**

```json
{
    "id": "rule_wander",
    "actor": "topi_01",
    "command": {
        "request_deed": {
            "target": {
                "kind": "Floor",
                "reach": 5.0
            },
            "condition": "history.time_since(kind=stepped, target_id=$target) > 5",
            "motion": "walk",
            "command": {
                "update_need": [
                    {
                        "key": "curiosity",
                        "delta": -15.0
                    }
                ],
                "record_event": {
                    "kind": "stepped",
                    "target_id": "$target"
                }
            }
        }
    }
}
```

**7. Flee once `animo`'s own `fear` sits past its true threshold (Kirby).**

```json
{
    "id": "rule_flee",
    "actor": "enemy_01",
    "command": {
        "request_deed": {
            "target": {
                "kind": "Escape_Point",
                "reach": 50.0
            },
            "motion": "run",
            "command": {
                "update_need": [
                    {
                        "key": "fear",
                        "delta": -50.0
                    }
                ]
            }
        }
    }
}
```

**8. A fixed turret, given a true line of sight (Contra).**

```json
{
    "id": "rule_shoot",
    "actor": "turret_01",
    "command": {
        "request_deed": {
            "target": {
                "kind": "Player",
                "reach": 15.0,
                "spread": 30.0
            },
            "act": "shoot",
            "command": {
                "update_need": [
                    {
                        "key": "aggression",
                        "delta": -35.0
                    }
                ]
            }
        }
    }
}
```

**9. Climb the one true ladder not yet climbed a real, given while (Donkey Kong).**

```json
{
    "id": "rule_climb",
    "actor": "kong_01",
    "command": {
        "request_deed": {
            "target": {
                "kind": "Ladder",
                "reach": 10.0
            },
            "condition": "history.time_since(kind=climbed, target_id=$target) > 10",
            "motion": "climb",
            "command": {
                "update_need": [
                    {
                        "key": "caution",
                        "delta": -20.0
                    }
                ],
                "record_event": {
                    "kind": "climbed",
                    "target_id": "$target"
                }
            }
        }
    }
}
```

**10. A field monster's own true wander, never the same ground twice running (Dragon Quest).**

```json
{
    "id": "rule_roam",
    "actor": "slime_01",
    "command": {
        "request_deed": {
            "target": {
                "kind": "Ground"
            },
            "motion": "walk",
            "condition": "history.time_since(kind=visited, target_id=$target) > 5",
            "command": {
                "update_need": [
                    {
                        "key": "territorial",
                        "delta": -15.0
                    }
                ],
                "record_event": {
                    "kind": "visited",
                    "target_id": "$target"
                }
            }
        }
    }
}
```

**11. Never fought twice, `germio`'s own true `once` flag alone (Adventures of Lolo).**

```json
{
    "id": "rule_guard",
    "actor": "guardian_01",
    "command": {
        "request_deed": {
            "act": "attack_pattern_A",
            "command": {
                "update_need": [
                    {
                        "key": "duty",
                        "delta": -60.0
                    }
                ]
            }
        }
    },
    "once": true
}
```

**12. An erratic, given approach, wide of reach (Castlevania).**

```json
{
    "id": "rule_swoop",
    "actor": "bat_01",
    "command": {
        "request_deed": {
            "target": {
                "kind": "Player",
                "reach": 100.0,
                "spread": 180.0
            },
            "motion": "fly",
            "act": "erratic_approach",
            "command": {
                "update_need": [
                    {
                        "key": "hunger",
                        "delta": -25.0
                    }
                ]
            }
        }
    }
}
```

**13. Follow once a real, given trigger starts it, staying near (an escort event).**

```json
{
    "id": "rule_escort",
    "trigger": "sig_escort_started",
    "actor": "companion_01",
    "command": {
        "request_deed": {
            "target": {
                "kind": "Player"
            },
            "motion": "walk",
            "until": {
                "near": 3.0
            },
            "command": {
                "update_need": [
                    {
                        "key": "loneliness",
                        "delta": -40.0
                    }
                ]
            }
        }
    }
}
```

**14. A boss's own true pattern, switched past half health (Mega Man).**

```json
{
    "id": "rule_enrage",
    "actor": "boss_01",
    "command": {
        "request_deed": {
            "condition": "self.hp_ratio < 0.5",
            "act": "attack_pattern_phase2",
            "command": {
                "update_need": [
                    {
                        "key": "desperation",
                        "delta": 40.0
                    }
                ]
            }
        }
    }
}
```

**15. Laugh once, the one true round every shot missed (Duck Hunt).**

```json
{
    "id": "rule_laugh",
    "actor": "dog_01",
    "command": {
        "request_deed": {
            "condition": "history.count(kind=laughed) == 0 && round.hits == 0",
            "act": "laugh",
            "command": {
                "update_need": [
                    {
                        "key": "mockery",
                        "delta": -30.0
                    }
                ],
                "record_event": {
                    "kind": "laughed"
                }
            }
        }
    }
}
```

**The same true shape carries all fifteen**: `actor` is a real,
given `animo` Persona's own name; `request_deed` alone is `Modio`'s
own true domain (a real Seek, a real Deed); the inner `update_need`
is `animo` again, spending or raising the very Need that, in real
play, would have crossed its own true threshold to fire this whole
real Rule in the first place.

**A real, given catch, found live against `animo`'s own true
`Engine.Affect`**: every one of these fifteen Need names (`hunger`,
`duty`, `generosity`, and the rest) must be held, whole, in the
real Persona data `stemic` gives that agent — `Engine.Affect` reads
an unlisted Need name as a quiet no-op (a real, given warning
logged, nothing else truly happens). None of these fifteen have
been checked against a real, given `stemic` Persona file yet.

**Three more real, given gaps, checked live, none yet closed:**

| Real gap                                                                               | What is still unknown                                                                                                                                                       |
| -------------------------------------------------------------------------------------- | --------------------------------------------------------------------------------------------------------------------------------------------------------------------------- |
| Every `Kind` value (`Ground`, `Floor`, `Ladder`, `Escape_Point`, `Wall`, and the rest) | `Seek.Kind` holds a bare, given string, no real fixed list at all — whether `stemic` truly names its own real objects this same way is never checked here                   |
| The `$target` mark, used inside `record_event`'s own `target_id`                       | Copied whole from one real, given fixture (`deed_rule.json`); whether `germio`'s own true parser resolves it correctly in every real spot it appears here is never once run |
| All fifteen, as a whole                                                                | Checked only on paper — never truly loaded into a real `Modio`/`germio` engine and run; a real, given static check, never a real, given proof it plays                      |

**One real, given piece of this whole claim now stands checked live,
not on paper alone — and checked twice, the second real run closing a
real gap the first one left open.** The first real run skipped
`Modio`'s own true `Seek`/`StageGate` step outright, feeding `Deed` a
hand-made `Found` directly — so a second, given run was made,
`StageGate.Worth` truly called against three real, given candidates
(a `Wall`, wrong kind; a `Player` past real reach; a `Player` truly
inside both reach and kind), and only the one real match came back:

```text
StageGate.Worth(near=[Wall,Player(dist=12),Player(dist=5)], seek) -> [Player(dist=5)]
Hand.Begin -> PlainMind.Lock(soft=True)
Deed.Tick(distance=5) -> Deed.End = Running
Deed.Tick(distance=1.5) -> Deed.End = Done
Hand.Landed -> PlainMind.Affect(hunger, -30)
```

**This checks `Modio`'s own real whole loop — Seek, Deed, and Hand
together — not `Deed`/`Hand` alone.**
`germio`'s own true half — parsing this whole JSON shape, reading
`condition`, and truly building a real `Modio.Deed` from it — was
never once run at the time this whole memo was written: `germio`'s
own Scripts held no real `.csproj` at all then, a real Unity-only
`.asmdef` in its place. **Checked live again, this same day: `germio`
now holds a real `Tests~/CoreTests/CoreTests.csproj` (germio
TASK-065), so a real run against `germio`'s own true parsing is no
longer blocked this same way — it stands as real, given open work,
never a wall any more.** The other fourteen patterns stay exactly
where they stood: checked only on paper.

**A real, given piece still missing outright, found this same day,
never once named here before:** the check above fed `StageGate.Worth`
a hand-made, given list of three candidates directly — `Runtime/`
itself (TASK-006's own true "what is left for P-02": asking Unity's
own real `Physics` and filling that same list, tick by tick) has
never once been built. `docs/modio_spec.md` §3.7 already gives its
whole real shape (a wide, cheap check every tick, a straight line
thrown only where that finds something, real sums checked against
`stemic`'s own `Level_1`) — but not one line of it stands as real,
given code yet. Without `Runtime/`, `Modio`'s own whole loop can only
ever be checked against a hand-made list, never a real, given running
game.

### TASK-021

**Done 2026-09-21, 5 tests.** `EngineMind` stands built, against
`IEngineFacing` (option B, 2026-09-20 — a stand-in shape, never a
true tie to `animo`'s own `Engine` yet; that true tie still waits on
a thin, given piece, not yet built).

**Found true, checked live: `animo`'s own `Engine.cs` already holds
almost every real member `Modio`'s own `IMind` asks for — `Behavior`,
`Lock`, `Affect` — real, given, working code, not a bare stub.**
Checked against a real, given search: no `Modio.Core.IMind` is
implemented anywhere in `animo`, `germio`, or `stemic` — only
`Modio`'s own test-only `PlainMind` (`Tests~/CoreTests/MindTests.cs`)
stands one in for real, given tests today.

**Two real, given gaps, found live, keep the two whole from truly
meeting yet:**

| Real gap                          | What it means                                                                                                                                                                                                                             |
| --------------------------------- | ----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- |
| `Lock`'s own second real argument | `IMind` asks for `bool soft`; `animo`'s own `Engine.Lock` takes a real `LockMode` enum (`Hard`/`Soft`) instead — a real, given type mismatch, checked precisely: C# never lets an implicit interface match happen here at all             |
| `Affect`'s own true arity         | `IMind` asks for exactly two real arguments (`need`, `delta`); `animo`'s own `Engine.Affect` holds a third, given optional one (`force_reset = false`) — C# still never lets this stand in for `IMind.Affect` implicitly, optional or not |
| `Modio`'s own missing `.asmdef`   | `animo` holds four real, given Unity assembly files; `Modio` holds none at all — a real, given Unity project can never reference `Modio` as things stand                                                                                  |

**A thin, given adapter closes the first two real gaps — real, given
design, checked live against both real signatures:**

```text
EngineMind (wraps a real, given animo.Core.Engine, implements Modio.Core.IMind)
    Behavior => engine.Behavior                          (a plain, given pass-through)
    Lock(duration, soft) => engine.Lock(duration,
        soft ? LockMode.Soft : LockMode.Hard)             (true type translation)
    Affect(need, delta) => engine.Affect(need, delta)      (force_reset left at its own true default)
```

**Where this whole adapter must live — found true by real, given
elimination, then found again, reversed, this same day:** never
inside `Modio` itself. `IMind.cs`'s own true words — "Modio does not
name animo here", "modio stays free of a build it need not know" —
name `Modio.csproj` itself, its own true build output, never the
whole `modio` repository as a real, given place. Never inside
`animo`'s own `Core` either — checked live, `Animo.csproj` never
once names `Modio`, the same true independence `Modio` itself holds
toward `animo`; a real `ProjectReference` to `Modio.csproj` from
inside `Animo.csproj` would break that same true symmetry.

`germio` was once thought the one, true, natural home (it already
reads a Rule's own `actor` — an `animo` Persona name — beside its
own `request_deed` — `Modio`'s own true domain — in the very same
real JSON object), ruled out at the time since `germio` held no real
`.csproj` at all. **Checked live again, this same day: `germio` now
holds a real `Tests~/CoreTests/CoreTests.csproj` of its own (germio
TASK-065) — but a bridge naming both `Animo.csproj` and
`Modio.csproj` from inside it would still break `germio`'s own true
independence toward `animo`, the same real rule `germio-editor`
(a wholly separate JS project, checked live, naming neither `animo`
nor `Modio` at all) already holds true. `germio` stays ruled out.**

**The one, true, correct home, found this same day: a small, new
`.csproj` inside `modio`'s own repository, standing beside
`Scripts/Modio.csproj` — never inside it, never touching it —
naming both `Animo.csproj` and `Modio.csproj` from its own true
outside. `modio`'s own `.gitignore` names no `*.csproj` rule at all,
unlike `germio`'s own, so a real, given new file here needs no extra
line to stand tracked. This holds the same true shape
`germio-editor` already proves: one repository, more than one real,
given project, each free to know what the others do not.**

**A real, given wrong turn, caught and reversed this same session,
kept here whole as a true warning:** the first real design drafted a
`Need`-name check *inside* `EngineMind` itself — throwing loud at
construction if a `Rule`'s own `update_need` named a `Need` `animo`'s
own `Persona` never registered. **This was itself a real, given
mistake, caught live**: `animo.Engine`'s own `Need` set is not fixed
in the engine's own true code at all — it comes whole from a real,
given `Persona.needs.values` (`Dictionary<string, float>`, checked
live in `Scripts/Model/Data.cs`), built once at construction
(`Engine.cs`'s own real `_need_index`, "Built once in PHASE B") and
never changed again after. **Checking this once, deep inside a
single adapter instance, at runtime, repeats this whole session's
own found mistake (TASK-053's own true lesson) in reverse** — a real,
given check that only fires once real gameplay is already running is
far too late; the true, right home for this whole check is
build-time, across every real `Rule` file and every real `Persona`
file a given game (`stemic`) ships together, all at once, the same
true way `validate_tasklist.js`/`validate_score_format.js` already
run in this whole family. **`germio`'s own true `Validator.cs`
already holds the one, true, matching precedent for this: `V036`
("an actor no persona answers to"), fed a real, given
`known_actors` collection from outside, checked against every
real `Rule.actor` found.** A real, given `V037` — fed a real, given
`known_needs` map (`agent_id -> its own true Need-name set`), checked
against every real `update_need.key` a `Rule` holds — is the true,
correct home for this whole check, never `EngineMind` itself. This
whole `V037` piece is tracked as its own true, separate task, in
`germio`'s own `TASKLIST.md`, never duplicated here.

**Real, given scope, settled for this one task alone:** `EngineMind`
itself stays a thin, given pass-through — `Behavior`/`Lock`/`Affect`
translation only, no `Need`-name checking of its own at all, that
whole real job handed whole to `germio`'s own future `V037`.

**Held, 2026-09-20 — three real holes in `EngineMind`'s own
contract, closed:**

1. **`Lock`'s own direction.** `IMind.Lock(bool soft)` hands one
   `bool` in; `Engine.Lock` asks for a true `LockMode`. Held:
   `soft == true` turns into `LockMode.Soft`; `soft == false` turns
   into `LockMode.Hard` — a plain, one-way turn, never the other way
   round.
2. **`Affect`'s own third, missing argument.** `IMind.Affect` hands
   two things in; `Engine.Affect` asks for a third,
   `force_reset`. Held: `EngineMind` always hands `false` for it — the
   safe, given default, never a hard reset from a call that never
   asked for one.
3. **A `null` `Engine`.** Held: `EngineMind`'s own constructor throws
   `ArgumentNullException` the moment a `null` `Engine` is handed in
   — never a silent, later fault once some real call is made against
   it.

**How to check it — write these Red first:**

1. `Behavior` reads back whatever the true, given `Engine.Behavior`
   itself holds, whole and unchanged
2. `Lock(true)` calls `Engine.Lock(LockMode.Soft)`
3. `Lock(false)` calls `Engine.Lock(LockMode.Hard)`
4. `Affect`, called through `IMind`'s own two-argument shape, calls
   `Engine.Affect` with `force_reset: false`
5. building an `EngineMind` around a `null` `Engine` throws
   `ArgumentNullException`, at once — never later, and never quietly

**Checked live, this same session, a real, given fact this whole
task sits on top of: no game truly holds a `Need` at all yet.** A
real `Need` name comes into being the one true moment someone writes
it into a real `Persona`'s own `needs.values` map (a
`Dictionary<string, float>`, checked live in `animo`'s own
`Scripts/Model/Data.cs`) — checked live, this whole real shape lives
only in `animo`'s own `examples/` folder today (`tanukichi.json`,
`goblin_scout.json`, `shiori.json`, `poc_pair.json`), never once in
`stemic`, `tropika`, or `flugi`'s own real data. `stemic`'s own real
`germio.json` — the one true `Rule` file a real game ships — holds
zero real `update_need` entries, checked live. **So the question
"when does a Need name settle" never truly reaches a real, given
game at all yet: `Persona` data, `germio` `Rule` use of it, `V037`'s
own check, and `EngineMind` itself are all four still real, given
work, not yet real, given practice.**

### TASK-022

**`TargetMarkLogic` itself done, 2026-09-21, 2 tests. Real, given
work still owed:** the Unity Tag edge (`GameObject.CompareTag`) and
the real, given checks against `stemic`'s own Tag list — both still
need a real Windows Unity open.

**Found true, checked live, this same session — a real, given gap:
picking up one named item (a given key, not a plain given block) asks
for more than `kind` alone. `kind`'s own true eleven marks (`germio`'s
own `Env.cs`) tell what class of thing stands there, never which
particular one — and `germio`'s own true rule, held here whole,
never bends: one way, no exceptions.**

**Two real, given paths were weighed, checked against real, given
counted fact:**

+ The object's own real name — already tried, already dropped, kept
  whole in `docs/modio_spec.md` §3.3.1: counted 2026-08-21,
  `Level_1`'s own 24 pieces held three real, given names twice over.
  Never one to a piece.
+ A field added by hand, read at runtime, given a whole new mark
  through `Found` and `TargetMark` both — real, given work, but no
  small one.

**A third real, given path, drafted here, never yet checked live:**
Unity's own real Tag. Set once, from the Inspector, on one given
`GameObject` alone — no new mark added to `germio`'s own `Env.cs`, no
new field carried through `Found`, no `MonoBehaviour` chain added
either (`Common`'s own real cost, already weighed and dropped once,
stays dropped). `Runtime` reads it with `GameObject.CompareTag`, a
plain, given Unity call, the same true shape `Like()` already holds
for `kind` — never the object's own real name, so the same real
counting gap does not open again.

**Real, given work still owed, none of it started:** a real check
that `stemic`'s own given Tag list truly holds one entry per named
item, never two given items sharing one; how `Found` (and
`TargetMark` behind it) carries this Tag's own real text through to
`update_inventory.key`, so a `Rule` may write `"$target"` and get
back the item's own true name, not a plain `g_1042`; and whether this
whole real shape holds once checked live, in a real Windows Unity
open.

**Held, 2026-09-20 — a real, given clash in the two paragraphs
above, closed.** The first says outright: no new field carried
through `Found`. The second then asks how `Found` carries the Tag's
own text through. Both cannot be true at once. **Closed: `Found`
never carries a Tag at all — not now, not later.** A pickup's own
`Tag` is read once, straight, at the one true moment a pickup `Deed`
truly lands (`Enact`, never `Perceive`) — through `TASK-036`'s own
`ITagSource`, keyed by the `Choice.ID` that `Deed.Holding` (`Choice`,
`TASK-019`, already built) already holds at that same true moment.
No tick before that moment ever reads a Tag at all — the hot path
(`Perceive`, every tick, every character) never touches a string.

```text
readonly struct TargetMark {
    public readonly string Tag;  // never null (ITagSource's own
                                  // rule, TASK-036); read once, at
                                  // Enact, keyed by Choice.ID
}
```

`update_inventory.key` reads `TargetMark.Tag` in place of a plain
`g_1042` id string — the whole real point of this task.

**"One entry per named item," made plain.** This never meant one
`GameObject` to one Tag — the strength below turns that around on
purpose. It means the Tag **list itself** (Unity's own Project
rules page, the catalog of names a Tag may hold) never holds two
different given ways of writing the one true kind of key (`"GoldenKey"` and
`"Golden_Key"` both standing for the same true thing) — a build-time
check, the same true shape as `germio`'s own `V036` (§ above), fed
the Tag list and every `Rule`'s own `condition` strings, checked
once, never on the hot path at all.

**How to check the logic — write these Red first (no Unity, once
`TASK-036` stands):**

1. a `Deed.Holding` truly taken, its own `Choice.ID` handed to a
   stand-in `ITagSource` answering `"GoldenKey"`, gives back a
   `TargetMark` whose `Tag` reads `"GoldenKey"`, whole
2. `update_inventory.key`, built from that `TargetMark`, reads
   `"GoldenKey"` — never the plain id string `g_1042`
3. this whole turn runs once, at `Enact` alone — never called from
   inside `Perceive`'s own loop (checked by a test double counting
   its own calls, held at `1` across a whole tick with many things
   found)

**A real, given strength found this same session, weighed hard
against, and not once broken:** where the object's own real name was
dropped for holding two given pieces to one name, a Tag turns that
same real fact around outright. More than one given key may share
one real Tag (`GoldenKey`), so any one picked up opens the same real
door — a whole real pattern (a locked gate needing only one key of a
matching set) `kind` alone could never once tell apart.

**Checked hard against, this whole real shape, three rounds run:**

+ "Pick up any one of three" reads as `condition:
  "inventory.GoldenKey >= 1"` alone — `germio`'s own `Evaluator`
  already reads such a line true (`EvaluatorTests.cs`).
+ Seeking more than one at once is no real, given trouble:
  `Perceive.Choose` already takes an `IReadOnlyList<Found>`, never
  one alone.
+ "Never pick up a spent key again" reads as `condition:
  "inventory.GoldenKey == 0"` on the pickup `Rule` itself —
  `EvaluatorTests.cs` already holds this same real line
  (`inventory.nonexistent == 0`), checked true.

No real crack was found in three rounds of hard checking. This whole
real shape stands ready, once `Runtime` and the Tag-reading piece of
it are truly built.

### TASK-023

**Done 2026-09-21.** `Scripts/Modio.asmdef` (referencing `Germio`,
`Animo`) and `Runtime/Modio.Runtime.asmdef` (referencing `Modio` as
well) both stand, the same two-part shape `germio` already holds.
`Runtime/` itself still holds no `.cs` file at all — the `.asmdef`
there is ready for `TASK-026` through `TASK-031` to fill.

**Modio holds no `.asmdef` at all today** — checked live, 2026-09-18.
`animo` holds four; Modio holds none. So no Unity project can take
Modio in as a package, and `Runtime/` (TASK-024), which must call
Unity's own `Physics`, has nothing to stand on. This was first noted
inside TASK-021 as one worry among three; it is split out here since it
is its own piece of work, needs no Unity open, and blocks TASK-024
outright.

**What to add:** `Scripts/Modio.asmdef` for the Unity-free core, and
`Runtime/Modio.Runtime.asmdef` referencing it, the same two-part shape
`germio` already holds (`Germio.asmdef`, `Germio.Editor.asmdef`). Both
are read by Unity, neither carries a `~` — see `docs/modio_spec.md`
§3.6. The `Scripts/Modio.csproj` used by `dotnet test` stays as it is;
the two build roads read the same `.cs` files and never write into each
other.

### TASK-024

**Done 2026-09-21, 14 tests** (the twelve below, plus two more —
a zero `halfYaw`/`halfPitch` finds nothing, held true after
2026-09-21's own second look — see the "Held" note further down).

**Build the wedge check — in `Scripts/`, with no Unity in it at all.**
Split out of the old TASK-024 on 2026-09-19, once it was seen that
only one line of stage one truly needs Unity. `StageGate.Worth` is the
standing example: the judging sits away from Unity, where a test may
reach it. The wedge check is the same kind of work, and belongs
beside it.

**What it holds:** given a `Self` (which way the character faces), the
three `Sight` values, a `Seek`, and a thing's own place and id, say
whether that thing falls inside the wedge. The whole of §3.7.3 but
step 1: the smaller-of-two joining of `Sight` and `Seek`, the turn
from a place into `yaw` and `pitch`, the ellipse check, dropping the
character's own id, and dropping an id already seen.

**Tests to write first, twelve of them:**

| #  | What it holds true                                                         |
| -- | -------------------------------------------------------------------------- |
| 1  | straight ahead (`yaw` 0, `pitch` 0) is always inside                       |
| 2  | straight behind is always outside                                          |
| 3  | dead on the side bound (`yaw` = `halfYaw`, `pitch` 0) is inside            |
| 4  | one degree past the side bound is outside                                  |
| 5  | dead on the up bound (`pitch` = `halfPitch`) is inside                     |
| 6  | at 45 degrees, the ellipse gives a different answer than a round cap would |
| 7  | where `Sight.reach` is the smaller, it is the one that holds               |
| 8  | where `Seek.spread` is the smaller, it is the one that holds               |
| 9  | a character with weak sight finds nothing where a keen one finds a thing   |
| 10 | turn `heading` by 90 degrees and the wedge turns with it                   |
| 11 | the character's own id is never given back                                 |
| 12 | the same id twice comes back once                                          |

**6 and 9 are the two that matter most.** 6 holds the ellipse itself
true — a round cap would pass every other test here. 9 holds true the
one thing the whole two-layer design was for: that a character of
weak sight fails a deed a keen one carries, with no line of code
telling it to.

**No garbage here either.** The check takes what it is given and
writes into a list made by the caller; it makes nothing of its own,
and never reads a `name`.

### TASK-025 — retired, split 2026-09-20

**This task grew too large to hold as one piece, and gave up on a
real test besides.** Five different pieces stood inside it, and the
only check named was "by eye, in a real Windows Unity open." `germio`
holding `Sight` itself (`sight_checklist.md` §4.7) split the first
piece away outright. The rest is split into `TASK-026` through
`TASK-036` below, each its own piece, each with its own true test —
matching how `TASK-009` already proved zero garbage by a real,
running test, not a read of the Profiler by eye.

**Held, 2026-09-20 — how a thin edge and its own logic are wired
together.** Unity cannot hold an interface in `[SerializeField]`
directly. So each edge below (`TASK-026`, `027`, `028`, `030`) is a
plain `MonoBehaviour` that implements its own interface
(`ISightSource` and the rest); the logic piece behind it
(`TASK-032`–`035`) holds a plain field of the interface's own type,
set once, in `Awake`, by `GetComponent<T>()` on that same
`MonoBehaviour`. No `[SerializeField]` ever names the interface
itself — only the concrete edge type is ever placed in the
Inspector.

**Held, 2026-09-20 — where a trigger is dropped, settled once, not
twice.** The old draft had `RawHit` itself carry `IsTrigger`, and
`TASK-034` drop it again — a hit the edge could never truly hand
over in the first place. **Trigger drop happens once, at the edge
alone** (`QueryTriggerInteraction.Ignore`, inside `TASK-028`).
`RawHit` never carries a trigger mark at all, and no logic test
below asks after one.

### TASK-026

**The thin Unity edge alone — one call, reading germio's own
`Sight`.** No logic of its own stands here: it reads `reach`,
`halfYaw`, `halfPitch` and `eyeHeight` from germio's own `Sight`
component, once at start, through the new `ISightSource` interface
below. **No separate logic task stands behind this one** (`TASK-033`
was dropped, held there for why) — a plain copy of four numbers,
with no branch in it, is this task's own Play Mode test, not a
second task.

```text
interface ISightSource {
    float Reach { get; }      // > 0, meters (Unity's own unit)
    float HalfYaw { get; }    // > 0 and <= 180, degrees
    float HalfPitch { get; }  // > 0 and <= 180, degrees
    float EyeHeight { get; }  // meters, above the body's own root
}
```

**Contract:** every value is held true by germio's own `Sight`
Inspector fields (`[Range]` there, not checked again here) — Runtime
trusts them, never throws on them, never branches on them at all.
**Held, 2026-09-20: this trust rests on germio's own `TASK-069`
truly holding `[Range]` on every one of the four fields — not yet
checked, since `TASK-069`'s own words are changed but its code is
not yet built.** `TASK-026`'s own Play Mode test only proves the
four numbers read back whole; it does not, and cannot, prove germio
truly holds them inside a given range. This trust stays open across
the two repository roots until `TASK-069` stands built and its own test
runs. What happens if germio's own `Sight` is destroyed mid-play,
once `TASK-026` already cached it at `Awake`, is not yet closed —
held open, out of scope for this split.

A real `Sight` (in germio) implements this; nothing past the
interface's own four lines may be Unity-shaped. **How to check it:**
a Play Mode test, one prefab holding a real `Sight`, checking the
four numbers read back whole.

### TASK-027

**The thin Unity edge alone — one call, `transform.forward`.** Turns
a body's own forward line into a plain `Vector3`, handed to
`IHeadingSource` below (`TASK-032` holds the logic that turns it
into `Self.Heading`, a `float`).

```text
interface IHeadingSource {
    Vector3 Forward { get; }  // a unit vector, never zero — Unity's
                               // own Transform.forward is always
                               // unit length by its own contract
}
```

**How to check it:** a Play Mode test, turning a prefab and checking
`Forward` reads back what the prefab truly holds. The turn from
`Vector3` into one `float` of heading is `TASK-032`'s own work, and
needs no Unity at all.

### TASK-028

**The thin Unity edge alone — one call,
`Physics.OverlapSphereNonAlloc`.** Fills a `Collider[16]`, then hands
each hit through `IBroadPhaseSource` below as a plain record — never
a real `Collider` past this one line. `TASK-034` holds every piece
of logic once held here: the buffer cut-off, trigger drop, the wide
collider's own `ClosestPoint`, and the hand-off into the wedge check
(`TASK-024`).

```text
readonly struct RawHit {
    public readonly int Id;      // GetInstanceID()
    public readonly Vector3 ClosestPoint;
}
interface IBroadPhaseSource {
    // origin: where the sphere's own center stands (the eyes, per Sight).
    // radius: how wide the sphere reaches — held true 2026-09-21, found
    // missing here on the first real try at writing the true edge.
    // buffer: allocated once by the caller (TASK-034), fixed at 16,
    // never null, never zero-length — a rule the caller must hold, not a
    // case Find itself must guard.
    // returns: the count truly found, always in [0, buffer.Length].
    // Indices at or past the count are left unspecified (stale) —
    // callers read only [0, count). No order is promised among the
    // filled slots.
    int Find(Vector3 origin, float radius, RawHit[] buffer);
}
```

**Settled 2026-09-19, kept here as true against a real scene, moved
from the old `TASK-025`: stage one passes
`QueryTriggerInteraction.Ignore`.** Counted in `stemic`'s own
`Level_1`: of every collider there, only three are triggers —
`Despawn`, `RayBox`, `MainCamera`. `Ground` and `Block`, what a seek
is truly after, are plain colliders. Dropping triggers loses nothing
sought. **Watched:** `germio` holds `Home` as a kind, `poc_pair.json`
holds `GoHome` as an act, but no `Home` stands in `Level_1` today —
check whether one, once put down, is a trigger.

**How to check the edge alone:** a Play Mode test, a held scene,
checking `RawHit[]` reads back what the scene truly holds — real
ids, real closest points, and never past the true count. `TASK-034`
reads this same `IBroadPhaseSource`, and needs no Unity at all.

### TASK-029

**The name interface — Modio asks, germio answers.** One call, an
`int` id in (`GetInstanceID()`, no boxing), a kind and an id string
out. Modio holds the interface; germio's own world table (`TASK-067`)
answers it — the same shape `IMind` already holds toward `animo`
(`TASK-021`). Already shaped this way; no change owed here.

**Held, 2026-09-20: an id germio's own table has never held.** Reads
back an empty `kind` and an empty id string — the same, standing
shape `Choice.None()` already holds for "nothing found" — never
`null`, never thrown. `TASK-024`'s own wedge check already drops a
`Found` whose kind reads empty, so this same empty-string answer
falls straight into ground already proven true.

**How to check it — write these Red first:**

1. a known id answers with its own true kind and id string, whole
2. an id the stand-in has never held answers with an empty kind and
   an empty id string — never `null`

**How to check it:** **this piece alone may be proved by a plain
`dotnet test`**, unlike every other Unity-edge piece here — the
interface itself asks nothing of Unity. Write a stand-in answering a
known id with a known kind and string; check Modio's own calling
code reads it back whole. A second, Play Mode test then checks
germio's own table gives the same answer for real.

### TASK-030

**The thin Unity edge alone — one call, `Physics.Raycast`.** A
single ray from the eyes toward one thing stage one already held
worth it, handed through `IRaySource` below as a plain record.
`TASK-035` holds the logic reading what came back.

```text
readonly struct RawRay {
    public readonly bool Hit;
    public readonly int Id;      // meaningful only when Hit; 0 when not
}
interface IRaySource {
    // direction: a unit vector, the ray's own line — never a point
    // to reach toward (renamed from "toward" to hold this plain).
    // reach: > 0, the ray's own most far reach in meters.
    RawRay Cast(Vector3 from, Vector3 direction, float reach);
}
```

**Contract:** `direction` is always a unit vector handed in by the
caller (`TASK-035`'s own logic, itself reading `Choice`/`Found`'s own
`Angle`, already a settled direction — never a raw point). A zero or
non-unit `direction`, or a `reach <= 0`, breaks a rule the caller
must hold, not a case `Cast` itself must answer for. **Held,
2026-09-20: a thing at the exact edge, at `reach`'s own true
distance, is held true (`<=`, not a strict `<`)** — matching Unity's
own `Physics.Raycast`, which asks for `maxDistance` under this same
rule.

**How to check it:** a Play Mode test — a wall between the eyes and
a thing; `Hit` reads false, or `Id` reads the wall's own id, never
the thing past it. A clear line; `Id` reads the true thing's own id.
A thing set at `reach` less a hair still reads true; past `reach`
by a hair reads false — the edge itself, matched close as a real
scene allows.

### TASK-031

**Held, 2026-09-21 — set right, after being held wrong.** This task
once called for a real, running Unity test (`[UnityTest]`, Unity's
own Test Runner) to prove zero garbage across a whole tick. **Checked
against the whole of this family's own true history: no repository
here has ever once run a test inside Unity itself.** Every
`EditModeTests` folder, in every repository, runs through a plain
`dotnet test` alone — the name never meant a real Unity Editor ran
it. Building a real Unity Test Runner piece for this task alone
would have been the first of its kind, never once asked for, and is set aside
outright.

**Held true instead, matching this family's own real practice:**
proving zero garbage across a whole tick — `Runtime`, whole, once
`TASK-026` through `TASK-030` (the thin edges) stand — is checked
**by eye, in a real Windows Unity open, with the Profiler's own GC
Alloc column held at zero through a whole round.** The same true
words the old `TASK-025` already held. `TASK-032` through `TASK-036`
(the logic behind each edge) already carry their own real,
`dotnet test`-checked zero-garbage proof; this task is only the
whole, put together, checked the one way this family truly checks
Unity-true things.

**Held, 2026-09-21, checked live: a real hole in "zero garbage",
found and closed once already, held open here as a true warning.**
`BroadPhaseLogic.Gather` and `WedgeCheck.Worth` both take a
`List<T>` the caller holds — but a `List<T>` still at its own
starting size of 0 makes new, once, the first time anything is ever
added to it (checked live: 72 bytes, one `Add` on an empty list).
**`Runtime` must give each list a true starting size
(`new List<Place>(16)`, `new List<Found>(16)`) once, at
`Awake` — never a fresh, empty list, tick after tick.** This one
line, missed, would fail this whole task's own bar on its first real
run.

### TASK-032

**Done 2026-09-21, 7 tests.**

**The heading logic — split from `TASK-027`, needs no Unity at
all.** Takes an `IHeadingSource` (a plain `Vector3`, `TASK-027`'s
own edge) and turns it into `Self.Heading`, the one `float` §3.7.5
asks for. **Held, 2026-09-20: the body may lean (a slope, a step),
but `Self.Heading` stays level (§9.2-8's own held word). So this
logic first drops `Forward`'s own `Y`, then makes the flat `X`/`Z`
that remains a unit vector again, before ever turning it into an
angle.** A `Forward` handed in as `Vector3.zero` is a caller's own
mistake (never a true value from a real `Transform`) — not a case
this logic need answer for.

**Held, 2026-09-20, a second time — dropping `Y` may itself leave
almost nothing.** A `Forward` leaning close to straight up or down
leaves a flat `X`/`Z` close to `Vector3.zero` too, the very hole
`Forward`'s own true rule was held to close, come back through
the side door. **Closed: this logic holds its own last true
`Heading`, as a small, given field — not a pure turn from one
`Vector3` alone.** When the flat length falls under a small, given
mark (`0.001`), `Heading` is left unchanged, holding its last true
value, rather than turned from a shaking, near-zero line. A real
body walking `stemic`'s own `Level_1` never leans this far, so this
path stands mostly untouched — but a defined, tested answer stands
ready all the same.

**How to check it — write these Red first:**

1. straight down the world's own `+Z` reads `0`
2. turned a quarter reads `90`
3. turned by half reads `180`
4. turned three-quarters reads `270`
5. a small, given `Vector3` noise (unit length, off by a hair) still
   reads within a small, named error of the true heading
6. a `Forward` leaning well up (a real slope's own sharp angle,
   `Y` far from `0`) still reads the same flat heading as the same
   direction with no lean at all — proves the drop-`Y`-then-turn
   order holds true
7. a `Forward` given straight up (`(0, 1, 0)`, flat length near
   zero) leaves `Heading` unchanged from whatever it last truly held
   — proves the near-zero hole is closed by holding still, not by an
   shaking turn

**How to check zero garbage:** run the turn 10,000 times against one
`IHeadingSource`; `GC.GetTotalAllocatedBytes` must show **0**,
matching `TASK-009`.

### TASK-033

**Dropped 2026-09-20, held here for why.** This task asked only to
copy four numbers from `ISightSource` straight through, with no
branch, no choice, no logic of any true kind — the same real shape
as `TASK-026`'s own edge, dressed as a second task for no true
reason past matching the shape of `TASK-032`/`034`/`035`/`036`. A
Red test with no logic to make it fail is not a true Red test.
**Folded back into `TASK-026`:** the four-number read-back the old
`TASK-033` asked for is `TASK-026`'s own Play Mode test, already
named there — no second task is owed.

### TASK-034

**Done 2026-09-21, 6 tests** (the four below, plus two more from
2026-09-21's own second look — an empty `own_id` never drops a
not-yet-named thing, and the `places` list's own first-`Add` cost is
now held as a written warning, not a hole).

**The broad-phase logic — split from `TASK-028`, needs no Unity at
all.** Takes an `IBroadPhaseSource` (`TASK-028`'s own edge, a plain
`RawHit[]`) and hands each true hit into the wedge check (`TASK-024`,
already built). Holds every piece of logic once held together inside
the old `TASK-025`.

**How to check it — write these Red first (most already proven
true, alone, by `TASK-024`; checked again here with a real edge
standing in front):**

1. a source returning 20 hits into a 16-slot buffer reads back 16,
   and a warning is made
2. a hit whose `ClosestPoint` sits outside the wedge, but whose
   collider is wide, is still found (matches `TASK-024`'s own test 6
   and 9)
3. the character's own id, found among the hits, is dropped (matches
   `TASK-024`'s own test 11)
4. one id, found twice among the hits, is read once (matches
   `TASK-024`'s own test 12)

**How to check zero garbage:** run against a fixed `IBroadPhaseSource`
10,000 times; `GC.GetTotalAllocatedBytes` must show **0**.

### TASK-035

**Done 2026-09-21, 4 tests.**

**The ray-result logic — split from `TASK-030`, needs no Unity at
all.** Takes an `IRaySource` (`TASK-030`'s own edge) and turns
`RawRay` into what `Choice` (`TASK-019`) or a `Found` (`TASK-024`)
still needs — a true, given thing, or none at all.

**How to check it — write these Red first:**

1. `Hit == false` reads as nothing found, whole
2. `Hit == true`, `Id` matching what stage one already held, reads as
   that same thing, found true
3. `Hit == true`, `Id` matching neither what stage one held nor the
   wall between — a thing not asked after — is dropped, not held as
   a false true
4. `Hit == false`, with `Id` handed in as a real, given value (never
   `0`, as if the edge broke its own contract) still reads as nothing
   found — proves the logic checks `Hit` first, and never reads `Id`
   on its own

**How to check zero garbage:** run against a fixed `IRaySource`
10,000 times; `GC.GetTotalAllocatedBytes` must show **0**.

### TASK-036

**Done 2026-09-21, 4 tests.**

**The Tag logic — split from `TASK-022`'s own drafted third path,
needs no Unity at all.** Takes an `ITagSource` (a plain `string`, the
Unity edge's own `GameObject.CompareTag` wrapped thin) and turns a
Tag string into what a pickup `Rule` needs — the same true shape
`Like()` already holds for `kind`.

```text
interface ITagSource {
    string Tag { get; }  // never null — Unity's own GameObject.tag
                          // is never null, "Untagged" by default
}
```

**Contract:** matched exact, case-sensitive against a known string
(`"GoldenKey"`), the same true way `GameObject.CompareTag` itself
compares — no folding of upper and lower case, ever.

**How to check it — write these Red first:**

1. a known Tag (`"GoldenKey"`) reads back as that same string, whole
2. an empty Tag (Unity's own default, `"Untagged"`) reads as no Tag
   held at all
3. two different given ids, both handed the same Tag string, both
   read back that one Tag — proves more than one key may share one
   real Tag, the strength `TASK-022` itself found
4. a Tag handed in with the case changed (`"goldenkey"`) reads as a
   different Tag from `"GoldenKey"` — no folding of case, ever

**How to check zero garbage:** run the read 10,000 times against a
fixed `ITagSource`; `GC.GetTotalAllocatedBytes` must show **0**.

**The thin edge itself (`GameObject.CompareTag`) stays inside
`TASK-022`'s own real, given work, still owed: a real check that
`stemic`'s own Tag list holds one entry per named item, and how
`Found`/`TargetMark` carries the Tag's own text through to
`update_inventory.key`. That real, given check still needs a real
Windows Unity open — `TASK-036` above only takes the string-logic
away from it.**

### TASK-037

**Found true, held 2026-09-21: `germio`'s own `WorldNames`
(`TASK-067`, germio's own repository, built and Green) and `Modio`'s
own `INameSource` (`TASK-029`) were built apart, with no line
joining either to the other.** The same true hole `TASK-021` once
found between `IMind` and `animo`'s real `Engine` — found again,
here, and closed the same way.

**`NameSourceAdapter` turns `Modio`'s own `INameSource` ask into a
real `IWorldNamesFacing` call** (`Scripts/Core/IWorldNamesFacing.cs`,
the true shape of `germio`'s own `WorldNames.NameOf`, held here with
no tie to `germio` at all — the same option B choice `TASK-021`
made). A stand-in implements `IWorldNamesFacing` for testing; the
real `germio.WorldNames` is wired in later, through a thin piece not
built here.

**Held true, 2026-09-21: this piece holds real logic of its own, and
is not `TASK-033` come back.** `TASK-033` was dropped for holding no
branch at all — a plain copy, dressed as a task. Here, the
constructor's own `null` check is real, given logic, checked below;
`NameOf` alone is a plain pass-through, and is not tested by itself —
only through the constructor's own true guard.

**How to check it — write these Red first:**

1. `NameOf`, called on a `NameSourceAdapter` built around a given
   `IWorldNamesFacing`, reads back exactly what that stand-in itself
   answers, whole
2. building a `NameSourceAdapter` around a `null` table throws
   `ArgumentNullException`, at once — never later, and never quietly

**Everything still owed on the sight design is held in one place:**
`docs/sight_checklist.md` — what the spec marks open, what it never
says at all, and what cannot be known until it runs, with the order
to take them in.

**Not settled, and to be weighed before building:** whether `Sight`
is read once at start or every tick (a character in the dark may see
less); today it reads once. Whether `Self.Heading` staying one
`float` (no up or down in the character's own facing) is right;
today the wedge stays level.
