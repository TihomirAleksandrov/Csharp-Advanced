using System;
using System.Linq;

namespace PredicateForNames
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int nameLength = int.Parse(Console.ReadLine());
            string[] names = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();

            names = FilterNames(names, nameLength);
            Console.WriteLine(string.Join("\n", names));
        }

        static string[] FilterNames(string[] names, int nameLength)
        {
            Predicate<string> filter = x => x.Length <= nameLength;

            string[] filteredNames = names.Where(x => filter(x)).ToArray();

            return filteredNames;
        }
    }
}
