namespace Examples.TicTacToe.Consoled
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Examples.TicTacToe;

    // Завдання 3: controller без клавіатури. Грає наперед заданий список ходів
    // (номери клітинок 1–9) через ту саму модель — view оновлюються як завжди.
    public class ScriptedInput
    {
        private readonly IReadOnlyList<int> cellNumbers;

        public ScriptedInput(IEnumerable<int> cellNumbers)
        {
            this.cellNumbers = cellNumbers.ToList();
        }

        public void StartProcessing(TicTacToeWithEvents game)
        {
            game.StartGame();

            var played = 0;
            // Зупиняємось, щойно гра закінчилась: MakeMove після кінця кидає виняток
            while (played < cellNumbers.Count && !game.IsEnded)
            {
                var cellNumber = cellNumbers[played];
                var (x, y) = CellNumbers.ToCoordinates(cellNumber);

                Console.Out.WriteLine($"--- Move {played + 1}: player {game.CurrentPlayer.Name} -> cell {cellNumber}");
                game.MakeMove(x, y);
                played++;
            }

            var skipped = cellNumbers.Count - played;
            if (skipped > 0)
            {
                Console.Out.WriteLine($"Game ended, {skipped} remaining move(s) skipped");
            }
        }
    }
}
