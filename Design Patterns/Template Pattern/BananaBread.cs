using System;
using System.Collections.Generic;
using System.Text;

namespace Template_Pattern
{
    public class BananaBread : Bread
    {
        public override void Bake()
        {
            Console.WriteLine("Baking banana bread");
        }

        public override void MixIngredients()
        {
            Console.WriteLine("Collecting bananas for bread");
        }
    }
}
