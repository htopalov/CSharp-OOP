using System;
using System.Collections.Generic;
using System.Text;

namespace Template_Pattern
{
    class WholegrainBread : Bread
    {
        public override void Bake()
        {
            Console.WriteLine("Baking wholegraing bread");
        }

        public override void MixIngredients()
        {
            Console.WriteLine("Collecting ingredients for wholegraing bread");
        }
    }
}
