using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;

using WarCroft.Constants;
using WarCroft.Entities.Items;
using WarCroft.Entities.Characters;
using WarCroft.Entities.Characters.Contracts;

namespace WarCroft.Core
{
	public class WarController
	{
		private readonly IList<Character> party;

		private readonly IList<Item> pool;

		public WarController()
		{
			party = new List<Character>();
			pool = new List<Item>();
		}

		public string JoinParty(string[] args)
        {
            string characterType = args[0];
            string characterName = args[1];

            Character character = CreateCharacter(characterType, characterName);

			party.Add(character);

			return string.Format(SuccessMessages.JoinParty, character.Name);
        }       

        public string AddItemToPool(string[] args)
		{
			string itemType = args[0];

			Item item = CreateItem(itemType);

			pool.Add(item);

			return string.Format(SuccessMessages.AddItemToPool, item.GetType().Name);
		}       

        public string PickUpItem(string[] args)
        {
            string characterName = args[0];

            Character character = GetCharacter(characterName);

            Item itemToAdd = pool.LastOrDefault();

            if (itemToAdd == null)
            {
                throw new InvalidOperationException(ExceptionMessages.ItemPoolEmpty);
            }

			pool.Remove(itemToAdd);
            character.Bag.AddItem(itemToAdd);

            return string.Format(SuccessMessages.PickUpItem, character.Name, itemToAdd.GetType().Name);
        }

       
        public string UseItem(string[] args)
		{
			string characterName = args[0];
			string itemType = args[1];

			Character character = GetCharacter(characterName);

			Item item = character.Bag.GetItem(itemType);

			character.UseItem(item);

			return string.Format(SuccessMessages.UsedItem,character.Name, item.GetType().Name);
		}

		public string GetStats()
		{
			StringBuilder report = new StringBuilder();

			IEnumerable<Character> ordered = party
				.OrderByDescending(x => x.IsAlive)
				.ThenByDescending(x => x.Health);

			foreach (var character in ordered)
            {
				report.AppendLine(string.Format(SuccessMessages.CharacterStats,
					character.Name, character.Health, character.BaseHealth,
					character.Armor, character.BaseArmor, character.IsAlive ? "Alive" : "Dead"));
            }

			return report.ToString().TrimEnd();
		}

		public string Attack(string[] args)
		{
			string attackerName = args[0];
			string receiverName = args[1];

			Character attacker = GetCharacter(attackerName);
			Character receiver = GetCharacter(receiverName);

			Warrior warrior = attacker as Warrior;

            if (warrior == null)
            {
				throw new ArgumentException(string.Format(ExceptionMessages.AttackFail, attacker.Name));
            }
			
			warrior.Attack(receiver);

			string result = string.Format(SuccessMessages.AttackCharacter,
				attacker.Name, receiver.Name, attacker.AbilityPoints,
				receiver.Name, receiver.Health, receiver.BaseHealth, receiver.Armor, receiver.BaseArmor);

            if (!receiver.IsAlive)
            {
				result += $"{Environment.NewLine}{string.Format(SuccessMessages.AttackKillsCharacter, receiver.Name)}";
            }

			return result;
		}

		public string Heal(string[] args)
		{
			string healerName = args[0];
			string healingReceiverName = args[1];

			Character healer = GetCharacter(healerName);
			Character receiver = GetCharacter(healingReceiverName);

			Priest priest = healer as Priest;

			if (priest == null)
			{
				throw new ArgumentException(string.Format(ExceptionMessages.HealerCannotHeal, healer.Name));
			}

			priest.Heal(receiver);
			
			return string.Format(SuccessMessages.HealCharacter,
				healer.Name, receiver.Name, healer.AbilityPoints, receiver.Name, receiver.Health);
		}

		private static Character CreateCharacter(string characterType, string characterName)
		{
            Character character = characterType switch
            {
                nameof(Warrior) => new Warrior(characterName),
                nameof(Priest) => new Priest(characterName),
                _ => throw new ArgumentException(string.Format(ExceptionMessages.InvalidCharacterType, characterType)),
            };
            return character;
		}

		private Item CreateItem(string itemType)
		{
            Item item = itemType switch
            {
                nameof(HealthPotion) => new HealthPotion(),
                nameof(FirePotion) => new FirePotion(),
                _ => throw new ArgumentException(string.Format(ExceptionMessages.InvalidItem, itemType)),
            };

            return item;
		}

		private Character GetCharacter(string characterName)
		{
			Character characterToAddItem = party.FirstOrDefault(x => x.Name == characterName);

			if (characterToAddItem == null)
			{
				throw new ArgumentException(string.Format(ExceptionMessages.CharacterNotInParty, characterName));
			}

			return characterToAddItem;
		}
	}
}
