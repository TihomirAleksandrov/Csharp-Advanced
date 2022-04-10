using System;
using System.Linq;
using System.Collections.Generic;

namespace FashionBoutique
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] clothes = Console.ReadLine().Split().Select(int.Parse).ToArray();

            Stack<int> stack = new Stack<int>(clothes);

            int rackCapacity = int.Parse(Console.ReadLine());
            int rackCount = 1;
            int currRack = 0;

            while (stack.Count > 0)
            {
                int currCloth = stack.Pop();

                if ((currCloth + currRack) <= rackCapacity)
                {
                    currRack += currCloth;
                }
                else
                {
                    currRack = currCloth;
                    rackCount++;
                }
            }

            Console.WriteLine(rackCount);
        }
    }
}
