namespace Examples.TicTacToe.Consoled
{
    using System;
    using Examples.TicTacToe;

    // Alternative controller: "move N" with a cell number 1-9 (1-3 top row, 7-9 bottom row).
    public class CellNumberConsoleInput : ConsoleInputBase
    {
        protected override string MoveHint => "MOVE N (N is a cell number from 1 to 9)";

        protected override void HandleMoveCommand(TicTacToeWithEvents game, string[] splitCommand)
        {
            if (splitCommand.Length != 2
                || !int.TryParse(splitCommand[1], out var cellNumber)
                || cellNumber < 1 || cellNumber > 9)
            {
                Console.WriteLine($"Invalid move. Use {MoveHint}");
                return;
            }

            var index = cellNumber - 1;  // 0-8
            var x = index / 3;           // row
            var y = index % 3;           // column
            game.MakeMove(x, y);
        }
    }
}
