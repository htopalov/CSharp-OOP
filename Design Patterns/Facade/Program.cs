using System;

namespace Facade
{
    class Program
    {
        static void Main(string[] args)
        {
            Car car = new CarBuilderFacade()
                .infoBuilder
                  .WithType("Zaporojec")
                  .WithColor("Glowing red")
                  .WithNumbeRofDoors(5)
                .addressBuilder
                  .CityOfCar("Sofia")
                  .AddressOfCar("bul. T. Aleksandrov 1")
                  .Build();
            Console.WriteLine(car);
        }
    }
}
