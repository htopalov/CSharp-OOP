using System;
using System.Collections.Generic;
using System.Text;

namespace PlayersAndMonsters
{
    public class Wizard : Hero
    {
        public Wizard(string userName, int level)
            :base(userName,level)
        {

        }
        public string Username { get; set; }
        public int Level { get; set; }
    }
}
