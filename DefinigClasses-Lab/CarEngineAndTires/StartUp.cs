using System;
using System.Linq;
using System.Collections.Generic;

namespace CarManufacturer
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            List<Tire[]> tires = new List<Tire[]>();
            string command = Console.ReadLine();

            while (command != "No more tires")
            {
                string[] tireInfo = command.Split(' ', StringSplitOptions.RemoveEmptyEntries).ToArray();
               
                int year1 = int.Parse(tireInfo[0]);
                double pressure1 = double.Parse(tireInfo[1]);
                Tire tire1 = new Tire(year1, pressure1);
                
                int year2 = int.Parse(tireInfo[2]);
                double pressure2 = double.Parse(tireInfo[3]);
                Tire tire2 = new Tire(year2, pressure2);

                int year3 = int.Parse(tireInfo[4]);
                double pressure3 = double.Parse(tireInfo[5]);
                Tire tire3 = new Tire(year3, pressure3);

                int year4 = int.Parse(tireInfo[6]);
                double pressure4 = double.Parse(tireInfo[7]);
                Tire tire4 = new Tire(year4, pressure4);

                tires.Add(new Tire[]
                {
                    tire1,
                    tire2,
                    tire3,
                    tire4
                });

                command = Console.ReadLine();
            }

            List<Engine> engines = new List<Engine>();

            command = Console.ReadLine();

            while (command != "Engines done")
            {
                string[] engineInfo = command.Split(' ', StringSplitOptions.RemoveEmptyEntries).ToArray();

                int horsePower = int.Parse(engineInfo[0]);
                double capacity = double.Parse(engineInfo[1]);

                engines.Add(new Engine(horsePower, capacity));

                command = Console.ReadLine();
            }

            List<Car> cars = new List<Car>();

            command = Console.ReadLine();

            while (command != "Show special")
            {
                string[] carInfo = command.Split(' ', StringSplitOptions.RemoveEmptyEntries).ToArray();

                string make = carInfo[0];
                string model = carInfo[1];
                int year = int.Parse(carInfo[2]);
                double fuelQuantity = double.Parse(carInfo[3]);
                double fuelConsumption = double.Parse(carInfo[4]);
                int engineIndex = int.Parse(carInfo[5]);
                int tiresIndex = int.Parse(carInfo[6]);

                cars.Add(new Car(make, model, year, fuelQuantity, fuelConsumption, engines[engineIndex], tires[tiresIndex]));

                command = Console.ReadLine();
            }

            List<Car> specialCars = new List<Car>();

            foreach(Car car in cars)
            {
                if (car.Year >= 2017)
                {
                    if (car.Engine.HorsePower > 330)
                    {
                        double pressureSum = 0;

                        foreach(Tire tire in car.Tires)
                        {
                            pressureSum += tire.Pressure;
                        }

                        if (pressureSum >= 9 && pressureSum <= 10)
                        {
                            specialCars.Add(car);
                        }
                    }
                }
            }
            
            for (int i = 0; i < specialCars.Count; i++)
            {
                specialCars[i].Drive(20);
            }

            foreach (Car car in specialCars)
            {
                Console.WriteLine($"Make: {car.Make}\nModel: {car.Model}\nYear: {car.Year}\nHorsePowers: {car.Engine.HorsePower}\nFuelQuantity: {car.FuelQuantity}");
            }
        }
    }
}
