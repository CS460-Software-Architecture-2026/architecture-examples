namespace Examples.TicTacToe.Consoled;
using Examples.TicTacToe;

public class ScriptedInput
{
    private readonly IEnumerable<int> moves;

    public ScriptedInput(IEnumerable<int> moves)
    {
        this.moves = moves;
    }

    public void StartProcessing(TicTacToeWithEvents game)
    {
        game.StartGame();

        foreach (var move in moves)
        {
            if (move is >= 1 and <= 9)
            {
                var index = move - 1;
                Console.WriteLine($"Move to cell {move}");
                game.MakeMove(index / 3, index % 3);
            }
        }
    }
}