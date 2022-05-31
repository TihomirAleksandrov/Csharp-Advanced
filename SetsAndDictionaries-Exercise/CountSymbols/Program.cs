using System;
using System.Linq;
using System.Collections.Generic;

namespace CountSymbols
{
    internal class Program
    {
        static void Main(string[] args)
        {
            SortedDictionary<char, int> letters = new SortedDictionary<char, int>();

            char[] lettersArr = Console.ReadLine().ToCharArray();

            foreach (char c in lettersArr)
            {
                if (letters.ContainsKey(c))
                {
                    letters[c]++;
                }
                else
                {
                    letters.Add(c, 1);
                }
            }

            foreach (var pair in letters)
            {
                Console.WriteLine($"{pair.Key}: {pair.Value} time/s");
            }
        }
    }
}
