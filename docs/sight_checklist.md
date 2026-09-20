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
