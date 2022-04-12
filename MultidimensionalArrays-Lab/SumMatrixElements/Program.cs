using System;
using System.Linq;

namespace SumMatrixElements
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();
            int rowsNum = input[0];
            int colsNum = input[1];

            int[,] matrix = new int[rowsNum, colsNum];

            for (int row = 0; row < rowsNum; row++)
            {
                input = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();

                for (int col = 0; col < colsNum; col++)
                {
                    matrix[row, col] = input[col];
                }
            }

            Console.WriteLine(rowsNum);
            Console.WriteLine(colsNum);

            int sum = 0;

            foreach (int num in matrix)
            {
                sum += num;
            }

            Console.WriteLine(sum);
        }
    }
}
