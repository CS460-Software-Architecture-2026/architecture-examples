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
                        if (int.TryParse(splitCommand[1], out int n) && n >= 1 && n <= 9)
                        {
                            int row = (n - 1) / 3;
                            int col = (n - 1) % 3;
                            game.MakeMove(row, col);
                        }
                        else
                        {
                            Console.WriteLine("Please enter a number from 1 to 9.");
                        }
                        break;
                }
                
            }
        }
    }
}