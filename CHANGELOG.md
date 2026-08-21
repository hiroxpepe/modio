# CHANGELOG

## v0.0.3 — 2026-08-21

+ Seeking moved into Modio, beside memory. The `germio` sensor plan
  broke in three places, all from one cause: seeking cut off from
  remembering. See `docs/modio_spec.md` §3.3.
+ Nothing blocks work now: no other repository must build a thing
  first.
+ Fading counted against a real level: `Level_1` holds 12 blocks, so
  fading at 120 seconds leaves nothing new at all.

## v0.0.2 — 2026-08-21

+ `docs/modio_spec.md` written again from nothing, on the three
  powers: Perceive, Remember, Enact.
+ A meeting may never stand in for seeking.

## v0.0.1 — 2026-08-20

+ First true draft of `docs/modio_spec.md`.
+ Repository set up to match the family standard (hooks, word lists,
  writing rules, checking tools).
+ `ROADMAP.md` and `TASKLIST.md` opened.
