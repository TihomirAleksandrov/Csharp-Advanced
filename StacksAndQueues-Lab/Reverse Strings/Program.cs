using System;
using System.Collections.Generic;

namespace Reverse_Strings
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            Stack<char> stack = new Stack<char>();
            
            foreach (char letter in input)
            {
                stack.Push(letter);
            }

            while (stack.Count > 0)
            {
                Console.Write(stack.Pop());
            }
        }
    }
}
