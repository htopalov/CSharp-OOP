using System;
using System.Collections.Generic;
using System.Text;

namespace Ferrari
{
    public class Ferrari : IVehicle
    {
        private string driver;
        public Ferrari(string driver)
        {
            this.Driver = driver;
        }
        public string Driver
        {
            get
            {
                return this.driver;
            }
            private set
            {
                this.driver = value;
            }
        }

        public string Model => "488-Spider";

        public string Brakes()
        {
            return "Brakes!";
        }

        public string GasPedal()
        {
            return "Zadu6avam sA!";
        }
    }
}
