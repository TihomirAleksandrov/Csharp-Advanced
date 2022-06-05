using System;
using System.Linq;
using System.Collections.Generic;

namespace SumNumbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).Select(x => int.Parse(x)).ToList();

            int sum = numbers.Sum();

            Console.WriteLine(numbers.Count);
            Console.WriteLine(sum);
        }
    }
}
