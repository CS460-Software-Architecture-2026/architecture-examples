namespace Examples.TicTacToe.Consoled;

public class CellsRecord
{
    public CellsRecord(int cellsNumber, Player player)
    {
        this.cellsNumber = cellsNumber;
        this.Player = player;
    }
    public int cellsNumber { get; set; }
    public Player Player { get; set; }
}

public class CellsView
{
    private List<CellsRecord> cellsRecords;
    private int emptyCells = 9;

    public CellsView(Player Fplayer, Player Splayer)
    {
        cellsRecords = new List<CellsRecord>()
        {
            new CellsRecord(0, Fplayer),
            new CellsRecord(0, Splayer)
        };
    }
    
    public void ListenTo(TicTacToeWithEvents game)
    {
        game.GameStarted += OnGameStarted;
        game.CellMarked += OnCellMarked;
    }

    private void OnGameStarted(Cell[,] field)
    {
        foreach (var record in cellsRecords)
        {
            record.cellsNumber = 0;
        }
        emptyCells = field.Length;
        Print();
    }
    
    private void OnCellMarked(Player player)
    {
        var record = cellsRecords.First(r => r.Player == player);
        record.cellsNumber++;
        emptyCells--;
        Print();
    }

    private void Print()
    {
        foreach (var record in  cellsRecords)
        {
            Console.WriteLine($"{record.Player.Name}: {record.cellsNumber}");
        }
        Console.WriteLine($"Empty cells: {emptyCells}");
    }
}