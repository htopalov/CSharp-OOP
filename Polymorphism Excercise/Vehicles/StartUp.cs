using System;

namespace Vehicles
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string[] inputCar = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            IVehicle car = car = new Car(double.Parse(inputCar[1]), double.Parse(inputCar[2]));
            string[] inputTruck = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            IVehicle truck = new Truck(double.Parse(inputTruck[1]), double.Parse(inputTruck[2]));
            int commandsCount = int.Parse(Console.ReadLine());
            for (int i = 0; i < commandsCount; i++)
            {
                string[] input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string typeOfCommand = input[0].ToLower();
                string typeOfVehicle = input[1];
                double amount = double.Parse(input[2]);
                if (typeOfCommand == "drive")
                {
                    if (typeOfVehicle == nameof(Car))
                    {
                        Console.WriteLine(car.Drive(amount));
                    }
                    else
                    {
                        Console.WriteLine(truck.Drive(amount));
                    }
                }
                else if (typeOfCommand == "refuel")
                {
                    if (typeOfVehicle == nameof(Car))
                    {
                        car.Refuel(amount);
                    }
                    else
                    {
                        truck.Refuel(amount);
                    }
                }
            }
            Console.WriteLine($"Car: {car.FuelQuantity:f2}");
            Console.WriteLine($"Truck: {truck.FuelQuantity:f2}");
        }
    }
}
