using System;
using System.Collections.Generic;
using System.Text;

namespace Template_Pattern
{
    public class WhiteBread : Bread
    {
        public override void Bake()
        {
            Console.WriteLine("Baking white bread");
        }

        public override void MixIngredients()
        {
            Console.WriteLine("Collecting ingredients for white bread");
        }
    }
}
