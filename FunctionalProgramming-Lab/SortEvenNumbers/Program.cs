using System;
using System.Linq;
using System.Collections.Generic;

namespace SortEvenNumbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).Select(x => int.Parse(x)).ToList();

            numbers = numbers.Where(x => x % 2 == 0).ToList();
            numbers.Sort();

            Console.WriteLine(string.Join(", ", numbers));
        }
    }
}
