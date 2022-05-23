using System;

using WarCroft.Constants;
using WarCroft.Entities.Items;
using WarCroft.Entities.Inventory;

namespace WarCroft.Entities.Characters.Contracts
{
    public abstract class Character
    {
		private string name;

		private double baseHealth;

		private double health;

		private double baseArmor;

		private double armor;

		private double abilityPoints;

		private IBag bag;

        protected Character(string name, double health, double armor, double abilityPoints, Bag bag)           
        {
            Name = name;
            BaseHealth = health;
            Health = BaseHealth;
            BaseArmor = armor;
            Armor = BaseArmor;
            AbilityPoints = abilityPoints;
            Bag = bag;
        }
       
      
        public string Name 
        { 
            get => name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.CharacterNameInvalid);
                }

                name = value;
            } 
        }
                
        public double BaseHealth 
        { 
            get => baseHealth; 
            private set => baseHealth = value; 
        }

        public double Health 
        { 
            get => health;
            set
            {
                if (value < 0)
                {
                    health = 0;
                }
                else if (value > baseHealth)
                { 
                    health = baseHealth;
                }
                else
                {
                    health = value;
                }
            }            
        }

        public double BaseArmor 
        { 
            get => baseArmor; 
            private set => baseArmor = value; 
        }

        public double Armor 
        { 
            get => armor;
            set
            {
                if (value < 0)
                {
                    armor = 0;
                }
                else
                {
                    armor = value;
                }
            
            }
        }

        public double AbilityPoints 
        { 
            get => abilityPoints; 
            private set => abilityPoints = value; 
        }
       
        public IBag Bag 
        { 
            get => bag; 
            private set => bag = value; 
        }

        public bool IsAlive { get; set; } = true;

        public void TakeDamage(double hitPoints)
        {
            EnsureAlive();

            double pointsLeft = Armor < hitPoints ? hitPoints - Armor : 0;
            Armor -= hitPoints;

            if (pointsLeft > 0)
            {
                Health -= pointsLeft;

                if (Health == 0)
                {
                    IsAlive = false;
                }
            }          
        }

        public void UseItem(Item item)
        {
            EnsureAlive();

            item.AffectCharacter(this);
        }

        protected void EnsureAlive()
		{
			if (!this.IsAlive)
			{
				throw new InvalidOperationException(ExceptionMessages.AffectedCharacterDead);
			}
		}

        protected static void IsCharacterAlive(Character character)
        {
            character.EnsureAlive();           
        }
    }
}