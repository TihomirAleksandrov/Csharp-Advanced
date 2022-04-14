using System;
using System.Linq;

namespace MatrixShuffling
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] size = Console.ReadLine().Split().Select(int.Parse).ToArray();

            int rows = size[0];
            int cols = size[1];

            string[,] matrix = new string[rows, cols];

            for (int row = 0; row < rows; row++)
            {
                string[] input = Console.ReadLine().Split().ToArray();

                for (int col = 0; col < cols; col++)
                {
                    matrix[row, col] = input[col];
                }
            }

            string command = Console.ReadLine();

            while (command != "END")
            {
                bool flag = true;
                string[] splitCommand = command.Split().ToArray();

                if (splitCommand[0] == "swap" && splitCommand.Length == 5)
                {
                    int row1 = int.Parse(splitCommand[1]);
                    int col1 = int.Parse(splitCommand[2]);
                    int row2 = int.Parse(splitCommand[3]);
                    int col2 = int.Parse(splitCommand[4]);

                    if (row1 >= rows || row2 >= rows || col1 >= cols || col2 >= cols || row1 < 0 || row2 < 0 || col1 < 0 || col2 < 0)
                    {
                        flag = false;
                    }
                    else
                    {
                        string oldValue = matrix[row1, col1];
                        matrix[row1, col1] = matrix[row2, col2];
                        matrix[row2, col2] = oldValue;

                        PrintOutput(matrix);
                    }
                }
                else
                {
                    flag = false;
                }

                if (!flag)
                {
                    Console.WriteLine("Invalid input!");
                }

                command = Console.ReadLine();
            }
        }

        static void PrintOutput(string[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write($"{matrix[row, col]} ");
                }
                Console.WriteLine();
            }
        }
    }
}
