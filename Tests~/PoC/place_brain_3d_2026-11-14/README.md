# A small brain that finds its way in 3D (a trial, 2026-11-14)

This is a trial, kept for later reading, for the open question of
`docs/place_memory_design.md` (how a character knows where it is, and
why it is wrong at times). Nothing here is built into `modio`. The
master's word, 2026-11-14: the way this trial goes is good.

## How to open it

Open `place_brain_3d.html` in a browser. It loads `three.js` (`r128`)
from `cdnjs.cloudflare.com`. Drag to turn the view.

## What the brain does

The trial follows two ways of looking at the sense of place, used in
the study of how people find their way: the guesses from moving and
from marks are put together by how sure each one is, and a mark is
known by its look.

| # | Part | What it does |
| - | ---- | ------------ |
| 1 | The guess from moving | The steps and the turns are added up into a guessed place. The more it walks and turns, the wider the guess grows |
| 2 | The way faced | At a turn, the way faced is made new; a poor turn gives a wider error |
| 3 | The sense of height | Held apart from the flat sense. A climb is felt as less than it is, the more so the weaker the sense, and the brain does not know it |
| 4 | Marks | A seen mark is matched with the remembered mark of the same look. Where two look the same, the one nearer the guess is taken (here a mistake comes in) |
| 5 | Putting them together | The guess and the mark are mixed by how sure each is; the surer one counts more |
| 6 | Persons | Five values that may be changed: how much the marks are seen, how well the way faced is made new, fear (a wide guess makes the seen space small), how deep the memory is, and the sense of height |

## What was measured

The same `step` code as in the page was run 20 times (seeds 1 to 20),
3,000 steps each, for four persons. "Wrong floor" is the part of the
time on a floor when the brain takes the other floor.

| # | Person | Flat error | Wrong floor | Lost | Wrong marks |
| - | ------ | ---------- | ----------- | ---- | ----------- |
| 1 | Almost never lost | 0.22 | 0.0% | 0.0% | 0.0 |
| 2 | The values as they start | 0.56 | 0.0% | 1.6% | 0.6 |
| 3 | Often lost | 5.44 | 21.8% | 75.2% | 1.0 |
| 4 | A weak sense of height alone | 0.22 | 14.3% | 12.7% | 21.1 |

Row 4 is the way people get lost in a building of many floors: the
flat place is right, but the floor is not, and the red post of one
floor is taken for the one just over or under it.

## What it does not do

| # | Point |
| - | ----- |
| 1 | The numbers in the code (the size of each error) were put in by hand, not made to match measures of people |
| 2 | Every mark is known from the start; no mark is put into memory on the way |
| 3 | Floors and posts do not hide a mark from view |
| 4 | Only marks are used; roads between marks and a map of the whole are not in it |
| 5 | The look of the page was not checked by eye here; only the numbers of the same code were |
