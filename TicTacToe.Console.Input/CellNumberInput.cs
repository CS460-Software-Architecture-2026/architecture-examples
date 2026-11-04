namespace Examples.TicTacToe.Consoled
{
    using System;
    using Examples.TicTacToe;

    // Завдання 2: альтернативний controller. Приймає номер клітинки 1–9
    // замість двох координат. Модель і view ті самі — змінюється лише спосіб вводу.
    public class CellNumberInput
    {
        public void StartProcessing(TicTacToeWithEvents game)
        {
            Console.Out.WriteLine("Welcome to Tic Tac Toe! Type START to play, then a cell number 1-9. EXIT to quit.");
            Console.Out.WriteLine(" 1 │ 2 │ 3\n 4 │ 5 │ 6\n 7 │ 8 │ 9\n");

            while (true)
            {
                var command = ReadLine.Read("> ").Trim().ToLower();

                if (command == "exit")
                {
                    return;
                }

                if (command == "start")
                {
                    game.StartGame();
                    continue;
                }

                if (!int.TryParse(command, out var cellNumber) || !CellNumbers.IsValid(cellNumber))
                {
                    Console.Out.WriteLine("Enter START, EXIT or a cell number from 1 to 9");
                    continue;
                }

                var (x, y) = CellNumbers.ToCoordinates(cellNumber);
                try
                {
                    game.MakeMove(x, y);
                }
                catch (Exception e)
                {
                    // Напр. клітинка зайнята або гра не почалась — модель кидає виняток
                    Console.Out.WriteLine(e.Message);
                }
            }
        }
    }
}
