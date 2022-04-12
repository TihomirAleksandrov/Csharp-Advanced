using System;
using System.Linq;

namespace SquareWithMaximumSum
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] size = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();

            int rows = size[0];
            int cols = size[1];

            int[,] matrix = FillMatrix(rows, cols);

            int biggestSum = int.MinValue;
            int[,] biggestSquare = new int[2, 2];

            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    int sum = 0;
                    int[,] square = new int[2, 2];

                    if (row == rows - 1 || col == cols - 1)
                    {
                        break;
                    }
                    else
                    {
                        square[0,0] = matrix[row, col];
                        square[0,1] = matrix[row, col + 1];
                        square[1,0] = matrix[row + 1, col];
                        square[1,1] = matrix[row + 1, col + 1];

                        foreach(int num in square)
                        {
                            sum += num;
                        }

                        if (sum > biggestSum)
                        {
                            biggestSquare = square;
                            biggestSum = sum;
                        }
                    }
                }
            }

            PrintOutput(biggestSquare, biggestSum);
        }

        static int[,] FillMatrix(int rows, int cols)
        {
            int[,] matrix = new int[rows, cols];

            for (int row = 0; row < rows; row++)
            {
                int[] rowInput = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();

                for (int col = 0; col < cols; col++)
                {
                    matrix[row, col] = rowInput[col];
                }
            }

            return matrix;
        }

        static void PrintOutput(int[,] biggestSquare, int biggestSum)
        {
            for (int row = 0; row < 2; row++)
            {
                for (int col = 0; col < 2; col++)
                {
                    Console.Write($"{biggestSquare[row, col]} ");
                }
                Console.WriteLine();
            }

            Console.WriteLine(biggestSum);
        }
    }
}
