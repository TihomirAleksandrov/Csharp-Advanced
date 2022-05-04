using System;
using System.Linq;
using System.Collections.Generic;

namespace ParkingLot
{
    internal class Program
    {
        static void Main(string[] args)
        {
            HashSet<string> cars = new HashSet<string>();

            string input = Console.ReadLine();

            while (input != "END")
            {
                string[] splitInput = input.Split(", ", StringSplitOptions.RemoveEmptyEntries).ToArray();

                string command = splitInput[0];
                string car = splitInput[1];

                if (command == "IN")
                {
                    cars.Add(car);
                }
                else if (command == "OUT")
                {
                    if (cars.Contains(car))
                    {
                        cars.Remove(car);
                    }
                }

                input = Console.ReadLine();
            }

            if (cars.Count == 0)
            {
                Console.WriteLine("Parking Lot is Empty");
            }
            else
            {
                foreach (string car in cars)
                {
                    Console.WriteLine(car);
                }
            }
        }
    }
}
