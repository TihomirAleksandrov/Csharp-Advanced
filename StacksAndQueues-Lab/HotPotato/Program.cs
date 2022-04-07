using System;
using System.Linq;
using System.Collections.Generic;

namespace HotPotato
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] names = Console.ReadLine().Split().ToArray();
           
            Queue<string> queue = new Queue<string>(names);

            int count = int.Parse(Console.ReadLine());

            while (queue.Count > 1)
            {
                for (int i = 1; i <= count; i++)
                {
                    if (i < count)
                    {
                        queue.Enqueue(queue.Dequeue());
                    }
                    else
                    {
                        Console.WriteLine($"Removed {queue.Dequeue()}");
                    }
                }
            }

            Console.WriteLine($"Last is {queue.Dequeue()}");
        }
    }
}
