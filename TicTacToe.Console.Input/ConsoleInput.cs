using ConsoleInputBase = Examples.TicTacToe.Consoled.ConsoleInputBase;

namespace Examples.TicTacToe.Consoled
{
    using Examples.TicTacToe;

    // Original controller: "move X Y" with coordinates 0-2.
    public class ConsoleInput : ConsoleInputBase
    {
        protected override string MoveHint => "MOVE X Y (X, Y from 0 to 2)";

        protected override void HandleMoveCommand(TicTacToeWithEvents game, string[] splitCommand)
        {
            var x = int.Parse(splitCommand[1]);
            var y = int.Parse(splitCommand[2]);
            game.MakeMove(x, y);
        }
    }
}
