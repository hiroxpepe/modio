# Why a `place` should be wrong at times, and how

> Made 2026-09-19. This whole design is talk on paper, weighed hard
> against real study, twice thrown out and built again. Nothing here
> is built; nothing here is the last word. It is cross-marked from
> `docs/modio_spec.md` §4.3.

---

## 1. The question that started this

`Self.Heading` (§3.3.2) is read straight off Unity's own world turn.
So is the place a character stands at (§4.3), turned into a world
point and rounded. **A character reading the world's own true turn
and true point has a sense of place no living thing has.** People
get lost. Do the two square with a game where `animo`'s own `Need`
values are meant to make a character feel alive?

---

## 2. What real study says a body's own sense of place is built from

Four cell kinds, found in the brain's own memory part and the part beside it, were behind a 2014 science
prize. Each kind fires for one thing:

| Cell kind           | Fires for                          |
| ------------------- | ---------------------------------- |
| place cell          | one given place, and no other      |
| step-count cell     | steps taken, added up as one walks |
| head-direction cell | which way the head itself points   |
| edge cell           | a wall or a drop close by          |

`Modio`'s own design, by chance, already lines up with three of the
four: `Self.Heading` with the head-direction cell, `place` with the
place cell, `angle`/`distance` with the step-count cell, `Wall`'s own kind
with the edge cell.

**The edge cell's own true rule, checked hard 2026-09-19:** it fires
for a wall's own distance and way round from the body, and **takes
no notice of an object put down near it at all** — adding a thing to
a room changes nothing in how these cells fire, only a true wall
does. This throws out, outright, any design that names a `place`
from what things stand there; only the shape of the walls around a
body may.

**A step-count cell's own count of steps drifts.** The more steps from where
counting began, the less true the count is. **A place cell's own
firing puts that drift right**, given something seen that is known —
but where two rooms look alike, the putting-right itself goes wrong, and
the count of steps is thrown out for a place that is not truly there.

---

## 3. Two designs tried here, and thrown out

### 3.1 Naming a `place` by what is seen right now

**Tried:** build the name from the kind and count of things `Found`
holds, at the moment asked.

**Thrown out:** turning the head changes what is seen, so the same
spot would carry a different name each way it is faced. `§4.5.1`
holds that a `place` is saved, and stands across one level to the
next; a name that turns with the head cannot be saved at all.

### 3.2 Letting a walked count of steps drift with error

**Tried:** hold a guessed point that drifts a little with each step,
righted only where what is seen matches an old `place`.

**Thrown out:** it gives no true telling of why people do **not** get
lost — at home, on a walked road, near a plain, known mark. Drift
alone climbs the more one walks, with nothing to say why home is
never lost.

---

## 4. Why a mistake is made at all — not drift, but how deep a

memory sits

**A memory does not simply fade with time. It is worked over, after
the fact, and made to hold true — this is real, and real study has
a name for it.** Three things stand behind it:

+ **Going over it again, while still.** The hippocampus (the brain's
own memory part) plays back a
  walked road, fast, in short waves — while the body stands still, or
  rests. Walking a road once is not what makes it hold; going over it
  again, after, is.
+ **Feeling makes a memory hold harder.** A place tied to a strong
  feeling is gone over again with the amygdala (the brain's own
  feeling part) working beside the hippocampus, and holds far
  stronger than a plain one.
+ **Holding is a choice, not a mere fade.** Weak ties are cut; strong
  ties are built up. This is why home is never taken for a strange
  room, though both are old by the clock, the same.

**So the true root of a mistake is this: a memory that has not held
long can be taken for another; one that has held long is almost
never taken wrong.** Home is gone
over so many times, and tied to so much feeling, that no strange room
could ever be taken for it. A passage walked once, with nothing
felt, does not hold deep, and is an easy mistake.

---

## 5. The design, three parts

### 5.1 `Depth` already holds the strength a memory needs

