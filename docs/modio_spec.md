# Modio Specification

> **Tulving-driven Memory and Seeing Ahead, for Game Agents**
> **v0.0.3** (seeking moved in, 2026-08-21) / written again from nothing v0.0.2 / first draft 2026-08-20
> STUDIO MeowToon — h.adachi

---

## About this document

This is the **English reference spec** for Modio, the HOW layer.
It follows the project writing rule
(`docs/standard/writing_standard.md`), so readers whose first
language is not English can read it with no trouble.

Style rules:

+ Short sentences. One idea per sentence.
+ Active voice. Do not use the passive form where you can help it.
+ Technical words stay as they are; each is given its sense in
  `docs/standard/tech_terms.md`.
+ Avoid long chains of describing words.
+ Common verbs and nouns. Do not use rare words.

### Why this was written twice over

v0.0.1 held a way out: where the sensor was missing, it said a
meeting would do instead. **That was wrong, and it was wrong in a
way this family has already paid for once.**

`animo` was built to a very high bar on the inside — 452 tests, no
garbage on the hot path, five rounds of hard questioning — and then,
the first day it met a real game, a whole side of it was found
missing: it knows no place at all. Building inward, and calling the
outside somebody else's work, is how that happened.

**Reaching for a meeting in place of a sensor is that same move.**
A meeting is two bodies touching. A sensor finds a thing that is
still far off. **One waits; the other looks.** A character that
waits to knock into a friend is not seeking company, whatever `animo`
may have wanted.

v0.0.2 held no way out, and named the sensor in `germio` as the one
thing that had to come first.

v0.0.3 went further. Held up against what Modio truly asks, the
`germio` sensor plan broke in three places — and all three came from
one cause: **seeking had been cut off from remembering.** So seeking
moved here, beside memory. See §3.3.

---

## 1. What the HOW layer is for

### 1.1 The three questions

| Repository | Question | Holds     |
| ---------- | -------- | --------- |
| `germio`   | WHAT     | the world |
| `animo`    | WHY      | the want  |
| `modio`    | HOW      | the deed  |

### 1.2 The one job

**Modio carries a want through, inside a world.**

`animo` gives one Behavior — a plain string — every true tick. It
holds no place, no thing, no other agent, by design. `germio` holds
a world that moves, but knows nothing of want.

**Between a want and a world lies everything that makes the want
real.** That is Modio.

---

## 2. The three powers

To carry a want through, Modio must be able to do three things.
**Not one of them may be left out.**

### 2.1 Perceive — to know the world

A want cannot be carried through by a character that knows nothing.
**"I am alone, so I look for someone" — looking is a thing done on
purpose.**

| Way of knowing | What it is                                                                 |
| -------------- | -------------------------------------------------------------------------- |
| **Seeking**    | **on purpose** — finding a thing still far off                             |
| Meeting        | by chance — two bodies touch. **Proof of arrival, never a way of seeking** |

**Seeking belongs to Modio itself.** It was once meant to sit in
`germio`, as a sensor there. That was wrong, and §3.4 sets out why:
seeking and remembering are one act, and splitting them across two
apart builds breaks both.

### 2.2 Remember — to hold a past

Knowing the world as it is now is not enough.

+ "A want for new places" needs someone who knows which place is new.
+ "A want to give" needs someone who knows who was given to already.

`animo` holds the state of now, and no past at all. `germio` does hold
a past — `Store` keeps a history of the game (§4.2) — but it is the
**world's** past, one for all: "a rule fired", "a node was entered".

**Modio holds a past of its own: what *this one character* did.** That
is what Tulving's own memory of living means, and no other layer has
it.

### 2.3 Enact — to carry a thing through over time

A want is of the moment. **A deed takes time, and may fail part way.**

`animo` says `"Explore"` this tick, and again the next. It never
learns whether the character truly went anywhere.

### 2.4 The three powers are Tulving's own claim, laid out

| Power    | Time                      |
| -------- | ------------------------- |
| Perceive | now                       |
| Remember | past ⇄ what is to come    |
| Enact    | now, reaching a little on |

Tulving held that the true point of the memory of living is not
looking back. It is that **the same paths let a mind picture what is
to come.** So Remember faces both ways by nature, not as an added
part.

This is settled science, not a guess: work on people who have lost
their memory, shared brain activity seen in scans, and studies of
what people do, all point the same way.

---

## 3. Perceive

### 3.1 Seeking is the ground everything else stands on

Every want that reaches outside the character needs seeking:

| Want                    | What must be sought           |
| ----------------------- | ----------------------------- |
| Go to another character | that character, still far off |
| Find a new place        | a place not yet met           |
| Go where it is safe     | a known, held place           |
| Give a thing            | who to give it to             |

**Meeting cannot stand in for any of these.** A body that waits to
be run into does not seek. It waits.

Real sums, on a field 30 steps across, two characters set down at
random: seeking brings them together in **8 seconds**; waiting to be
run into takes **316 seconds** — forty times longer. `loneliness`
climbs at 1.0 a second and stops at 100. **Waiting means it is pinned
at the top long before they meet, and never falls again.** The want
is not slowed. It is broken.

### 3.2 Perceive reports, and never judges

§2.4 gives Perceive one time only: **now**.

| Belongs to Perceive                     | Belongs elsewhere                          |
| --------------------------------------- | ------------------------------------------ |
| "a Ground sits 2.0 ahead, 3.0 below"    | "that is a fall; keep away" — **Remember** |
| "a Human sits 8.5 off, 20 degrees left" | "go to them" — **Enact**                   |
| "a Block sits 1.0 ahead, 0.5 up"        | "that can be climbed" — **Enact**          |

**Where Perceive judges, the line between the three powers is lost.**
An early draft had Perceive hand back how wide and deep each
thing was, so a fall could be worked out from that. That was
Remember's work, slipped in where it did not belong. It was cut.

### 3.3 What Perceive hands back

Five fields. Not one more.

```text
kind      what it is
id        which one it is
angle     how far round, from straight ahead
distance  how far off
height    how far up or down, from where the feet are
```

**Why each one, and no other:**

| Field      | Why it must be there                                                     | Ground for it |
| ---------- | ------------------------------------------------------------------------ | ------------- |
| `kind`     | `seek` names a kind (`"Ground"`, `"Human"`), and something must match it | §3.4          |
| `id`       | memory's own `object` column must name the same thing twice, on two days | §4.1          |
| `angle`    | Enact turns the body before walking (`face`)                             | §5            |
| `distance` | `until` with `near` needs a number to test                               | §5            |
| `height`   | how far up or down a thing sits, from where the feet are                 | §4.3          |

**What is left out, and why:**

| Left out                             | Why                                                                                           |
| ------------------------------------ | --------------------------------------------------------------------------------------------- |
| How wide, how deep, how big          | Judging a fall from size is Remember's work (§3.2)                                            |
| `Vector3`, `Transform`, `GameObject` | Perceive must be open to a check with no Unity at all (§3.6)                                  |
| Whether it may be held               | That is `germio`'s own live state, read at the moment of taking, not seen from a distance     |
| The full name string                 | `kind` and `id` say all Modio needs; a name would draw a reader into taking meaning out of it |

### 3.3.1 `id` — how a thing is known to be the same thing twice

`id` is Unity's own `GetInstanceID()`. Every `GameObject` carries one
already; nothing is added, nothing is attached.

Three other ways were weighed, and each was dropped:

