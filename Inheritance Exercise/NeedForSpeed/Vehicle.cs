using System;
using System.Collections.Generic;
using System.Text;

namespace NeedForSpeed
{
    public class Vehicle
    {
        private double defaultFuelConsumption = 1.25;
        public Vehicle(int horsePower, double fuel)
        {
            this.HorsePower = horsePower;
            this.Fuel = fuel;
        }

        public int HorsePower { get; set; }
        public double Fuel { get; set; }
        public double DefaultFuelConsumption { get; set; }
        public virtual double FuelConsumption
        {
            get
            {
                return defaultFuelConsumption;
            }
        }

        public virtual void Drive(double kilometers)
        {
            Fuel -= FuelConsumption * kilometers;
        }
    }
}
