using System;

namespace PascalTriangle
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int rowsNum = int.Parse(Console.ReadLine());

            long[][] pascalTriangle = new long[rowsNum][];
            pascalTriangle[0] = new long[1] { 1 };

            for (int row = 1; row < rowsNum; row++)
            {
                pascalTriangle[row] = new long[row + 1];

                for (int col = 0; col <= row; col++)
                {
                    if (col == 0 || col == row)
                    {
                        pascalTriangle[row][col] = 1;
                    }
                    else
                    {
                        pascalTriangle[row][col] = pascalTriangle[row - 1][col] + pascalTriangle[row - 1][col - 1];
                    }
                }
            }

            for (int row = 0; row < rowsNum; row++)
            {
                Console.WriteLine(String.Join(" ", pascalTriangle[row]));
            }
        }
    }
}
