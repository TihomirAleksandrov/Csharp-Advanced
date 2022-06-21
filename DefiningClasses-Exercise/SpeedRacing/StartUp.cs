using System;
using System.Collections.Generic;
using System.Linq;

namespace DefiningClasses
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            HashSet<Car> cars = new HashSet<Car>();

            int inputNum = int.Parse(Console.ReadLine());

            for (int i = 0; i < inputNum; i++)
            {
                string[] carInfo = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();

                string model = carInfo[0];
                double fuelAmount = double.Parse(carInfo[1]);
                double fuelConsumptionPerKm = double.Parse(carInfo[2]);

                cars.Add(new Car(model, fuelAmount, fuelConsumptionPerKm));
            }

            string command = Console.ReadLine();

            while (command != "End")
            {
                string[] driveInfo = command.Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();

                string carModel = driveInfo[1];
                double distance = double.Parse(driveInfo[2]);

                foreach (Car car in cars)
                {
                    if (car.Model == carModel)
                    {
                        car.Drive(distance);
                        break;
                    }
                }

                command = Console.ReadLine();
            }

            foreach (Car car in cars)
            {
                Console.WriteLine($"{car.Model} {car.FuelAmount:f2} {car.TravelledDistance}");
            }
        }
    }
}
