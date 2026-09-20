# Sight — everything still owed, before the eyes truly see

> Made 2026-09-19, after a hard look at what `docs/modio_spec.md`
> §3.6.2, §3.7 and §3.7.3 say, and what they leave out. Every line of
> the sight design is work on paper: not one line of `Runtime/` has
> been built, and nothing here has been seen to run. This list holds
> what is owed, in three kinds: what the spec itself marks as open,
> what the spec never says at all, and what cannot be known until it
> runs.

---

## 1. Open in the spec, and marked so

Each of these is already written down as not settled. They are held
here together so none is lost.

| # | What | Where | To settle it |
| --- | --- | --- | --- |
| 1 | **Settled 2026-09-19.** `Collider.ClosestPoint` is used outright. `Level_1`'s own colliders, checked one by one, are all `BoxCollider` or a convex `MeshCollider` (`Despawn`, `m_Convex: 1` — held out anyway by the trigger rule). Unity's own reference holds `ClosestPoint` true for both | spec §3.7.3 | Done |
| 2 | **Settled 2026-09-19, and kept as it stands.** Read once at start. Checked against every act in both personas (10 in all) and the first game's own plan: none asks for sight to change while play runs. `Sight` holds what a body can see at all, not what it is doing now | spec §3.7.6 | Done |
| 3 | `Self.Heading` is one `float`, so the wedge stays level: a character can look to the side but never up or down | TASKLIST-025 | **Weighed 2026-09-19, and kept.** `Human.cs` turns a body flat, never leaning; no act in either persona asks a character to look up. Up and down are held by `halfPitch` instead. But this same look turned up a real hole — sight was being taken from the body, not the head — now closed by `Sight.eyes` (§3.7.5). **Settled in full 2026-09-19: what turns a thing toward what it looks at.** Checked live: `germio`'s own `faceToFace` is written but never called, and no line in the whole of `germio` ever sets `.Rotation`; no act in either persona asks for a turn alone. Real study of a body's own turning splits it two ways — a fast, automatic pull toward something sudden (settled ~100 ms), and a slower, turn, held on purpose toward a goal (settled past 300 ms, and held). Only the kind held on purpose is taken up here: when `animo` picks an act, `germio` turns `Sight.eyes` toward that act's own target, slow, with `Quaternion.Slerp`, the same way `Human.cs` already turns a body. The fast, automatic pull toward a sudden thing is left out, matched to §3.7.1's own rule that an unseen thing reads the same as a gone one — a missed pull reads the same way. This is `germio`'s own new work, not `Modio`'s |
| 4 | The 3 in 10 that reach stage two was counted before `Sight` cut the sphere down | spec §3.7 | Count it again, once `Runtime/` runs |

---

## 2. Never said at all — closed 2026-09-19

These five were found on 2026-09-19 and settled the same day. Each is
now written into `docs/modio_spec.md`; nothing here is left to guess
at.

| # | What | Where it is settled now |
| --- | --- | --- |
| 1 | Bounds on the `Sight` values | §3.7.4 — below 0 `reach` throws; a half-angle of 0 or less throws; too-large values are cut down with a warning. The shape `animo`'s own `Engine.Lock` already holds |
| 2 | Where stage two throws from | §3.7.5 — from the eyes. `Sight` gains a fourth value, `eyeHeight`. From the feet, a character would meet its own floor |
| 3 | How `Found.Height` is worked out | §3.7.5 — the met point's own height, less the character's base. From the feet, not the eyes, so a place does not move when a body bends low |
| 4 | A `reach` of 0 | §3.7.4 — allowed, and takes no Unity call at all. A character that for now sees nothing is a real thing to want |
| 5 | `Sight` changed while the game runs | §3.7.6 — read once at start, and a later change does nothing. Said plainly, so no one is caught out |

**`Sight` now holds five things:** `reach`, `halfYaw`, `halfPitch`,
`eyeHeight`, and `eyes` (which `Transform` it looks from).

---

## 3. Cannot be known until it runs

Nothing here is a hole in the writing. Each is a thing that is only
true once something exists to be true of.

| # | What stands today | What it blocks |
| --- | --- | --- |
| 1 | Modio holds no `.asmdef`, so Unity cannot take it in at all (TASK-023) | Everything. `Runtime/` has nothing to stand on |
| 2 | Not one line of `Runtime/` is built (TASK-025) | The whole design has never been run |
| 3 | `germio` holds no world table (its own TASK-067) | `Runtime/` has no one to ask for a kind or an id |
| 4 | `stemic` holds no prefab for either persona (its own TASK-018 to 023) | There is no body to put a `Sight` part on |
| 5 | The `Sight` numbers are borrowed from a person's own eyes (210 by 150) | Whether they suit a game character at all is unknown |

---

## 4. The head-turn idea — held up today, and found short (2026-09-20)

Row 3 in part 1 called the head-turn "Settled in full" on 2026-09-19.
Today it was held up again, against the true code and against
`package.json`. What stood was less settled than the words said.

### 4.1 Checked against the true code

+ No `Sight` type stands anywhere at all — not in `germio`, not in
  `modio`, not in `animo`.
+ `faceToFace` still stands unused, as row 3 already said.
+ No line ties `animo`'s pick of an act to any turn of the eyes.

So "Settled in full" meant a plan was made on paper, and no more.
Read row 3 that way from now on.

