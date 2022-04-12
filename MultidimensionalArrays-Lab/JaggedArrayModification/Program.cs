using System;
using System.Linq;

namespace JaggedArrayModification
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine());
            
            int[][] jaggedArray = FillArray(rows);

            ModifyArray(jaggedArray, rows);

            PrintOutput(jaggedArray, rows);
        }

        static int[][] FillArray(int rows)
        {
            int[][] jaggedArray = new int[rows][];
            
            for (int row = 0; row < rows; row++)
            {
                int[] rowInput = Console.ReadLine().Split().Select(int.Parse).ToArray();
                jaggedArray[row] = new int[rowInput.Length];

                for (int col = 0; col < rowInput.Length; col++)
                {
                    jaggedArray[row][col] = rowInput[col];
                }
            }

            return jaggedArray;
        }

        static void ModifyArray(int[][] jaggedArray, int rows)
        {
            string command = Console.ReadLine();

            while (command != "END")
            {
                string[] splitCommand = command.Split().ToArray();
                string currCommand = splitCommand[0];
                int currRow = int.Parse(splitCommand[1]);
                int currCol = int.Parse(splitCommand[2]);
                int number = int.Parse(splitCommand[3]);

                if (currRow >= rows || currRow < 0 || currCol < 0 || currCol >= jaggedArray[currRow].Length)
                {
                    Console.WriteLine("Invalid coordinates");
                }
                else
                {
                    if (currCommand == "Add")
                    {
                        jaggedArray[currRow][currCol] += number;
                    }
                    else if (currCommand == "Subtract")
                    {
                        jaggedArray[currRow][currCol] -= number;
                    }
                }

                command = Console.ReadLine();
            }
        }

        static void PrintOutput(int[][] jaggedArray, int rows)
        {
            for (int row = 0; row < rows; row++)
            {
                Console.Write(string.Join(" ", jaggedArray[row]));
                Console.WriteLine();
            }
        }
    }
}
