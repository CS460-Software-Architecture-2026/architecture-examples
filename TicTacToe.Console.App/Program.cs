using Examples.TicTacToe;
using Examples.TicTacToe.Consoled;

// Model
var game = new TicTacToeWithEvents(new Player("A"), new Player("B"));

// Views — обидві слухають ОДНУ й ту саму гру (завдання 1)
var boardView = new ConsoleOutput();
boardView.ListenTo(game);

var statsView = new StatsOutput();
statsView.ListenTo(game);

// Controller — обирається аргументом запуску; модель і view не змінюються
//   dotnet run --project TicTacToe.Console.App              -> MOVE X Y (оригінальний)
//   dotnet run --project TicTacToe.Console.App -- cells     -> клітинки 1–9 (завдання 2)
//   dotnet run --project TicTacToe.Console.App -- scripted  -> готові ходи (завдання 3)
var mode = args.Length > 0 ? args[0].ToLower() : "coords";

switch (mode)
{
    case "cells":
        new CellNumberInput().StartProcessing(game);
        break;

    case "scripted":
        // A: 5, 2, 8 -> виграє середній стовпчик; останній хід (4) має бути пропущений
        new ScriptedInput(new[] { 5, 1, 2, 9, 8, 4 }).StartProcessing(game);
        break;

    default:
        new ConsoleInput().StartProcessing(game);
        break;
}
