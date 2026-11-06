using Examples.TicTacToe;
using Examples.TicTacToe.Consoled;

var playerA = new Player("A");
var playerB = new Player("B");
var  game = new TicTacToeWithEvents(playerA, playerB);
var output = new ConsoleOutput();
output.ListenTo(game);

var occupiedByField = new OccupiedCellsByField(playerA, playerB);
occupiedByField.ListenTo(game);

var occupiedByEvents = new OccupiedCellsByEvents();
occupiedByEvents.ListenTo(game);

// Choose one controller 
// ConsoleInputBase input = new ConsoleInput();               // MOVE X Y, coordinates 0-2
ConsoleInputBase input = new CellNumberConsoleInput();  // MOVE N, cell number 1-9
input.StartProcessing(game);