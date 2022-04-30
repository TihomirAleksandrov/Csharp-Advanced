using System;
using System.Linq;
using System.Collections.Generic;

namespace ProductShop
{
    internal class Program
    {
        static void Main(string[] args)
        {
            SortedDictionary<string, Dictionary<string, double>> products = new SortedDictionary<string, Dictionary<string, double>>();

            string input = Console.ReadLine();

            while (input != "Revision")
            {
                string[] splitInput = input.Split(", ", StringSplitOptions.RemoveEmptyEntries).ToArray();

                string shop = splitInput[0];
                string product = splitInput[1];
                double price = double.Parse(splitInput[2]);

                if (products.ContainsKey(shop))
                {
                    if (products[shop].ContainsKey(product))
                    {
                        products[shop][product] = price;
                    }
                    else
                    {
                        products[shop].Add(product, price);
                    }
                }
                else
                {
                    products.Add(shop, new Dictionary<string, double>());
                    products[shop].Add(product, price);
                }

                input = Console.ReadLine();
            }

            foreach (var pair in products)
            {
                Console.WriteLine($"{pair.Key}->");
                foreach (var pair2 in pair.Value)
                {
                    Console.WriteLine($"Product: {pair2.Key}, Price: {pair2.Value}");
                }
            }
        }
    }
}
