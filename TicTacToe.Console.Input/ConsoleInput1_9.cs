namespace Examples.TicTacToe.Consoled
{
    using System;
    using Examples.TicTacToe;

    public  class ConsoleInput1_9
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
                        var num = int.Parse(splitCommand[1]);

                        int y = (num - 1)% 3;
                        int x = (num - 1)/3;
                        
                        game.MakeMove(x, y);
                        break;
                }
                
            }
        }
    }
}