using System;
using System.Collections.Generic;

namespace _6__8_Queens_Puzzle
{
    class Program
    {
        const int Size = 8;
        static int[,] matrix = new int[Size, Size];
        static HashSet<int> attackedRows = new HashSet<int>();
        static HashSet<int> attackedCol = new HashSet<int>();
        static HashSet<int> LeftDia = new HashSet<int>();
        static HashSet<int> RightDia = new HashSet<int>();
        static void Main(string[] args)
        {
            PlaceQueens(0);
        }
        static void PlaceQueens(int row)
        {
            if (row == Size)
            {
                PrinstSolution();
            }
            for (int col = 0; col < Size; col++)
            {
                if (CanPlaceQueen(row, col))
                {
                    MarkAttackedPosition(row, col);
                    PlaceQueens(row + 1);
                    UnMarkAttackedPosition(row, col);
                }
            }
        }

        private static void UnMarkAttackedPosition(int row, int col)
        {
            matrix[row, col] = 0;
            attackedRows.Remove(row);
            attackedCol.Remove(col);
            LeftDia.Remove(col - row);
            RightDia.Remove(col + row);
        }

        private static void MarkAttackedPosition(int row, int col)
        {
            matrix[row, col] = 1;
            attackedRows.Add(row);
            attackedCol.Add(col);
            LeftDia.Add(col - row);
            RightDia.Add(col + row);
        }

        private static bool CanPlaceQueen(int row, int col)
        {
            bool isFreePosition = attackedRows.Contains(row)
            || attackedCol.Contains(col)
            || LeftDia.Contains(col - row)
            || RightDia.Contains(col + row);

            return !isFreePosition;
        }

        private static void PrinstSolution()
        {
            for (int r = 0; r < Size; r++)
            {
                for (int c = 0; c < Size; c++)
                {
                    if (matrix[r, c] == 1)
                    {
                        Console.Write("* ");
                    }
                    else
                    {
                        Console.Write("- ");
                    }
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }
    }
}
