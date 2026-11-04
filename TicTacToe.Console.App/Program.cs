using Examples.TicTacToe;
using Examples.TicTacToe.Consoled;

var firstPlayer = new Player("A");
var secondPlayer = new Player("B");
var game = new TicTacToeWithEvents(firstPlayer, secondPlayer);
var output = new ConsoleOutput();
output.ListenTo(game);
var statistics = new StatisticsOutput(firstPlayer, secondPlayer);
statistics.ListenTo(game);

if (args.Contains("--coordinates"))
{
    Console.WriteLine("Use MOVE X Y with coordinates from 0 to 2.");
    var input = new ConsoleInput();
    input.StartProcessing(game);
}
else
{
    var input = new CellNumberInput();
    input.StartProcessing(game);
}
