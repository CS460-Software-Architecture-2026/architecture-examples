namespace Examples.TicTacToe.Consoled
{
    using System;
    using Examples.TicTacToe;

    public  class NumberConsoleInput
    {
        public void StartProcessing(TicTacToeWithEvents game)
        {
            string command = null;
            Console.Out.WriteLine("Welcome to greatest Tic Tac Toe game! Type START to play ");
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
                        var number = int.Parse(splitCommand[1]);
                        var x = (number - 1) / 3;
                        var y = (number - 1) % 3;
                        game.MakeMove(x, y);
                        break;
                }
                
            }
        }
    }
}