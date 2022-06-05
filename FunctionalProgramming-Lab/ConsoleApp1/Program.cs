using System;
using System.Linq;

namespace AddVAT
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Func<double, double> addVAT = x => x + x * 0.2;

            double[] prices = Console.ReadLine()
                .Split(", ",StringSplitOptions.RemoveEmptyEntries)
                .Select(x => double.Parse(x))
                .Select(addVAT)
                .ToArray();

            foreach (var number in prices)
            {
                Console.WriteLine($"{number:f2}");
            }
        }
    }
}
