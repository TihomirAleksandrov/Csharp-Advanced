using System;
using System.Collections.Generic;
using System.Linq;

namespace SetsOfElements
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] inputNum = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            int firstNum = inputNum[0];
            int secondNum = inputNum[1];

            HashSet<int> set1 = new HashSet<int>();
            HashSet<int> set2 = new HashSet<int>();

            for (int i = 0; i < firstNum; i++)
            {
                set1.Add(int.Parse(Console.ReadLine()));
            }

            for (int i = 0; i < secondNum; i++)
            {
                set2.Add(int.Parse(Console.ReadLine()));
            }

            HashSet<int> combinedSet = new HashSet<int>();

            foreach (int i in set1)
            {
                if (set2.Contains(i))
                {
                    combinedSet.Add(i);
                }
            }

            Console.WriteLine(string.Join(" ", combinedSet));
        }
    }
}
