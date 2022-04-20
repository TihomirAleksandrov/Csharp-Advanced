using System;
using System.Linq;

namespace JaggedArrayManipulator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine());

            double[][] jaggedArray = new double[rows][];

            for (int row = 0; row < rows; row++)
            {
                double[] nums = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(double.Parse).ToArray();

                jaggedArray[row] = new double[nums.Length];

                for (int col = 0; col < nums.Length; col++)
                {
                    jaggedArray[row][col] = nums[col];
                }
            }

            jaggedArray = AnalyzeArray(jaggedArray, rows);

            string input = Console.ReadLine();

            while (input != "End")
            {
                string[] splitInput = input.Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();

                string command = splitInput[0];
                int row = int.Parse(splitInput[1]);
                int col = int.Parse(splitInput[2]);
                double value = double.Parse(splitInput[3]);

                if (row >= 0 && row < rows)
                {
                    if (col >= 0 && col < jaggedArray[row].Length)
                    {
                        if (command == "Add")
                        {
                            jaggedArray[row][col] += value;
                        }
                        else if (command == "Subtract")
                        {
                            jaggedArray[row][col] -= value;
                        }
                    }
                }

                input = Console.ReadLine();
            }

            PrintArray(jaggedArray);
        }

        static void PrintArray(double[][] jaggedArray)
        {
            for (int row = 0; row < jaggedArray.GetLength(0); row++)
            {
                for (int col = 0; col < jaggedArray[row].Length; col++)
                {
                    Console.Write($"{jaggedArray[row][col]} ");
                }
                Console.WriteLine();
            }
        }

        static double[][] AnalyzeArray(double[][] jaggedArray, int rows)
        {
            for (int row = 0; row < rows - 1; row++)
            {
                if (jaggedArray[row].Length == jaggedArray[row + 1].Length)
                {
                    for (int col = 0; col < jaggedArray[row].Length; col++)
                    {
                        jaggedArray[row][col] *= 2;
                        jaggedArray[row + 1][col] *= 2;
                    }
                }
                else
                {
                    for (int col = 0; col < jaggedArray[row].Length; col++)
                    {
                        jaggedArray[row][col] /= 2;
                    }

                    for (int col = 0; col < jaggedArray[row + 1].Length; col++)
                    {
                        jaggedArray[row + 1][col] /= 2;
                    }
                }
            }

            return jaggedArray;
        }
    }
}
