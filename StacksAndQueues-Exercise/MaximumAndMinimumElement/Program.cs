using System;
using System.Linq;
using System.Collections.Generic;

namespace MaximumAndMinimumElement
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Stack<int> stack = new Stack<int>();

            int inputCount = int.Parse(Console.ReadLine());

            for (int i = 0; i < inputCount; i++)
            {
                int[] input = Console.ReadLine().Split().Select(int.Parse).ToArray();

                int commandNum = input[0];

                if (commandNum == 1)
                {
                    int num = input[1];
                    stack.Push(num);
                }
                else if (commandNum == 2)
                {
                    stack.Pop();
                }
                else if (commandNum == 3)
                {
                    if (stack.Count > 0)
                    {
                        int maxNum = int.MinValue;

                        foreach (int num in stack)
                        {
                            if (num > maxNum)
                            {
                                maxNum = num;
                            }
                        }

                        Console.WriteLine(maxNum);
                    }
                }
                else if (commandNum == 4)
                {
                    if (stack.Count > 0)
                    {
                        int minNum = int.MaxValue;

                        foreach (int num in stack)
                        {
                            if (num < minNum)
                            {
                                minNum = num;
                            }
                        }

                        Console.WriteLine(minNum);
                    }
                }
            }

            Console.WriteLine(string.Join(", ", stack));
        }
    }
}
