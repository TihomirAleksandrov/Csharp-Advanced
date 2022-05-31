using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace SimpleTextEditor
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string text = string.Empty;
            Stack<string> memory = new Stack<string>();
            int inputNum = int.Parse(Console.ReadLine());
            Stack<string> lastCommand = new Stack<string>();

            for (int i = 0; i < inputNum; i++)
            {
                string[] input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();

                if (input[0] == "1")
                {
                    text += input[1];
                    memory.Push(input[1]);
                    lastCommand.Push("1");
                }
                else if (input[0] == "2")
                {
                    int elementsCount = int.Parse(input[1]);
                    if (text.Length >= elementsCount)
                    {
                        int startIndex = text.Length - elementsCount;
                        string substring = text.Substring(startIndex);
                        text = text.Remove(startIndex);
                        memory.Push(substring);
                        lastCommand.Push("2");
                    }
                }
                else if (input[0] == "3")
                {
                    int index = int.Parse(input[1]);
                    
                    if (text.Length >= index)
                    {
                        Console.WriteLine(text[index-1]);
                    }
                }
                else if (input[0] == "4")
                {
                    string lastChange = string.Empty;
                    
                    if (lastCommand.Peek() == "1")
                    {
                        lastCommand.Pop();
                        lastChange = memory.Pop();
                        int indexCount =text.Length - lastChange.Length;

                        text = text.Remove(indexCount);
                    }
                    else if (lastCommand.Peek() == "2")
                    {
                        lastCommand.Pop();
                        lastChange = memory.Pop();
                        text += lastChange;
                    }
                }
            }
        }
    }
}
