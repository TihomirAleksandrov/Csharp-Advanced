using System;
using System.Linq;
using System.Collections.Generic;

namespace TruckTour
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Queue<Pump> pumps = new Queue<Pump>();

            for (int i = 0; i < n; i++)
            {
                long[] pumpInfo = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(long.Parse).ToArray();

                long fuel = pumpInfo[0];
                long distance = pumpInfo[1];

                pumps.Enqueue(new Pump(fuel, distance));
            }

            int lowestIndex = 0;

            while (true)
            {
                long fuelCounter = 0;
                bool flag = true;

                foreach (Pump pump in pumps)
                {
                    long liters = pump.FuelAmount;
                    long distance = pump.Distance;

                    fuelCounter += liters;

                    if (fuelCounter - distance < 0)
                    {
                        lowestIndex++;
                        Pump currPump = pumps.Dequeue();
                        pumps.Enqueue(currPump);
                        flag = false;
                        break;
                    }

                    fuelCounter -= distance;
                }

                if (flag)
                {
                    Console.WriteLine(lowestIndex);
                    break;
                }
            }
        }
    }

    public class Pump
    {
        public Pump(long fuel, long distance)
        {
            FuelAmount = fuel;
            Distance = distance;
        }
        
        public long FuelAmount { get; set; }

        public long Distance { get; set; }
    }
}
