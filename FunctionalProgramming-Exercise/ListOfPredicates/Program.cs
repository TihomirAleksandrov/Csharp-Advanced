using System;
using System.Linq;
using System.Collections.Generic;

namespace ListOfPredicates
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int range = int.Parse(Console.ReadLine());
            List<int> numbers = FillArray(range);

            int[] dividers = Console.ReadLine().Split().Select(int.Parse).ToArray();

            numbers = Filter(numbers, dividers);
            Console.WriteLine(string.Join(" ", numbers));
        }

        static List<int> FillArray(int range)
        {
            List<int> numbers = new List<int>();

            for (int i = 1; i <= range; i++)
            {
                numbers.Add(i);
            }

            return numbers;
        }

        static List<int> Filter(List<int> numbers, int[] dividers)
        {
            foreach (int divider in dividers)
            {
                Func<int, bool> filter = x => x % divider == 0;
                numbers = numbers.Where(filter).ToList();
            }

            return numbers;
        }
    }
}
