namespace Examples.TicTacToe.Consoled
{
    using System;
    using Examples.TicTacToe;

    public class PlayerCellCountOutput
    {
        private readonly Player firstPlayer;
        private readonly Player secondPlayer;

        public PlayerCellCountOutput(Player firstPlayer, Player secondPlayer)
        {
            this.firstPlayer = firstPlayer;
            this.secondPlayer = secondPlayer;
        }

        public void ListenTo(TicTacToeWithEvents game)
        {
            game.GameStarted += OnFieldUpdated;
            game.FieldUpdated += OnFieldUpdated;
        }

        private void OnFieldUpdated(Cell[,] field)
        {
            var firstPlayerCells = 0;
            var secondPlayerCells = 0;
            var emptyCells = 0;

            foreach (var cell in field)
            {
                if (cell.IsEmpty)
                {
                    emptyCells++;
                }
                else if (cell.MarkedByPlayer == firstPlayer)
                {
                    firstPlayerCells++;
                }
                else if (cell.MarkedByPlayer == secondPlayer)
                {
                    secondPlayerCells++;
                }
            }

            Console.Out.WriteLine(
                $"Cell counts — {firstPlayer.Name}: {firstPlayerCells}, " +
                $"{secondPlayer.Name}: {secondPlayerCells}, empty: {emptyCells}");
        }
    }
}
