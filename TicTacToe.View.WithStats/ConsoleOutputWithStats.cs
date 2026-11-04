namespace Examples.TicTacToe.Consoled
{
    using System;
    using Examples.TicTacToe;

    public class ConsoleOutputWithStats
    {
        private TicTacToeWithEvents game;

        public void ListenTo(TicTacToeWithEvents game)
        {
            this.game = game;
            game.FieldUpdated += OnFieldUpdated;
        }
        
        private void OnFieldUpdated(Cell[,] field)
        {
            var markedByPlayer1 = 0; 
            var markedByPlayer2 = 0; 
            var remainEmpty = 0; 
            for (var i = 0; i < field.GetLength(0); i++)
            {
                for (var j = 0; j < field.GetLength(1); j++)
                {
                    var cell = field[i, j];
                    if (cell.IsEmpty)
                    {
                        remainEmpty++;
                        continue;
                    }

                    if (cell.MarkedByPlayer.Name == "A")
                    {
                        markedByPlayer1++;
                    }
                    else
                    {
                        markedByPlayer2++;
                    }
                }
            }
            Console.Out.WriteLine($"Marked by first player {markedByPlayer1} cells.");
            Console.Out.WriteLine($"Marked by second player {markedByPlayer2} cells.");
            Console.Out.WriteLine($"Remains empty {remainEmpty} cells.");
            
            string v(Cell cell)
            {
                return cell.IsEmpty ? " " : cell.MarkedByPlayer.Name;
            }
        }
    }
}