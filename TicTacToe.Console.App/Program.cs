using Examples.TicTacToe;
using Examples.TicTacToe.Consoled;

var playerA = new Player("A");
var playerB = new Player("B");
var game = new TicTacToeWithEvents(playerA, playerB);

var boardView = new ConsoleOutput();
boardView.ListenTo(game);

var countView = new PlayerCellCountOutput(playerA, playerB);
countView.ListenTo(game);

var input = new NumberedCellInput();
input.StartProcessing(game);