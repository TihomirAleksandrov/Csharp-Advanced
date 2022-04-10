using System;
using System.Linq;
using System.Collections.Generic;

namespace FastFood
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int foodQuantity = int.Parse(Console.ReadLine());

            int[] orders = Console.ReadLine().Split().Select(int.Parse).ToArray();

            Queue<int> queue = new Queue<int>(orders);

            int biggestOrder = int.MinValue;

            foreach (int order in queue)
            {
                if (order > biggestOrder)
                {
                    biggestOrder = order;
                }
            }

            while (queue.Count > 0)
            {
                if (foodQuantity >= queue.Peek())
                {
                    int currOrder = queue.Dequeue();
                    foodQuantity -= currOrder;
                }
                else
                {
                    break;
                }
            }

            Console.WriteLine(biggestOrder);
            
            if (queue.Count == 0)
            {
                Console.WriteLine("Orders complete");
            }
            else
            {
                Console.WriteLine($"Orders left: {string.Join(" ", queue)}");
            }
        }
    }
}
