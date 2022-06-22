using System;
using System.Linq;
using System.Collections.Generic;

namespace BeaverAtWork
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());

            char[,] pond = FillMatrix(size);

            int currRow = 0;
            int currCol = 0;
            int branchesCount = 0;

            for (int row = 0; row < size; row++)
            {
                for (int col = 0; col < size; col++)
                {
                    if (pond[row, col] == 'B')
                    {
                        currRow = row;
                        currCol = col;
                    }

                    if (char.IsLower(pond[row, col]))
                    {
                        branchesCount++;
                    }
                }
            }

            List<char> branches = new List<char>();

            string command = Console.ReadLine();

            while (command != "end")
            {
                if (branchesCount == 0)
                {
                    break;
                }

                if (command == "up")
                {
                    if (currRow - 1 != -1)
                    {
                        if (pond[currRow - 1, currCol] == 'F')
                        {
                            if (currRow - 2 == -1)
                            {
                                pond[currRow - 1, currCol] = '-';
                                pond[currRow, currCol] = '-';
                                currRow = size - 1;
                                if (char.IsLower(pond[currRow, currCol]))
                                {
                                    branches.Add(pond[currRow, currCol]);
                                    pond[currRow, currCol] = 'B';
                                    branchesCount--;
                                }
                                else
                                {
                                    pond[currRow, currCol] = 'B';
                                }
                            }
                            else
                            {
                                pond[currRow - 1, currCol] = '-';
                                pond[currRow, currCol] = '-';
                                currRow = 0;
                                if (char.IsLower(pond[currRow, currCol]))
                                {
                                    branches.Add(pond[currRow, currCol]);
                                    pond[currRow, currCol] = 'B';
                                    branchesCount--;
                                }
                                else
                                {
                                    pond[currRow, currCol] = 'B';
                                }
                            }
                        }
                        else if (pond[currRow - 1, currCol] == '-')
                        {
                            pond[currRow - 1, currCol] = 'B';
                            pond[currRow, currCol] = '-';
                            currRow--;
                        }
                        else if (char.IsLower(pond[currRow - 1, currCol]))
                        {
                            branches.Add(pond[currRow - 1, currCol]);
                            pond[currRow - 1, currCol] = 'B';
                            pond[currRow, currCol] = '-';
                            currRow--;
                            branchesCount--;
                        }
                    }
                    else
                    {
                        if (branches.Count > 0)
                        {
                            branches.RemoveAt(branches.Count - 1);
                        }
                    }
                }
                else if (command == "down")
                {
                    if (currRow + 1 != size)
                    {
                        if (pond[currRow + 1, currCol] == 'F')
                        {
                            if (currRow + 2 == size)
                            {
                                pond[currRow + 1, currCol] = '-';
                                pond[currRow, currCol] = '-';
                                currRow = 0;
                                if (char.IsLower(pond[currRow, currCol]))
                                {
                                    branches.Add(pond[currRow, currCol]);
                                    pond[currRow, currCol] = 'B';
                                    branchesCount--;
                                }
                                else
                                {
                                    pond[currRow, currCol] = 'B';
                                }
                            }
                            else
                            {
                                pond[currRow + 1, currCol] = '-';
                                pond[currRow, currCol] = '-';
                                currRow = size - 1;
                                if (char.IsLower(pond[currRow, currCol]))
                                {
                                    branches.Add(pond[currRow, currCol]);
                                    pond[currRow, currCol] = 'B';
                                    branchesCount--;
                                }
                                else
                                {
                                    pond[currRow, currCol] = 'B';
                                }
                            }
                        }
                        else if (pond[currRow + 1, currCol] == '-')
                        {
                            pond[currRow + 1, currCol] = 'B';
                            pond[currRow, currCol] = '-';
                            currRow++;
                        }
                        else if (char.IsLower(pond[currRow + 1, currCol]))
                        {
                            branches.Add(pond[currRow + 1, currCol]);
                            pond[currRow + 1, currCol] = 'B';
                            pond[currRow, currCol] = '-';
                            currRow++;
                            branchesCount--;
                        }
                    }
                    else
                    {
                        if (branches.Count > 0)
                        {
                            branches.RemoveAt(branches.Count - 1);
                        }
                    }
                }
                else if (command == "left")
                {
                    if (currCol - 1 != -1)
                    {
                        if (pond[currRow, currCol - 1] == 'F')
                        {
                            if (currCol - 2 == -1)
                            {
                                pond[currRow, currCol - 1] = '-';
                                pond[currRow, currCol] = '-';
                                currCol = size - 1;
                                if (char.IsLower(pond[currRow, currCol]))
                                {
                                    branches.Add(pond[currRow, currCol]);
                                    pond[currRow, currCol] = 'B';
                                    branchesCount--;
                                }
                                else
                                {
                                    pond[currRow, currCol] = 'B';
                                }
                            }
                            else
                            {
                                pond[currRow, currCol - 1] = '-';
                                pond[currRow, currCol] = '-';
                                currCol = 0;
                                if (char.IsLower(pond[currRow, currCol]))
                                {
                                    branches.Add(pond[currRow, currCol]);
                                    pond[currRow, currCol] = 'B';
                                    branchesCount--;
                                }
                                else
                                {
                                    pond[currRow, currCol] = 'B';
                                }
                            }
                        }
                        else if (pond[currRow, currCol - 1] == '-')
                        {
                            pond[currRow, currCol - 1] = 'B';
                            pond[currRow, currCol] = '-';
                            currCol--;
                        }
                        else if (char.IsLower(pond[currRow, currCol - 1]))
                        {
                            branches.Add(pond[currRow, currCol - 1]);
                            pond[currRow, currCol - 1] = 'B';
                            pond[currRow, currCol] = '-';
                            currCol--;
                            branchesCount--;
                        }
                    }
                    else
                    {
                        if (branches.Count > 0)
                        {
                            branches.RemoveAt(branches.Count - 1);
                        }
                    }
                }
                else if (command == "right")
                {
                    if (currCol + 1 != size)
                    {
                        if (pond[currRow, currCol + 1] == 'F')
                        {
                            if (currCol + 2 == size)
                            {
                                pond[currRow, currCol + 1] = '-';
                                pond[currRow, currCol] = '-';
                                currCol = 0;
                                if (char.IsLower(pond[currRow, currCol]))
                                {
                                    branches.Add(pond[currRow, currCol]);
                                    pond[currRow, currCol] = 'B';
                                    branchesCount--;
                                }
                                else
                                {
                                    pond[currRow, currCol] = 'B';
                                }
                            }
                            else
                            {
                                pond[currRow, currCol + 1] = '-';
                                pond[currRow, currCol] = '-';
                                currCol = size - 1;
                                if (char.IsLower(pond[currRow, currCol]))
                                {
                                    branches.Add(pond[currRow, currCol]);
                                    pond[currRow, currCol] = 'B';
                                    branchesCount--;
                                }
                                else
                                {
                                    pond[currRow, currCol] = 'B';
                                }
                            }
                        }
                        else if (pond[currRow, currCol + 1] == '-')
                        {
                            pond[currRow, currCol + 1] = 'B';
                            pond[currRow, currCol] = '-';
                            currCol++;
                        }
                        else if (char.IsLower(pond[currRow, currCol + 1]))
                        {
                            branches.Add(pond[currRow, currCol + 1]);
                            pond[currRow, currCol + 1] = 'B';
                            pond[currRow, currCol] = '-';
                            currCol++;
                            branchesCount--;
                        }
                    }
                    else
                    {
                        if (branches.Count > 0)
                        {
                            branches.RemoveAt(branches.Count - 1);
                        }
                    }
                }

                command = Console.ReadLine();
            }

            if (branchesCount == 0)
            {
                Console.WriteLine($"The Beaver successfully collect {branches.Count} wood branches: {string.Join(", ", branches)}.");
            }
            else
            {
                Console.WriteLine($"The Beaver failed to collect every wood branch. There are {branchesCount} branches left.");
            }

            for (int row = 0; row < size; row++)
            {
                for (int col = 0; col < size; col++)
                {
                    Console.Write($"{pond[row,col]} ");
                }
                Console.WriteLine();
            }
        }

        static char[,] FillMatrix(int size)
        {
            char[,] pond = new char[size, size];

            for (int row = 0; row < size; row++)
            {
                char[] inputRow = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(x => char.Parse(x)).ToArray();

                for (int col = 0; col < size; col++)
                {
                    pond[row, col] = inputRow[col];
                }
            }

            return pond;
        }

    }
}
