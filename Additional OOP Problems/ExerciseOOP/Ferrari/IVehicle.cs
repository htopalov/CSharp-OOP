using System;
using System.Collections.Generic;
using System.Text;

namespace Ferrari
{
    public interface IVehicle
    {
        public string Driver { get;}
        public string Model { get;}
        string Brakes();
        string GasPedal();

    }
}
