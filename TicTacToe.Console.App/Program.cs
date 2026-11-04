using Examples.TicTacToe;
using Examples.TicTacToe.Consoled;

var  game = new TicTacToeWithEvents(new Player("A"), new Player("B") );
new ConsoleOutput().ListenTo(game);
new ConsoleOutputWithStats().ListenTo(game);

var input = new ConsoleInputNumber();
input.StartProcessing(game);