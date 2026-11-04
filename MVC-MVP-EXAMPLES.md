# MVC and MVP examples

Imported from the existing `SoftwareArchitecture/mvc-tic-tac-toe` working tree, including its current Hangman MVP work in progress. All 23 C# source files are preserved. The 17 projects target .NET 10 and explicitly select C# 12 to override this repository's C# 10 default.

Open `Software Architecture Examples.sln`. Projects are grouped under MVC and MVP, with TicTacToe and Hangman subfolders. Hangman.Model is shared by both Hangman variants and appears under MVC/Hangman.

## Examples

| Example | Projects | Entry point |
|---|---|---|
| Tic-Tac-Toe MVC | TicTacToe.Model, TicTacToe.Console.Input, TicTacToe.View.Console, TicTacToe.Console.App | TicTacToe.Console.App |
| Tic-Tac-Toe MVP | MVP.Model, MVP.ViewModel, MVP.View, MVP.Presenter, MVP.App | MVP.App |
| Hangman MVC | Hangman.Model, Hangman.Console.Input, Hangman.View.Console, Hangman.Console.App | Hangman.Console.App |
| Hangman MVP, unfinished | Shared Hangman.Model, Hangman.MVP.View, Hangman.MVP.Presenter, Hangman.MVP.App | Hangman.MVP.App |

The MVC examples use input controllers that call the model and output views that subscribe to model events. The Tic-Tac-Toe MVP presenter runs the interaction loop and prepares a display model for the view. The `MVP.ViewModel` project is a display-data object within this MVP example, not a separate MVVM implementation.

## Run

Use a terminal with the .NET 10 SDK. From the repository root:

```sh
dotnet run --project TicTacToe.Console.App/TicTacToe.Console.App.csproj
dotnet run --project MVP.App/MVP.App.csproj
dotnet run --project Hangman.Console.App/Hangman.Console.App.csproj
```

Run one command at a time. Tic-Tac-Toe MVC accepts `start` and `move X Y` with coordinates 0–2; use Ctrl+C to stop it because the original `exit` command does not leave the input loop. Tic-Tac-Toe MVP accepts cell numbers 1–9. Hangman MVC accepts `START`, individual letters, `RESTART`, and `EXIT`.

The MVC input projects retain their ReadLine dependency and should run in an interactive terminal.

Hangman MVP is preserved as an unfinished comparison/refactoring example. Its entry point constructs the presenter but never calls `Run()`, so it currently exits without displaying anything. The presenter/view flow also lacks complete state rendering after guesses; adding the call alone does not complete this example.

## Verification and existing limitations

The four app projects and their dependencies build. Existing nullable-reference warnings remain. All six existing tests pass:

```sh
dotnet test TicTacToe.Model.Tests/TicTacToe.Model.Tests.csproj
```

Import smoke checks completed a winning game in each Tic-Tac-Toe variant and exercised start, a guess, and exit in Hangman MVC. Hangman MVP's immediate exit was verified.

This is a source transfer, not a repair of the original exercises. In particular, the Tic-Tac-Toe MVC model still has restart-state and some win/draw-ordering issues, and its command parser assumes valid input. The existing tests do not cover those cases. Prepare the example further before using it as a robust student starter.
