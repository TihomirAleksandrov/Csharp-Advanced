using System;

namespace KnightGame
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());

            char[,] board = new char[size, size];

            for (int row = 0; row < size; row++)
            {
                char[] rowInput = Console.ReadLine().ToCharArray();

                for (int col = 0; col < size; col++)
                {
                    board[row, col] = rowInput[col];
                }
            }

            int knightsRemoved = 0;

            while (true)
            {
                int maxAttacks = 0;
                int maxRow = 0;
                int maxCol = 0;
                
                for (int row = 0; row < size; row++)
                {
                    for (int col = 0; col < size; col++)
                    {
                        if (board[row, col] == 'K')
                        {
                            int attack = CheckAttack(board, row, col);

                            if (attack > maxAttacks)
                            {
                                maxAttacks = attack;
                                maxCol = col;
                                maxRow = row;
                            }
                        }
                    }
                }

                if (maxAttacks > 0)
                {
                    board[maxRow, maxCol] = '0';
                    knightsRemoved++;
                }
                else
                {
                    Console.WriteLine(knightsRemoved);
                    break;
                }
            }
        }

        static int CheckAttack(char[,] board, int row, int col)
        {
            int attacks = 0;
            
            if (CheckIndex(board, row - 1, col - 2) && board[row -1, col - 2] == 'K')
            {
                attacks++;
            }
            if (CheckIndex(board, row - 2, col - 1) && board[row - 2, col - 1] == 'K')
            {
                attacks++;
            }
            if (CheckIndex(board, row + 1, col - 2) && board[row + 1, col - 2] == 'K')
            {
                attacks++;
            }
            if (CheckIndex(board, row + 2, col - 1) && board[row + 2, col - 1] == 'K')
            {
                attacks++;
            }
            if (CheckIndex(board, row - 1, col + 2) && board[row - 1, col + 2] == 'K')
            {
                attacks++;
            }
            if (CheckIndex(board, row - 2, col + 1) && board[row - 2, col + 1] == 'K')
            {
                attacks++;
            }
            if (CheckIndex(board, row + 1, col + 2) && board[row + 1, col + 2] == 'K')
            {
                attacks++;
            }
            if (CheckIndex(board, row + 2, col + 1) && board[row + 2, col + 1] == 'K')
            {
                attacks++;
            }

            return attacks;
        }

        static bool CheckIndex(char[,] board, int row, int col)
        {
            return row >= 0 && row < board.GetLength(0) && col >= 0 && col < board.GetLength(1);
        }
    }
}
