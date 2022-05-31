using System;
using System.Linq;
using System.Collections.Generic;

namespace BalancedParenthesis
{
    internal class Program
    {
        static void Main(string[] args)
        {
            char[] input = Console.ReadLine().ToCharArray();
            Queue<char> symbols = new Queue<char>(input);
            bool isBallanced = true;

            if (symbols.Count % 2 != 0 || !CheckSymbols(symbols))
            {
                isBallanced = false;
            }
            else
            {
                Stack<char> parentheses = new Stack<char>();
                foreach (char symbol in symbols)
                {
                    if (symbol == '{' || symbol == '[' || symbol == '(')
                    {
                        parentheses.Push(symbol);
                    }
                    else
                    {
                        if (parentheses.Count == 0)
                        {
                            isBallanced = false;
                            break;
                        }
                        else if (symbol == ']' && parentheses.Peek() == '[')
                        {
                            parentheses.Pop();
                        }
                        else if (symbol == '}' && parentheses.Peek() == '{')
                        {
                            parentheses.Pop();
                        }
                        else if (symbol == ')' && parentheses.Peek() == '(')
                        {
                            parentheses.Pop();
                        }
                        else
                        {
                            isBallanced = false;
                            break;
                        }
                    }
                }
            }

            if (isBallanced)
            {
                Console.WriteLine("YES");
            }
            else
            {
                Console.WriteLine("NO");
            }
        }

        static bool CheckSymbols(Queue<char> parentheses)
        {
            char[] allowedChars = { '{', '}', '(', ')', '[', ']' };

            foreach (char symbol in parentheses)
            {
                if (allowedChars.Contains(symbol))
                {
                    continue;
                }
                else
                {
                    return false;
                }
            }

            return true;
        }
    }
}
