namespace Examples.TicTacToe.Consoled;

public class CellNumberInput
{
    private const int FieldSize = 3;

    public void StartProcessing(TicTacToeWithEvents game)
    {
        while (true)
        {
            var command = ReadLine.Read("> ");
            var parts = command.Split(new char[0], StringSplitOptions.RemoveEmptyEntries);
            if (parts.Length == 0)
            {
                continue;
            }

            if (parts[0].ToLower() == "start")
            {
                game.StartGame();
            }
            else if (int.TryParse(parts[0], out var cell) && cell >= 1 && cell <= 9)
            {
                game.MakeMove((cell - 1) / FieldSize, (cell - 1) % FieldSize);
            }
        }
    }
}