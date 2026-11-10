namespace Examples.TicTacToe.Consoled
{
    using System;
    using Examples.TicTacToe;

    // Stateless: recounts everything from the field passed with each event.
    public class OccupiedCellsByField
    {
        private readonly Player firstPlayer;
        private readonly Player secondPlayer;

        public OccupiedCellsByField(Player firstPlayer, Player secondPlayer)
        {
            this.firstPlayer = firstPlayer;
            this.secondPlayer = secondPlayer;
        }

        public void ListenTo(TicTacToeWithEvents game)
        {
            game.GameStarted += Print;
            game.FieldUpdated += Print;
        }

        private void Print(Cell[,] field)
        {
            var firstCount = 0;
            var secondCount = 0;
            foreach (var cell in field)
            {
                if (cell.MarkedByPlayer == firstPlayer)
                {
                    firstCount++;
                }
                else if (cell.MarkedByPlayer == secondPlayer)
                {
                    secondCount++;
                }
            }

            var emptyCount = field.Length - firstCount - secondCount;
            Console.WriteLine($"[OccupiedCellsByField] Player {firstPlayer.Name}: {firstCount}");
            Console.WriteLine($"[OccupiedCellsByField] Player {secondPlayer.Name}: {secondCount}");
            Console.WriteLine($"[OccupiedCellsByField] Empty: {emptyCount}\n");
        }
    }
}