### 4.2 Is the head-turn truly owed?

+ A first read said no: `Rest`, `GoHome`, `Approach`, `ShowFind`,
  `Explore`, `Call`, `Tend`, `Give` — none asks the body to face one
  way while it looks another.
+ A truer read says yes: `Explore` and `Patrol` **are** this case. A
  character that explores or walks a round without turning its head
  looks wrong. The first read was too quick, and is set aside.

### 4.3 Who moves the neck — held up, and split three ways

+ The plan in row 3 has `germio` turn `Sight.eyes`. But `Sight` is
  `modio`'s own type (§3.6, §3.7.3). For `germio` to read it,
  `germio` would need to depend on `modio`.
+ Checked against `package.json` in all three: `germio` depends on
  nothing; `animo` depends on `germio`; `modio` depends on both. A
  line from `germio` to `modio` runs the wrong way, and breaks this
  order.
+ Weighed, and set aside: `modio` holding the bone itself and
  turning it. `germio` already holds all turning of a body
  (`Human.cs`), and a Deed's own `face` step (§5.2) leans on that.
  Splitting "turning" across two layers would only raise the same
  question again for the body's own turn.
+ Where the bone itself sits: `stemic` holds `Pete`, a Humanoid rig
  with a true `Head` bone. Neither `germio` nor `modio` should know
  this bone by name, since a body with no head at all (§3.7.5's own
  "block-shaped thing") must still work.
+ Held for now: the turning call stays `germio`'s own work in name,
  matching how a body already turns. Which `Transform` is handed to
  it, and how that `Transform` is kept from a fight with the walk
  animation, is `stemic`'s own work, through Unity's own Humanoid
  Look-At IK.

### 4.4 A real neck, turned while a walk plays on — checked, not run

+ Unity turns a Humanoid's head, neck and eyes toward a point
  through `Animator.SetLookAtPosition` and `SetLookAtWeight`, called
  from `OnAnimatorIK`, once "IK Pass" is turned on for the layer.
  This runs after the walk pose is laid down, so both hold true at
  once.
+ `stemic`'s own word list already allows `OnAnimatorIK`, and
  `Assets/Plugins/UniRx` already wraps it. `Pete`'s own `.fbx.meta`
  reads Humanoid. The true parts stand ready, though none of this
  has been run.
+ A point, handed to `SetLookAtPosition` fresh on every tick, can
  turn the head side to side while the walk plays on. This is not
  yet run in `stemic`.
+ A warning, from Unity's own words, not yet checked live:
  `clampWeight` holds a neck back from turning too far from the
  body's own front. A slight turn should hold true; a turn near a
  right angle may be held back and never fully reached.

### 4.5 A newer plan — `modio` hands on a number, not a `Transform`

To keep `germio` free of any tie to `modio`, and `modio` free of any
tie to a `Transform`, one more plan was raised: `modio` works out,
on its own, where a character should look, as a number — the same
way it already hands on a `motion` or a `target` (§7.3) — and hands
that number on. **Held up, and found short, on four counts:**

| # | What is short |
| --- | --- |
| 1 | "`modio` touches nothing of Unity at all" does not hold. §3.3.2 says outright that `Runtime` already reads `transform.forward`, straight off the body, for `heading`. The true rule is narrower: reading is allowed; moving a body is never allowed (§8) |
| 2 | Nothing says where the number for "what to look toward" would come from. `Perceive` (§3.3) hands back what is found, not a pick of where next to look; no line ties one to the other |
| 3 | A `Deed`'s own three steps (§5.2) each hold a clear end. A head turning side to side while a walk plays on has no end at all. Nothing in `modio`'s design today holds a kind of output that runs on without a stop |
| 4 | Whether the number is a place in the world or an angle held against the body is not settled. A place still asks for `heading` to make sense of it; an angle asks `germio` or `stemic` to turn it into a place. Either way, something new must be agreed and written down |

Two counts already open, from part 3 above, stand in this newer
plan's own way too:

+ `Runtime/` holds not one line of code (part 3, #2). There is
  nowhere yet to put this new work.
+ A `Deed` does not carry the `id` of what it reached for, through
  to its own end (§9.2, #3). "What to look toward" would run into
  the same kind of hole.

### 4.6 Where this stands now

No code has been written for any of this. `TASK-023` and `TASK-024`
still stand ready to take up first, apart from everything above. The
head-turn itself waits on: a settled place for `Sight` (or for
`modio`'s own new number) that keeps the depend-on order true; a
settled kind of output that can run on without a stop; and
`Runtime/` itself, which stands on nothing today.

---

## The order to take them in

```text
1. spec, part 2      settled 2026-09-19         — done
2. TASK-023          the asmdef                 — no Unity open needed
3. TASK-024          the wedge check            — dotnet test, twelve tests
4. germio TASK-067   the world table            — germio's own work
5. stemic TASK-018+  a prefab to look through   — stemic's own work
6. TASK-025          Runtime, the eyes          — a real Unity open
7. part 1, part 3    settle the rest by eye     — once it runs
```

Step 1 is done. Steps 2 and 3 need no Unity at all, and may be done here, today. Steps
4 and 5 belong to other builds. Step 6 is where the design is
first put to the test, and step 7 is where what was guessed is either
held true or thrown out.
