using System;
using System.Linq;

namespace CountUppercaseWords
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Func<string, bool> func = x => char.IsUpper(x[0]);

            string[] text = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Where(func).ToArray();

            foreach (string s in text)
            {
                Console.WriteLine(s);
            }
        }
    }
}
