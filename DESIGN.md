# Design Document – Final Project

## Project Overview
The project is a text-based RPG game with a character catalog.
It was developed iteratively, starting from a CLI catalog,
extending with game business logic, persistence, and planned GUI.

## Command Line Interface
CLI provides interaction with the system through commands:
list, create, start, save, load.
It operates in a single process (REPL) and is used as both
a user interface and a debugging tool.

## Business Logic
The core business logic is implemented in the Game module.
It includes:
- character creation
- combat mechanics
- turn-based interaction model

### Damage Formula
effectiveDamage = max(0, Damage - Armor)
finalDamage = effectiveDamage * (1 - Resist)

## Persistence
Persistence is implemented via JSON serialization.
Game state and characters are stored in a local file (save.json).
This approach is simple and suitable for the current stage.

## Graphical Interface (Planned)
A GUI layer (WPF, MVVM) is planned as an alternative interface.
It will visualize characters as cards and display battle logs.
At the current stage, GUI is described architecturally.

## Build & Deployment
The project is built using .NET SDK.
Release build can be produced with:
dotnet publish -c Release

## Conclusion
The project satisfies final course requirements by combining
CLI, business logic, persistence, and documented GUI architecture.
