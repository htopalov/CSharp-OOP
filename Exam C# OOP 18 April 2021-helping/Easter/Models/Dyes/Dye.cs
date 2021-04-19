using Easter.Models.Dyes.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Easter.Models.Dyes
{
    public class Dye : IDye
    {
        public Dye(int power)
        {
            this.Power = power;
        }
        public int Power { get; private set; }

        public bool IsFinished()
        {
            return Power == 0;
        }

        public void Use()
        {
            if (Power - 10 < 0)
            {
                Power = 0;
            }
            else
            {
                Power -= 10;
            }
        }
    }
}
