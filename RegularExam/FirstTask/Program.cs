using System;
using System.Collections.Generic;
using System.Linq;

namespace FirstTask
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> tilesPut = new Dictionary<string, int>()
            {
                {"Countertop", 0},
                {"Floor", 0},
                {"Oven", 0},
                {"Sink", 0},
                {"Wall", 0}
            };

            int[] whiteInput = Console.ReadLine().Split(' ',StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            Stack<int> whiteTiles = new Stack<int>(whiteInput);
            int[] greyInput = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            Queue<int> greyTiles = new Queue<int>(greyInput);

            while (true)
            {
                if (whiteTiles.Count == 0 || greyTiles.Count == 0)
                {
                    break;
                }

                int curWhite = whiteTiles.Pop();
                int curGrey = greyTiles.Dequeue();

                if (curWhite == curGrey)
                {
                    int tileSize = curWhite + curGrey;

                    if (tileSize == 40)
                    {
                        tilesPut["Sink"]++;
                    }
                    else if (tileSize == 50)
                    {
                        tilesPut["Oven"]++;
                    }
                    else if (tileSize == 60)
                    {
                        tilesPut["Countertop"]++;
                    }
                    else if (tileSize == 70)
                    {
                        tilesPut["Wall"]++;
                    }
                    else
                    {
                        tilesPut["Floor"]++;
                    }
                }
                else
                {
                    curWhite /= 2;
                    whiteTiles.Push(curWhite);
                    greyTiles.Enqueue(curGrey);
                }
            }

            if (whiteTiles.Count == 0)
            {
                Console.WriteLine("White tiles left: none");
            }
            else
            {
                Console.WriteLine($"White tiles left: {string.Join(", ", whiteTiles)}");
            }

            if (greyTiles.Count == 0)
            {
                Console.WriteLine("Grey tiles left: none");
            }
            else
            {
                Console.WriteLine($"Grey tiles left: {string.Join(", ", greyTiles)}");
            }

            foreach (var pair in tilesPut.OrderByDescending(x => x.Value).ThenBy(x => x.Key).Where(x => x.Value != 0))
            {
                Console.WriteLine($"{pair.Key}: {pair.Value}");
            }
        }
    }
}
