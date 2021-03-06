namespace Vehicles
{
    public interface IVehicle
    {
        public double FuelQuantity { get;}

        public double FuelConsumption { get;}

        string Drive(double kilometers);

        void Refuel(double fuel);
    }
}
