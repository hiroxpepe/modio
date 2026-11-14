# Modio

**Tulving-driven memory and seeing ahead, for game agents.**

The HOW layer of the STUDIO MeowToon game stack.

## The three questions

| Repository  | Question | Holds        |
| ----------- | -------- | ------------ |
| `germio`    | WHAT     | the world    |
| `animo`     | WHY      | the want     |
| **`modio`** | **HOW**  | **the deed** |

`animo` gives back one Behavior each tick — a plain string, holding
no place, no object, no other agent. `germio` holds the world, but
knows nothing of want. **Modio takes one Behavior and carries it out
as one Deed: a thing with a start, a middle, and one of three ends.**

## Why a memory layer at all

`animo` holds the state of now. `germio` holds the state of now.
**Neither holds the past.**

So a want for new places cannot work — no one knows which place is
new. A want to give cannot work — no one knows who was given to
already.

**Modio is the only layer with a past.**

**The aim, the master's word, 2026-11-14: a game should go after how
wise and how natural its enemies and other characters are, before how
fine its pictures are.** What enemies and other characters in most
games do not have, and what Modio gives in its place:

| # | What most games do                                                                      | What Modio does (`docs/modio_spec.md`)                                                                                 |
| - | --------------------------------------------------------------------------------------- | ---------------------------------------------------------------------------------------------------------------------- |
| 1 | a character notes the player in a cone of sight, looks a while, and gives up by a clock | seeking comes from a want, and is done on purpose (§3.1)                                                               |
| 2 | a character knows where the player is, through walls                                    | it knows only what it has seen and what it keeps in memory (§3.7.1)                                                    |
| 3 | a character has no past of its own                                                      | it holds what this one character did (§2.2)                                                                            |
| 4 | a new level or scene wipes its memory                                                   | places and other characters are kept into the next level, and saved (§4.5.1)                                           |
| 5 | a character never loses its way                                                         | it puts the same signs together that a person does, and may go wrong the same way (`docs/place_memory_design.md`, §10) |

Why games do little of this, and how Modio meets it: a wise enemy is
hard to test and may make a player angry, it costs time to work out, and a
picture sells better than a wise enemy. Modio goes wrong only the way a
person does, so a mistake does not make a player angry; it keeps few places, so
memory stays small; and it makes no garbage at run time.

## Seeing ahead comes free

Tulving held that the true point of the memory of living is not
remembering. It is that **the same paths let a mind picture what is
to come.**

So `Recall` faces two ways:

+ **back** — "have I touched that block?"
+ **ahead** — "where will my Needs sit in 30 seconds?"

Facing ahead works because `animo`'s own `rates` are fixed and plain.
**The future of a want can be worked out; it need not be guessed.**

## What sets this apart

NPCs that remember are no longer new. But every one found runs on an
LLM with a search by meaning — a server, a key, a sum paid per call,
and an answer that shifts run to run.

|                         | LLM-backed NPC memory | **Modio**        |
| ----------------------- | --------------------- | ---------------- |
| What runs it            | an LLM, by meaning    | plain numbers    |
| Where it runs           | a server              | all on its own   |
| Same input, same answer | no                    | **yes**          |
| Mobile                  | no                    | **yes, zero-GC** |

## Seeking sits here, beside memory

Seeking — finding a thing still far off — is the ground the whole
layer rests on. A meeting (two bodies touching) is proof of arrival,
never a way of seeking.

Real sums, on a field 30 steps across: seeking brings two
characters together in **8 seconds**; waiting to be run into takes
**316 seconds**. `loneliness` climbs at 1.0 a second and stops at
100 — so waiting means it is pinned at the top long before arrival,
and never falls again.

Seeking was first planned for `germio`. It broke in three places, all
from one cause: **"find a Block not yet met" is one act, and cannot
be split across two apart builds.** See `docs/modio_spec.md` §3.3.

## Where to read next

+ `docs/modio_spec.md` — the full reference spec
+ `ROADMAP.md` — the phases
+ `TASKLIST.md` — the open work

## Rights to use

MIT. See `LICENSE`.
