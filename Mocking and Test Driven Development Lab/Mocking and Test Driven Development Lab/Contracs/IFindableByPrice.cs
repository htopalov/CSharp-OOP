using System;
using System.Collections.Generic;
using System.Text;

namespace Mocking_and_Test_Driven_Development_Lab.Contracs
{
    public interface IFindableByPrice
    {
        IList<IProduct> FindAllInPriceRange(decimal lowerEndPrice, decimal higherEndPrice);
        IList<IProduct> FindAllByPrice(decimal price);
        IProduct FindMostExpensiveProducts();
    }
}
