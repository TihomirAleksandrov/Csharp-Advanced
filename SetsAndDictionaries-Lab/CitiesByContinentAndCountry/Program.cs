using System;
using System.Linq;
using System.Collections.Generic;

namespace CitiesByContinentAndCountry
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Dictionary<string, List<string>>> cities = new Dictionary<string, Dictionary<string, List<string>>>();

            int inputCount = int.Parse(Console.ReadLine());

            for (int i = 0; i < inputCount; i++)
            {
                string[] input = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).ToArray();

                string continent = input[0];
                string country = input[1];
                string city = input[2];

                if (!cities.ContainsKey(continent))
                {
                    cities.Add(continent, new Dictionary<string, List<string>>());
                }

                if (!cities[continent].ContainsKey(country))
                {
                    cities[continent].Add(country, new List<string>());
                }

                cities[continent][country].Add(city);
            }

            foreach (string continent in cities.Keys)
            {
                Console.WriteLine($"{continent}:");

                foreach (string country in cities[continent].Keys)
                {
                    Console.Write($"  {country} -> {string.Join(", ", cities[continent][country])}");

                    Console.WriteLine();
                }
            }
        }
    }
}
