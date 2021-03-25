using System;
using System.Collections.Generic;
using System.Text;

namespace Mocking_and_Test_Driven_Development_Lab.Contracs
{
    public interface IFindable
    {
        IProduct Find(int index);
        IProduct FindByLabel(string label);
        IList<IProduct> FindAllByQuantity(int quantity);
    }
}
