# Sight — everything still owed, before the eyes truly see

> Made 2026-09-19, after a hard look at what `docs/modio_spec.md`
> §3.6.2, §3.7 and §3.7.3 say, and what they leave out. Every line of
> the sight design is work on paper: not one line of `Runtime/` has
> been built, and nothing here has been seen to run. This list holds
> what is owed, in three kinds: what the spec itself marks as open,
> what the spec never says at all, and what cannot be known until it
> runs.

---

## Still owed, checked 2026-09-21 — the whole list, in one place

+ [ ] The four thin Unity edges (`TASK-026`, `027`, `028`, `030`) — needs a real Windows Unity open
+ [ ] Zero-garbage proof across a whole tick (`TASK-031`) — waits on the point above
+ [ ] germio's own world table (`TASK-067`) — germio's own work
+ [ ] germio `TASK-069`'s own words, still reading "`Sight.eyes` (`modio`'s own name for it)" — words alone, no code, no Unity needed
+ [ ] stemic's own prefab for either persona (`TASK-018` to `023`) — stemic's own work, needs Unity
+ [ ] stemic's own new task, the `Explore` sweep (4.8-2) — not yet given a task number, needs Unity
+ [ ] The "3 in 10" count, from spec §3.7 — waits on `Runtime/` running
+ [ ] Whether the `Sight` numbers (210 by 150) truly suit a game character — only known once it runs
+ [ ] Reading `Choice.Angle` for a real target, once `Runtime/` can fill one (4.8-2) — waits on `Runtime/`

---

## 1. Open in the spec, and marked so

Each of these is already written down as not settled. They are held
here together so none is lost.

| # | What | Where | To settle it |
| --- | --- | --- | --- |
| 1 | **Settled 2026-09-19.** `Collider.ClosestPoint` is used outright. `Level_1`'s own colliders, checked one by one, are all `BoxCollider` or a convex `MeshCollider` (`Despawn`, `m_Convex: 1` — held out anyway by the trigger rule). Unity's own reference holds `ClosestPoint` true for both | spec §3.7.3 | Done |
| 2 | **Settled 2026-09-19, and kept as it stands.** Read once at start. Checked against every act in both personas (10 in all) and the first game's own plan: none asks for sight to change while play runs. `Sight` holds what a body can see at all, not what it is doing now | spec §3.7.6 | Done |
| 3 | `Self.Heading` is one `float`, so the wedge stays level: a character can look to the side but never up or down | TASKLIST-025 | **Weighed 2026-09-19, and kept.** `Human.cs` turns a body flat, never leaning; no act in either persona asks a character to look up. Up and down are held by `halfPitch` instead. But this same look turned up a real hole — sight was being taken from the body, not the head — now closed by `Sight.eyes` (§3.7.5). **Held 2026-09-19, and found short the next day — see part 4 below for the true, final word on who turns what, and toward where.** |
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
| 1 | **Closed 2026-09-21.** `Modio` now holds `Scripts/Modio.asmdef` and `Runtime/Modio.Runtime.asmdef` (`TASK-023`, done). Unity may take `Modio` in as a package | Everything, once. Now closed |
| 2 | Not one line of `Runtime/` itself is built (`TASK-026` to `TASK-028`, `TASK-030`) | The Unity edges alone. The logic behind each (`TASK-032`, `TASK-034`, `TASK-035`, `TASK-036`) is done, 2026-09-21, Green — `TASK-024`'s own wedge check too |
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
+ **Held at first, and turned over the next day (see 4.8):** this
  part first held the turning call itself as `germio`'s own work,
  matching how a body already turns. That did not hold up. The
  true, final word is in 4.8 below.

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
| 4 | **Set right, 2026-09-20 — this was never truly open.** `Found` and `Choice` (`TASK-019`, built) already answer it in full: neither ever holds a place in the world at all — each holds only `Angle`, `Distance` and `Height`, read against the body itself. `Found.cs`'s own words: "Nothing here is a Vector3, a Transform or a GameObject." Any number `modio` hands on for where to look was always going to be a body-relative angle, matching this same, already-built shape. What was missed was reading `Found.cs` before calling this open |

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

### 4.7 Held, 2026-09-20 — where each piece now stands

+ **`Sight` moves to `germio`.** `germio` already holds eight
  `MonoBehaviour` types, each with `[SerializeField]` values of its
  own (`Zone.cs` is one). `Sight` (`reach`, `halfYaw`, `halfPitch`,
  `eyeHeight`, `eyes`) fits this same shape. `germio` keeps its own
  depend-on-nothing place; `modio`'s `Runtime` reads the five
  values, and never the type itself — this also keeps the wedge
  check open to a plain `dotnet test`, with no live Unity behind it,
  since a `MonoBehaviour` cannot be made new outside one.
+ **Read `Engine.Behavior`, never `Engine.Snapshot()`, for the head
  turn.** `Snapshot()` builds three `Dictionary` objects and one
  more object, fresh, on every call — right for a monitor read once
  a frame, wrong for a read on every character, every tick.
  `Engine.Behavior` hands back the same string with nothing made
  new. Zero-GC for this piece turns on this one line.
+ **One new depend-on line, read-only:** `stemic` comes to depend on
  `animo`, to read `Behavior`. Today `stemic`'s own `manifest.json`
  names `germio` and `briko`, and no more. `germio`'s own
  depend-on-nothing place, and `animo`'s own depend-on-`germio`-only
  place, both stay as they stood.
