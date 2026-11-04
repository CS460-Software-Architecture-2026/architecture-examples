namespace Examples.TicTacToe.Consoled
{
    using System;
    using Examples.TicTacToe;

    public class CellCountOutput
    {
        private readonly Player firstPlayer;
        private readonly Player secondPlayer;

        public CellCountOutput(Player firstPlayer, Player secondPlayer)
        {
            this.firstPlayer = firstPlayer;
            this.secondPlayer = secondPlayer;
        }

        public void ListenTo(TicTacToeWithEvents game)
        {
            game.GameStarted += ShowCounts;
            game.FieldUpdated += ShowCounts;
        }

        private void ShowCounts(Cell[,] field)
        {
            var firstCount = 0;
            var secondCount = 0;
            var emptyCount = 0;

            foreach (var cell in field)
            {
                if (cell.IsEmpty)
                {
                    emptyCount++;
                }
                else if (cell.MarkedByPlayer == firstPlayer)
                {
                    firstCount++;
                }
                else if (cell.MarkedByPlayer == secondPlayer)
                {
                    secondCount++;
                }
            }

            Console.WriteLine($"Cells: {firstPlayer.Name}={firstCount}, {secondPlayer.Name}={secondCount}, empty={emptyCount}");
        }
    }
}
