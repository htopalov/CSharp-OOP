using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FootballTeamGenerator
{
    public class Team
    {
        private string name;
        private Dictionary<string,Player> playersNames;
        public Team(string name)
        {
            this.Name = name;
            this.playersNames = new Dictionary<string, Player>();
        }
        public string Name
        {
            get { return name; }
            private set
            {
                if (value == string.Empty)
                {
                    throw new ArgumentException("A name should not be empty.");
                }
                else
                {
                    this.name = value;
                }
            }
        }
        public double AverageSkillTeam
        {
            get 
            {
                if (playersNames.Count>0)
                {
                    return Math.Round(playersNames.Values.Average(x => x.Skill));
                }
                return 0;
            }
        }
        public void AddPlayer(Player player)
        {
            playersNames.Add(player.Name, player);
        }
        public void RemovePlayer(string playerName)
        {
            
            if (this.playersNames.ContainsKey(playerName))
            {
                playersNames.Remove(playerName);
            }
            else
            {
                throw new ArgumentException($"Player {playerName} is not in {this.Name} team.");
            }
        }
    }
}
