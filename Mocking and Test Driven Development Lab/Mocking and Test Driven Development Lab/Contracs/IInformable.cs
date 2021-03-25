using System;
using System.Collections.Generic;
using System.Text;

namespace Mocking_and_Test_Driven_Development_Lab.Contracs
{
    public interface IInformable
    {
        bool Contains(IProduct product);
        int Count { get; }
    }
}
