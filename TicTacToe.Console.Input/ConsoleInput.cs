namespace Examples.TicTacToe.Consoled
{
    using System;
    using Examples.TicTacToe;

    public  class ConsoleInput
    {
        public void StartProcessing(TicTacToeWithEvents game)
        {
            string command = null;
            Console.Out.WriteLine("Welcome to Tic Tac Toe! Type START to play, MOVE X Y to mark a cell, or EXIT to quit.");
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
                        return;
                    case "move":
                        var x = int.Parse(splitCommand[1]);
                        var y = int.Parse(splitCommand[2]);
                        game.MakeMove(x, y);
                        break;
                }
                
            }
        }
    }
}