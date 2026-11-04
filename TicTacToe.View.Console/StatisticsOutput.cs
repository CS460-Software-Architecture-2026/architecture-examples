namespace Examples.TicTacToe.Consoled
{
    using System;
    using Examples.TicTacToe;

    public class StatisticsOutput
    {
        private readonly Player firstPlayer;
        private readonly Player secondPlayer;

        public StatisticsOutput(Player firstPlayer, Player secondPlayer)
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

            Console.Out.WriteLine($"{firstPlayer.Name}: {firstCount}, {secondPlayer.Name}: {secondCount}, Empty: {emptyCount}");
        }
    }
}
