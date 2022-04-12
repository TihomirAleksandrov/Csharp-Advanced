using System;
using System.Linq;

namespace SymbolInMatrix
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());

            char[,] matrix = new char[size, size];

            for (int row = 0; row < size; row++)
            {
                char[] symbols = GetInput();

                for (int col = 0; col < size; col++)
                {
                    matrix[row, col] = symbols[col];
                }
            }

            char symbol = char.Parse(Console.ReadLine());
            bool flag = false;

            for (int row = 0; row < size; row++)
            {
                for (int col = 0; col < size; col++)
                {
                    if (matrix[row, col] == symbol)
                    {
                        Console.WriteLine($"({row}, {col})");
                        flag = true;
                        break;
                    }
                }

                if (flag)
                {
                    break;
                }
            }

            if (!flag)
            {
                Console.WriteLine($"{symbol} does not occur in the matrix");
            }
        }

        static char[] GetInput()
        {
            string input = Console.ReadLine();

            char[] symbols = new char[input.Length];

            for (int i = 0; i < symbols.Length; i++)
            {
                symbols[i] = input[i];
            }

            return symbols;
        }
    }
}
