namespace Vehicles
{
    public class Car : IVehicle
    {
        private double fuelQuantity;
        private double fuelConsumption;
        private const double additionalFuel = 0.9;


        public Car(double fuelQuantity, double fuelConsumption)
        {
            this.FuelQuantity = fuelQuantity;
            this.FuelConsumption = fuelConsumption;
        }
        public double FuelQuantity
        {
            get => this.fuelQuantity;
            
            private set
            {
                this.fuelQuantity = value;
            }
        }


        public double FuelConsumption
        {
            get => this.fuelConsumption;

            private set
            {
                this.fuelConsumption = value;
            }
        }

        public string Drive(double kilometers)
        {
            double consumption = kilometers * (FuelConsumption + additionalFuel);
            if (consumption > FuelQuantity)
            {
                return "Car needs refueling";
            }
            else if (FuelQuantity >= consumption)
            {
                this.FuelQuantity -= consumption;    
            }
            return $"Car travelled {kilometers} km";

        }

        public void Refuel(double fuel)
        {
            this.FuelQuantity += fuel;
        }
    }
}
