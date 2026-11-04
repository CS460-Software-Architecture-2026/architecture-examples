namespace Examples.TicTacToe.Consoled
{
    using System;
    using Examples.TicTacToe;

    public  class ConsoleInputWithNumbers
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

                        var cells = new (int x, int y)[]
                        {
                            (0, 0), (0, 1), (0, 2),
                            (1, 0), (1, 1), (1, 2),
                            (2, 0), (2, 1), (2, 2)
                        };

                        var (x, y) = cells[number - 1];
                        game.MakeMove(x, y);
                        break;
                }
                
            }
        }
    }
}