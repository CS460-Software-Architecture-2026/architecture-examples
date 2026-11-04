using Examples.TicTacToe;
using Examples.TicTacToe.Consoled;
using TicTacToe.View.Console;

var game = new TicTacToeWithEvents(new Player("A"), new Player("B"));

var output = new ConsoleOutput();
output.ListenTo(game);

var stats = new StatsOutput();  
stats.ListenTo(game);

var input = new ConsoleInput();
input.StartProcessing(game);