namespace Examples.TicTacToe.Consoled
{
    using System;
    using System.Linq;
    using Examples.TicTacToe;

    public class ConsoleStatsOutput
    {
        private TicTacToeWithEvents game;

        public void ListenTo(TicTacToeWithEvents game)
        {
            this.game = game;
            game.GameStarted += GameOnGameStarted;
            game.FieldUpdated += OnFieldUpdated;
            game.PlayerWon += OnPlayerWon;
            game.MatchDrawn += OnMatchDrawn;
        }

        private void OnMatchDrawn()
        {
            Console.Out.WriteLine("[Stats] Final: draw, board is full");
        }

        private void OnPlayerWon(Player player)
        {
            Console.Out.WriteLine($"[Stats] Final: {player.Name} won");
        }

        private void OnFieldUpdated(Cell[,] field)
        {
            PrintStats(field);
        }

        private void GameOnGameStarted(Cell[,] field)
        {
            PrintStats(field);
        }

        private void PrintStats(Cell[,] field)
        {
            var cells = field.Cast<Cell>().ToList();
            var empty = cells.Count(c => c.IsEmpty);
            var byPlayer = cells
                .Where(c => !c.IsEmpty)
                .GroupBy(c => c.MarkedByPlayer.Name)
                .Select(g => $"{g.Key}: {g.Count()}");

            Console.Out.WriteLine($"[Stats] {string.Join(", ", byPlayer)}  Empty: {empty}");
        }
    }
}