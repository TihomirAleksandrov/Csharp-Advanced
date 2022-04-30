using System;
using System.Linq;

namespace Largest3Numbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();

            int[] sortedNums = numbers.OrderByDescending(x => x).ToArray();

            for (int i = 0; i < 3; i++)
            {
                if (sortedNums.Length == i)
                {
                    break;
                }

                Console.Write($"{sortedNums[i]} ");
            }
        }
    }
}
