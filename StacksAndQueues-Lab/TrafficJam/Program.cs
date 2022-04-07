using System;
using System.Collections.Generic;

namespace TrafficJam
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int passCount = int.Parse(Console.ReadLine());
            int counter = 0;

            Queue<string> queue = new Queue<string>();

            string input = Console.ReadLine();

            while (input != "end")
            {
                if (input == "green")
                {
                    for (int i = 0; i < passCount; i++)
                    {
                        if (queue.Count == 0)
                        {
                            break;
                        }
                        else
                        {
                            Console.WriteLine($"{queue.Dequeue()} passed!");
                            counter++;
                        }
                    }
                }
                else
                {
                    queue.Enqueue(input);
                }
                
                input = Console.ReadLine();
            }

            Console.WriteLine($"{counter} cars passed the crossroads.");
        }
    }
}
