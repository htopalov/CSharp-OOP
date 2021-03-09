using System;

namespace Vehicles
{
    public class StartUp
    {
        static void Main(string[] args)
        {

            string[] carData = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            Vehicle car = new Car(double.Parse(carData[1]), double.Parse(carData[2]), double.Parse(carData[3]));
            string[] truckData = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            Vehicle truck = new Truck(double.Parse(truckData[1]), double.Parse(truckData[2]), double.Parse(truckData[3]));
            string[] busData = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            Vehicle bus = new Bus(double.Parse(busData[1]), double.Parse(busData[2]), double.Parse(busData[3]));
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string command = input[0];
                string vehicleType = input[1];
                double amount = double.Parse(input[2]);
                if (command == "Drive")
                {
                    try
                    {
                        if (vehicleType == nameof(Car))
                        {
                            car.Drive(amount);
                            Console.WriteLine($"Car travelled {amount} km");
                        }
                        else if (vehicleType == nameof(Truck))
                        {
                            truck.Drive(amount);
                            Console.WriteLine($"Truck travelled {amount} km");
                        }
                        else
                        {

                            bus.Drive(amount);
                            Console.WriteLine($"Bus travelled {amount} km");
                        }
                    }
                    catch(ArgumentException ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
                else if (command == "Refuel")
                {
                    try
                    {
                        if (vehicleType == nameof(Car))
                        {
                            car.Refuel(amount);
                        }
                        else if (vehicleType == nameof(Truck))
                        {
                            truck.Refuel(amount);
                        }
                        else
                        {
                            bus.Refuel(amount);
                        }
                    }
                    catch(ArgumentException ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
                else if (command == "DriveEmpty")
                {
                    try
                    {
                        ((Bus)bus).TurnOnConditioner();
                        bus.Drive(amount);
                        Console.WriteLine($"Bus travelled {amount} km");
                    }
                    catch(ArgumentException ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
            }
            Console.WriteLine(car);
            Console.WriteLine(truck);
            Console.WriteLine(bus);
        }
    }
}
