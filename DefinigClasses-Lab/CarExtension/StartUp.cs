using System;

namespace CarManufacturer
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            Car car = new Car()
            {
                Make = "Mazda",
                Model = "MX-5",
                Year = 2020,
                FuelQuantity = 200,
                FuelConsumption = 100
            };

            car.Drive(1);
            car.Drive(2000);
            Console.WriteLine(car.WhoAmI());
        }
    }
}
