using System;

using WarCroft.Constants;
using WarCroft.Entities.Inventory;
using WarCroft.Entities.Characters.Contracts;

namespace WarCroft.Entities.Characters
{
    public class Warrior : Character, IAttacker
    {
        private const double Default_BaseHealth = 100;

        private const double Default_BaseArmor = 50;

        private const double Default_AbilityPoints = 40;

        //private  IBag Default_Bag = new Satchel();

        public Warrior(string name) 
            : base(name, Default_BaseHealth, Default_BaseArmor, Default_AbilityPoints, new Satchel())
        {
        }

        public void Attack(Character character)
        {
            this.EnsureAlive();

            IsCharacterAlive(character);

            if (character.Equals(this))
            {
                throw new InvalidOperationException(ExceptionMessages.CharacterAttacksSelf);
            }

            character.TakeDamage(this.AbilityPoints);
        }

    }
}
