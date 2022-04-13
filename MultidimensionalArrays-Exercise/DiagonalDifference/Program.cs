using System;
using System.Linq;

namespace DiagonalDifference
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int squareSize = int.Parse(Console.ReadLine());
            
            int[,] square = new int[squareSize, squareSize];

            for (int row = 0; row < squareSize; row++)
            {
                int[] input = Console.ReadLine().Split().Select(int.Parse).ToArray();
                
                for (int col = 0; col < squareSize; col++)
                {
                    square[row, col] = input[col];
                }
            }

            int diagonalSum1 = 0;
            int diagonalSum2 = 0;
            
            for (int i = 0; i < squareSize; i++)
            {
                diagonalSum1 += square[i,i];
            }

            int reverseDiagonalIndex = squareSize - 1;

            for (int i = 0; i < squareSize; i++)
            {
                diagonalSum2 += square[i, reverseDiagonalIndex];
                reverseDiagonalIndex--;
            }

            Console.WriteLine(Math.Abs(diagonalSum1 - diagonalSum2));
        }
    }
}
