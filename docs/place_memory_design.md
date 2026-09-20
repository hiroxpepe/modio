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

| # | Question                                                                                                                                                                                                                                                        |
| - | --------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- |
| 1 | how big `delta` must be before a `Depth` is lifted                                                                                                                                                                                                              |
| 2 | **Settled 2026-09-19, in full: a 4-by-3 set of 12 cells (matching `Sight`'s own true 210-by-150 ratio), each held as one of four bands (near, mid, far, x), not a true number.** Left open still: where the band lines truly sit for `Sight`'s own real `reach` |
| 3 | whether a rest (the `Rest` act, held in both personas already) should itself lift `Depth` for memories made close before it, matching the still-body going-over-again that real study points to                                                                 |
| 4 | how many true ways in `Level_1` would give, once counted — not yet done                                                                                                                                                                                         |

**Settled 2026-09-19, not left open: what a place-name does where
`germio`'s own eleven marks are too few to tell a scene apart —
mountains, rivers, a whole city block, none of which stand in any
plan today. Weighed on the spot, not put off, and settled twice —
once wrongly (a count of kinds), once true (§5.3's own shape of
wall-distances). A wall's own shape holds true wherever a game's own
world calls a boundary by any name at all, or none, so no widening
of `germio`'s own marks is asked for.**
