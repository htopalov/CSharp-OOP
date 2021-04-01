using System;
using System.Collections.Generic;
using System.Linq;
using WarCroft.Constants;
using WarCroft.Core.IO;
using WarCroft.Entities.Characters;
using WarCroft.Entities.Characters.Contracts;
using WarCroft.Entities.Items;

namespace WarCroft.Core
{
    public class WarController
    {
        private List<Character> party;
        private List<Item> pool;

        public WarController()
        {
            this.party = new List<Character>();
            this.pool = new List<Item>();
        }

        public string JoinParty(string[] args)
        {
            string characterType = args[0];
            string name = args[1];
            if (characterType != typeof(Warrior).Name && characterType != typeof(Priest).Name)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.InvalidCharacterType, characterType));
            }
            Character character = null;
            switch (characterType)
            {
                case "Warrior":
                    character = new Warrior(name);
                    break;
                case "Priest":
                    character = new Priest(name);
                    break;
            }
            party.Add(character);

            return string.Format(SuccessMessages.JoinParty, name);
        }

        public string AddItemToPool(string[] args)
        {
            string itemName = args[0];
            if (itemName != "HealthPotion" && itemName != "FirePotion")
            {
                throw new ArgumentException(string.Format(ExceptionMessages.InvalidItem, itemName));
            }
            Item item = null;
            switch (itemName)
            {
                case "HealthPotion":
                    item = new HealthPotion();
                    break;
                case "FirePotion":
                    item = new FirePotion();
                    break;
            }
            pool.Add(item);

            return string.Format(SuccessMessages.AddItemToPool, itemName);
        }

        public string PickUpItem(string[] args)
        {
            string characterName = args[0];
            if (!party.Any(x => x.Name == characterName))
            {
                throw new ArgumentException(string.Format(ExceptionMessages.CharacterNotInParty, characterName));
            }
            if (pool.Count == 0)
            {
                throw new InvalidOperationException(ExceptionMessages.ItemPoolEmpty);
            }
            var character = party.FirstOrDefault(x => x.Name == characterName);
            var item = pool[pool.Count-1];
      
            character.Bag.AddItem(item);
            pool.RemoveAt(pool.Count-1);

            return string.Format(SuccessMessages.PickUpItem, characterName, item.GetType().Name);
        }

        public string UseItem(string[] args)
        {
            string characterName = args[0];
            string itemName = args[1];
            if (!party.Any(x => x.Name == characterName))
            {
                throw new ArgumentException(string.Format(ExceptionMessages.CharacterNotInParty, characterName));
            }

            var character = party.FirstOrDefault(x => x.Name == characterName);
            var item = character.Bag.GetItem(itemName);
            character.UseItem(item);

            return string.Format(SuccessMessages.UsedItem, characterName, itemName);
        }

        public string GetStats()
        {
            StringBuilderWriter stringBuilderWriter = new StringBuilderWriter();
            foreach (var character in party.OrderByDescending(x => x.IsAlive).ThenByDescending(x => x.Health))
            {
                stringBuilderWriter.WriteLine(character.ToString());
            }

            return stringBuilderWriter.sb.ToString().Trim();
        }

        public string Attack(string[] args)
        {
            string attackerName = args[0];
            string receiverName = args[1];
            if (!party.Any(x => x.Name == attackerName))
            {
                throw new ArgumentException(string.Format(ExceptionMessages.CharacterNotInParty, attackerName));
            }
            if (!party.Any(x => x.Name == receiverName))
            {
                throw new ArgumentException(string.Format(ExceptionMessages.CharacterNotInParty, receiverName));
            }

            var attacker = party.FirstOrDefault(x => x.Name == attackerName);
            var receiver = party.FirstOrDefault(x => x.Name == receiverName);
            if (attacker.GetType().Name != "Warrior")
            {
                throw new ArgumentException(string.Format(ExceptionMessages.AttackFail, attackerName));

            }
            Warrior warrior = (Warrior)attacker;
            warrior.Attack(receiver);

            StringBuilderWriter stringBuilderWriter = new StringBuilderWriter();
            stringBuilderWriter.WriteLine($"{attackerName} attacks {receiverName} for {warrior.AbilityPoints} hit points! {receiverName} has {receiver.Health}/{receiver.BaseHealth} HP and {receiver.Armor}/{receiver.BaseArmor} AP left!");
            if (receiver.Health <= 0)
            {
                stringBuilderWriter.WriteLine($"{receiver.Name} is dead!");
            }
            return stringBuilderWriter.sb.ToString().Trim();
        }

        public string Heal(string[] args)
        {
            string healerName = args[0];
            string healingReceiverName = args[1];
            if (!party.Any(x => x.Name == healerName))
            {
                throw new ArgumentException(string.Format(ExceptionMessages.CharacterNotInParty, healerName));
            }
            if (!party.Any(x => x.Name == healingReceiverName))
            {
                throw new ArgumentException(string.Format(ExceptionMessages.CharacterNotInParty, healingReceiverName));
            }

            var healer = party.FirstOrDefault(x => x.Name == healerName);
            var receiver = party.FirstOrDefault(x => x.Name == healingReceiverName);

            if (healer.GetType().Name != "Priest")
            {
                throw new ArgumentException(string.Format(ExceptionMessages.HealerCannotHeal, healerName));
            }

            Priest priest = (Priest)healer;

            priest.Heal(receiver);
            StringBuilderWriter stringBuilderWriter = new StringBuilderWriter();
            stringBuilderWriter.WriteLine($"{healer.Name} heals {priest.Name} for {priest.AbilityPoints}! {receiver.Name} has {receiver.Health} health now!");

            return stringBuilderWriter.sb.ToString().Trim();
        }
    }
}
