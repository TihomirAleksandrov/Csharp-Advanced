using System;
using System.Linq;

namespace ActionPoint
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] names = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();

            Action<string[]> print = names => Console.WriteLine(string.Join("\n", names));

            print(names);
        }
    }
}
