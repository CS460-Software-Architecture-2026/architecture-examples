using Examples.TicTacToe;
using Examples.TicTacToe.Consoled;

var  game = new TicTacToeWithEvents(new Player("A"), new Player("B") );
var output = new ConsoleOutput();
output.ListenTo(game);

var statistics = new StatisticsOutput();
// var input = new ConsoleInput();
var input = new NumberConsoleInput();

statistics.ListenTo(game);
input.StartProcessing(game);
