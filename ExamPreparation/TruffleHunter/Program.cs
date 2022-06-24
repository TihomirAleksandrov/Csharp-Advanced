using System;
using System.Collections.Generic;
using System.Linq;

namespace TruffleHunter
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());

            Dictionary<string, int> truffles = new Dictionary<string, int>()
            {
                {"White", 0},
                {"Summer", 0},
                {"Black", 0},
                {"Eaten", 0}
            };
            
            char[,] forest = new char[size, size];

            for (int row = 0; row < size; row++)
            {
                char[] rowInput = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(x => char.Parse(x)).ToArray();
                for (int col = 0; col < size; col++)
                {
                    forest[row, col] = rowInput[col];
                }
            }

            string input = Console.ReadLine();

            while (input != "Stop the hunt")
            {
                string[] splitInput = input.Split(" ",StringSplitOptions.RemoveEmptyEntries).ToArray();

                string command = splitInput[0];
                int row = int.Parse(splitInput[1]);
                int col = int.Parse(splitInput[2]);
                
                if (command == "Collect")
                {
                    forest = CollectTruffles(forest, row, col, truffles);
                }
                else if (command == "Wild_Boar")
                {
                    string direction = splitInput[3];

                    forest = WildBoar(forest, row, col, truffles, direction);
                }
                
                input = Console.ReadLine();
            }

            Print(forest, truffles);
        }

        static void Print(char[,] forest, Dictionary<string, int> truffles)
        {
            Console.WriteLine($"Peter manages to harvest {truffles["Black"]} black, {truffles["Summer"]} summer, and {truffles["White"]} white truffles.");
            Console.WriteLine($"The wild boar has eaten {truffles["Eaten"]} truffles.");

            for (int row = 0; row < forest.GetLength(0); row++)
            {
                for (int col = 0; col < forest.GetLength(1); col++)
                {
                    Console.Write($"{forest[row,col]} ");
                }
                Console.WriteLine();
            }
        }

        static char[,] WildBoar(char[,] forest, int row, int col, Dictionary<string, int> truffles, string direction)
        {
            switch (direction)
            {
                case "up":
                    for (int rows = row; rows >= 0; rows -= 2)
                    {
                        if (char.IsUpper(forest[rows, col]))
                        {
                            truffles["Eaten"]++;
                            forest[rows, col] = '-';
                        }
                    }
                    break;
                case "down":
                    for (int rows = row; rows < forest.GetLength(0); rows += 2)
                    {
                        if (char.IsUpper(forest[rows, col]))
                        {
                            truffles["Eaten"]++;
                            forest[rows, col] = '-';
                        }
                    }
                    break;
                case "left":
                    for (int cols = col; cols >= 0; cols -= 2)
                    {
                        if (char.IsUpper(forest[row, cols]))
                        {
                            truffles["Eaten"]++;
                            forest[row, cols] = '-';
                        }
                    }
                    break;
                case "right":
                    for (int cols = col; cols < forest.GetLength(1); cols += 2)
                    {
                        if (char.IsUpper(forest[row, cols]))
                        {
                            truffles["Eaten"]++;
                            forest[row, cols] = '-';
                        }
                    }
                    break;
                default:
                    break;
            }

            return forest;
        }

        static char[,] CollectTruffles(char[,] forest, int row, int col, Dictionary<string, int> truffles)
        {
            if (char.IsUpper(forest[row,col]))
            {
                switch (forest[row,col])
                {
                    case 'W':
                        truffles["White"]++;
                        break;
                    case 'B':
                        truffles["Black"]++;
                        break;
                    case 'S':
                        truffles["Summer"]++;
                        break;
                    default:
                        break;
                }
            }

            forest[row, col] = '-';

            return forest;
        }
    }
}
