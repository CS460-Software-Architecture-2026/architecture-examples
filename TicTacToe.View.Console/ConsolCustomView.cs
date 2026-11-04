namespace Examples.TicTacToe.Consoled
{
    using System;
    using Examples.TicTacToe;

    public class ConsolCustomView
    {
        private TicTacToeWithEvents game;

        public void ListenTo(TicTacToeWithEvents game)
        {
            this.game = game;
            game.FieldUpdated += OnFieldUpdated;
        }

        private void OnFieldUpdated(Cell[,] field)
        {
            int empty = 0;
            Dictionary<string, int> players = new Dictionary<string, int>();
            foreach (Cell cell in field)
            {
                if (cell.IsEmpty) 
                    empty++;
                else
                {
                    if (!players.ContainsKey(cell.MarkedByPlayer.Name))
                    {
                        players.Add(cell.MarkedByPlayer.Name, 0);
                    }
                    players[cell.MarkedByPlayer.Name]++;
                }
            }
            Console.Out.WriteLine("Empty cells: {0}", empty);
            foreach (KeyValuePair<string, int> player in players)
            {
                Console.Out.WriteLine("Player {0}: {1}", player.Key, player.Value);
            }
        }
    }    
}
