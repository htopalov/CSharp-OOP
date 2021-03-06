namespace Vehicles
{
    public class Truck : IVehicle
    {
        private double fuelQuantity;
        private double fuelConsumption;
        private const double additionalFuel = 1.6;
        public Truck(double fuelQuantity, double fuelConsumption)
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
                return "Truck needs refueling";
            }
            else if (FuelQuantity >= consumption)
            {
                this.FuelQuantity -= consumption;
            }
            return $"Truck travelled {kilometers} km";
        }

        public void Refuel(double fuel)
        {
            this.FuelQuantity += fuel * 0.95;
        }
    }
}
