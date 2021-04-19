using System;
using System.Collections.Generic;
using System.Text;

namespace Easter.Models.Bunnies
{
    public class HappyBunny : Bunny
    {
        public HappyBunny(string name)
            : base(name, 100)
        {
        }

        public override void Work()
        {
            if (Energy - 10 < 0)
            {
                Energy = 0;
            }
            else
            {
                Energy -= 10;
            }
        }
    }
}
