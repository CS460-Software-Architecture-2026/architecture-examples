namespace Examples.TicTacToe.Consoled;

using System;
using Examples.TicTacToe;

public class CellNumInput
{
    public void StartProcessing(TicTacToeWithEvents game)
    {
        string command = null;
        Console.Out.WriteLine("Welcome to greatest Tic Tac Toe game! Type START to play ");
        while (true)
        {
            command = ReadLine.Read("> ");
            var splitCommand = command.Split(new char[0]);
            switch (splitCommand[0].ToLower())
            {
                case "start":
                    game.StartGame();
                    break;
                case "exit":
                    return;
                default:
                    if (int.TryParse(command, out var cell) && cell is >= 1 and <= 9)
                    {
                        var index = cell - 1;
                        game.MakeMove(index / 3, index % 3);
                    }
                    else
                    {
                        Console.WriteLine($"Enter start, exit, or cell 1-9");
                    }
                    break;
            }
        }
    }
}

