namespace Examples.TicTacToe.Consoled;

public class StatsOutput
{
    private TicTacToeWithEvents game;

    public void ListenTo(TicTacToeWithEvents game)
    {
        this.game = game;
        game.GameStarted += OnFieldUpdated;
        game.FieldUpdated += OnFieldUpdated;
    }
    private void OnFieldUpdated(Cell[,] obj)
    {
        var empty = 0;
        var playerOccupied = new Dictionary<string, int>();

        foreach (var cell in obj)
        {
            if (cell.IsEmpty)
            {
                empty++;
            }
            else
            {
                var playerName = cell.MarkedByPlayer.Name;
                if (!playerOccupied.ContainsKey(playerName))
                {
                    playerOccupied[playerName] = 0;
                }

                playerOccupied[playerName]++;
            }
        }

        var playersStats = string.Join(", ", playerOccupied.Select(p => $"{p.Key}: {p.Value}"));
        Console.WriteLine($"[Stats] {(playersStats.Length > 0 ? playersStats + ", " : "")}Empty: {empty}");
    }
}