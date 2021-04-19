using Easter.Models.Bunnies.Contracts;
using Easter.Models.Eggs.Contracts;
using Easter.Models.Workshops.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Easter.Models.Workshops
{
    public class Workshop : IWorkshop
    {
        public void Color(IEgg egg, IBunny bunny)
        {
            while (bunny.Energy > 0 && bunny.Dyes.Any(x => x.IsFinished() == false) && egg.IsDone() == false)
            {
                var dye = bunny.Dyes.First(x => x.IsFinished() == false);
                bunny.Work();
                dye.Use();
                egg.GetColored();
            }

        }
    }
}
