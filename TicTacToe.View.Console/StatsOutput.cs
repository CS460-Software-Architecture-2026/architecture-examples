namespace Examples.TicTacToe.Consoled
{
    using System;
    using Examples.TicTacToe;

    public class StatsOutput
    {
        public void ListenTo(TicTacToeWithEvents game)
        {
              game.FieldUpdated += OnFieldUpdated;
        }

        private void OnFieldUpdated(Cell[,] field)
        {
            int a = 0;
            int b = 0;
            int empty = 0;

            for (int row = 0; row < 3; row++)
            {
                for (int col = 0; col < 3; col++)
                {
                    var cell = field[row, col];

                    if (cell.IsEmpty)
                        empty++;
                    else if (cell.MarkedByPlayer.Name == "A")
                        a++;
                    else
                        b++;
                }
            }

            Console.WriteLine($"Stats: A = {a}, B = {b}, empty = {empty}\n");
        }
    }
}