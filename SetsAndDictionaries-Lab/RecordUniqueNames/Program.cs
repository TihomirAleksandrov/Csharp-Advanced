using System;
using System.Collections.Generic;

namespace RecordUniqueNames
{
    internal class Program
    {
        static void Main(string[] args)
        {
            HashSet<string> names = new HashSet<string>();
            
            int inputNum = int.Parse(Console.ReadLine());

            for (int i = 0; i < inputNum; i++)
            {
                names.Add(Console.ReadLine());
            }

            foreach (string name in names)
            {
                Console.WriteLine(name);
            }
        }
    }
}
