# TASKLIST

Work items still open for this repository. Any person may put in a new
item; the person who does the work marks it done (`+ [x]`) and puts the
change in as a commit.

<!-- format: v1 | fields: status, id, title, phase -->

+ [ ] TASK-001 [P-01]: Work out, by real sums, how fast the memory must fade
+ [ ] TASK-002 [P-01]: Find a real measure behind the 30-second limit
+ [ ] TASK-003 [P-01]: Work out the whole set of forward-facing questions
+ [ ] TASK-004 [P-01]: Put the spec through a true G review
+ [ ] TASK-005 [P-02]: Build the Deed core, ending Done, Failed, or Dropped
+ [ ] TASK-006 [P-02]: Build the DSL reader, and its own check
+ [ ] TASK-007 [P-03]: Build the memory table, and its own fading
+ [ ] TASK-008 [P-03]: Prove no garbage is made on the hot path
+ [ ] TASK-009 [P-04]: Build Recall, facing back
+ [ ] TASK-010 [P-04]: Build Recall, facing ahead
+ [ ] TASK-011 [P-04]: Build a runner, proving same input, same answer
+ [ ] TASK-012 [P-05]: Join Modio to stemic, and check it by real play
+ [ ] TASK-013 [P-XX]: Put the rest of the docs into Basic English

## Detail

### TASK-001

`docs/modio_spec.md` §7 holds this open: with no fading, the memory
table grows with no end. Count the blocks in a real `stemic` level,
and work out, by real sums, whether the table truly stays small at a
given fading rate. **A guess is not a measure** — the same bar
`animo` met when its own `suppression` sums were checked.

### TASK-002

`limit: 30.0` (how long before a Deed is given up) is a plain guess
with no ground under it. Needs a real measure, from real play.

### TASK-003

`docs/modio_spec.md` §5.2 shows one forward-facing shape only
(`seek.before`). The whole set — every question a character may
truly ask about what is to come — is not yet worked out.

### TASK-004

Every other true spec in this family stands on a real, hard-questioning
G review. This one does not yet.

### TASK-005

Build `Deed`: one Behavior in, carried out over time, ending one of
three ways. Write the failing test first, and see it fail, before any
code at all.

### TASK-006

Build the reader for `modio.json`, plus a check that catches a bad
file before play, the same true way `animo`'s own Validator does.

### TASK-007

Build the memory table (`when`/`what`/`object`/`with`), and the
fading TASK-001 settles.

### TASK-008

`animo` proved zero garbage with a test running `Live()` 100,000
times. Modio must meet the same bar, and has no such test yet.

### TASK-009

Build `Recall` facing back: "have I touched that block", "have I
given to this one".

### TASK-010

Build `Recall` facing ahead: "where will my Needs sit in 30 seconds".
Reads `animo`'s own `rates`, which are fixed and plain, so the answer
is worked out, never guessed.

### TASK-011

`animo` has `ScenarioRunner`, proving same input, same answer. Modio
needs its own, or nothing here can be truly checked ahead of play.

### TASK-012

Put Modio into `stemic`, driving `place_curious` and
`company_seeking` (see `animo`'s own `docs/persona_design_spec.md`
§6), and check by real play that each acts on what it remembers.

### TASK-013

`docs/modio_spec.md` is written to the family rule already. The rest
of the docs, once written, must follow.
