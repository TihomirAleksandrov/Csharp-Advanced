using System;
using System.Linq;
using System.Collections.Generic;

namespace BasicStackOperations
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Stack<int> stack = new Stack<int>();

            int[] arguments = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int inputNum = arguments[0];
            int popCount = arguments[1];
            int targetNum = arguments[2];
            int minNum = int.MaxValue;

            int[] input = Console.ReadLine().Split().Select(int.Parse).ToArray();

            for (int i = 0; i < inputNum; i++)
            {
                stack.Push(input[i]);
            }

            for (int i = 0; i < popCount; i++)
            {
                stack.Pop();
            }

            if (stack.Count > 0)
            {
                while (stack.Count > 0)
                {
                    int popNum = stack.Pop();

                    if (popNum < minNum)
                    {
                        minNum = popNum;
                    }

                    if (popNum == targetNum)
                    {
                        Console.WriteLine("true");
                        return;
                    }
                }

                Console.WriteLine(minNum);
            }
            else
            {
                Console.WriteLine(0);
            }
        }
    }
}
