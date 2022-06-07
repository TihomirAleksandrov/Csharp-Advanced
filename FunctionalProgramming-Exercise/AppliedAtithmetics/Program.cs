using System;
using System.Linq;

namespace AppliedAtithmetics
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(x => int.Parse(x)).ToArray();

            string command = Console.ReadLine();

            while (command != "end")
            {
                switch (command)
                {
                    case "add":
                        numbers = Add(numbers);
                        break;
                    case "multiply":
                        numbers = Multiply(numbers);
                        break;
                    case "subtract":
                        numbers = Subtract(numbers);
                        break;
                    case "print":
                        Print(numbers);
                        break;
                }

                command = Console.ReadLine();
            }
        }

        static int[] Add(int[] numbers)
        {
            return numbers.Select(x => x + 1).ToArray();
        }

        static int[] Multiply(int[] numbers)
        {
            return numbers.Select(x => x * 2).ToArray();
        }

        static int[] Subtract(int[] numbers)
        {
            return numbers.Select(x => x - 1).ToArray();
        }

        static void Print(int[] numbers)
        {
            Console.WriteLine(string.Join(" ", numbers));
        }
    }
}
