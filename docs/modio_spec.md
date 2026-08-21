# Modio Specification

> **Tulving-driven Memory and Seeing Ahead, for Game Agents**
> **v0.0.2** (written again from nothing, 2026-08-21) / first draft 2026-08-20
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

### Why v0.0.2 was written from nothing

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

v0.0.2 holds no way out. Where Modio needs a thing, it says so, and
waits for that thing to be built.

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

**Modio must be able to seek.** A sensor (`germio`'s own TASK-014)
is what makes seeking possible. Until it stands, Modio cannot be
built. See §6.

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

### 3.2 What Modio asks of a sensor

| Asked for  | Sense                                                      |
| ---------- | ---------------------------------------------------------- |
| `type`     | what kind of thing to look for (`germio`'s own type marks) |
| `reach`    | how far to look                                            |
| `spread`   | how wide to look                                           |
| Given back | what was found, and where it sits                          |

`germio`'s own `docs/sensor_spec.md` sets out a sensor of this shape.
**It is written, and not yet built.**

### 3.3 Meeting is proof of arrival

A meeting (`OnCollisionEnter`) says one thing, and says it well:
**"you got there."** Modio uses it for exactly that — to close a
deed, never to open one.

---

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

### 4.3 Fading

Rows fade with time: the ones longest past, and the ones least deep,
go first.

Fading is not for looks. It keeps two things true:

+ **The table stays small.** With no fading it grows with no end — a
  thing `animo`'s own zero-GC bar would never allow.
+ **A want for new places keeps working.** Once every place has been
  met, nothing is new any more. Fading makes a place new again.

### 4.4 Facing the other way

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

### 6.3 The one thing that blocks everything

**Modio cannot be built before `germio`'s own TASK-014 (the sensor)
stands.**

This is not a wish. Without seeking, every want that reaches outside
the character falls back on waiting to be run into — and a
character that waits is not carrying a want through. **It would look
as though it worked, while quietly throwing away everything `animo`
decided.** That is the very way `animo` came to be missing a whole
side of itself, and this spec will not walk the same road twice.

---

## 7. The DSL — `modio.json`

```json
{
  "schema_version": "1.0",
  "deeds": [
    {
      "behavior": "Explore",
      "seek": { "type": "Block", "reach": 15.0, "spread": 90.0,
                "not_in_memory": "met" },
      "phases": [
        { "body": "face" },
        { "body": "walk" }
      ],
      "until": { "meets": "Block" },
      "hold": { "mode": "soft", "at_most": 30.0 },
      "then": {
        "affect": [ { "need": "curiosity", "delta": -25 } ],
        "remember": "met"
      }
    },
    {
      "behavior": "Approach",
      "seek": { "type": "Human", "reach": 30.0, "spread": 120.0 },
      "phases": [
        { "body": "face" },
        { "body": "walk" }
      ],
      "until": { "near": 2.0 },
      "hold": { "mode": "soft", "at_most": 30.0 },
      "then": {
        "affect": [
          { "need": "loneliness", "delta": -30 },
          { "need": "separation", "delta": -40 }
        ]
      }
    },
    {
      "behavior": "Give",
      "given": { "holding": "Item" },
      "seek": { "type": "Human", "reach": 30.0, "spread": 120.0,
                "not_in_memory": "gave" },
      "phases": [
        { "body": "face" },
        { "body": "walk" },
        { "act": "hand_over" }
      ],
      "until": { "reparented": true },
      "hold": { "mode": "soft", "at_most": 30.0 },
      "then": {
        "affect": [ { "need": "togetherness", "delta": -30 } ],
        "remember": "gave",
        "world": { "flag": "gift_given", "value": true }
      }
    },
    {
      "behavior": "GoHome",
      "seek": { "type": "Home", "reach": 60.0, "spread": 360.0,
                "before": { "need": "fatigue", "reaches": 70 } },
      "phases": [
        { "body": "face" },
        { "body": "walk" }
      ],
      "until": { "near": 1.5 },
      "hold": { "mode": "soft", "at_most": 30.0 },
      "then": {
        "affect": [ { "need": "exposure", "delta": -30 } ],
        "remember": "met"
      }
    }
  ]
}
```

### 7.1 The words each part may take

| Part                 | Words                                                                   | Where it comes from                          |
| -------------------- | ----------------------------------------------------------------------- | -------------------------------------------- |
| `given`              | `holding`, `other_is`                                                   | `transform`, `DoUpdate`                      |
| `seek.type`          | `Block`, `Human`, `Home`, `Item`                                        | `germio`'s own `Env.cs`                      |
| `seek.reach`         | how far to look                                                         | sensor                                       |
| `seek.spread`        | how wide to look                                                        | sensor                                       |
| `seek.not_in_memory` | `met`, `gave`, `shown`                                                  | Modio's own memory, facing back              |
| `seek.before`        | a Need, and the value it reaches                                        | Modio's own memory, facing forward           |
| `phases[].body`      | `idle`, `walk`, `run`, `backward`, `jump`, `abort_jump`, `stop`, `face` | `germio`'s own `FixedUpdate`                 |
| `phases[].act`       | `hand_over`                                                             | making it a child of the other               |
| `until`              | `near`, `meets`, `reparented`, `elapsed`, `while`                       | sensor, meeting, `transform`, timer          |
| `hold.mode`          | `soft`, `hard`                                                          | `animo`'s own `LockMode`                     |
| `hold.at_most`       | seconds                                                                 | `animo`'s own `LOCK_DURATION_WARN_THRESHOLD` |
| `then.affect`        | a Need and a number (**more than one allowed**)                         | `animo`'s own `Affect`                       |
| `then.remember`      | `met`, `gave`, `shown`                                                  | Modio's own memory                           |
| `then.world`         | `flag`, `counter`                                                       | `germio`'s own `Scenario.initial_state`      |

**`seek` never takes a `trigger`. Meeting is proof of arrival, and
belongs in `until` alone.**

---

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
