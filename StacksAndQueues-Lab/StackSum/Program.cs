using System;
using System.Linq;
using System.Collections.Generic;

namespace StackSum
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine().Split().Select(x => int.Parse(x)).ToArray();

            Stack<int> stack = new Stack<int>(numbers);

            string input = Console.ReadLine().ToLower();

            while (input != "end")
            {
                string[] inputArgs = input.Split().ToArray();
                string command = inputArgs[0];

                if (command == "add")
                {
                    int num1 = int.Parse(inputArgs[1]);
                    int num2 = int.Parse(inputArgs[2]);
                    
                    stack.Push(num1);
                    stack.Push(num2);
                }
                else if (command == "remove")
                {
                    int count = int.Parse(inputArgs[1]);
                    
                    if (count <= stack.Count)
                    {
                        for (int i = 0; i < count; i++)
                        {
                            stack.Pop();
                        }
                    }
                }
                
                input = Console.ReadLine().ToLower();
            }

            Console.WriteLine($"Sum: {stack.Sum()}");
        }
    }
}
