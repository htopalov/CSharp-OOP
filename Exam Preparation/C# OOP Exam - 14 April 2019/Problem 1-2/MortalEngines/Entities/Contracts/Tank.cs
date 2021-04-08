using System;
using System.Collections.Generic;
using System.Text;

namespace MortalEngines.Entities.Contracts
{
    public class Tank : BaseMachine, ITank
    {
        public Tank(string name, double attackPoints, double defensePoints) 
            : base(name, attackPoints - 40, defensePoints + 30, 100)
        {
            this.DefenseMode = true;
        }

        public bool DefenseMode { get; private set; }

        public void ToggleDefenseMode()
        {
            if (DefenseMode == false)
            {
                DefenseMode = true;
                AttackPoints -= 40;
                DefensePoints += 30;
            }
            else if (DefenseMode == true)
            {
                DefenseMode = false;
                AttackPoints += 40;
                DefensePoints -= 30;
            }
        }
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(base.ToString());
            if (DefenseMode == true)
            {
                sb.AppendLine(" *Defense: ON");
            }
            else
            {
                sb.AppendLine(" *Defense: OFF");
            }

            return sb.ToString().Trim();

        }
    }
}
