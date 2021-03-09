using System;
using System.Collections.Generic;
using System.Text;

namespace Raiding
{
    public class Warrior : BaseHero
    {
        private const int power = 100;
        public Warrior(string name)
            :base(name,power)
        {

        }

        public override string CastAbility()
        {
           return $"{this.GetType().Name} - {Name} hit for {Power} damage";
        }
    }
}