`§4.4` already gives three depths — `seen`, `met`, `held` — each
fading at its own speed, slowest for the deepest. **This is the same
shape as strength through feeling and going-over.** Nothing new is
needed here.

### 5.2 A strong `Affect` should lift a `Depth`, one step

**Not yet built.** `Hand.Landed` already calls `IMind.Affect(need,
delta)` when a deed lands. Where `delta`'s own size passes a mark not
yet set, the `Row` made for that meeting is written one `Depth` step
higher than it would stand on its own — `seen` becomes `met`. This is
the amygdala's own true part, carried into one line of code.

### 5.3 A `place`'s own name comes from the shape of what stands in the way

**Thrown out by the master, 2026-11-14: it would not truly work.** A run on `stemic`'s own `Level_1` (its 12 blocks, read from `Level_1.unity`; a stand every 0.5 on each ground, faced 4 ways: 4,916 stands) gave 372 names. The most common name, all 12 cells `x`, came at 550 stands (11 in 100), at places as far as 34.6 apart. Of the 58,992 cells, `x` was 71.5 in 100, `near` 27.2, `mid` 1.3, and `far` 16 cells alone; the top row was almost always `x`, since the blocks stand lower than the eye. So the name is made by a few cells, `far` is almost never used, and facing open ground gives one name anywhere. Put in for the run, as nothing is settled: the band lines at 10, 20, and 30; the eye 1.0 over the ground; the sight of `germio`'s own `Sight.cs` as it starts (`reach` 30, `halfYaw` 90, `halfPitch` 45); every stand, and not the ways in alone. Nothing of the run is kept.

**Not yet built. Thrown out once already, 2026-09-19, and built
again true.** The first try named a `place` from the kind and count
of everything `Found` held — a rich mix here, a plain one there.
**Real study says this is wrong outright.** Boundary cells — the
brain's own cells for a sense of place, standing beside the place
cell itself — fire for a wall's own distance and direction, and
**take no notice of an object at all**: adding a thing to a room
changes nothing in how these cells fire; only a true wall does.

So a `place`'s own name is drawn not from what is held, but from
**how far something a body cannot walk through stands, seen as a
flat picture, not a set of single lines.** "Cannot walk through" is
not one of `germio`'s own eleven marks alone — a real study wall is
anything that truly blocks moving on, so this reaches `Wall` and
`Block` alike, whatever `germio` may add later.

