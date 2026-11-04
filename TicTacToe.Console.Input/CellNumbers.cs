namespace Examples.TicTacToe.Consoled
{
    using System;

    // Перетворення номера клітинки 1–9 у координати моделі (0–2):
    //  1 │ 2 │ 3
    //  4 │ 5 │ 6
    //  7 │ 8 │ 9
    public static class CellNumbers
    {
        public static bool IsValid(int cellNumber) => cellNumber is >= 1 and <= 9;

        public static (int X, int Y) ToCoordinates(int cellNumber)
        {
            if (!IsValid(cellNumber))
            {
                throw new ArgumentOutOfRangeException(nameof(cellNumber), "Cell number must be between 1 and 9");
            }

            var index = cellNumber - 1;
            return (index / 3, index % 3);
        }
    }
}
