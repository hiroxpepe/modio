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

## Where to read next

+ `docs/modio_spec.md` — the full reference spec
+ `ROADMAP.md` — the phases
+ `TASKLIST.md` — the open work

## Rights to use

MIT. See `LICENSE`.
