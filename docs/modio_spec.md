# Modio Specification

> **Tulving-driven Memory and Seeing Ahead, for Game Agents**
> **v0.0.1** (first draft) / 2026-08-20
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

---

## 1. Why Modio must be

### 1.1 The three questions

Each part of the STUDIO MeowToon game stack answers one question:

| Repository | Question | Holds     |
| ---------- | -------- | --------- |
| `germio`   | WHAT     | the world |
| `animo`    | WHY      | the want  |
| `modio`    | HOW      | the deed  |

`animo` answers "what do I want" every true tick, and gives back one
Behavior — a plain string. `germio` holds the world: a body that
walks, blocks that sit, items that may be held. **Between the two
sits a gap that neither can close.**

### 1.2 The gap

**A want is of the moment. A deed takes time, and may fail part way.**

`animo` says `"Explore"` this tick, and `"Explore"` the next, and the
next. It never learns whether the character truly went anywhere. It
holds no place, no object, no other agent — by design (see
`animo`'s own `docs/adapter_spec.md`).

`germio` moves the body, but knows nothing of want. It cannot say
whether walking for a long stretch counts as "explored".

**Modio takes one Behavior and carries it out as one Deed: a thing
with a start, a middle, and one of three ends.**

### 1.3 The second gap: no one remembers

A deeper hole sits under the first.

`animo` holds Needs — the state of now. `germio` holds the world —
the state of now. **Neither holds the past.**

So:

+ `"Explore"` (a want for new places) cannot work: no one knows which
  place is new.
+ `"Give"` cannot work: no one knows who was already given to.
+ `"ShowFind"` cannot work: no one knows what was already shown.

**Modio holds the memory. It is the only layer with a past.**

---

## 2. The ground this stands on

### 2.1 Tulving's own three kinds of memory (1972, 1985)

Endel Tulving set out three kinds of memory:

| Kind    | Sense                               | Who holds it here |
| ------- | ----------------------------------- | ----------------- |
| Doing   | how the body does a thing           | `germio`          |
| Knowing | general knowledge of the world      | `germio.json`     |
| Living  | what **I** did, **when**, **where** | **`modio`**       |

**Only the memory of living is missing from the stack today.**

### 2.2 Tulving's own deeper claim: mental time travel

Tulving later held that the true point of the memory of living is **not**
remembering the past. It is that **the same paths let a mind
picture what is to come.**

This is settled science, not a guess. Work on people who have lost their memory,
shared brain activity seen in scans, and studies of what people do,
all point the same way: people use the memory paths that bring back past
events to build pictures of what may come.

**So a layer that holds the memory of living can see ahead by the same
paths, not as an added part.**

### 2.3 What already exists, and what does not (checked 2026-08-20)

NPCs that remember are no longer new. `Wanderfolk`, `MemoryLake`,
`Inworld AI`, and `Mantella` all hold NPC memory today.

**But every one of them runs on an LLM, with a search by meaning.**
Each needs a server, a key, a sum paid for every call, and gives an
answer that shifts run to run.

|                         | LLM-backed NPC memory | **Modio**        |
| ----------------------- | --------------------- | ---------------- |
| What runs it            | an LLM, by meaning    | plain numbers    |
| Where it runs           | a server              | all on its own   |
| Same input, same output | no                    | **yes**          |
| Mobile                  | no                    | **yes, zero-GC** |
| Checked ahead of play   | no                    | **yes**          |

**A library for the memory of living, and for seeing ahead, that runs
on its own, gives the same answer every time, and makes no garbage, built
for game agents, was not found.** That is the ground
Modio stands on.

This is the same road `animo` took: it turned Maslow's own hierarchy
into two plain numbers (`tier` and `suppression`) and proved the
result with 452 tests and zero garbage on the hot path. **Modio turns
Tulving's own mental time travel into plain numbers, and must meet the
same bar.**

---

## 3. The two cores

### 3.1 `Deed` — one thing done

A Deed takes one Behavior and carries it out over time. It ends in
one of three ways:

| End         | To `animo`                      | To memory | To the world |
| ----------- | ------------------------------- | --------- | ------------ |
| **Done**    | `Affect` (may be more than one) | written   | written      |
| **Failed**  | nothing                         | nothing   | nothing      |
| **Dropped** | nothing                         | nothing   | nothing      |

+ **Done** — the Deed reached its own end. The Need falls; the memory
  is kept.
+ **Failed** — the Deed could not reach its end (no target found, the
  target left, time ran out). The Need does not fall, so `animo` will
  ask again.
+ **Dropped** — `animo` gave a different Behavior part way. The Deed
  folds, and the next one starts.

### 3.2 `Recall` — one road, two ways

`Recall` reads the memory. **Which way it faces is the only
difference.**

| Facing      | Asks                                     | Reads                                              |
| ----------- | ---------------------------------------- | -------------------------------------------------- |
| **Back**    | "Have I touched that block?"             | the memory itself                                  |
| **Forward** | "Where will my Needs sit in 30 seconds?" | the memory's own shape, plus `animo`'s own `rates` |

Facing forward works because `animo`'s own `rates` are fixed and
plain: a Need that climbs at +1.2 a second will sit 36 points higher
in 30 seconds. **The future of a want can be worked out; it need not
be guessed.**

This is Tulving's own claim, put to work: **one road, two
directions.**

---

## 4. The memory itself

One table, one per character.

| Column   | Sense                                 |
| -------- | ------------------------------------- |
| `when`   | the time it happened (for fading)     |
| `what`   | `touched` / `held` / `gave` / `shown` |
| `object` | what it was done to                   |
| `with`   | who it was done with (may be empty)   |

**Nothing else.** A row is written only when a Deed ends **Done**.

### 4.1 Fading

Rows fade with time: the ones longest past, and the ones least deep,
go first.

Fading is not for looks. It is what keeps two things true:

+ **The table stays small.** With no fading it grows with no end — a
  thing `animo`'s own zero-GC bar would never allow.
+ **`Explore` keeps working.** Once every block has been touched,
  nothing is new any more, and `Explore` dies. Fading makes a place
  new again.

### 4.2 How deep a memory sits

Master's own word: seeing, touching, and holding are not the same
weight. They are three depths of one true meeting.

| Depth       | How it happens       | Fades   |
| ----------- | -------------------- | ------- |
| **seen**    | the Sensor caught it | fast    |
| **touched** | the bodies met       | slower  |
| **held**    | it was made a child  | slowest |

**This mirrors `animo`'s own five stages: `animo` holds want in
layers, `modio` holds meeting in layers.**

---

## 5. The DSL — `modio.json`

```json
{
  "schema_version": "1.0",
  "deeds": [
    {
      "behavior": "Explore",
      "seek": { "type": "Block", "not_in_memory": "touched" },
      "phases": [
        { "body": "face" },
        { "body": "walk", "say": "Something new?" }
      ],
      "until": { "hit": "Block" },
      "limit": 30.0,
      "then": {
        "affect": [ { "need": "curiosity", "delta": -25 } ],
        "remember": "touched"
      }
    },
    {
      "behavior": "Give",
      "given": { "holding": "Item" },
      "seek": { "type": "Human", "by": "sensor", "not_in_memory": "gave" },
      "phases": [
        { "body": "face" },
        { "body": "walk" },
        { "act": "hand_over", "say": "This is for you." }
      ],
      "until": { "reparented": true },
      "limit": 30.0,
      "then": {
        "affect": [ { "need": "togetherness", "delta": -30 } ],
        "remember": "gave",
        "world": { "flag": "gift_given", "value": true }
      }
    },
    {
      "behavior": "Approach",
      "seek": { "type": "Human", "by": "sensor" },
      "phases": [
        { "body": "face" },
        { "body": "walk" }
      ],
      "until": { "near": 2.0 },
      "limit": 30.0,
      "then": {
        "affect": [
          { "need": "loneliness", "delta": -30 },
          { "need": "separation", "delta": -40 }
        ]
      }
    }
  ]
}
```

### 5.1 The words each part may take

| Part                 | Words                                                                   | Where it comes from                   |
| -------------------- | ----------------------------------------------------------------------- | ------------------------------------- |
| `given`              | `holding`, `other_is`                                                   | `transform`, `DoUpdate`               |
| `seek.type`          | `Block`, `Human`, `Home`, `Item`                                        | `germio`'s own `Env.cs` type marks    |
| `seek.by`            | `sensor`, `name`                                                        | `germio`'s own Sensor, `Like()`       |
| `seek.not_in_memory` | `touched`, `gave`, `shown`                                              | **Modio's own memory**                |
| `seek.before`        | a Need, and the value it reaches                                        | **Recall, facing forward**            |
| `phases[].body`      | `idle`, `walk`, `run`, `backward`, `jump`, `abort_jump`, `stop`, `face` | `germio`'s own `FixedUpdate`          |
| `phases[].act`       | `hand_over`                                                             | making it a child of the other        |
| `phases[].say`       | any words                                                               | `super-nekokun`'s own `say()`         |
| `until`              | `elapsed`, `near`, `hit`, `reparented`, `while`                         | timer, distance, bodies meeting, `tf` |
| `then.affect`        | a Need and a number (**more than one allowed**)                         | `animo`'s own `Engine.Affect`         |
| `then.remember`      | `touched`, `gave`, `shown`                                              | Modio's own memory                    |
| `then.world`         | `flag`, `counter`                                                       | `germio`'s own `Store`                |

### 5.2 Facing forward, in the DSL

```json
"seek": { "type": "Home", "before": { "need": "fatigue", "reaches": 70 } }
```

**"Head for home before I am worn out."** One line. This is the whole
point of the forward-facing Recall: a character that acts ahead of its
own need, not after it.

---

## 6. What Modio never does

+ **It never picks what to want.** That is `animo`'s own work.
+ **It never moves a body itself.** That is `germio`'s own work.
+ **It never writes into `animo`.** It calls `Affect`, and nothing more.

---

## 7. Still open

| # | Point                   | What is owed                                                                                                          |
| - | ----------------------- | --------------------------------------------------------------------------------------------------------------------- |
| 1 | How fast memory fades   | Count the blocks in a real `stemic` level. Work out, by real sums, whether the table truly stays small.               |
| 2 | `limit: 30.0`           | A guess with no ground under it. Needs a real measure.                                                                |
| 3 | Zero-GC                 | `animo` proved it with a test running `Live()` 100,000 times. Modio must meet the same bar, and has no such test yet. |
| 4 | Facing forward, in full | §5.2 shows one shape only. The whole set of forward-facing questions is not yet worked out.                           |
| 5 | Same answer, every run  | `animo` has `ScenarioRunner`, proving same input, same answer. Modio needs its own.                                   |

---

## 8. Where this came from

Every part of this spec was found by reading real code, not by guessing:

+ `germio`'s own `FixedUpdate` holds seven true states, and no more.
+ `germio`'s own `Env.cs` already names `Home`, `Item`, `Block`.
+ `Like()` picks objects by the name they carry.
+ Holding has been the parent-child tie for three whole builds
  (`super-nekokun`'s own `Item.cs`, then `Holdable.cs`, then
  `germio`'s own `Common.Holdable` with `tropika`'s own
  `Block_Holdable`).
+ `super-nekokun`'s own `Enemy.cs` already shows a wandering NPC:
  random turns, a plate to stay on, a word said out loud, and a timer
  for the wait.
+ `super-nekokun`'s own `Player.cs` shows one deed reaching three
  layers at once: the body (`transform.parent`), the character
  (`doUpdate.holding`), and the game itself (`gameSystem.hasKey`).

**Modio adds one thing none of them hold: a past.**
