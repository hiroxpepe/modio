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

`animo` holds the state of now. `germio` holds the state of now.
**Modio is the only layer with a past.**

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
| `distance` | `until: near 2.0` needs a number to test                                 | §5            |
| `height`   | how far up or down a thing sits, from where the feet are                 | §4.3          |

**What is left out, and why:**

| Left out                             | Why                                                                                           |
| ------------------------------------ | --------------------------------------------------------------------------------------------- |
| How wide, how deep, how big          | Judging a fall from size is Remember's work (§3.2)                                            |
| `Vector3`, `Transform`, `GameObject` | Perceive must be open to a check with no Unity at all (§3.6)                                  |
| Whether it may be held               | That is `germio`'s own live state, read at the moment of taking, not seen from a distance     |
| The full name string                 | `kind` and `id` say all Modio needs; a name would draw a reader into taking meaning out of it |

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

### 3.6 Two parts, held apart

| Part       | Does                                                                | Knows Unity? |
| ---------- | ------------------------------------------------------------------- | ------------ |
| `Runtime/` | asks Unity's own `Physics`, and turns each hit into the five fields | yes          |
| `Scripts/` | takes that list, weighs it against memory, and picks one            | **no**       |

This is the shape `signo` already holds, with its own `Scripts` apart
from `Audition~`, and `quyno` with its own `Core` apart from
`Bridge~`.

**Why it must be so:** `animo` proved itself with 452 tests, no
garbage on the hot path, and a runner giving the same answer every
run — all because it holds no place at all. Modio must hold places.
**If judging and Physics sat in one part, none of that could be
proved.** Held apart, the judging takes a plain list, and a test may
write that list by hand:

```text
given:   Ground/id=1  angle=20   distance=8.5   height=0.0
         Ground/id=2  angle=-45  distance=12.0  height=0.0
memory:  id=1 is met
asked:   kind=Ground, not_in_memory=met
then:    id=2 is picked
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

### 4.1 One table, one per character

| Column   | Sense                               |
| -------- | ----------------------------------- |
| `when`   | when it happened (for fading)       |
| `what`   | `met`, `held`, `gave`, `shown`      |
| `object` | what it was done to                 |
| `with`   | who it was done with (may be empty) |

**A row is written only where a deed ends Done.**

### 4.2 How deep a meeting sits

Master's own word: seeing, touching, and holding are three depths of
one meeting, not three separate things.

| Depth    | How it happens      | Fades   |
| -------- | ------------------- | ------- |
| **seen** | the sensor found it | fast    |
| **met**  | the bodies touched  | slower  |
| **held** | it was made a child | slowest |

**This mirrors `animo`'s own five stages: `animo` holds want in
layers; Modio holds meeting in layers.**

### 4.3 `edge` — a place to keep away from

`met` says "no longer new". **`edge` says the opposite: keep away.**

A step too high, or a fall in front, is written as `edge`. A place
held as `edge` is left out of every later seek, so the character
turns aside before reaching it, not after knocking into it.

Two rows, one table, opposite uses — which is why `edge` is its own
mark, and not a kind of `met`.

### 4.4 Fading

Rows fade with time: the ones longest past, and the ones least deep,
go first.

Fading is not for looks. It keeps two things true:

+ **The table stays small.** With no fading it grows with no end — a
  thing `animo`'s own zero-GC bar would never allow.
+ **A want for new places keeps working.** Once every place has been
  met, nothing is new any more. Fading makes a place new again.

### 4.5 Facing the other way

The same table, read facing the other way, says what is to come.

| Facing  | Asks                                     | Reads                                             |
| ------- | ---------------------------------------- | ------------------------------------------------- |
| Back    | "have I met that place?"                 | the table                                         |
| Forward | "where will my Needs sit in 30 seconds?" | the table's own shape, plus `animo`'s own `rates` |

Facing forward works because `animo`'s own `rates` are fixed and
plain: a Need climbing at +1.2 a second will sit 36 points higher in
30 seconds. `animo`'s own `GetNeed(need)` gives the value now.
**What is to come can be worked out; it need not be guessed.**

---

## 5. Enact

### 5.1 `Deed` — one thing done

A Deed takes one Behavior and carries it through over time. It ends
one of three ways:

| End         | To `animo`                      | To memory | To the world |
| ----------- | ------------------------------- | --------- | ------------ |
| **Done**    | `Affect` (may be more than one) | written   | written      |
| **Failed**  | nothing                         | nothing   | nothing      |
| **Dropped** | nothing                         | nothing   | nothing      |

+ **Done** — the Deed reached its end. The Need falls; the memory is kept.
+ **Failed** — no thing was found, the thing left, or time ran out.
  The Need does not fall, so `animo` will ask again.
+ **Dropped** — `animo` gave a different Behavior part way.

### 5.2 Holding a Deed together, while it plays out

`animo` already holds what a Deed needs: `Lock(duration, LockMode)`.

| Mode     | What it does                                                                                                                             |
| -------- | ---------------------------------------------------------------------------------------------------------------------------------------- |
| **Soft** | scores still work on the inside; only what is given back is held. `animo`'s own spec calls this "a spoken line, that may be broken into" |
| Hard     | everything held                                                                                                                          |

**Soft is what a Deed wants**: the Behavior holds steady while the
deed plays out, but a true, sudden Need (fear, say) can still break
in and drop it.

`animo`'s own `LOCK_DURATION_WARN_THRESHOLD` is 30 seconds. **This
is the ground under Modio's own limit on how long a Deed may run** —
not a number picked out of the air.

### 5.3 A Deed may satisfy more than one Need

`super-nekokun`'s own `Player.cs` shows one deed reaching three
layers at once: the body (`transform.parent`), the character
(`doUpdate.holding`), and the game itself (`gameSystem.hasKey`).

So a Deed's own close may call `Affect` more than once. Reaching a
friend may quiet both "I am alone" and "I am cut off" together.
**One arrival, two wants met.**

---

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

### 7.1 What `germio` gains, so that Modio needs nothing else

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

### 7.2 A deed, written out

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
      "until": "meets($target)",
      "command": {
        "update_need": { "key": "curiosity", "delta": -25 },
        "record_event": { "kind": "met", "target_id": "$target" }
      }
    }
  },
  "once": false
}
```

