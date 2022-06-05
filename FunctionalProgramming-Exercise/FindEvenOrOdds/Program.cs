using System;
using System.Collections.Generic;
using System.Linq;

namespace FindEvenOrOdds
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Predicate<int> isEven = x => x % 2 == 0;

            int[] boundaries = Console.ReadLine().Split().Select(x => int.Parse(x)).ToArray();

            int lowerBound = boundaries[0];
            int upperBound = boundaries[1];
            string criteria = Console.ReadLine();

            List<int> numbers = new List<int>();

            for (int i = lowerBound; i <= upperBound; i++)
            {
                if (criteria == "even")
                {
                    if (isEven(i))
                    {
                        numbers.Add(i);
                    }
                }
                else
                {
                    if (!isEven(i))
                    {
                        numbers.Add(i);
                    }
                }
            }

            Console.WriteLine(string.Join(" ", numbers));
        }
    }
}
