using System;
using System.Collections.Generic;
using System.Text;

namespace MortalEngines.Entities.Contracts
{
    public class Fighter : BaseMachine , IFighter
    {
        public Fighter(string name, double attackPoints, double defensePoints) 
            : base(name, attackPoints + 50, defensePoints -25, 200)
        {
            this.AggressiveMode = true;
        }

        public bool AggressiveMode { get; private set; }

        public void ToggleAggressiveMode()
        {
            if (AggressiveMode == false)
            {
                AggressiveMode = true;
                AttackPoints += 50;
                DefensePoints -= 25;
            }
            else
            {
                AggressiveMode = false;
                AttackPoints -= 50;
                DefensePoints += 25;
            }
        }
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(base.ToString());
            if (AggressiveMode == true)
            {
                sb.AppendLine(" *Aggressive: ON");
            }
            else
            {
                sb.AppendLine(" *Aggressive: OFF");
            }

            return sb.ToString().Trim();
            
        }
    }
}
