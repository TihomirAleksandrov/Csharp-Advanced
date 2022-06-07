using System;
using System.Linq;

namespace ReverseAndExclude
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(x => int.Parse(x)).ToArray();

            int divisibleNum = int.Parse(Console.ReadLine());

            numbers = CheckDivision(numbers, divisibleNum);
            numbers = Reverse(numbers);
            Print(numbers);
        }

        static int[] CheckDivision(int[] numbers, int divisibleNum)
        {
            Predicate<int> predicate = x => x % divisibleNum == 0;

            int[] newNums = numbers.Where(x => !predicate(x)).ToArray();

            return newNums;
        }

        static int[] Reverse(int[] numbers)
        {
            Array.Reverse(numbers);

            return numbers;
        }

        static void Print(int[] numbers)
        {
            Console.Write(string.Join(" ", numbers));
        }
    }
}
