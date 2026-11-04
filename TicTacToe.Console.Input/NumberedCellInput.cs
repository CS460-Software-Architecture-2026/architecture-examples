namespace Examples.TicTacToe.Consoled
{
    using System;
    using Examples.TicTacToe;

    public class NumberedCellInput
    {
        public void StartProcessing(TicTacToeWithEvents game)
        {
            Console.Out.WriteLine(
                "Welcome to Tic Tac Toe! Type START to play, MOVE 1-9 to mark a cell " +
                "(1-3 top row, 4-6 middle, 7-9 bottom), or EXIT to quit.");

            while (true)
            {
                Console.Out.Write("> ");
                var command = Console.ReadLine();
                if (command == null)
                {
                    return;
                }

                var parts = command.Split((char[]?)null, StringSplitOptions.RemoveEmptyEntries);

                if (parts.Length == 0)
                {
                    continue;
                }

                switch (parts[0].ToLowerInvariant())
                {
                    case "start":
                        game.StartGame();
                        break;
                    case "exit":
                        return;
                    case "move":
                        if (parts.Length != 2
                            || !int.TryParse(parts[1], out var cellNumber)
                            || cellNumber < 1
                            || cellNumber > 9)
                        {
                            Console.Out.WriteLine("Enter a cell number from 1 to 9, for example: MOVE 5.");
                            break;
                        }

                        var x = (cellNumber - 1) / 3;
                        var y = (cellNumber - 1) % 3;
                        game.MakeMove(x, y);
                        break;
                    default:
                        Console.Out.WriteLine("Unknown command. Use START, MOVE 1-9, or EXIT.");
                        break;
                }
            }
        }
    }
}