**Every word here but four is `germio`'s own already.** `id`,
`trigger`, `condition`, `command`, `once`, `record_event`,
`history.time_since` — all stood before Modio did.

### 7.3 `$target` — the one new mark

A rule as written today names everything up front:

```text
"flags.route_forest == true"                    a name, fixed
"record_event": { "target_id": "stage_01" }     a name, fixed
```

**A deed cannot.** What it finds is known only once it looks. So
`$target` stands for whatever was found, in three places: choosing
(`condition`), ending (`until`), and writing down (`command`).

It is put in place **before** the Evaluator runs:

```text
before : history.time_since(kind=met, target_id=$target) > 60
after  : history.time_since(kind=met, target_id=g_0041) > 60
```

**`ExprLexer`, `ExprParser` and `Evaluator` are untouched.** `$`
belongs to no token kind today, so it runs into nothing else.

### 7.4 Why a mark of `germio`'s own making is needed

`$target` must hold something that means the same thing twice.
Counted on a real scene, 2026-08-21: **the object name will not do.**

| Tried             | Why it fails                                                                      |
| ----------------- | --------------------------------------------------------------------------------- |
| The name          | `Level_1` holds 24 pieces; three names are used twice over                        |
| `GetInstanceID()` | made new on every scene load, and `Despawn.cs` reads the scene again on each fall |
| `GlobalObjectId`  | Editor only; cannot be read while the game runs                                   |

So `germio` must give each piece a mark that is saved with the scene
(TASK-015 there). **Modio cannot remember a place until it can name
the same place twice.**

### 7.5 One rule at a time, by design

`germio`'s own `docs/dsl_spec.md` §6 sets a limit: a `history.*` call
works alone, or right inside one comparison. **Inside `&&`, `||` or
`!` it gives back `false`, always.**

Modio holds to this, and writes one condition to a rule. Where two
must be true at once, two rules are written, each with its own
trigger — the way that spec itself calls for.

**A limit taken on with open eyes, not a limit walked into.**

## 8. What Modio never does

+ **It never picks what to want.** That is `animo`'s own work.
+ **It never moves a body itself.** That is `germio`'s own work.
+ **It never writes into `animo`.** It calls `Affect`, and no more.
+ **It never lets a want quietly fall away.** Where a want cannot be
  carried through, the Deed ends **Failed**, and `animo` is left to
  ask again. It never stands in something easier and calls it done.

---

## 9. Still open

| # | Point                   | What is owed                                                                                                                                                       |
| - | ----------------------- | ------------------------------------------------------------------------------------------------------------------------------------------------------------------ |
| 1 | **The sensor**          | `germio`'s own TASK-014. **Nothing here can be built first.**                                                                                                      |
| 2 | How fast memory fades   | Count the blocks in a real `stemic` level. Work out, by real sums, whether the table stays small.                                                                  |
| 3 | Saying a line           | `Store.NotifyRequested` shows a line for the whole screen. A line over one character's head — as `super-nekokun`'s own `say()` gave — has no home in `germio` yet. |
| 4 | Facing forward, in full | §7 shows one shape (`seek.before`). The whole set of forward-facing questions is not worked out.                                                                   |
| 5 | Same answer, every run  | `animo` has `ScenarioRunner`, proving same input, same answer. Modio needs its own.                                                                                |
| 6 | Zero-GC                 | `animo` proved it with a test running `Live()` 100,000 times. Modio must meet the same bar.                                                                        |

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
