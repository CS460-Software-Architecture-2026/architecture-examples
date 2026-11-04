namespace Examples.TicTacToe.Consoled
{
    using System;
    using System.Linq;
    using Examples.TicTacToe;

    // Завдання 1: друга view. Як і ConsoleOutput, лише слухає події моделі —
    // ні модель, ні ConsoleOutput про неї не знають.
    public class StatsOutput
    {
        public void ListenTo(TicTacToeWithEvents game)
        {
            game.GameStarted += PrintStats;
            game.FieldUpdated += PrintStats;
        }

        private void PrintStats(Cell[,] field)
        {
            // Подія передає все поле, тож рахуємо прямо з нього
            var cells = field.Cast<Cell>().ToList();
            var empty = cells.Count(cell => cell.IsEmpty);

            var perPlayer = cells
                .Where(cell => !cell.IsEmpty)
                .GroupBy(cell => cell.MarkedByPlayer.Name)
                .OrderBy(group => group.Key)
                .Select(group => $"{group.Key}: {group.Count()}");

            var occupied = string.Join(", ", perPlayer);
            var prefix = occupied.Length > 0 ? occupied + ", " : "";

            Console.Out.WriteLine($"[Stats] {prefix}empty: {empty}");
        }
    }
}
