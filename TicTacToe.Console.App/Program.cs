using Examples.TicTacToe;
using Examples.TicTacToe.Consoled;

var firstPlayer = new Player("A");
var secondPlayer = new Player("B");
var game = new TicTacToeWithEvents(firstPlayer, secondPlayer);

var board = new ConsoleOutput();
board.ListenTo(game);

var counts = new CellCountOutput(firstPlayer, secondPlayer);
counts.ListenTo(game);

if (args.Length > 0 && args[0] == "--numbers")
{
    new NumberConsoleInput().StartProcessing(game);
}
else
{
    new ConsoleInput().StartProcessing(game);
}
