using System;
using System.Linq;
using System.Collections.Generic;

namespace Wardrobe
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Dictionary<string, int>> wardrobe = new Dictionary<string, Dictionary<string, int>>();
            
            int inputNum = int.Parse(Console.ReadLine());

            for (int i = 0; i < inputNum; i++)
            {
                string[] separators = {" -> ", "," };
                string[] clothes = Console.ReadLine().Split(separators, StringSplitOptions.RemoveEmptyEntries).ToArray();

                string color = clothes[0];

                if (wardrobe.ContainsKey(color))
                {
                    for (int j = 1; j < clothes.Length; j++)
                    {
                        if (wardrobe[color].ContainsKey(clothes[j]))
                        {
                            wardrobe[color][clothes[j]]++;
                        }
                        else
                        {
                            wardrobe[color].Add(clothes[j], 1);
                        }
                    }
                }
                else
                {
                    wardrobe.Add(color, new Dictionary<string, int>());
                    for (int j = 1; j < clothes.Length; j++)
                    {
                        if (wardrobe[color].ContainsKey(clothes[j]))
                        {
                            wardrobe[color][clothes[j]]++;
                        }
                        else
                        {
                            wardrobe[color].Add(clothes[j], 1);
                        }
                    }
                }
            }

            string[] searchedClothes = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();
            string searchedColor = searchedClothes[0];
            string searchedCloth = searchedClothes[1];

            foreach (var color in wardrobe)
            {
                Console.WriteLine($"{color.Key} clothes:");

                foreach (var pair in color.Value)
                {
                    if (color.Key == searchedColor && pair.Key == searchedCloth)
                    {
                        Console.WriteLine($"* {pair.Key} - {pair.Value} (found!)");
                    }
                    else
                    {
                        Console.WriteLine($"* {pair.Key} - {pair.Value}");
                    }
                }
            }
        }
    }
}
