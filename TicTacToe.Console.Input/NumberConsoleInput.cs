namespace Examples.TicTacToe.Consoled
{
    using System;
    using Examples.TicTacToe;

    public class NumberConsoleInput
    {
        public void StartProcessing(TicTacToeWithEvents game)
        {
            var started = false;

            while (true)
            {
                var command = Console.ReadLine()?.Trim();

                if (command == null || command.Equals("exit", StringComparison.OrdinalIgnoreCase))
                {
                    return;
                }

                if (!started && command.Equals("start", StringComparison.OrdinalIgnoreCase))
                {
                    game.StartGame();
                    started = true;
                    continue;
                }

                if (!started || !int.TryParse(command, out var number) || number < 1 || number > 9)
                {
                    continue;
                }

                var row = (number - 1) / 3;
                var column = (number - 1) % 3;

                if (game.GetCellValue(row, column) != null)
                {
                    continue;
                }

                game.MakeMove(row, column);

                if (game.IsEnded)
                {
                    return;
                }
            }
        }
    }
}
