# 🎮 Oyuncak Hazinesi Nerede? ("Where Is the Toy Treasure?")

**An escape-room-style educational game designed to teach 5th-grade science concepts through narrative-driven puzzle mechanics, tested with 43 students across two schools in Ankara, Turkey.**

> Built as a solo end-to-end product: learning design, UX architecture, classroom deployment, and statistical evaluation.

📄 For the full project report (including screenshots, activities, and evaluation data), see [ProjectReport.pdf](./ProjectReport.pdf).

> Developed and evaluated between May 2023 – June 2025.
---

## Quick Overview

| | |
|---|---|
| **Genre** | Educational escape room / puzzle-adventure |
| **Subject** | Science: States of Matter & Phase Changes |
| **Target** | 5th grade (ages 10–11), Turkish national curriculum (MEB) |
| **Activities** | 13 interactive levels + intro & finale sequences |
| **Evaluation** | Pre/post testing (n=43), usability survey (64-item Likert), Wilcoxon & Mann-Whitney U analyses |
| **Role** | Solo designer, developer, researcher, and field tester |

---

## Table of Contents

- [The Problem](#the-problem)
- [The Solution](#the-solution)
- [Game Design & Mechanics](#game-design--mechanics)
- [Learning Architecture](#learning-architecture)
- [Usability Principles in Practice](#usability-principles-in-practice)
- [User Research & Evaluation](#user-research--evaluation)
- [Key Findings & Insights](#key-findings--insights)
- [What I Would Do Differently](#what-i-would-do-differently)
- [Product Thinking Highlights](#product-thinking-highlights)
- [Tech & Tools](#tech--tools)
- [References & Academic Foundation](#references--academic-foundation)

---

## The Problem

States of matter is one of the foundational topics in science education, yet it's riddled with persistent student misconceptions that traditional instruction struggles to address:

- **"Solid particles don't move"**: A study of 1,000 Scottish students found most believed only gas and liquid particles are in motion (Dow, Auld & Wilson, 1978).
- **"If I can't see it, it doesn't exist"**: Younger children equate matter with visibility, leading to beliefs like "water disappears" during evaporation (Bar & Galili, 1994).
- **"Evaporation only happens after boiling"**: Students fail to grasp that vaporization occurs at all temperatures (Canpolat et al., 2006).
- **"All liquids boil at the same temperature"**: 13% of students in a 300-student study held this belief (Kırıkkaya & Güllü, 2008).
- **"Melting point ≠ freezing point"**: Students perceive melting and freezing as disconnected phenomena rather than reversible processes at the same temperature.

These misconceptions compound across grade levels and create fragile mental models that block deeper scientific reasoning.

---

## The Solution

**Oyuncak Hazinesi Nerede?** wraps the entire "States of Matter" curriculum unit inside an escape-room narrative. A toy company has hidden a treasure chest somewhere in a multi-room building. To find it, you and your in-game friend (AKA the agent) must solve science puzzles in kitchens, labs, and storage rooms, each room teaching a specific concept through hands-on interaction.

The core insight: **if the puzzle mechanic *is* the learning objective, students can't progress without actually understanding the science.**

### Design Pillars

1. Every activity is embedded in a treasure-hunt storyline that gives purpose to each scientific task. You're not "learning about melting points." You're melting an iron ingot to forge a key.

2. Each of the 13 activities was designed to directly address a documented misconception from the literature, rather than covering curriculum checkboxes generically.

3. Early levels provide explicit guidance (help animations, sticky notes, peer dialogue). As players build confidence, scaffolding fades. Sticky notes lose their "click to close" hints, instructions become implicit, and the peer character shifts from directing to questioning.

4. A peer-like friend accompanies the player throughout, providing relatedness (Self-Determination Theory) and collaborative framing (constructivist theory) in what is essentially a single-player experience.

---

## Game Design & Mechanics

### Activity Breakdown

| Activity | Mechanic | Science Concept | Misconception Addressed |
|---|---|---|---|
| **1** | Drag-and-drop classification | Three states of matter | Confusing object vs. material state (e.g., balloon = solid?) |
| **2** | "Ayrıştıratör" molecular zoom machine | Particle motion in all states | "Solid particles don't move" |
| **3** | Kitchen pouring simulation | Shape retention & fluidity | Conflating container shape with substance properties |
| **4** | Locked-door puzzle (highest molecular motion) | Synthesis of states' properties | Applying knowledge under constraint |
| **5** | Erit-Ex machine: melt iron → mold key → freeze | Melting point = Freezing point | Perceiving melting/freezing as unrelated |
| **6** | Hygrometer + lamp stations (3 temperatures) | Evaporation at all temperatures | "Evaporation only happens after boiling" |
| **7** | Iodine sublimation → password reveal on window | Sublimation (solid → gas) | Phase changes require liquid intermediate |
| **8–9** | Boil water then oil, use boiling point as door code | Substance-specific boiling points | "All liquids boil at 100°C" |
| **10** | Oxygen cooling machine → liquid oxygen → key mold | Condensation (gas → liquid) | Gas "disappears" rather than transforms |
| **11** | Steam + ice plate → frost scratch → password | Deposition (gas → solid) | Phase change vocabulary gaps |
| **12** | Heat/cool machine with real-time graphing | Temperature plateaus during phase changes | Temperature always rises/falls linearly |
| **13** | "Boss level": identify pure substance by freezing behavior | Freezing point constancy for pure substances | Mixtures and pure substances behave the same |

### Core Interaction Patterns

- **Drag-and-drop**: Used for classification, material placement, and experimental setup. Consistent visual indicators (highlights, cursor changes) signal draggable elements throughout.
- **Click-and-hold**: Introduced in Activity 7 for the sublimation tube. Requires sustained interaction to complete the animation, adding tactile engagement.
- **Observation > Record > Apply**: A recurring loop: perform an experiment, note results on the in-game phone, then use that data to solve a puzzle (e.g., boiling point becomes a door code).
- **Sticky-note clues**: Contextual hints embedded in the environment that evolve from explicit instructions to poetic riddles as the game progresses.
- **Locked-door progression**: Every room transition requires demonstrating understanding, ensuring no concept is skipped.

### Feedback System

The game uses a layered feedback approach:

- **Immediate corrective feedback**: Wrong drag-and-drop placements trigger gentle, specific messages. Instead of a generic "try again," the system explains: "Think about what's *inside* the balloon."
- **Color-coded note validation**: When players record observations on the phone, incorrect entries turn red, prompting self-correction without revealing the answer.
- **Procedural guards**: Attempting actions out of sequence (e.g., placing iron in an inactive machine) triggers contextual prompts that explain the reasoning behind the required sequence.
- **Motivational reinforcement**: Correct completions are rewarded with story progression, character reactions, and the satisfaction of unlocking the next room.

---

## Learning Architecture

### Theoretical Foundations

The courseware's instructional design draws on multiple frameworks, each mapped to specific design decisions:

**Self-Determination Theory (SDT)**
- *Competence*: Difficulty ramps progressively; each solved puzzle reinforces capability.
- *Autonomy*: Players choose exploration order within activities, control the phone/help tools, and proceed at their own pace.
- *Relatedness*: The companion character creates a social bond; the treasure-hunt framing provides shared purpose.

**ARCS Motivation Model (Keller)**
- *Attention*: Novel machines (Ayrıştıratör, Erit-Ex), unexpected plot twists (the "Boss" character in Activity 13), humor ("Isn't there any chocolate in this kitchen?").
- *Relevance*: Familiar settings (kitchens, everyday objects), real-world substances.
- *Confidence*: Phone-based note review before challenging sections; scaffolded difficulty.
- *Satisfaction*: Tangible rewards (forged keys, unlocked doors, the final treasure).

**Mayer's Multimedia Learning Principles**
- *Personalization*: The player's name is used throughout the game.
- *Signaling*: Visual highlights on interactive elements; animated cues for the Help button.
- *Spatial contiguity*: Feedback appears adjacent to the relevant interaction, not in disconnected pop-ups.

**Constructivism & Scaffolding**
- Students construct understanding through experimentation, not instruction.
- The "fading" strategy progressively removes explicit guidance, requiring learners to transfer patterns from earlier activities.

### Bloom's Taxonomy Coverage

The 37 instructional objectives span all six levels of Bloom's taxonomy:

- **Remember** (11 objectives): Recall states, properties, particle identity
- **Understand** (17 objectives): Classify materials, explain phase changes, identify characteristic temperatures
- **Apply** (10 objectives): Discover phase-change progressions, use scientific vocabulary, observe temperature behavior
- **Analyze** (2 objectives): Infer heat exchange processes, outline vaporization temperature patterns
- **Evaluate** (3 objectives): Conclude distinctiveness of melting/freezing/boiling points per substance
- **Create** (5 objectives): Distinguish states, relate characteristic temperatures to substances, synthesize melting–freezing relationship

---

## Usability Principles in Practice

The courseware was designed with systematic attention to usability heuristics. Here's how each principle manifests:

### Learnability

| Principle | Implementation |
|---|---|
| **Consistency** | All control elements (Continue, Previous, Help, Phone) maintain fixed position and visual style across all 13+ screens. |
| **Familiarity** | Standard conventions: question mark = help, red = error, green = success. Drag-and-drop follows platform norms. |
| **Predictability** | Navigation buttons always behave the same way. Sticky notes always close on background click (taught once, expected thereafter). |
| **Synthesizability** | Help button animation plays once in Activity 1; users generalize this affordance to all subsequent activities without re-instruction. |
| **Generalizability** | Visual markers for draggable items are consistent, so learning to interact in Activity 1 transfers to Activity 13. The white background behind heating elements consistently signals chemical transformation. |

### Flexibility

| Principle | Implementation |
|---|---|
| **Dialogue initiative** | Users choose which items to classify first, when to take notes, and when to use help. The system rarely forces a strict sequence. |
| **Multi-threading** | The Phone and Help buttons are accessible concurrently with main activities, enabling note-taking alongside experimentation. |
| **Task migrability** | In later activities (e.g., 12), the system handles temperature visualization automatically, migrating procedural burden from user to system so learners can focus on conceptual analysis. |

### Robustness

| Principle | Implementation |
|---|---|
| **Responsiveness** | Every user action receives timely feedback. Correct placements, procedural errors, and sequence violations all produce immediate, context-specific responses. |
| **Task conformance** | The system supports the full range of actions needed to complete each objective. Drag targets accept items from any screen position; the phone allows free-form note entry. |
| **Error prevention** | Duplicate placements, out-of-sequence actions, and empty submissions are all intercepted with helpful guidance rather than silent failures. |

### Scaffolding Strategy: The "Fading" Model

The courseware implements a deliberate progression from high to low support:

```
Activities 1–3:  Full scaffolding
                 → Help button animation, explicit sticky notes, step-by-step peer dialogue

Activities 4–7:  Partial scaffolding
                 → Sticky notes become riddles, peer asks questions instead of giving answers,
                   "click to close" hints removed

Activities 8–12: Minimal scaffolding
                 → No guiding notes in second room (Activity 9), system handles more procedures,
                   learner expected to transfer patterns independently

Activity 13:     Near-zero scaffolding ("Boss Level")
                 → New character, no peer guidance, must synthesize all prior knowledge
```

---

## User Research & Evaluation

### Study Design

- **Design**: One-group pretest-posttest with usability survey
- **Participants**: 43 students (4th grade) from 2 schools in Ankara: 1 private (individual use, n=15), 1 public (collaborative groups of 2-3, n=28)
- **Rationale for 4th graders**: Eliminated prior-knowledge confounds since 5th graders may have already covered the topic

### Instruments

| Instrument | Items | Max Score | Purpose |
|---|---|---|---|
| Pretest | 15 questions (MC, T/F, short answer) | 25 pts | Baseline knowledge |
| Posttest | 15 questions (parallel form) | 25 pts | Post-intervention knowledge |
| Usability Test | 64 Likert items + 4 open-ended | 320 pts | Perceived usability, engagement, design quality |

All instruments were expert-reviewed by a science teacher with a master's in curriculum design, then pilot-tested with 2 students for language clarity.

### Field Conditions

**Private school**: Students used individual computers. Session split across 2 non-consecutive days due to scheduling issues (5 students excluded for attendance mismatch).

**Public school**: Only 11 of 16 lab computers were functional. The researcher personally troubleshot hardware, configured on-screen keyboards, and adapted the session to group-based work. Two students used the interactive whiteboard. Despite infrastructure challenges, student engagement was remarkably high. The entire class spontaneously surrounded the researcher during the break to express excitement. The classroom teacher subsequently installed the courseware on the smartboard for continued use.

---

## Key Findings & Insights

### Statistical Results

| Research Question | Test Used | Result | p-value |
|---|---|---|---|
| Pre→Post score improvement | Wilcoxon Signed-Rank | Not significant | .140 |
| Usability perception → Achievement | Mann-Whitney U | Not significant | .082 |
| Individual vs. Group use → Achievement | Mann-Whitney U | Not significant | .077 |
| Gameplay frequency → Achievement | Spearman's rho (ρ=−0.085) | Not significant | .589 |
| Prior science grades → Usability perception | Spearman's rho (ρ=−0.350) | **Significant** | **.022** |

### What the Numbers Tell Us

**The headline**: No statistically significant improvement in test scores. But this finding requires context.

**The nuance**: The pretest contained a 6-point recall question (Q21–Q26 covering basic properties of states) that was relatively straightforward, likely inflating baseline scores. Meanwhile, the posttest distributed points more evenly across application-level items. This scoring asymmetry may have masked genuine learning gains on higher-order objectives.

**The standout finding**: Students with *lower* prior science grades rated the courseware's usability significantly *higher* (ρ=−0.350, p=.022). This suggests the game format particularly resonated with students who may be less engaged by traditional instruction. That is exactly the population educational games should serve.

### Usability Reception

- **Average usability score**: 250.13 / 320 (78.2%)
- **Highest**: 289/320 (90.3%)
- **"Usable" threshold met by**: 20 of 43 students (46.5%)

---

## What I Would Do Differently

### Assessment Design
- Align pretest and posttest item difficulty more carefully to avoid high-value recall items that inflate baselines
- Add delayed post-test (2-4 weeks later) to measure retention beyond immediate recall

### Study Design
- Include a control group for causal attribution
- Larger sample size for adequate statistical power
- Standardize implementation conditions across schools

### Product Improvements
- **Character customization**: Allow players to choose companion gender and appearance (strongest qualitative feedback)
- **Transparent pot visuals** in boiling activities to visually disprove the "boiling only at the surface" misconception
- **Adaptive difficulty**: Branch paths based on player performance rather than fixed linear progression
- **Analytics dashboard**: Track time-per-activity, error frequency, and help-button usage to identify friction points
- **Mobile-first redesign**: Given the public school's infrastructure challenges, a tablet/phone version would dramatically increase accessibility

---

## Highlights

### End-to-End Ownership
Sole responsibility for the entire product lifecycle: literature review → learning design → UX architecture → development → field testing → statistical analysis → iteration recommendations.

### User-Centered Design Under Constraints
When the public school's computer lab was non-functional, I didn't cancel. I triaged hardware, reconfigured the session for group use, adapted the smartboard as an alternative input device, and still collected valid data. Product managers ship in imperfect conditions.

### Iterative, Data-Informed Decision Making
The product went through multiple rounds of testing and revision before the final classroom deployment. After the alpha build, the pretest and posttest were reviewed by a science teacher with a master's in curriculum design, who flagged content misalignments and language issues. Based on that feedback, question phrasing was revised and item types were adjusted. A beta round followed with two pilot students (one 4th grader, one 5th grader) who were asked to verbalize any confusion as they worked through the tests and the courseware itself. That session surfaced readability problems and interaction ambiguities that led to further language adjustments and UX changes. The revised instruments were then re-validated by the same expert before final deployment. This alpha-review, beta-test, re-validate cycle shaped the product significantly between its first draft and its classroom-ready version. On the evaluation side, every statistical test was chosen based on actual data characteristics (Shapiro-Wilk normality testing led to non-parametric alternatives when assumptions were violated), not default assumptions.

### Honest Evaluation of Outcomes
The primary hypothesis was not supported, and I reported that transparently, analyzing why (assessment design limitations, sample size constraints) rather than cherry-picking favorable interpretations. I know that understanding *why* something didn't work is as valuable as proving it did.

### Stakeholder Management
Coordinated with school administrations, classroom teachers, and an expert reviewer across multiple institutions, navigating scheduling conflicts, infrastructure gaps, and varying expectations.

### Inclusivity & Player Feedback
Identified and documented the character-customization gap from qualitative data, a product insight that directly maps to player retention and DAU in game contexts.

---

## Tech & Tools

- **Game Development**: Interactive courseware built with multimedia authoring tools
- **Statistical Analysis**: SPSS (Shapiro-Wilk, Wilcoxon, Mann-Whitney U, Spearman's rho, Independent Samples t-test)
- **Assessment Design**: Parallel-form pre/post tests validated through expert review and pilot testing
- **Usability Instrument**: Custom 64-item Likert scale + 4 open-ended items

---

## References & Academic Foundation

Bar, V., & Galili, I. (1994). Stages of children’s views about evaporation. *International Journal of Science Education, 16(2), 157-174*. https://doi.org/10.1080/0950069940160205

Canpolat, N., Pinarbasi, T., & Sözbilir, M. (2006). Prospective teachers' misconceptions of vaporization and vapor pressure. *Journal of Chemical Education, 83(8), 1237*. https://doi.org/10.1021/ed083p1237

Çelebi, Ö. (2004). Effect of conceptual change oriented instruction on removing misconceptions about phase changes *(Master's thesis, Middle East Technical University)*.

Das, M., Singh, A., & Amrita, J. (2014). Importance of science in school curriculum. *WeSchool Knowledge Builder-The National Journal, 2, 16-18.*

Efendioğlu, A. (2012). Courseware development model (CDM): The effects of CDM on primary school pre-service teachers' achievements and attitudes. *Computers & Education, 59(2), 687- 700*. https://doi.org/10.1016/j.compedu.2012.03.015

Fensham, P. J. (2013). Beginning to teach chemistry. *In The content of science: A constructivist approach to its teaching and learning (pp. 14-28*). Routledge.

**Full reference list available in the project report.**
