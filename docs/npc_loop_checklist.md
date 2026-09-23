# NPC through animo and modio — every real thing still owed

> Made 2026-09-22, after nine tasks were designed, precise, TDD-shaped,
> across two repository builds — and not one line of any of them written
> yet. This holds every real thing still owed, checked live, so
> "the design is done" is never taken as "the game runs."

---

## Still owed — the whole list, in one place

+ [ ] Every one of the nine designed tasks — `TASK-038`, `TASK-039`
      (in `modio`); `TASK-070` through `TASK-075` (in `germio`) —
      holds a real, given Red test plan and not one true line of
      code. `TASK-037`, `TASK-067`, and `TASK-069` are the only three
      real, Green, built pieces this whole loop stands on so far
+ [ ] **The one true missing link between "wants to go this way" and
      a real button signal.** `TASK-070` (`germio`) makes `Human`'s
      own button fields made to work the same true way with a computed source; `TASK-039`
      (`modio`) makes `DeedRunner` know a real direction and distance
      to a real target. **No piece anywhere turns that direction into
      `Up`/`Down`/`Left`/`Right` true signals.** This was true from
      `docs/npc_input_compat_checklist.md`'s own first write, and
      still stands true now
+ [ ] `TASK-038`'s own `SeekResolver.Nearest` covers the
      `condition`-empty case alone. **The real, standing
      `rule_explore` (`Tests~/ModelTests/TestData/deed_rule.json`, in
      `germio`) holds a true, given, non-empty `condition`
      (`history.time_since(kind=met, target_id=$target) > 60`) —
      this real, standing sample is not covered by what stands
      designed today**
+ [ ] Zero garbage at real scale — many `DeedRunner`s at once, each
      calling `BroadPhaseLogic` every tick — is reasoned true, never
      measured true. `BroadPhaseLogic` itself is proven zero-garbage
      alone (`TASK-034`); many run together, at once, is not yet
      checked
+ [ ] Every real Windows Unity open, so far, has turned up a real,
      given bug no design caught first: a missing `using`, a missing
      `.asmdef` reference, a missing `LangVersion`, `bin`/`obj` read
      as Plugins. **The nine designed-not-built tasks should be held
      to the same true expectation** — real, given problems, not yet
      found, likely stand inside more than one of them
+ [ ] The kind-wide shared memory idea (`germio`'s own `TASK-074`,
      held as an idea alone) — not designed, not given a task number
+ [ ] `docs/npc_input_compat_checklist.md`'s own still-open items
      (in `germio`) — `mapGamepad()` not yet made `virtual`, the
      shared `VirtualControllerObject`, the phone-shake calls, the
      static `Look` field, and the `partial class` question — none
      touched by today's work
+ [ ] The narrow, given window where `DeedRunner` might still run one
      tick against a Node already truly gone, during an async scene
      change — held as a known, narrow risk, not yet given its own
      real check
