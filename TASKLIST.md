# TASKLIST

Work items still open for this repository. Any person may put in a new
item; the person who does the work marks it done (`+ [x]`) and puts the
change in as a commit.

<!-- format: v1 | fields: status, id, title, phase -->

+ [ ] TASK-001 [P-01]: Wait on germio TASK-014, the sensor — blocks everything
+ [ ] TASK-002 [P-01]: Work out, by real sums, how fast the memory must fade
+ [ ] TASK-003 [P-01]: Work out the whole set of forward-facing questions
+ [ ] TASK-004 [P-01]: Find a home in germio for a line said over a head
+ [ ] TASK-005 [P-01]: Put the spec through a hard-questioning G review
+ [ ] TASK-006 [P-02]: Build seeking, asking the sensor by type, reach, spread
+ [ ] TASK-007 [P-03]: Build the memory table, and the three depths of meeting
+ [ ] TASK-008 [P-03]: Build fading, to the rate TASK-002 settles
+ [ ] TASK-009 [P-03]: Prove no garbage is made on the hot path
+ [ ] TASK-010 [P-04]: Build the Deed, ending Done, Failed, or Dropped
+ [ ] TASK-011 [P-04]: Hold a Deed together with animo Lock, in Soft mode
+ [ ] TASK-012 [P-04]: Build the DSL reader, and a check that runs before play
+ [ ] TASK-013 [P-05]: Build the far look, reading rates and GetNeed
+ [ ] TASK-014 [P-05]: Build a runner, proving same input, same answer
+ [ ] TASK-015 [P-06]: Join Modio to stemic, and check it by real play
+ [ ] TASK-016 [P-XX]: Put the rest of the docs into Basic English

## Detail

### TASK-001

**Everything waits on this.** `germio`'s own TASK-014 builds the
sensor. Without seeking, Modio has no way to find a thing still far
off, and every want reaching outside the character would fall back on
waiting to be run into.

`docs/modio_spec.md` §6.3 sets out why no way around this is taken:
it would look as though it worked, while quietly throwing away
everything `animo` decided. **That is how `animo` itself came to be
missing a whole side, and this repository will not walk the same road
twice.**

### TASK-002

With no fading, the memory table grows with no end. Count the blocks
in a real `stemic` level, and work out, by real sums, whether the
table stays small at a given rate. **A guess is not a measure** — the
bar `animo` met when its own `suppression` sums were checked.

### TASK-003

`docs/modio_spec.md` §7 shows one forward-facing shape only
(`seek.before`). The whole set — every question a character may ask
about what is to come — is not yet worked out.

### TASK-004

`super-nekokun`'s own `Enemy.cs` gave a line over a character's head
(`say()`), which showed what the character had in mind. `germio` has
no such thing: `Store.NotifyRequested` shows a line for the whole
screen. A Behavior that cannot be seen cannot be checked by eye.

### TASK-005

Every other spec in this family stands on a real, hard-questioning G
review. This one does not yet.

### TASK-006

Build seeking: ask the sensor for a thing of a given `type`, within a
`reach` and a `spread`, and hold what comes back. **Meeting is not
seeking** — it belongs to TASK-010, as proof of arrival.

### TASK-007

Build the memory table (`when`/`what`/`object`/`with`), and the three
depths of meeting (`seen`, `met`, `held`), each fading at its own
rate.

### TASK-008

Build fading, at the rate TASK-002 settles. Two things must hold: the
table stays small, and a place met long ago becomes new again.

### TASK-009

`animo` proved zero garbage with a test running `Live()` 100,000
times. Modio must meet the same bar.

### TASK-010

Build `Deed`: one Behavior in, carried through over time, ending one
of three ways. Only **Done** writes anything at all. Write the failing
test first, and see it fail, before any code.

### TASK-011

`animo`'s own `Lock(duration, LockMode.Soft)` holds the Behavior
steady while a Deed plays out, and still lets a sudden Need break in.
`LOCK_DURATION_WARN_THRESHOLD` (30 seconds) is the ground under how
long a Deed may run.

### TASK-012

Build the reader for `modio.json`, plus a check that catches a bad
file before play, the way `animo`'s own Validator does.

### TASK-013

Build the far look: read the memory facing the other way, plus
`animo`'s own `rates` and `GetNeed(need)`. A Need climbing at +1.2 a
second sits 36 points higher in 30 seconds — **worked out, never
guessed.**

### TASK-014

`animo` has `ScenarioRunner`, proving same input, same answer. Modio
needs its own, or nothing here can be checked ahead of play.

### TASK-015

Put Modio into `stemic`, driving `place_curious` and
`company_seeking` (see `animo`'s own `docs/persona_design_spec.md`
§6), and check by real play that each truly seeks, remembers, and
acts on both.

### TASK-016

`docs/modio_spec.md` is written to the family rule already. The rest
of the docs, once written, must follow.