| Tried                      | Why it was dropped                                                                                                                                                                                    |
| -------------------------- | ----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- |
| The object name            | **Not one to a piece.** Counted 2026-08-21: `Level_1` holds 24 pieces, and three names are used twice over — `Ground_5.0x0.5x5.0_Green_2`, `Ground_5.0x0.5x5.0_Green_1`, `Block_1.0x1.0x1.0_Green_1`. |
| A mark added to each piece | It would take a `MonoBehaviour`, and `germio`'s own `Common` runs three `FixedUpdate` chains. On 24 pieces that is 72 chains, every step of the motion work, for nothing.                             |
| Where it stands            | Two ways of doing one job, one for things that move and one for things that do not. **One way, no exceptions.**                                                                                       |

**Written out, an `id` takes a letter in front: `g_1042`.** Measured
2026-08-21 against `germio`'s own `ExprLexer`: a value inside
`history.count(kind=..., target_id=...)` must be an Identifier, and an
Identifier is `[a-zA-Z_][a-zA-Z0-9_-]*` — **it may not start with a
number.** `GetInstanceID()` gives back a plain number, so `1042` on its
own would throw at parse time. `g_` in front makes it hold, and costs
nothing.

This also settles a whole row of edge cases: a number can hold no
space, no dot, no round mark, so the written-out `id` can never break an
expression it sits inside.

`GetInstanceID()` is made new when a scene is read again — and that is
right, not wrong. **A scene read again is a world built new: the
old pieces are gone.** A memory of a piece that no longer stands has
lost what it spoke of, and should go with it.

**This holds only for things near by.** A memory of another character,
or of a place, is named otherwise and lives on — see §4.5.1.

### 3.3.2 `heading` — which way the character itself faces

`Perceive` hands back one thing more, and it is not about a thing
found. It is about the character:

```text
heading   which way it faces, against the world
```

Two jobs need it:

+ **Writing a place down.** `angle` and `distance` are told from where
  the character stands. To keep where a thing was, they must be turned
  into a place in the world — which takes `heading`.
+ **"South is done; try north."** A way cannot be named without a
  fixed sense of which way is which.

This does not widen §3.3. Those five fields tell of a **thing found**;
`heading` tells of **the character**. Two reports, not one.

### 3.4 The world is read the way `germio` names it

`germio`'s own `Env.cs` holds the marks a thing is known by:

```text
GROUND_TYPE  = "Ground"     the floor underfoot
BLOCK_TYPE   = "Block"      a solid thing in the way, or to climb
WALL_TYPE    = "Wall"       a bound not to pass
PLAYER_TYPE  = "Human"      a character, player-led or not
ITEM_TYPE    = "Item"       a thing that may be taken
HOME_TYPE    = "Home"       a place come back to
```

`germio` reads these by name — `Like(type)` is `name.Contains(type)`
— and has done so through all three builds (`super-nekokun`, then
`germio`, then `tropika`).

**Perceive reads the world by the same marks.** Not by Unity layer:
`stemic` holds only Unity's own five stock layers (Default, Water,
UI, one for see-through art, and one that lines pass through) with no Block, Ground or
Player layer at all — a check on 2026-08-21. Not by the name a piece
was built under, either: the size written into such a name
(`Ground_10.0x0.5x10.0_Green`) is `briko`'s own doing, for laying
out a level in the Editor, and is no part of what a character sees.

**So `kind` is one of `germio`'s own marks, and nothing else.** Where
`germio` gains a mark, Modio gains a kind. Where it does not, Modio
cannot invent one.

### 3.5 How a seek is asked, and answered

```text
asked:    kind, reach, spread, and what memory to leave out
answered: every thing found, nearest first
```

| Asked           | Sense                                                           |
| --------------- | --------------------------------------------------------------- |
| `kind`          | which of `germio`'s own marks to look for                       |
| `reach`         | how far out to look                                             |
| `spread`        | how far round to look, in degrees                               |
| `not_in_memory` | which memory mark to leave out (`met`, `gave`, `shown`, `edge`) |

**Every thing found comes back, not one.** An early draft gave back
one thing only. It broke at once: "a place not yet met" needs the
whole near set, weighed against memory. One thing back, already met,
leaves no second try.

Nearest first, so that where two are alike, the near one wins with no
further sorting.

### 3.5.1 What is new, what is gone, what has moved

Each tick, what `Perceive` hands back is set against what memory
holds. Three answers come out:

| Where it sits           | What it means                      | Used for                          |
| ----------------------- | ---------------------------------- | --------------------------------- |
| in both                 | seen before                        | not new any more                  |
| **found only now**      | **never seen**                     | the mark of a want for new places |
| **held only in memory** | **gone: broken, taken, or hidden** | stop reaching for it              |

This is how a virtual DOM works, turned to a different end. A virtual
DOM sets a copy against the real thing to **write the real thing
back**; Modio sets what it sees against what it holds **to know what
has changed**, and writes nothing.

**And this is why `id` cannot be dropped.** With no `id`, "three
blocks" against "three blocks" says nothing at all. With `id`, a piece
that has gone is known to have gone.

The four ways `germio`'s own world moves are all met here:

| In the world | In the answer                                                          |
| ------------ | ---------------------------------------------------------------------- |
| broken       | held only in memory                                                    |
| made         | found only now                                                         |
| carried off  | held only in memory (out of sight)                                     |
| **moved**    | **same `id`, new `angle` and `distance`** — known to be the same thing |

The last is the one a virtual DOM keeps a `key` for. Without `id`,
a thing that moved would read as one thing gone and another made.

### 3.6 Two parts, held apart

| Part       | Does                                                                | Knows Unity? |
| ---------- | ------------------------------------------------------------------- | ------------ |
| `Runtime/` | asks Unity's own `Physics`, and turns each hit into the five fields | yes          |
| `Scripts/` | takes that list, weighs it against memory, and picks one            | **no**       |

This is the shape `signo` already holds, with its own `Scripts` apart
from `Audition~`, and `quyno` with its own `Core` apart from
`Bridge~`. **Modio's own two are named `Scripts/` and `Runtime/`,
neither with a `~`**: unlike `Audition~` or `Droid~`, both are read by
Unity, since Modio is taken in as a package.

**Why it must be so:** `animo` proved itself with 452 tests, no
garbage on the hot path, and a runner giving the same answer every
run — all because it holds no place at all. Modio must hold places.
**If judging and Physics sat in one part, none of that could be
proved.** Held apart, the judging takes a plain list, and a test may
write that list by hand:

```text
self:    heading=90
given:   Ground/id=1042  angle=20   distance=8.5   height=0.0
         Ground/id=1055  angle=-45  distance=12.0  height=0.0
memory:  actor=place_curious_01, deed=met, thing=1042
asked:   kind=Ground, and not met
then:    id=1055 is picked
```

No Physics. No Transform. Same answer, every run.

### 3.7 What `Runtime` does, and what it costs

Two stages, carried over from the older plan that once sat in
`germio`:

| Stage | What                                                       | How often                            |
| ----- | ---------------------------------------------------------- | ------------------------------------ |
| One   | a wide, cheap check — is anything near at all              | every tick                           |
| Two   | a straight-line check — is it truly in sight, and how high | only where stage one finds something |

Measured on `stemic`: every Ground and Block piece carries a
`BoxCollider`, with no `MeshCollider` anywhere, so a straight-line
check against one stays cheap. **The saving is in not running stage
two every tick, for every character.**

`Level_1` holds 24 pieces set down, from 8 kinds. A wide check at 30
reach turns up a few, not a great number. **A fixed list of 16 holds
every case seen so far**, and `Runtime` fills the same list again each
tick, so nothing is made new.

