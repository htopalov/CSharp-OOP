using CounterStrike.Models.Maps.Contracts;
using CounterStrike.Models.Players.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CounterStrike.Models.Maps
{
    public class Map : IMap
    {
        private List<IPlayer> terrorists;
        private List<IPlayer> counterTerrorists;

        public Map()
        {
            terrorists = new List<IPlayer>();
            counterTerrorists = new List<IPlayer>();
        }
        public string Start(ICollection<IPlayer> players)
        {
            terrorists = players.Where(x => x.GetType().Name == "Terrorist").ToList();
            counterTerrorists = players.Where(x => x.GetType().Name == "CounterTerrorist").ToList();

            while (IsTeamAlive(terrorists) && IsTeamAlive(counterTerrorists))
            {
                Attacking(terrorists, counterTerrorists);
                Attacking(counterTerrorists, terrorists);
                if (!IsTeamAlive(counterTerrorists))
                {
                    return "Terrorists win";
                }
                if (!IsTeamAlive(terrorists))
                {
                    return "Counter Terrorists win";
                }
            }
          
            return " Method Not Working!!!!";

        }

        private void Attacking(List<IPlayer> attackerTeam, List<IPlayer> receiverTeam)
        {
            foreach (var attacker in attackerTeam)
            {
                //comment next check if needed, mistake in the problem....
                //checked: bug confirmed
                //if check should be commented.....
                //if (!attacker.IsAlive)
                //{
                //    continue;
                //}
                foreach (var receiver in receiverTeam)
                {
                    receiver.TakeDamage(attacker.Gun.Fire());
                }
            }
        }
        private bool IsTeamAlive(List<IPlayer> players)
        {
            return players.Any(x => x.IsAlive);
        }
    }
}
