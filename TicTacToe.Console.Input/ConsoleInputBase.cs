namespace Examples.TicTacToe.Consoled
{
    using System;
    using Examples.TicTacToe;

    // Shared input loop; subclasses decide only how to turn "move ..." arguments into a move.
    public abstract class ConsoleInputBase
    {
        public void StartProcessing(TicTacToeWithEvents game)
        {
            string command = null;
            Console.Out.WriteLine("Welcome to greatest Tic Tac Toe game! Type START to play ");
            Console.Out.WriteLine($"To make a move type {MoveHint}");
            while (true)
            {
                command = ReadLine.Read("> ");
                var splitCommand = command.Split(new char[0]);
                switch (splitCommand[0].ToLower())
                {
                    case "start":
                        game.StartGame();
                        break;
                    case "exit":
                        break;
                    case "move":
                        HandleMoveCommand(game, splitCommand);
                        break;
                }
            }
        }

        // How to type a move with this controller, e.g. "MOVE X Y".
        protected abstract string MoveHint { get; }

        // splitCommand[0] is "move", the arguments start at index 1.
        protected abstract void HandleMoveCommand(TicTacToeWithEvents game, string[] splitCommand);
    }
}
