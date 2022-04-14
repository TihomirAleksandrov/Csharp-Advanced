using System;
using System.Linq;

namespace MaximalSum
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] size = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            int rows = size[0];
            int cols = size[1];

            double[,] matrix = new double[rows, cols];

            for (int row = 0; row < rows; row++)
            {
                double[] input = Console.ReadLine().Split(" ",StringSplitOptions.RemoveEmptyEntries).Select(double.Parse).ToArray();
                
                for (int col = 0; col < cols; col++)
                {
                    matrix[row, col] = input[col];
                }
            }

            double[,] biggestSquare = new double[3, 3];
            double biggestSum = int.MinValue;

            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    if (col >= cols - 2 || row >= rows - 2)
                    {
                        continue;
                    }
                    else
                    {
                        double[,] square = FillSquare(matrix, row, col);
                        double sum = GetSum(square);

                        if (sum > biggestSum)
                        {
                            biggestSum = sum;
                            biggestSquare = square;
                        }
                    }
                }
            }

            PrintOutput(biggestSquare, biggestSum);
        }

        static void PrintOutput(double[,] biggestSquare, double biggestSum)
        {
            Console.WriteLine($"Sum = {biggestSum}");

            for (int row = 0; row < biggestSquare.GetLength(0); row++)
            {
                for (int col = 0; col < biggestSquare.GetLength(1); col++)
                {
                    Console.Write($"{biggestSquare[row, col]} ");
                }
                Console.WriteLine();
            }
        }

        static double GetSum(double[,] square)
        {
            double sum = 0;
            
            foreach(double num in square)
            {
                sum += num;
            }

            return sum;
        }

        static double[,] FillSquare(double[,] matrix, int row, int col)
        {
            double[,] square = new double[3, 3];
            int mainCol = col;

            for (int currRow = 0; currRow < 3; currRow++)
            {
                for (int currCol = 0; currCol < 3; currCol++)
                {
                    square[currRow, currCol] = matrix[row, col];
                    col++;
                }
                col = mainCol;
                row++;
            }

            return square;
        }
    }
}
