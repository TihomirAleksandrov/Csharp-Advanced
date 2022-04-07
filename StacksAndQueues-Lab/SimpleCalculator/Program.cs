using System;
using System.Collections.Generic;
using System.Linq;

namespace SimpleCalculator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split().ToArray();

            Stack<string> stack = new Stack<string>(input);

            int sum = 0;
            int currNum = 0;

            while (stack.Count > 0)
            {
                if (stack.Count % 2 != 0)
                {
                    currNum = int.Parse(stack.Pop());
                }
                else
                {
                    string symbol = stack.Pop();
                    if (symbol == "+")
                    {
                        sum += currNum;
                    }
                    else if (symbol == "-")
                    {
                        sum -= currNum;
                    }
                }

                if (stack.Count == 1)
                {
                    sum += int.Parse(stack.Pop());
                }
            }

            Console.WriteLine(sum);
        }
    }
}