**A picture, cut into a rough set of cells — checked against a body's own
true sight, 2026-09-19.** `Sight` (§3.7.3, §3.7.4) already holds a
wide-by-tall shape, 210 by 150 (or whatever `halfYaw`/`halfPitch` a
prefab holds), a ratio of 1.4 to 1. A set of cells true to that ratio, at its
smallest whole size, is **4 across by 3 up-and-down — 12 cells in
all**, not a row of eight single lines run out from the body. At a
way-in (§4.3's own step-crossed-or-wall-gone-round moment), each of
the 12 cells holds the distance to the nearest thing that blocks
moving on, within that cell's own slice of the whole sight.

**Rounded rough, not fine — a real body's own true limit, checked
2026-09-19.** A person's own sense of distance holds true only to
about 20 units; past that, real study shows the guess grows badly
wrong, fast. So no true number is kept at all — each cell is read as
one of four bands alone: `near` (well within reach), `mid`, `far`
(near the edge of `reach`), or `x` (nothing found within `reach`). A
picture such as this:

```text
far   mid   mid   far   |
mid   near  near  mid   |  (12 cells, read left to
x     near  near  mid   |   right, row by row)

→ "p_f_m_m_f_m_n_n_m_x_n_n_m"
```

Held fixed from there on, however the head later turns, until the
next way-in is crossed. **The rough bands do double work: they hold
a body's own true limit on telling distance apart, and, being few,
they make two given places more likely to share one name — the very
thing a mistake asks for.**

**Why this, and not a kind or a count at all.** A wall's own shape
around a body does not care what a game calls it — `Wall`, the side
of a hill, a river's own far bank, a building's own front. Real
study backs this outright: boundary cells fire for **any true
boundary to moving through**, never for the name given to it. So this
shape holds true wherever `germio`'s own eleven marks are rich, and
just as true where a game's own world calls for kinds no plan here
has thought of yet — nothing about the shape asks `germio` to widen
its own marks at all.

**Where two ways in give the same rough shape, they draw the same
name.** This is the true root of a mistake: two rooms built the same
size, walled the same way, but standing far apart, would share one
`place` name — the very thing real study shows happens to a body
walking between two truly alike rooms.

---

## 6. How this plays out, put plainly

| What stands                                                         | What follows                                                                                                       |
| ------------------------------------------------------------------- | ------------------------------------------------------------------------------------------------------------------ |
| a young (`seen`) memory of place A, and a like scene met at place B | the character reads B as A — walks on without looking, though B is new                                             |
| `seen` fades fast (§4.4)                                            | the mistake sets itself right soon; a later pass finds B fresh again                                               |
| a deep (`met`/`held`) memory of place A, met again at place B       | the mistake holds far longer — the character keeps away from B as it did A                                         |
| an `edge` (§4.5) tied to place A, met at place B                    | the character fears a drop that is not there at B — a real fit with the `fear` Need                                |
| the same way in walked again and again                              | each landed deed may lift its own `Depth` (§5.2) — the true place, told apart from any like one, holds ever deeper |

**This also tells why a home is never lost.** Walked and felt again
and again, it stands far deeper than any one strange room could ever
reach, so it is never taken for one.

---

## 7. Why this still fits `§4.5.1` (a `place` is saved, and

stands across levels)

The name comes from `Found`, a plain, given list — nothing tied to
the moment it is asked, once past the way in. **The same way in,
walked at a later time, gives the same name**, so long as what stands
there has not truly changed. Saved and read back later, the name
still means the same true thing. A changed scene (a broken block)
giving a new name at the same way in is not a fault — a real person,
too, may not know a room once its own things have moved.

---

## 8. What this design touches, and what it leaves whole

| Piece                                                               | Touched?                                                         |
| ------------------------------------------------------------------- | ---------------------------------------------------------------- |
| `Row`, `Memory`                                                     | no — `Place` already holds a plain string                        |
| `Depth`                                                             | no — the three steps already stand                               |
| `Hand.Landed`                                                       | yes — one check on `delta`'s own size, a few lines               |
| a new piece in `Scripts/Core`, naming a `place` from a way-in scene | yes — new, and Unity-free, so it may be checked by `dotnet test` |

---

## 9. Left open

