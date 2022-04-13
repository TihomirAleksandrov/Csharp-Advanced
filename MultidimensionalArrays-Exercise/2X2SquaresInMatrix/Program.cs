using System;
using System.Linq;

namespace _2X2SquaresInMatrix
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] size = Console.ReadLine().Split().Select(int.Parse).ToArray();
            
            int rowSize = size[0];
            int colSize = size[1];

            string[,] square = new string[rowSize, colSize];

            for (int row = 0; row < rowSize; row++)
            {
                string[] symbols = Console.ReadLine().Split().ToArray();
                
                for (int col = 0; col < colSize; col++)
                {
                    square[row, col] = symbols[col];
                }
            }

            int counter = 0;

            for (int row = 0; row < rowSize; row++)
            {
                for (int col = 0; col < colSize; col++)
                {
                    if (col == colSize - 1 || row == rowSize - 1)
                    {
                        continue;
                    }
                    else
                    {
                        string symbol1 = square[row, col];
                        string symbol2 = square[row, col+1];
                        string symbol3 = square[row+1, col];
                        string symbol4 = square[row+1, col+1];
                        
                        if (symbol1 == symbol2 && symbol1 == symbol3 && symbol1 == symbol4)
                        {
                            counter++;
                        }
                    }
                }
            }

            Console.WriteLine(counter);
        }
    }
}
