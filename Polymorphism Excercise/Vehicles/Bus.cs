using System;
using System.Collections.Generic;
using System.Text;

namespace Vehicles
{
    public class Bus : Vehicle
    {
        private const double airConditioner = 1.4;
        public Bus(double fuelQuantity, double fuelConsumption, double tankCapacity)
            : base(fuelQuantity, fuelConsumption, tankCapacity, airConditioner)
        {
        }

        public void TurnOnConditioner()
        {
            this.AirConditioner = airConditioner;
        }
        public void TurnOffConditioner()
        {
            this.AirConditioner = 0;
        }
    }
}
