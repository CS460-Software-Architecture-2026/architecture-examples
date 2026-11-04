using Examples.TicTacToe;

namespace TicTacToe.View.Console;

public class StatsOutput
{
    public void ListenTo(TicTacToeWithEvents game)
    {
        game.GameStarted += Show;
        game.FieldUpdated += Show;
    }

    private void Show(Cell[,] field)
    {
        var perPlayer = new Dictionary<string, int>();
        var empty = 0;

        foreach (var cell in field)
        {
            if (cell.IsEmpty)
            {
                empty++;
            }
            else
            {
                var name = cell.MarkedByPlayer.Name;
                perPlayer[name] = perPlayer.GetValueOrDefault(name) + 1;
            }
        }

        var players = string.Join(", ", perPlayer.Select(p => $"{p.Key}: {p.Value}"));
        System.Console.WriteLine($"Stats -> {players} | empty: {empty}\n");
    }
}