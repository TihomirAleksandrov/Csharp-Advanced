using System;
using System.Linq;
using System.Collections.Generic;

namespace BakeryShop
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double[] waterInput = Console.ReadLine().Split(" ",StringSplitOptions.RemoveEmptyEntries).Select(x => double.Parse(x)).ToArray();
            double[] flourInput = Console.ReadLine().Split(" ",StringSplitOptions.RemoveEmptyEntries).Select(x => double.Parse(x)).ToArray();
            
            Stack<double> flour = new Stack<double>(flourInput);
            Queue<double> water = new Queue<double>(waterInput);

            Dictionary<string, int> products = new Dictionary<string, int>()
            {
                { "Croissant", 0 },
                { "Muffin", 0 },
                { "Baguette", 0 },
                { "Bagel", 0 }
            };

            while (true)
            {
                if (flour.Count == 0 || water.Count == 0)
                {
                    break;
                }

                double currWater = water.Dequeue();
                double currFlour = flour.Pop();

                MakeProduct(currWater, currFlour, products, flour);
            }

            Dictionary<string, int> sortedProducts = products.OrderByDescending(x => x.Value).ThenBy(x => x.Key).ToDictionary(x => x.Key, x => x.Value);

            PrintOutput(sortedProducts, flour, water);
        }

        static void PrintOutput(Dictionary<string, int> sortedProducts, Stack<double> flour, Queue<double> water)
        {
            foreach (var product in sortedProducts)
            {
                if (product.Value == 0)
                {
                    continue;
                }

                Console.WriteLine($"{product.Key}: {product.Value}");
            }

            if (water.Count == 0)
            {
                Console.WriteLine("Water left: None");
            }
            else
            {
                Console.WriteLine($"Water left: {string.Join(", ", water)}");
            }

            if (flour.Count == 0)
            {
                Console.WriteLine("Flour left: None");
            }
            else
            {
                Console.WriteLine($"Flour left: {string.Join(", ", flour)}");
            }
        }

        static void MakeProduct(double currWater, double currFlour, Dictionary<string, int> products, Stack<double> flour)
        {
            double productsSum = currWater + currFlour;
            double waterPercentage = (currWater * 100) / productsSum;

            if (waterPercentage == 50)
            {
                products["Croissant"]++;
            }
            else if (waterPercentage == 40)
            {
                products["Muffin"]++;
            }
            else if (waterPercentage == 30)
            {
                products["Baguette"]++;
            }
            else if (waterPercentage == 20)
            {
                products["Bagel"]++;
            }
            else
            {
                double excessFlour = currFlour - currWater;
                products["Croissant"]++;
                flour.Push(excessFlour);
            }
        }
    }
}
