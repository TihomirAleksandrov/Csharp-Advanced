using System;
using System.Linq;
using System.Collections.Generic;

namespace SoftUniParty
{
    internal class Program
    {
        static void Main(string[] args)
        {
            HashSet<string> guests = new HashSet<string>();
            HashSet<string> VIP = new HashSet<string>();

            string input = Console.ReadLine();

            while (input != "PARTY")
            {
                if (char.IsDigit(input[0]))
                {
                    VIP.Add(input);
                }
                else
                {
                    guests.Add(input);
                }
                
                input = Console.ReadLine();
            }

            while (input != "END")
            {
                if (char.IsDigit(input[0]))
                {
                    if (VIP.Contains(input))
                    {
                        VIP.Remove(input);
                    }
                }
                else
                {
                    if (guests.Contains(input))
                    {
                        guests.Remove(input);
                    }
                }
                
                input = Console.ReadLine();
            }

            Console.WriteLine(VIP.Count + guests.Count);

            if (VIP.Count != 0)
            {
                foreach(string name in VIP)
                {
                    Console.WriteLine(name);
                }
            }

            if (guests.Count != 0)
            {
                foreach(string name in guests)
                {
                    Console.WriteLine(name);
                }
            }
        }
    }
}
