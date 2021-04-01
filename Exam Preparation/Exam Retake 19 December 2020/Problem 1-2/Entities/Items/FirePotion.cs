﻿using System;
using System.Collections.Generic;
using System.Text;
using WarCroft.Entities.Characters.Contracts;

namespace WarCroft.Entities.Items
{
    public class FirePotion : Item
    {
        public FirePotion(int weight = 5)
            : base(weight)
        {
        }

        public override void AffectCharacter(Character character)
        {
            base.AffectCharacter(character);
            if (character.Health > 20)
            {
                character.Health -= 20;
            }
            else
            {
                character.Health = 0;
                character.IsAlive = false;
            }
        }
    }
}
