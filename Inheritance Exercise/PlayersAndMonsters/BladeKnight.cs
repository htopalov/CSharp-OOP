using System;
using System.Collections.Generic;
using System.Text;

namespace PlayersAndMonsters
{
    public class BladeKnight : DarkKnight
    {
        public BladeKnight(string userName, int level)
            :base(userName,level)
        {

        }
        public string Username { get; set; }
        public int Level { get; set; }
    }
}
