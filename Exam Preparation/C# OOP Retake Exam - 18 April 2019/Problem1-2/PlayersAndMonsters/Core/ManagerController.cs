namespace PlayersAndMonsters.Core
{
    using System;
    using System.Linq;
    using System.Text;
    using Contracts;
    using PlayersAndMonsters.Core.Factories;
    using PlayersAndMonsters.Core.Factories.Contracts;
    using PlayersAndMonsters.Models.BattleFields;
    using PlayersAndMonsters.Models.BattleFields.Contracts;
    using PlayersAndMonsters.Models.Players;
    using PlayersAndMonsters.Models.Players.Contracts;
    using PlayersAndMonsters.Repositories;
    using PlayersAndMonsters.Repositories.Contracts;

    public class ManagerController : IManagerController
    {
        private IPlayerRepository playerRepo;
        private ICardRepository cardRepo;
        private IBattleField field;
        private IPlayerFactory playerFactory;
        private ICardFactory cardFactory;
        public ManagerController()
        {
            this.playerRepo = new PlayerRepository();
            this.cardRepo = new CardRepository();
            this.field = new BattleField();
            this.cardFactory = new CardFactory();
            this.playerFactory = new PlayerFactory();
        }

        public string AddPlayer(string type, string username)
        {
            this.playerFactory = new PlayerFactory();
            var player = playerFactory.CreatePlayer(type, username);
            playerRepo.Add(player)  ;
            return $"Successfully added player of type {type} with username: {username}";
        }

        public string AddCard(string type, string name)
        {
            CardFactory cardFactory = new CardFactory();
            cardRepo.Add(cardFactory.CreateCard(type, name));

            return $"Successfully added card of type {type}Card with name: {name}";
        }

        public string AddPlayerCard(string username, string cardName)
        {
            var player = playerRepo.Find(username);
            var card = cardRepo.Find(cardName);

            player.CardRepository.Add(card);

            return $"Successfully added card: {cardName} to user: {username}";
        }

        public string Fight(string attackUser, string enemyUser)
        {
            var attacker = playerRepo.Find(attackUser);
            var enemy = playerRepo.Find(enemyUser);

            field.Fight(attacker, enemy);

            return $"Attack user health {attacker.Health} - Enemy user health {enemy.Health}";
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();
            foreach (var player in playerRepo.Players)
            {
                sb.AppendLine(player.ToString());
            }
            return sb.ToString().Trim();
        }
    }
}
