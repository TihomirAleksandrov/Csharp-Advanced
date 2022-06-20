using System;

namespace CarManufacturer
{
    public class StartUp 
    {
        public static void Main(string[] args)
        {
            Car car = new Car();

            car.Make = "Mercedes";
            car.Model = "C-class";
            car.Year = 2009;

            Car car1 = new Car()
            {
                Make = "Honda",
                Model = "Civic",
                Year = 2000
            };

            Console.WriteLine($"{car.Make} {car.Model} {car.Year}");
        }
    }
}
