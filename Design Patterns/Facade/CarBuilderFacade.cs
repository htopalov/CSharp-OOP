using System;
using System.Collections.Generic;
using System.Text;

namespace Facade
{
    public class CarBuilderFacade
    {
        protected Car Car { get; set; }
        public CarBuilderFacade()
        {
            Car = new Car();
        }
        public Car Build() => Car;
        public CarInfoBuilder infoBuilder => new CarInfoBuilder(Car);
        public CarAddressBuilder addressBuilder => new CarAddressBuilder(Car);
    }
}