+ **Zero-GC, held against the true code.** §9.1's own "Done" mark
  covers `Recall`'s own ring table alone, not `Sight` or the wedge
  check — those wait on `Runtime/`, which holds not one line of code, to be run and
  counted. The found-list's own fixed-16 plan (§3.7) already reads as
  zero-GC on paper. The one true risk found today —
  `Engine.Snapshot()` called every tick — is closed by reading
  `Engine.Behavior` instead.

### 4.8 Held, one day on — the three points 4.3/4.4/4.7 left hanging

Read back the next day, 4.3 said the turning call stayed `germio`'s
own work "for now"; 4.7 then said `stemic`'s own Look-At IK does it.
Both cannot be true at once. Two more points, never settled at all,
stood behind that one. All three are closed here.

**1. Who truly turns the head — `stemic`, and `stemic` alone.**
Unity's own Look-At IK (§4.4) only runs from `OnAnimatorIK`, a
call Unity makes on the same `GameObject` that holds the `Animator`
— `Pete`, in `stemic`. `germio` cannot be the one to call it; there
is no such call to make from outside. `germio`'s own part in this
whole idea shrinks to one thing alone: holding the `Sight` data
(4.7's first point), for `modio`'s wedge check. It calls no turn,
here or anywhere, for the head.

**2. What the head looks toward — a swept point today; a real
target, once one can be true.** Two things were never told apart:

+ `Sight`, and the wedge check it feeds (`TASK-024`) — this is
  `Perceive`'s own work, telling `modio` what stands near a
  character. It has no tie to what a head looks toward.
+ The head sweeping side to side while `Explore` runs — this is a
  played, made-up motion in `stemic` alone: a point that swings a
  set amount, left and right of the body's own front, on a timer.
  It is never a real thing found by `Sight`, and asks nothing of
  `modio`'s `Runtime` at all.

Row 3's own first word — a head turned toward the act's own real
target, not a made-up sweep — is not set aside outright after all;
only the "who calls it" half of row 3 was wrong (closed by point 1,
above: `stemic` alone, never `germio`). The "toward what" half may
yet stand. `Deed.Holding` (a `Choice`, `TASK-019`,
already built) already carries a body-relative `Angle` toward
whatever a character truly reaches for. Once `Runtime/` stands and
a `Choice` may hold a true, given thing (not `None`), the right
shape is two-fold: read `Choice.Angle` where `Holding` is truly
taken; fall back to the made-up sweep where it is `None` (nothing
yet chosen — most of `Explore`'s own running time). **A true, held
reason the sweep alone is built first:** `Runtime/` holds not one
line of code (part 3, #2), so no true `Choice` can be filled yet,
sweep or no. Building the sweep first, apart from `Sight` and
`Runtime` both, is the only path open today — but it is a first
step, not the whole of the answer.

**3. Which acts turn the sweep on — `Explore` alone, for now.**
`Patrol` was raised in 4.2 as a second true case. It belongs to
`goblin_scout`, a design case only (`docs/persona_design_spec.md`) —
no code, no `Behavior` string, nothing `Engine.Behavior` could ever
read today. Held: build against `Explore` (`place_curious`, real
and wired) alone. `Patrol` waits its own turn once `goblin_scout` is
more than a name on paper.

### 4.9 Held, 2026-09-21 — the logic side stands built, Green, and checked twice over

`TASK-021`, `TASK-022` (its `TargetMarkLogic` piece), `TASK-024`,
`TASK-032`, `TASK-034`, `TASK-035` and `TASK-036` all stand built
and Green — checked live, in this sandbox and again on a real
Windows machine, matching down to the failure count. Three real
holes, found only once Green work began, were closed the same day:
a `List<Place>` made new on every call (closed — the caller now
holds and reuses its own list); a zero `halfYaw`/`halfPitch` giving
a wrong "found" answer, from a division that gives `NaN` (closed —
guarded outright); and an empty or `null` `own_id` once wrongly taken
as a real character's own id (closed — `string.IsNullOrEmpty`).

**Still owed, and still real Unity work, none of it touched yet:**
the four thin edges (`TASK-026`, `027`, `028`, `030`) and the one
true, running proof of zero garbage across a whole tick
(`TASK-031`) — every one of these needs a real Windows Unity open,
which this sandbox does not have.

---

## The order to take them in

```text
1. spec, part 2      settled 2026-09-19         — done
2. TASK-023          the asmdef                 — done, 2026-09-21
3. TASK-024          the wedge check             — done, 2026-09-21, Green
4. germio TASK-067   the world table             — germio's own work
4b. germio TASK-069  set right, per 4.8          — words changed, no code
5. stemic TASK-018+  a prefab to look through    — stemic's own work
5b. stemic, new task the Explore sweep, per 4.8   — stemic's own work, held apart from Sight
6. TASK-026 to 031   Runtime, the eyes           — the logic half (032/034/035/036) done, 2026-09-21; the Unity-edge half (026-028, 030-031) still needs a real Windows Unity open
7. part 1, part 3    settle the rest by eye      — once it runs
```

Step 1 is done. Step 2 is done. Step 3 is done, Green, and checked twice over
(4.9 above). Step 4b is words alone — `TASK-069` still reads
"`Sight.eyes` (`modio`'s own name for it)", which 4.8 has now set
aside; the task's own words are owed a fix, to match. Steps 4, 4b,
5 and 5b belong to other builds, and 4b/5b do not wait on 4 or 5 —
the sweep (5b) stands apart from `Sight` outright, per 4.8. Step 6
is half done — the logic side, Green — and half still waiting on a
real Unity open. Step 7 is where what was guessed is either held
true or thrown out.
