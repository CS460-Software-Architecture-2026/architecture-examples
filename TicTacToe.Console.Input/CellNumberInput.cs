namespace Examples.TicTacToe.Consoled
{
    using System;
    using Examples.TicTacToe;

    public class CellNumberInput
    {
        public void StartProcessing(TicTacToeWithEvents game)
        {
            Console.Out.WriteLine("Type START to play, MOVE 1-9 to mark a cell, EXIT to quit.");
            Console.Out.WriteLine("Cell numbers:\n1 2 3\n4 5 6\n7 8 9");
            while (true)
            {
                Console.Out.Write("> ");
                var command = Console.ReadLine();
                if (command == null)
                {
                    return;
                }

                var splitCommand = command.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                if (splitCommand.Length == 0)
                {
                    continue;
                }

                switch (splitCommand[0].ToLower())
                {
                    case "start":
                        game.StartGame();
                        break;
                    case "exit":
                        return;
                    case "move":
                        if (splitCommand.Length != 2 || !int.TryParse(splitCommand[1], out var cell) || cell < 1 || cell > 9)
                        {
                            Console.Out.WriteLine("Use MOVE with a cell number from 1 to 9.");
                            break;
                        }

                        try
                        {
                            game.MakeMove((cell - 1) / 3, (cell - 1) % 3);
                        }
                        catch (Exception exception)
                        {
                            Console.Out.WriteLine(exception.Message);
                        }
                        break;
                }
            }
        }
    }
}