| # | Question                                                                                                                                                                                                                                                                                                |
| - | ------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- |
| 1 | how big `delta` must be before a `Depth` is lifted                                                                                                                                                                                                                                                      |
| 2 | **Settled 2026-09-19, then thrown out by the master 2026-11-14 (§5.3): a 4-by-3 set of 12 cells (matching `Sight`'s own true 210-by-150 ratio), each held as one of four bands (near, mid, far, x), not a true number.** Left open still: where the band lines truly sit for `Sight`'s own real `reach` |
| 3 | whether a rest (the `Rest` act, held in both personas already) should itself lift `Depth` for memories made close before it, matching the still-body going-over-again that real study points to                                                                                                         |
| 4 | how many true ways in `Level_1` would give, once counted — not yet done                                                                                                                                                                                                                                 |

**Settled 2026-09-19, not left open: what a place-name does where
`germio`'s own eleven marks are too few to tell a scene apart —
mountains, rivers, a whole city block, none of which stand in any
plan today. Weighed on the spot, not put off, and settled twice —
once wrongly (a count of kinds), once true (§5.3's own shape of
wall-distances). A wall's own shape holds true wherever a game's own
world calls a boundary by any name at all, or none, so no widening
of `germio`'s own marks is asked for.**

---

## 10. The way forward, 2026-11-14

**The three designs thrown out (§3.1, §3.2, §5.3) each used one sign
alone.** A count of what is seen turned with the head; a walked count
of steps had nothing to put it right; the shape of the walls, run on
`Level_1`, gave one name to every place that faced open ground. A
fourth, the edges of the ground, was thrown out by the master on the
spot: it leans on how one level is built, and the models of a level are
not fixed.

**How a person finds the way.** No one sign does it. A person puts
three together all the time: what is seen (marks that stand out and
do not move, the look of a whole scene, and the shape of the space),
the sense of moving (steps and turns), and the sense of which way the
body faces. The sense of moving goes wrong more the more one walks and
turns; seen marks put it right. A person is lost when the sense of
moving has gone wrong and no mark puts it right: no mark, a mark that
looks like another, a mark that moves, or no looking. The sense of
height is much weaker than the flat sense: a climb is felt as less
than it is, and a person in a building of many floors takes one floor
for another.

**What the study of how people find their way holds, and what is used
here.**

| # | Way of looking                                                                                                                              | Used here                                          |
| - | ------------------------------------------------------------------------------------------------------------------------------------------- | -------------------------------------------------- |
| 1 | signs are put together by how sure each is; the surer one counts more                                                                       | yes: the ground of the design                      |
| 2 | knowledge grows as marks, then roads between marks, then a map of the whole                                                                 | marks only, so far                                 |
| 3 | people are not the same: some keep roads, some keep the way faced; fear makes the seen space small; some cannot join two roads into one map | yes: values that may be changed for each character |
| 4 | the cells of the body for a place, for steps, for the way faced, and for walls and drops                                                    | as the reason for 1, not as a design               |

**The order of the work.** The needs of §3.1 and §4 come first: to tell
a new place, a known place, and a place to keep away from, across
levels. Going wrong, the way a person does, is put on top of that, and
not in its place.

**The trial.** `Tests~/PoC/place_brain_3d_2026-11-14/` holds a small
brain that puts the three signs together in 3D, on two floors joined
by a slope, with five values for each character. Its numbers are in its
`README.md`: one with a weak sense of height alone kept the flat place
well (error 0.22), took the wrong floor 14.3 in 100 of the time, and
took the red post of one floor for the one over or under it. The
master's word, 2026-11-14: the way the trial goes is good. Nothing of
it is built into `modio`.

---

## 11. From the trial to Modio, 2026-11-14

**What the trial is, and what it is not.** The working of the trial
(§10) is true as a way of reckoning; as the mind of a Modio character
it is not yet anything, since it is joined to no part of Modio.

| # | Part                                                            | In the trial                                              | True for Modio?                                           |
| - | --------------------------------------------------------------- | --------------------------------------------------------- | --------------------------------------------------------- |
| 1 | putting the sense of moving, the way faced, and height together | works, and the measures come from it                      | yes, as a way of reckoning                                |
| 2 | what is seen                                                    | made from the true points of the world, with error put on | no: it does not go through `Sight` or `Found`             |
| 3 | marks                                                           | five, put down by hand, and known from the start          | no: no mark is put into memory on the way                 |
| 4 | the road walked                                                 | a fixed road                                              | no: it does not come from a want of `animo`               |
| 5 | memory                                                          | none                                                      | no: nothing is written as a `Row`                         |
| 6 | the build                                                       | `JavaScript`, with garbage at run time, and no tests      | no: Modio is `C#`, with no garbage at run time, and tests |

**What Modio holds today (read in the code, 2026-11-14).**

| # | Part                              | What it holds                                                                                                                    | What it means for the plan                          |
| - | --------------------------------- | -------------------------------------------------------------------------------------------------------------------------------- | --------------------------------------------------- |
| 1 | `Found` (`Scripts/Core/Found.cs`) | `Kind`, `ID`, `Angle`, `Distance`, `Height`, as seen from the body                                                               | a seen mark, ready to use as it is                  |
| 2 | `Self` (`Scripts/Core/Self.cs`)   | `Heading` alone; no point of the body                                                                                            | the point of the body is made by the mind, not read |
| 3 | `Row` (`Scripts/Core/Row.cs`)     | `Place` is a plain string                                                                                                        | the name the mind makes goes here                   |
| 4 | a part that makes a place name    | none: §4.3 of `docs/modio_spec.md` says how, but no code does it                                                                 | the mind fills this gap                             |
| 5 | the edges in `Runtime/`           | `SightEdge`, `RayEdge`, `BroadPhaseEdge`, `HeadingEdge`, for `ISightSource`, `IRaySource`, `IBroadPhaseSource`, `IHeadingSource` | one more edge is needed, for the moving of the body |
| 6 | `Depth` (`Scripts/Core/Depth.cs`) | `SEEN`, `MET`, `HELD`                                                                                                            | how sure the mind is of a mark                      |

**The plan (put forward, not built).**

| # | Part                        | Where                                                       | What it does                                                                                                                                                                                                                                                                                                                                                     |
| - | --------------------------- | ----------------------------------------------------------- | ---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- |
| 1 | the mind (one new type)     | `Scripts/Core`, with no `Unity`, so `dotnet test` checks it | takes `Move` (how far the body went, how much it turned, how much it went up, each update) and `See` (a `Found` that is a mark); holds its guess of the point, the way faced, and how sure it is; makes no garbage at run time (the memory of marks is a table of fixed size); its error comes from a seed of its own, so a test gives the same answer each time |
| 2 | the edge of the moving body | `Runtime`, one new edge                                     | gives only how much the body moved in one update, never its point, as the body's own sense does                                                                                                                                                                                                                                                                  |
| 3 | marks                       | in the mind                                                 | a `Found` of a kind that does not move is a mark; its look is its kind; where kinds are the same, the mind may take one for another, as a person does                                                                                                                                                                                                            |
| 4 | the name of a place         | made by the mind                                            | the mind's guess of the point, rounded; when the mind is wrong, the place is wrong; new, known, and to keep away from (§3.1, §4.5 of `docs/modio_spec.md`) all come from it                                                                                                                                                                                      |
| 5 | how deep a mark sits        | `Depth`, as it is                                           | a mark only seen is less sure than one met or held                                                                                                                                                                                                                                                                                                               |

The order of the work, as for every change: this record first, then
the Red tests, then the build.

**Not yet settled.**

| # | Point                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                            |
| - | -------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- |
| 1 | **Settled, the master's word, 2026-11-14.** The nature of a character is kept in `animo`, in one place. Of the five values, two are not new: fear is the value of the `fear` Need of `animo` at that time, and how deep a memory sits is `Depth`. The other three (how much the marks are seen, how well the way faced is made new, the sense of height) are one value, the sense of direction (0 to 1), kept on the `Kind` of `animo` and changed by the `Persona` where one character is not like its kind, by the cascade `animo` has today. `IMind` gives Modio two more doors to read: `float SenseOfDirection { get; }` and `float Need(string need)`, which `EngineMind` fills from `Engine.sense_of_direction` and `Engine.GetNeed` of `animo`. The form is written in `docs/animo_spec.md` of `animo` (§6.2 to §6.4, §7.2, §8.1, §12.1: schema `1.5`, rule `A041`; where a number is given by more than one Kind or Persona, the last one given wins). Neither is built |
| 2 | which of the marks of `germio` are kinds that do not move                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                        |
| 3 | how much ground one place name holds when the guess is rounded                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                   |
| 4 | how a place kept into the next level (§4.5.1 of `docs/modio_spec.md`) and the mind's guess go together, since the guess starts from nothing in each level                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                        |
