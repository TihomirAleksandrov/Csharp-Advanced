using System;
using System.Linq;
using System.Collections.Generic;

namespace SecondTask
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());
            int curRow = 0;
            int curCol = 0;

            char[,] wall = new char[size, size];

            for (int row = 0; row < size; row++)
            {
                char[] rowInput = Console.ReadLine().ToCharArray();

                for (int col = 0; col < size; col++)
                {
                    wall[row, col] = rowInput[col];
                    if (rowInput[col] == 'V')
                    {
                        curRow = row;
                        curCol = col;
                    }
                }
            }

            int holesCounter = 1;
            int rodsCounter = 0;
            bool isElectrocuted = false;
            string command = Console.ReadLine();
            
            while (command != "End")
            {
                if (command == "up")
                {
                    if (curRow - 1 >= 0)
                    {
                        if (wall[curRow-1, curCol] == 'R')
                        {
                            Console.WriteLine("Vanko hit a rod!");
                            rodsCounter++;
                        }
                        else if (wall[curRow-1, curCol] == 'C')
                        {
                            holesCounter++;
                            wall[curRow, curCol] = '*';
                            wall[curRow - 1, curCol] = 'E';
                            isElectrocuted = true;
                            break;
                        }
                        else if (wall[curRow-1, curCol] == '*')
                        {
                            Console.WriteLine($"The wall is already destroyed at position [{curRow-1}, {curCol}]!");
                            wall[curRow, curCol] = '*';
                            wall[curRow - 1, curCol] = 'V';
                            curRow--;
                        }
                        else
                        {
                            holesCounter++;
                            wall[curRow-1, curCol] = 'V';
                            wall[curRow, curCol] = '*';
                            curRow--;
                        }
                    }
                }
                else if (command == "down")
                {
                    if (curRow + 1 < size)
                    {
                        if (wall[curRow + 1, curCol] == 'R')
                        {
                            Console.WriteLine("Vanko hit a rod!");
                            rodsCounter++;
                        }
                        else if (wall[curRow + 1, curCol] == 'C')
                        {
                            holesCounter++;
                            wall[curRow, curCol] = '*';
                            wall[curRow + 1, curCol] = 'E';
                            isElectrocuted = true;
                            break;
                        }
                        else if (wall[curRow + 1, curCol] == '*')
                        {
                            Console.WriteLine($"The wall is already destroyed at position [{curRow + 1}, {curCol}]!");
                            wall[curRow, curCol] = '*';
                            wall[curRow + 1, curCol] = 'V';
                            curRow++;
                        }
                        else
                        {
                            holesCounter++;
                            wall[curRow + 1, curCol] = 'V';
                            wall[curRow, curCol] = '*';
                            curRow++;
                        }
                    }
                }
                else if (command == "left")
                {
                    if (curCol - 1 >= 0)
                    {
                        if (wall[curRow, curCol - 1] == 'R')
                        {
                            Console.WriteLine("Vanko hit a rod!");
                            rodsCounter++;
                        }
                        else if (wall[curRow, curCol - 1] == 'C')
                        {
                            holesCounter++;
                            wall[curRow, curCol] = '*';
                            wall[curRow, curCol - 1] = 'E';
                            isElectrocuted = true;
                            break;
                        }
                        else if (wall[curRow, curCol - 1] == '*')
                        {
                            Console.WriteLine($"The wall is already destroyed at position [{curRow}, {curCol - 1}]!");
                            wall[curRow, curCol] = '*';
                            wall[curRow, curCol - 1] = 'V';
                            curCol--;
                        }
                        else
                        {
                            holesCounter++;
                            wall[curRow, curCol - 1] = 'V';
                            wall[curRow, curCol] = '*';
                            curCol--;
                        }
                    }
                }
                else if (command == "right")
                {
                    if (curCol + 1 < size)
                    {
                        if (wall[curRow, curCol + 1] == 'R')
                        {
                            Console.WriteLine("Vanko hit a rod!");
                            rodsCounter++;
                        }
                        else if (wall[curRow, curCol + 1] == 'C')
                        {
                            holesCounter++;
                            wall[curRow, curCol] = '*';
                            wall[curRow, curCol + 1] = 'E';
                            isElectrocuted = true;
                            break;
                        }
                        else if (wall[curRow, curCol + 1] == '*')
                        {
                            Console.WriteLine($"The wall is already destroyed at position [{curRow}, {curCol + 1}]!");
                            wall[curRow, curCol] = '*';
                            wall[curRow, curCol + 1] = 'V';
                            curCol++;
                        }
                        else
                        {
                            holesCounter++;
                            wall[curRow, curCol + 1] = 'V';
                            wall[curRow, curCol] = '*';
                            curCol++;
                        }
                    }
                }

                command = Console.ReadLine();
            }

            if (isElectrocuted)
            {
                Console.WriteLine($"Vanko got electrocuted, but he managed to make {holesCounter} hole(s).");
            }
            else
            {
                Console.WriteLine($"Vanko managed to make {holesCounter} hole(s) and he hit only {rodsCounter} rod(s).");
            }

            for (int row = 0; row < size; row++)
            {
                for (int col = 0; col < size; col++)
                {
                    Console.Write($"{wall[row, col]}");
                }

                Console.WriteLine();
            }
        }
    }
}
