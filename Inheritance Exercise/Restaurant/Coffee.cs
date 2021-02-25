using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurant
{
    public class Coffee : HotBeverage
    {
        private const decimal defaultPrice = 3.50M;
        private const double milliliters = 50;
        public Coffee(string name,double caffeine)
            :base(name,defaultPrice, milliliters)
        {
            this.Caffeine = caffeine;
        }

        public double Caffeine { get; set; }
    }
}
