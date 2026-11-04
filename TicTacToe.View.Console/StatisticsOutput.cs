namespace Examples.TicTacToe.Consoled
{
    using System;
    using Examples.TicTacToe;

    public class StatisticsOutput
    {
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
                else if (cell.MarkedByPlayer.Name == "A")
                {
                    firstPlayerCells++;
                }
                else if (cell.MarkedByPlayer.Name == "B")
                {
                    secondPlayerCells++;
                }
            }

            Console.WriteLine($"A: {firstPlayerCells}");
            Console.WriteLine($"B: {secondPlayerCells}");
            Console.WriteLine($"Empty: {emptyCells}");
        }
    }
}
