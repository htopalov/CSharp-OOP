using CounterStrike.Core.Contracts;
using CounterStrike.Models.Guns;
using CounterStrike.Models.Guns.Contracts;
using CounterStrike.Models.Maps;
using CounterStrike.Models.Maps.Contracts;
using CounterStrike.Models.Players;
using CounterStrike.Models.Players.Contracts;
using CounterStrike.Repositories;
using CounterStrike.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CounterStrike.Core
{
    public class Controller : IController
    {
        private GunRepository guns;
        private PlayerRepository players;
        private IMap map;

        public Controller()
        {
            this.guns = new GunRepository();
            this.players = new PlayerRepository();
            this.map = new Map();
        }
        public string AddGun(string type, string name, int bulletsCount)
        {
            IGun gun = null;
            switch(type)
            {
                case "Pistol":
                    gun = new Pistol(name, bulletsCount);
                    break;
                case "Rifle":
                    gun = new Rifle(name, bulletsCount);
                    break;
                default:
                    throw new ArgumentException(ExceptionMessages.InvalidGunType);
            }

            guns.Add(gun);

            return string.Format(OutputMessages.SuccessfullyAddedGun, name);
        }

        public string AddPlayer(string type, string username, int health, int armor, string gunName)
        {
            IPlayer player = null;
            var gun = guns.FindByName(gunName);
            if (gun == null)
            {
                throw new ArgumentException(ExceptionMessages.GunCannotBeFound);
            }
            switch(type)
            {
                case "Terrorist":
                    player = new Terrorist(username, health, armor, gun);
                    break;
                case "CounterTerrorist":
                    player = new CounterTerrorist(username, health, armor, gun);
                    break;
                default: throw new ArgumentException(ExceptionMessages.InvalidPlayerType);
            }

            players.Add(player);

            return string.Format(OutputMessages.SuccessfullyAddedPlayer, username);
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();
            var orderedListOfPlayers = players.Models
                                       .OrderBy(x => x.GetType().Name)
                                       .ThenByDescending(x => x.Health)
                                       .ThenBy(x => x.Username);
            foreach (var player in orderedListOfPlayers)
            {
                sb.AppendLine(player.ToString());
            }

            return sb.ToString().TrimEnd();
        }

        public string StartGame()
        {
            return map.Start(players.Models.ToList());
        }
    }
}
