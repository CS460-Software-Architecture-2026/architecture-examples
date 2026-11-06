namespace Examples.TicTacToe.Consoled
{
    using System;
    using System.Collections.Generic;
    using Examples.TicTacToe;

    // Stateful: keeps its own counters and updates them on each event.
    public class OccupiedCellsByEvents
    {
        private readonly Dictionary<Player, int> counts = new();
        private TicTacToeWithEvents game = null!;
        private int emptyCount;

        public void ListenTo(TicTacToeWithEvents game)
        {
            this.game = game;
            game.GameStarted += OnGameStarted;
            game.FieldUpdated += OnFieldUpdated;
        }

        private void OnGameStarted(Cell[,] field)
        {
            counts.Clear();
            counts[game.CurrentPlayer] = 0;
            emptyCount = field.Length;
            Print();
        }

        private void OnFieldUpdated(Cell[,] field)
        {
            // The event fires before the turn switches, so CurrentPlayer is the one who just moved.
            var player = game.CurrentPlayer;
            counts[player] = counts.GetValueOrDefault(player) + 1;
            emptyCount--;
            Print();
        }

        private void Print()
        {
            foreach (var (player, count) in counts)
            {
                Console.WriteLine($"[OccupiedCellsByEvents] Player {player.Name}: {count}");
            }

            Console.WriteLine($"[OccupiedCellsByEvents] Empty: {emptyCount}\n");
        }
    }
}
