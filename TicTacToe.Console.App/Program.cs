using Examples.TicTacToe;
using Examples.TicTacToe.Consoled;

var  game = new TicTacToeWithEvents(new Player("A"), new Player("B") );
var output = new ConsoleOutput();
output.ListenTo(game);
new ConsoleStatsOutput().ListenTo(game);

// var input = new ConsoleInput();
var input = new ConsoleNumberInput();
input.StartProcessing(game);