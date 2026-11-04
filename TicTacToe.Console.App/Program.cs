using Examples.TicTacToe;
using Examples.TicTacToe.Consoled;

var  game = new TicTacToeWithEvents(new Player("A"), new Player("B") );
var output = new ConsoleOutput();
var output2 = new ConsolCustomView();
output.ListenTo(game);
output2.ListenTo(game);

var input = new ConsoleInput();
input.StartProcessing(game);