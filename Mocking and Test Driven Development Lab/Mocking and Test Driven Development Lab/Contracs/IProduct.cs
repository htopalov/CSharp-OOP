using System;
using System.Collections.Generic;
using System.Text;

namespace Mocking_and_Test_Driven_Development_Lab.Contracs
{
    public interface IProduct
    {
        string Label { get; }
        decimal Price { get; }
        int Quantity { get; }
    }
}
