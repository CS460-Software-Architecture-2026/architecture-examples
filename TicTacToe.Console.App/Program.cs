using Examples.TicTacToe;
using Examples.TicTacToe.Consoled;

var fplayer = new Player("A");
var splayer = new Player("B");

var  game = new TicTacToeWithEvents(fplayer, splayer);
var output = new ConsoleOutput();
output.ListenTo(game);

var cellView = new CellsView(fplayer, splayer);
cellView.ListenTo(game);

var input = new ConsoleInput();
input.StartProcessing(game);