**How many characters at once: 64** (Master's own word, 2026-08-21).
Worked out at 50 ticks a second:

| What                       | How much                                                            |
| -------------------------- | ------------------------------------------------------------------- |
| Stage one, wide and cheap  | 64 × 50 = **3,200 a second**                                        |
| Stage two, one line thrown | only where stage one finds something — at 3 in 10, **960 a second** |
| Memory, all 64 together    | 15 rows each = 960 rows, near **37 KB**                             |
| The found-list             | 16 to a character, filled again each tick, never made new           |

**Every character runs, seen or not** (Master's own word): one that
walked off screen goes on wanting, seeking, and remembering, so a
player coming back finds it somewhere else, doing something else.
Holding still what cannot be seen would be cheaper, and would make the
world stop where no one looks. **Should the cost ever bite, that is
when to weigh it** — see §9.

### 3.7.1 What stands in the way is not seen

Stage two throws one straight line. Where a wall or a block stands
between, the line stops there.

```text
character ────────█────── the other one
                block

the line meets   : the block
Perceive hands back: the block. Not the other one.
```

**Modio is not told that something was hidden.** To it, this reads the
same as an empty field. That is right: a person cannot tell, by
looking, whether someone walked away or stepped behind a rock.

What follows from it:

| Then                               | And so                                           |
| ---------------------------------- | ------------------------------------------------ |
| A deed finds nothing               | it ends **Failed**; no `Affect` is called        |
| The Need does not fall             | `animo` asks for the same thing again, next tick |
| Something known drops out of sight | it reads as **held only in memory** (§3.5.1)     |

**And this is what makes seeking worth doing at all.** A place behind
a wall is not handed back, so it stays never-seen until the character
walks round. **With nothing in the way, one could stand still and take
in the whole world.**

### 3.7.2 The same power serves more than Modio

Seeking asks one plain question — *what of this kind stands within
this reach and this spread, with nothing in the way* — and more than
one caller wants the answer:

| Caller                    | Why                              |
| ------------------------- | -------------------------------- |
| A deed, in Modio          | to carry a want through          |
| **`flugi`'s own `Radar`** | **to draw marks on a screen**    |
| A drop-off check          | to keep from walking off an edge |

`angle` and `distance` are just what a radar draws; a thrown line
hides what stands behind a hill; `id` is a mark with no name to build.

**So seeking is written to be called from outside Modio, not only by a
deed.** Whether `flugi` takes it up is `flugi`'s own call, and belongs
in `flugi`'s own task list, not here.

### 3.8 Meeting is proof of arrival

A meeting (`OnCollisionEnter`) says one thing, and says it well:
**"you got there."**

|         | Seeking                   | Meeting                |
| ------- | ------------------------- | ---------------------- |
| When    | before, from far off      | at the moment of touch |
| Says    | "the thing is over there" | "you are here"         |
| Used by | `seek`                    | `until`                |

**Modio uses a meeting to close a deed, never to open one.** This is
why `seek` will not take a meeting, in any form, ever.

## 4. Remember

### 4.1 The four posts

Tulving set out what a memory of living is made of: **who, when,
where, what.** Modio holds these four, and holds nothing else.

| Post      | Column  | Sense                                           |
| --------- | ------- | ----------------------------------------------- |
| **who**   | `actor` | whose memory this is                            |
| **when**  | `at`    | the time it happened                            |
| **where** | `place` | the stretch of world it happened in             |
| **what**  | `deed`  | `met`, `held`, `gave`, `shown`, `asked`, `edge` |
|           | `thing` | what it was done to (an `id`, may be empty)     |
|           | `other` | who it was done with (an `id`, may be empty)    |

Six columns, four posts. `what` takes three, because a doing has a
shape: **what was done, to what, and with which other.**

**A row is written only where a deed ends Done.**

### 4.2 Why `actor` must be a column

`germio` already holds a past. `Store.RecordHistoryEvent` writes
`kind`, `target_id` and `timestamp` — three of the same four posts.
`docs/dsl_cookbook.md` §7 reads them back with
`history.count(kind=..., target_id=...)`.

**What it does not hold is `who`.** There is one `Store` for the whole
game, so its past is the **game's** past: "a rule fired", "a node was
entered".

| Held by            | Whose past            | How many                  |
| ------------------ | --------------------- | ------------------------- |
| `germio`'s `Store` | the world's           | one, for all              |
| **Modio**          | **a character's own** | **one to each character** |

Tulving's word for a memory of living is first-person by
definition — **what *I* did.** Take `who` away and it is no longer
that kind of memory at all.

Two characters given minds, both asking the same thing, show it
plainly: `germio` can only raise one flag, `flags.told_food`. It
cannot say which of the two asked. **Modio can.**

### 4.3 `place` — where a thing was done

A `thing` can be broken, carried off, or newly made. **The ground it
stood on cannot.** So `place` is what makes a memory hold up in a
world that moves.

**How a place is made.** Modio makes places as it walks; nothing
outside gives them. Standing on a stretch of ground, the character
holds a place. Step to ground that touches it, and it is the same
place. Step across a drop, or round a wall, and a new place is begun.

**What a place is worth.** `Level_1` holds 24 pieces, but a character
walking it meets a much smaller number of places — the ground under those pieces runs
together. So the number of places stays small, and the memory with it.

**What a place is written as.** Where the character stood when the
place was begun, turned into the world's own reckoning (§3.3.2), and
rounded. Two things done on the same stretch of ground fall to the same
`place`.

| Held      | `thing` | `place` | Lives                       |
| --------- | ------- | ------- | --------------------------- |
| **thing** | yes     | yes     | while that one thing stands |
| **place** | empty   | yes     | on, past a scene read again |

A scene read again makes every `id` new, so every memory of a
**thing** loses what it spoke of — as it should, since those things
are gone. Every memory of a **place** stands.

### 4.4 How deep a meeting sits

Master's own word: seeing, touching, and holding are three depths of
one meeting, not three separate things.

| Depth    | How it happens      | Fades   |
| -------- | ------------------- | ------- |
| **seen** | seeking found it    | fast    |
| **met**  | the bodies touched  | slower  |
| **held** | it was made a child | slowest |

**This mirrors `animo`'s own five stages: `animo` holds want in
layers; Modio holds meeting in layers.**

### 4.5 `edge` — a place to keep away from

`met` says "no longer new". **`edge` says the opposite: keep away.**

A step too high, or a fall in front, is written as `edge`. A place
held as `edge` is left out of every later seek, so the character turns
aside before reaching it, not after knocking into it.

Two rows, one table, opposite uses — which is why `edge` is its own
mark, and not a kind of `met`.

**This is why the drop-off check belongs here, and not in `germio`.**
A character that walks to the same drop, turns away, and walks back
again has taken in nothing. Knowing an edge is dangerous **is**
remembering it.

### 4.5.1 Three memories, three lives

Master's own word, 2026-08-21: a character carries what it feels from
one level into the next, and a game may be saved and taken up later.
That settles how long each memory lives, and what names what.

| Memory                | Named by          | Lives past a level? | Saved?  |
| --------------------- | ----------------- | ------------------- | ------- |
| **a thing near by**   | `GetInstanceID()` | no                  | no      |
| **another character** | **`agent_id`**    | **yes**             | **yes** |
| **a place**           | where it stood    | **yes**             | **yes** |

**Each name suits the life it must hold.**

+ A block, a step, an item picked up — these belong to one level, one
  reading of one scene. `GetInstanceID()` is made new each time, and
  so is the memory. **Nothing is lost that had anything left to say.**
+ Another character is named in `animo.json` and in `germio.json` both
  (`agent_id`, §7.1). **That name goes on past any scene, past any save.** So
  "I have given to this one" holds true a week later.
+ A place is where it is. Nothing names it but itself (§4.5).

**This is why the three could never share one name.** An earlier
draft held all memory under `GetInstanceID()`, which would have made
"I gave to them" go dark the moment a level was left. Three lives,
three names.

### 4.5.2 Carrying it over, and saving it

`animo`'s own `Engine.Snapshot()` reads a whole state out. Its other
half — `Restore` — is being built (`animo`'s own TASK-014).

| At a level's end | What Modio does                                               |
| ---------------- | ------------------------------------------------------------- |
| Needs            | `Snapshot()` each Engine, and hold it                         |
| memory           | keep the rows named by `agent_id` and by place; drop the rest |
| a deed running   | let it go — it belonged to a world now gone                   |
| a lock           | let it go with the deed                                       |

At the next level's start, `Restore` puts the Needs back, and the kept
rows go on standing. **A character walks into a new level still worn out,
still alone, and still knowing who it has given to.**

A save writes the same two things — the Snapshots, and the kept rows.
`germio`'s own save already carries the world (`Store`); these ride
beside it.

### 4.6 Letting go

Two ways of letting go were weighed. **`germio` already does both, and
Modio takes both.**

**By count.** `Store` holds `history.max_entries`, set to 1000, and
drops the row longest past, once over that. So the table cannot grow with no end.

An earlier draft here set a fading time instead — a row gone after so
many seconds. **Counted on a real level, that broke.** `Level_1` holds
12 blocks; fade at 120 seconds and every one of them still sits in
memory, so nothing is new and the want for new places dies flat out.
The right time turns on how many things there are, which a written-in
number cannot know. **A count does.**

**By age, read at the time of asking.** `history.time_since(kind=...,
target_id=...)` gives how long since a thing was last done.

```text
history.time_since(kind=met, target_id=$target) > 60
```

**"New again, if it has been a while."** The row is never touched. Age
is weighed each time the question is put.

| Way   | The row                     | Holds                                  |
| ----- | --------------------------- | -------------------------------------- |
| count | dropped, longest past first | the table stays small                  |
| age   | left alone                  | a place met long ago becomes new again |

**The two do different work, and Modio needs both.** Count keeps the
table from growing; age is what makes a place new again. Neither
stands in for the other.

Where the two meet: what fades is set to how deep the meeting was
(§4.4). Rows of `seen` are dropped first, `met` next, `held` last —
so the least deep goes before the deepest, as it does in a person.

### 4.7 Facing the other way

The same table, read facing the other way, says what is to come.
**One table, one way of reading it. Only the question changes.**

| Facing  | Asks                                 |
| ------- | ------------------------------------ |
| Back    | "have I met **that** one?"           |
| Forward | "what came of the ones **like** it?" |

Tulving's own claim, put to work: the paths that bring a past thing
back are the paths that build a picture of what is to come. **Not two
machines. One, faced two ways.**

#### 4.7.1 What "like it" means

Facing back matches on the `thing` — one `id`, one row. Facing forward
matches on **what Perceive hands back about it** (§3.3): its `kind`,
how far off, how far up or down.

```text
a Ground, 12 off, 3.0 down     was met, and written `edge`
a Ground, 14 off, 2.8 down     was met, and written `edge`
                ↓
now: a Ground, 13 off, 3.1 down
                ↓
"ones like this went badly"
```

**Nothing is worked out. Nothing is run forward.** The rows already
say it.

#### 4.7.2 Why not run the Needs forward instead

An earlier draft had Modio read `animo`'s own rates and work out where
a Need would sit in thirty seconds. Three things were wrong with it.

**It cannot be done.** `_rates_flat` and `_decay_rates` are held
private, and `GetActionScore`, `GetAllNeedNames`, `GetAllActionIds`
are all `internal`. Nothing outside `animo` can read them. To work a
Need forward, Modio would have to hold `animo`'s own sums over
again — suppression, influences, the commitment bonus — and then there
would be two of everything, drifting apart.

**It would not help even if it could.** Checked by real sums,
2026-08-21: at `fatigue` 55, `Rest` scores 40.8 and `GoHome` 6.9. Push
`exposure` up with an influence and it still loses — at `fatigue` 85,
`Rest` 78.4 against `GoHome` 36.7. **Maslow's own holding-back says
so, and says it well: one who is worn out rests where they stand.**
No amount of looking ahead changes which want wins; that is `animo`'s
to say, not Modio's.

**And it is not what Tulving said.** He held that the memory of living
is what lets a mind picture what is to come — not a sum worked out
from a rate. **A person does not work out how worn out they will be in thirty
seconds. They know how it went last time.**

#### 4.7.3 Where the forward-facing question is put

Not to `animo`. **To the seek.**

`animo` says what is wanted; that is settled, and Modio never touches
it. What Modio settles is **which thing to reach for**, and there the
past speaks:

```text
seeking hands back : Ground, 13 off, 3.1 down
Modio's own memory : Ground, 12 off, 3.0 down  →  edge
                     Ground, 14 off, 2.8 down  →  edge
                            ↓
                     "ones like this went badly"  →  left out of the seek
```

**This is settled inside Modio, before the deed ever starts.** It is
not written in `germio.json` at all, and `germio`'s own Evaluator never
sees it: the rows it would need — how far off, how far up or down — are
Perceive's own, and live only here (§7.7).

So a character keeps away from a drop it has never stood on, because
it stood on ones like it. **It does not know. It expects.** That is
what a memory of living buys, and it buys it with no sum at all.

#### 4.7.4 The three times, held together

| Time    | Held by             | How it is known                      |
| ------- | ------------------- | ------------------------------------ |
| past    | the table           | rows, matched on `thing`             |
| now     | Perceive            | what stands within reach, this tick  |
| to come | **the table again** | rows, matched on **what it is like** |

**Modio is the only layer that holds all three**, and it holds them in
one place, because Tulving said they are one thing.

### 4.8 What Modio never remembers

| Not held                 | Why                                                                                   |
| ------------------------ | ------------------------------------------------------------------------------------- |
| What was said            | `germio`'s own rules hold that. Modio holds **that** it asked, never **what**         |
| How the world stands now | `germio` holds that. Modio holds only what has been done                              |
| What it wants            | `animo` holds that. Modio holds no Need at all                                        |
| A full copy of the world | Modio's own picture is full of holes, and worn by time — and still it serves (§3.5.1) |

## 5. Enact

### 5.1 `Deed` — one thing done

A Deed takes one Behavior and carries it through over time. It ends
one of three ways, and only one of them writes anything at all:

| End         | To `animo`                      | To memory | To the world |
| ----------- | ------------------------------- | --------- | ------------ |
| **Done**    | `Affect` (may be more than one) | written   | written      |
| **Failed**  | nothing                         | nothing   | nothing      |
| **Dropped** | nothing                         | nothing   | nothing      |

+ **Done** — the Deed reached its end. The Need falls; the row is kept.
+ **Failed** — nothing was found, what was found left, or the time ran
  out. The Need does not fall, so `animo` asks again next tick.
+ **Dropped** — the deed was let go part way. Two things do this:
  `animo` giving a different Behavior, or `germio` moving to another
  Node. **A Node holds its own rules, so a Node change takes away the
  very rule the deed was carrying out.** Either way the deed folds,
  nothing is written, and the next one starts.

**Done is the one gate into memory.** Every row in the table (§4.1)
was written by a Deed that reached its end. Nothing else may write
there.

### 5.2 The steps within one Deed

A Deed is not one motion. Up to three steps run, in this order:

| Step | What                       | Runs when           | Ends when              |
| ---- | -------------------------- | ------------------- | ---------------------- |
| face | turn toward what was found | there is a `target` | it faces — of itself   |
| move | do what `motion` says      | always              | **`until` says so**    |
| act  | do what `act` says         | there is an `act`   | it is done — of itself |

**Only the middle step is watched.** `until` (§7.6) belongs to it, and
to it alone: facing ends when the turn is finished, and an act ends
when it is carried out. Neither needs watching.

**Steps are skipped where they do not apply.** `Rest` holds no
`target` and no `act`, so it runs one step: stand still, until so many
seconds have gone by. `Give` runs all three.

`super-nekokun`'s own `Player.cs` shows this shape already, in taking
something up: it turns to face the thing (`faceToObject`), then lifts,
then holds.

Where the middle step cannot end, the whole Deed ends **Failed**.

### 5.3 Holding a Deed together, while it plays out

`animo` already holds what a Deed needs: `Lock(duration, LockMode)`.

| Mode     | What it does                                                                                                                             |
| -------- | ---------------------------------------------------------------------------------------------------------------------------------------- |
| **Soft** | scores still work on the inside; only what is given back is held. `animo`'s own spec calls this "a spoken line, that may be broken into" |
| Hard     | everything held                                                                                                                          |

**Soft is what a Deed wants**: the Behavior holds steady while the
deed plays out, and a sudden Need — fear, say — can still break in and
drop it.

**How long a Deed may run** rests on two numbers `animo` already
holds, and they are not the same:

| Number                         | Value | What it is                                    |
| ------------------------------ | ----- | --------------------------------------------- |
| `LOCK_DURATION_WARN_THRESHOLD` | 30 s  | past this, `animo` warns — but still takes it |
| `LOCK_DURATION_MAX`            | 600 s | past this, `animo` cuts it down to 600        |

**Modio holds to 30 seconds**, the warning mark, and does not go
near the hard cap. A deed that has run half a minute and not landed is
a deed that will not land.

**Which Behavior to read.** `Engine.Behavior` gives back what was last
picked. `Engine.LockedBehavior` gives back what a lock is holding, and
is empty where no lock stands. **Modio reads `Behavior`, always** — a
lock Modio itself set holds that very Behavior steady, so the two say
the same thing while a deed runs, and `Behavior` is the one that keeps
saying something after.

Where a Deed ends, by any of the three ways, the lock is let go at
once. **A Deed that has ended must never hold `animo` still.**

### 5.4 A Deed may satisfy more than one Need

`super-nekokun`'s own `Player.cs` shows one deed reaching three layers
at once: the body (`transform.parent`), the character
(`doUpdate.holding`), and the game itself (`gameSystem.hasKey`).

So a Deed's own close may call `Affect` more than once. Reaching a
friend may quiet both "I am alone" and "I am cut off" together.
**One arrival, two wants met.**

This is not a small point. `company_seeking` holds `separation` at Stage 2
and `loneliness` at Stage 3, and `Call` — standing still and calling
out — cannot quiet `separation` on its own. **Were `Approach` to quiet
only `loneliness`, `separation` would climb with no way down, and
`Call` would win for ever.** Two `Affect` calls on one arrival is what
closes that round.

### 5.5 Failed is a move, not a fault

**Failed is how a character turns away from what will not work.**

| Then                              | And so                                        |
| --------------------------------- | --------------------------------------------- |
| Nothing of that kind is in sight  | Failed. The Need holds; `animo` asks again    |
| A wall stands in the way (§3.7.1) | Failed. To Modio this reads as an empty field |
| Every near thing is already met   | Failed — **and this is "south is done"**      |

The last one is worth setting out in full. "South is done; try north"
needs no new part at all:

```text
Explore begins, facing south
  → seeking finds Ground, but every one is already met
  → nothing to take           → Failed
  → curiosity does not fall
  → next tick, Explore begins again, facing another way
  → something not yet met     → walk to it → Done
```

**Turning away comes out of Failed, and nothing else.** A Deed that
gave up quietly, or stood in something easier, would break this: the
character would seem to have explored, while `curiosity` fell for
nothing.

### 5.6 What a Deed never does

| Never                       | Why                                                               |
| --------------------------- | ----------------------------------------------------------------- |
| Picks what to want          | `animo`'s work. A Deed only carries out what came back            |
| Writes on Failed or Dropped | A want unmet must stay unmet, or `animo` is given a false account |
| Stands in something easier  | Ending Failed is honest; seeming to succeed is not                |
| Runs past its lock          | 30 seconds, and the lock is let go (§5.3)                         |

## 6. What Modio needs, and what stands today

### 6.1 From `germio`

| # | Needed                              | Today                                                         | Blocks Modio? |
| - | ----------------------------------- | ------------------------------------------------------------- | ------------- |
| 1 | **sensor — seeking**                | **written, not built** (TASK-014)                             | **YES**       |
| 2 | Body — the seven doing-states       | built (`FixedUpdate`)                                         | no            |
| 3 | Proof of arrival — meeting, holding | built (`OnCollisionEnter`, `transform`)                       | no            |
| 4 | Writing to the world                | built (`Scenario.initial_state`)                              | no            |
| 5 | Saying a line                       | `Store.NotifyRequested` only; no line over a character's head | open          |

### 6.2 From `animo`

| # | Needed                         | Today |
| - | ------------------------------ | ----- |
| 1 | `Behavior` — the want          | built |
| 2 | `Affect` — giving back         | built |
| 3 | `Lock(Soft)` — holding a Deed  | built |
| 4 | `GetNeed` — for facing forward | built |

### 6.3 Nothing blocks Modio now

Seeking sits in Modio itself (§3.3), so no other build has to
make a thing first. Work may start.

**What must never be done is stand a meeting in for seeking.**
Without seeking, every want reaching outside the character falls back
on waiting to be run into — and a character that waits is not
carrying a want through. It would look as though it worked, while
quietly throwing away everything `animo` decided.

Real sums show the cost: on a field 30 steps across, seeking brings
two characters together in **8 seconds**; waiting to be run into
takes **316 seconds**, forty times longer. `loneliness` climbs at 1.0
a second and stops at 100. **Waiting means it is pinned at the top
long before arrival, and never falls again.** That is how a whole
side of `animo` came to be missing, and this spec will not walk the
same road twice.

---

## 7. No DSL of its own

**Modio holds no language of its own. It reads `germio.json`.**

An early draft set out a `modio.json`, with words of its own —
`seek`, `until`, `then`. It was thrown out. Two files, each holding
half of what a character does, would drift apart the first time one
was changed and the other forgotten.

**One file. `germio` reads the rules with no `actor`; Modio reads the
rules that name one.**

### 7.1 What `germio` gains

Three things, and no more (see `germio`'s own TASK-016 to TASK-018):

| Added to  | Name           | Shape                                      |
| --------- | -------------- | ------------------------------------------ |
| `Rule`    | `actor`        | a plain name. Empty means the world's rule |
| `Command` | `request_deed` | work that takes time                       |
| `Command` | `update_need`  | the one way to reach `animo`               |

Each was named to sit beside what is already there:

| New            | Sits beside                            | Why                                                |
| -------------- | -------------------------------------- | -------------------------------------------------- |
| `actor`        | `kind`, `scene`                        | a plain noun, as every `Rule` and `Node` field is  |
| `request_deed` | `request_transition`, `request_notify` | all three ask for what does not finish on the spot |
| `update_need`  | `update_counter`, `update_inventory`   | same shape: a key, and a change to it              |

### 7.2 `update_need` — a list, never one

```json
"update_need": [
  { "key": "loneliness", "delta": -30 },
  { "key": "separation", "delta": -40 }
]
```

| Field   | Type   | Sense                                          | May be left out |
| ------- | ------ | ---------------------------------------------- | --------------- |
| `key`   | text   | which Need, by the name `animo` holds it under | no              |
| `delta` | number | how far it moves. Below zero to quiet a want   | no              |

**A list, always — even where it holds one.** §5.4 sets out why:
`company_seeking` holds `separation` at Stage 2 and `loneliness` at
Stage 3, and one arrival must quiet both. Were this one pair only,
`separation` would climb with no way down, and `Call` would win for
ever.

### 7.3 `request_deed` — the five parts

```json
"request_deed": {
  "target":    { "kind": "Ground", "reach": 15.0, "spread": 90.0 },
  "condition": "history.time_since(kind=met, target_id=$target) > 60",
  "motion":    "walk",
  "until":     { "meets": "$target" },
  "command":   { ... }
}
```

| Part        | Type      | Sense                           | May be left out                                          |
| ----------- | --------- | ------------------------------- | -------------------------------------------------------- |
| `target`    | see §7.4  | what to seek                    | **yes** — for a deed that seeks nothing (`Rest`, `Call`) |
| `condition` | text      | which of the found ones to take | yes — empty takes the nearest                            |
| `motion`    | text      | how the body moves              | no                                                       |
| `until`     | see §7.6  | when the deed is done           | no                                                       |
| `command`   | `Command` | what to do once it lands        | no                                                       |

**`given` is checked again, right before the `act`.** Two characters
may reach for the same thing at the same moment: both saw it free,
both walked to it, and the first to arrive takes it. Were the second
to go on and hand over what it no longer holds, one item would land in
two places. **So the check runs twice — once to start the deed, and
once more before the act — and a deed that fails the second check ends
Failed.**

**`command` is `germio`'s own `Command` type, held inside.** So
`update_need`, `record_event`, `set_flag` — every command there is —
works here with nothing new added. **A `request_deed` inside a
`request_deed` is not let through (`germio`'s own V032).**

### 7.4 `target` — what to seek

| Field    | Type   | Sense                             | May be left out             |
| -------- | ------ | --------------------------------- | --------------------------- |
| `kind`   | text   | one of `germio`'s own type marks  | no                          |
| `reach`  | number | how far out to look               | yes — a set value stands in |
| `spread` | number | how far round to look, in degrees | yes — a set value stands in |

**`kind` takes one of these, and nothing else** (`germio`'s own
`Env.cs`, read by name — §3.4):

| `kind`    | What it names                         |
| --------- | ------------------------------------- |
| `Block`   | a solid thing, in the way or to climb |
| `Ground`  | the floor under the feet              |
| `Wall`    | a bound not to pass                   |
| `Item`    | a thing that may be taken             |
| `Coin`    | a thing picked up for a count         |
| `Balloon` | a thing that lifts what holds it      |
| `Human`   | a character, player-led or not        |
| `Vehicle` | a thing ridden                        |
| `Home`    | a place come back to                  |
| `Scene`   | a mark that a level ends here         |
| `Despawn` | a mark that what falls here is gone   |

**Eleven, read straight off `germio`'s own `Env.cs` (checked
2026-08-21).** Where `germio` gains a mark, Modio gains a kind; where
it does not, Modio cannot make one up.

### 7.5 `motion` — how the body moves

**One of `germio`'s own seven doing-states, and nothing else**
(`FixedUpdate`):

| `motion`     | What the body does                 |
| ------------ | ---------------------------------- |
| `idle`       | stands still                       |
| `walk`       | goes forward, slowly               |
| `run`        | goes forward, quickly              |
| `backward`   | goes back                          |
| `jump`       | leaves the ground                  |
| `abort_jump` | cuts a jump short                  |
| `stop`       | brings to a stop what it was doing |

**Turning to face comes first, and is not named here.** Every deed
with a `target` turns toward it before the `motion` begins (§5.2).

#### `act` — doing, where moving is not enough

Some of them end in a doing that no motion covers: handing a thing over,
holding one up. These take an `act`, written beside `motion`:

| `act`       | What happens                                       |
| ----------- | -------------------------------------------------- |
| `hand_over` | what is held is made a child of the target instead |
| `take_up`   | the target is made a child of this one             |
| `put_down`  | what is held is let go, and stands on its own      |

| Field    | May be left out | Sense                                   |
| -------- | --------------- | --------------------------------------- |
| `motion` | no              | how the body moves, while getting there |
| `act`    | **yes**         | what is done once there. Most need none |

Holding has been the parent-child tie through three whole builds
(`super-nekokun`'s own `Item.cs`, then `Holdable.cs`, then `germio`'s
own `Common.Holdable` with `tropika`'s own `Block_Holdable`), so an
`act` moves that tie and nothing else.

**Without `act`, `Give` and `ShowFind` cannot be written at all.**

### 7.6 `until` — when a deed is done

**`until` is not read by `germio`'s own Evaluator.** That reads
`history.*` and the state of the world; `until` watches how a deed
itself is going — how near, how long, what was touched. **The one
carrying the deed out is the one that knows.** So Modio reads it, and
it is written as a shape, not a line of text:

| Written                     | Done when                                             | Takes      |
| --------------------------- | ----------------------------------------------------- | ---------- |
| `{ "near": 2.0 }`           | within that far of the target                         | a number   |
| `{ "meets": "$target" }`    | the bodies touch                                      | `$target`  |
| `{ "elapsed": 4.0 }`        | that many seconds have gone by                        | a number   |
| `{ "while": "other_near" }` | **never done of itself** — held while the state holds | a set name |

**One key to an `until`, never two.** Where a deed must watch for two
things, it is written as two of them, each with its own trigger — the
same road §7.7 takes for conditions.

**There is no `until` for a tie moving, and none is needed.** Handing
a thing over is an `act`, and an act ends on its own clock (§5.2). A
deed that hands something over is watched to the point of arrival —
`{ "near": 1.5 }` — and the handing is what follows.

**Counted off against every deed the two given personas hold:**

| Deed       | `until`                     | `act`       |
| ---------- | --------------------------- | ----------- |
| `Rest`     | `{ "elapsed": 4.0 }`        | none        |
| `Call`     | `{ "while": "other_near" }` | none        |
| `Approach` | `{ "near": 2.0 }`           | none        |
| `Explore`  | `{ "meets": "$target" }`    | none        |
| `GoHome`   | `{ "near": 1.5 }`           | none        |
| `ShowFind` | `{ "near": 1.5 }`           | `show`      |
| `Tend`     | `{ "near": 1.2 }`           | `tend`      |
| `Give`     | `{ "near": 1.5 }`           | `hand_over` |

**Every one of the 10 is written with one `until` and no more.**
Where a deed takes time once it arrives — `Tend` cares for a few
seconds — that time belongs to the `act`, not to `until` (§5.2). So no
deed ever needs two.

`{ "while": ... }` is the odd one. It marks a deed that has no end of
its own: `Call` (standing and calling out) goes on until something
else brings it down — the lock running out (§5.3), or `animo` giving
another Behavior. **A deed that ends this way ends Failed, never
Done.**

**And that is meant.** `Call` never quiets `separation` by itself: a
call is not an answer. What quiets it is the other one arriving, and
`Approach` carries that (§5.4, two `update_need` entries on one
arrival). So `Call` is a deed that shows what a character feels, and
never a deed that puts it right.

Read with §5.1, this holds together: `separation` keeps climbing while
`Call` runs, which is right — the character is still cut off. Once it
climbs past what holds `Approach` down, `Approach` wins, and the round
closes.

### 7.7 `$target` — the one new mark

A rule as written today names everything up front:

```text
"flags.route_forest == true"                    a name, fixed
"record_event": { "target_id": "stage_01" }     a name, fixed
```

**A deed cannot.** What it finds is known only once it looks. So
`$target` stands for whatever was found.

**Where `$target` may be written:**

| Place                                        | Read by                             | Example                  |
| -------------------------------------------- | ----------------------------------- | ------------------------ |
| `request_deed.condition`                     | Evaluator, after it is put in place | `target_id=$target`      |
| `request_deed.until`                         | Modio                               | `{ "meets": "$target" }` |
| any text field inside `request_deed.command` | Executor, after it is put in place  | `"target_id": "$target"` |

**Nowhere else.** It has no meaning in a `Rule`'s own `condition`,
because no deed is running yet.

**How it is put in place.** Before the Evaluator or the Executor is
called, the text `$target` is put aside for what the deed found:

```text
before : history.time_since(kind=met, target_id=$target) > 60
after  : history.time_since(kind=met, target_id=g_0041) > 60
```

**`ExprLexer`, `ExprParser` and `Evaluator` are untouched.** `$`
belongs to no token kind today, so it runs into nothing else.

**What it holds** is the `id` of §3.3.1, written out with its letter
in front: `g_1042`.

**Where the mark is looked for, and where it is not:**

| Place                                                        | Looked for | Read by                                  |
| ------------------------------------------------------------ | ---------- | ---------------------------------------- |
| `request_deed.condition`                                     | yes        | Evaluator                                |
| `request_deed.until`, in its value                           | yes        | Modio                                    |
| every text field inside `request_deed.command`, however deep | yes        | Executor                                 |
| `Rule.condition` (outside a deed)                            | **no**     | — no deed is running                     |
| `Rule.trigger`, `Rule.id`, `actor`                           | **no**     | — these name the rule, not what it found |
| any number, any true-or-false                                | **no**     | — the mark is text only                  |

**How the change is made:**

| Rule                                   | Why                                                                                                       |
| -------------------------------------- | --------------------------------------------------------------------------------------------------------- |
| The whole word `$target`, and no other | `$targets` and `$targe` are other words, and are left alone                                               |
| Big and small letters count            | `$TARGET` is not the mark                                                                                 |
| Every time it appears                  | `like=$target, target_id=$target` takes the id in both places                                             |
| **Once, and never again**              | what is put in is never looked at a second time, so a value holding `$target` cannot run away with itself |
| Where the deed found nothing           | **the deed ends Failed, and nothing is evaluated at all** — an empty value would make a broken line       |

**Facing forward is asked of Modio's own memory, never of `germio`'s.**
Checked 2026-08-22: `germio`'s own `HistoryEntry` holds three things —
`kind`, `target_id`, `timestamp` — while being of a sort is judged on
what Perceive hands back: the kind, how far off, how far up or down
(§4.7.1). **Neither distance nor height is written there, and neither
belongs there.**

The deeper reason is §4.2: that `Store` holds **the world's** past, one
for the whole game. `like` asks *"how did it go for **me**, with things
of this sort"* — a first-person question, and so a question for the
memory Modio keeps for each character.

| Asked of               | Question                     | Written                                  |
| ---------------------- | ---------------------------- | ---------------------------------------- |
| `germio`'s own history | did this happen in the world | `history.count(kind=..., target_id=...)` |
| **Modio's own memory** | **how did ones like it go**  | **matched on kind, reach and height**    |

So a deed's own `condition` may hold `$target` and be read by
`germio`'s own Evaluator; the forward-facing question is settled by
Modio before the deed ever starts, in choosing which found thing to
take (§4.7.3).

### 7.8 Why a mark of `germio`'s own making is needed

`$target` must hold something that means the same thing twice.
Counted on a real scene, 2026-08-21: **the object name will not do.**

| Tried             | Why it fails                                                  |
| ----------------- | ------------------------------------------------------------- |
| The name          | `Level_1` holds 24 pieces; three names are used twice over    |
| `GetInstanceID()` | made new on every scene load — **and that is right** (§3.3.1) |
| `GlobalObjectId`  | Editor only; cannot be read while the game runs               |

`GetInstanceID()` serves: it holds while that one thing stands, and a
memory of a thing that no longer stands has lost what it spoke of.
**Nothing is added to `germio` for this** (its own TASK-015, dropped).

### 7.9 One condition to a rule, by design

`germio`'s own `docs/dsl_spec.md` §6 sets a limit: a `history.*` call
works alone, or right inside one comparison. **Inside `&&`, `||` or
`!` it gives back `false`, always.**

Modio holds to this, and writes one condition to a rule. Where two
must be true at once, two rules are written, each with its own
trigger — the way that spec itself calls for.

**A limit taken on with open eyes, not a limit walked into.**

### 7.10 How a Behavior becomes a deed

`animo` gives back a Behavior — a plain string, `"Explore"` — every
tick. `germio`'s own rules fire on a trigger. **Something must join
the two, and that something is Modio.**

Each tick, for each character it holds a mind for:

| Step | What Modio does                                                   |
| ---- | ----------------------------------------------------------------- |
| 1    | reads `Engine.Behavior`                                           |
| 2    | where it has not changed since last tick, does nothing            |
| 3    | where it has changed, calls `Bus.Publish(signal, actor)`          |
| 4    | `germio` fires whatever rule matches that trigger, for that actor |
| 5    | a `request_deed` in that rule comes back to Modio (§7.11)         |

**The trigger name is worked out, never written by hand:**

```text
"sig_behavior_" + the Behavior, in lower letters

"Explore"  →  sig_behavior_explore
"Give"     →  sig_behavior_give
"ShowFind" →  sig_behavior_show_find
```

A name in more than one word (`ShowFind`) is broken at each big
letter, and joined with a low line — the same shape `germio`'s own
JSON keys take (`set_flag`, `update_counter`).

**Why worked out, and not written by hand:** an `animo` persona and a
`germio` rule set are two files, written apart. A hand-written trigger
would fall out of step the first time an Action was given a new name on one
side. **Worked out from the Behavior itself, it cannot.**

**Step 2 matters.** `animo` gives back the same Behavior tick after
tick while a want holds. Firing every tick would start a fresh deed
each frame, and no deed would ever run its course. **A signal goes out
only where the Behavior has changed** — which is also when a running
deed ends **Dropped** (§5.1).

### 7.11 Who hears what `germio` fires

`germio` knows nothing of `animo`, and nothing of Modio. So the
Executor calls neither: it fires an event out of the `Store`, and
whoever is listening picks it up. This is the road
`request_notify` already takes — the Executor calls
`store.RequestNotify(id)`, `Store` fires `NotifyRequested`, and
`NoticeSystem` hears it.

| Command          | `Store` fires     | Heard by                                      |
| ---------------- | ----------------- | --------------------------------------------- |
| `request_notify` | `NotifyRequested` | `germio`'s own `NoticeSystem`                 |
| `update_need`    | `NeedRequested`   | **Modio**, which calls `animo`'s own `Affect` |
| `request_deed`   | `DeedRequested`   | **Modio**, which starts the deed              |

**Modio is the one listening for both.** Nothing in `germio` hears
them, and nothing in `germio` needs to.

`Store` holds two events today — `TransitionRequested` and
`NotifyRequested` — and the two above must be added beside them
(`germio`'s own TASK-040 and TASK-041). The shape is already set by
what stands: a `public event Action<...>`, and a method that fires it,
called from the Executor.

**The Executor takes them without trouble.** It runs a plain row of
`if (command.X != null)` checks — not a `switch` — so two more sit
beside the 10 already there, and none of those 10 is touched. **This
is also why one `Command` may hold `update_need` **and**
`record_event` at once (§7.3): the Executor was built that way from
the start.**

### 7.12 A deed, written out whole

```json
{
  "id": "rule_explore",
  "trigger": "sig_behavior_explore",
  "actor": "place_curious_01",
  "condition": "",
  "command": {
    "request_deed": {
      "target": { "kind": "Ground", "reach": 15.0, "spread": 90.0 },
      "condition": "history.time_since(kind=met, target_id=$target) > 60",
      "motion": "walk",
      "until": { "meets": "$target" },
      "command": {
        "update_need": [ { "key": "curiosity", "delta": -25 } ],
        "record_event": { "kind": "met", "target_id": "$target" }
      }
    }
  },
  "once": false
}
```

And one that hands a thing over, running all three steps (§5.2):

```json
{
  "id": "rule_give",
  "trigger": "sig_behavior_give",
  "actor": "company_seeking_01",
  "condition": "",
  "command": {
    "request_deed": {
      "target": { "kind": "Human", "reach": 30.0, "spread": 120.0 },
      "condition": "history.count(kind=gave, target_id=$target) == 0",
      "motion": "walk",
      "act": "hand_over",
      "until": { "near": 1.5 },
      "command": {
        "update_need": [ { "key": "togetherness", "delta": -30 } ],
        "record_event": { "kind": "gave", "target_id": "$target" },
        "set_flag": { "key": "gift_given", "value": true }
      }
    }
  },
  "once": false
}
```

**Every word in both but four is `germio`'s own already.** `id`,
`trigger`, `condition`, `command`, `once`, `record_event`, `set_flag`,
`history.count`, `history.time_since` — all stood before Modio did.

## 8. What Modio never does

+ **It never picks what to want.** That is `animo`'s own work.
+ **It never moves a body itself.** That is `germio`'s own work.
+ **It never writes into `animo`.** It calls `Affect`, and no more.
+ **It never lets a want quietly fall away.** Where a want cannot be
  carried through, the Deed ends **Failed**, and `animo` is left to
  ask again. It never stands in something easier and calls it done.

And these belong elsewhere, by design:

| Not Modio's                          | Whose                                                                                                                                                           |
| ------------------------------------ | --------------------------------------------------------------------------------------------------------------------------------------------------------------- |
| Two bodies knocking together         | `germio`'s own motion work. Modio names a `motion`; what happens when two characters meet on the way is the body's own doing, and works as it does for a player |
| What a character looks like doing    | the game's own, through its `Animator` (Master's own word, 2026-08-21: this is handled apart)                                                                   |
| Sound                                | `germio`'s own `SoundSystem`. Nothing is wired to it yet — see §9                                                                                               |
| A character falling out of the world | `germio`'s own. Where the body goes, the mind goes: the Engine is let go with it, as a running deed and its lock are (§4.5.2)                                   |
| Being blocked by a player            | nothing at all. A character that cannot get past waits, and its deed ends Failed at 30 seconds (§5.3). **That is the answer, not a hole in it**                 |

---

## 9. Still open

| #  | Point                     | What is owed                                                                                                                                                                                                                                                        |
| -- | ------------------------- | ------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- |
| 1  | Three things in `germio`  | `Rule.actor`, `Command.request_deed`, `Command.update_need` (TASK-016 to TASK-018 there). Nothing else is owed by `germio`: TASK-014 (a sensor) moved here, and TASK-015 (a mark on every piece) was dropped once `GetInstanceID()` was found to serve (§3.3.1).    |
| 2  | How places are drawn      | §4.3 sets out how a place is begun and where it ends, but no sums have been run on a real level. **How many places `Level_1` truly holds, walked end to end, is not yet counted.**                                                                                  |
| 3  | Saying a line             | `Store.NotifyRequested` shows a line for the whole screen. A line over one character's head — as `super-nekokun`'s own `say()` gave — has no home in `germio` yet. Without it, what a character has in mind cannot be seen, and cannot be checked by eye.           |
| 4  | Facing forward, in full   | §4.7 and §7 show one shape only (`before`). The whole set — every question a character may put about what is to come — is not worked out.                                                                                                                           |
| 5  | Same answer, every run    | `animo` has `ScenarioRunner`, proving same input, same answer. Modio needs its own. §3.6 shows the shape a test would take; nothing is built.                                                                                                                       |
| 6  | Zero-GC                   | `animo` proved it with a test running `Live()` 100,000 times. Modio must meet the same bar. The memory table must be a ring held at a fixed size — **never `germio`'s own `List` with `RemoveAt(0)`, which shifts every row and grows the backing store.**          |
| 7  | The cost at 64 characters | Every character runs, seen or not (Master's own word). Worked out: 3,200 wide checks a second, near 960 thrown lines, 37 KB of memory (§3.7). **Not measured on a real phone.** Should it bite, holding still what cannot be seen is the first thing to weigh.      |
| 8  | Sound                     | `germio` holds `SoundSystem`, and `signo`/`quyno` stand behind it. **Nothing here calls any of them.** A deed that hands a thing over makes no sound at all. To be taken up later (Master's own word, 2026-08-21).                                                  |
| 9  | Reading a level's rules   | Rules for the world and rules for each character sit side by side under one `Node`. With many characters, which rule belongs to which character grows hard to see by eye. **A way to list them by `actor` is owed** — `germio`'s own Validator is the place for it. |
| 10 | How much is let go of     | §4.6 takes both of `germio`'s own ways — by count, and by age. **The count itself is not settled.** `germio` uses 1000 for the whole game; Modio holds one table to a character, and what number serves there has not been worked out.                              |

---

## 10. Where this came from

Every part of this spec was found by reading real code:

+ `germio`'s own `FixedUpdate` holds seven doing-states, and no more.
+ `germio`'s own `Env.cs` already names `Home`, `Item`, `Block`, `Human`.
+ `Like()` picks a thing by the name it carries.
+ `germio`'s own `Triggers/Home.cs` already fires on reaching home.
+ Holding has been the parent-child tie for three whole builds
  (`super-nekokun`'s own `Item.cs`, then `Holdable.cs`, then
  `germio`'s own `Common.Holdable` with `tropika`'s own `Block_Holdable`).
+ `super-nekokun`'s own `Enemy.cs` shows a wandering NPC: random
  turns, a plate to stay on, a line said out loud, a timer for waiting.
+ `super-nekokun`'s own `Player.cs` shows one deed reaching three
  layers at once.
+ `animo`'s own `Lock(LockMode.Soft)` was already made for a thing
  that takes time and may be broken into.

**Modio adds one thing none of them hold: a past — and, by the same
paths, a look at what is to come.**
