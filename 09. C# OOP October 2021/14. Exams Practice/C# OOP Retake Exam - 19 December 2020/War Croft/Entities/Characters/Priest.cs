using System;

using WarCroft.Constants;
using WarCroft.Entities.Inventory;
using WarCroft.Entities.Characters.Contracts;

namespace WarCroft.Entities.Characters
{
    public class Priest : Character, IHealer
    {
        private const double Default_BaseHealth = 50;

        private const double Default_BaseArmor = 25;

        private const double Default_AbilityPoints = 40;

        //private IBag Default_Bag = new Backpack();

        public Priest(string name)
            : base(name, Default_BaseHealth, Default_BaseArmor, Default_AbilityPoints, new Backpack())
        {
        }

        public void Heal(Character character)
        {
            EnsureAlive();
            
            IsCharacterAlive(character);

            character.Health += AbilityPoints;
        }        
    }
}
