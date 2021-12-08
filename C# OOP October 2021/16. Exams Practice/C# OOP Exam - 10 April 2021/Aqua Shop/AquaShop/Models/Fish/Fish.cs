using System;

using AquaShop.Models.Fish.Contracts;
using AquaShop.Utilities.Messages;

namespace AquaShop.Models.Fish
{
    public abstract class Fish : IFish
    {
        private string name;

        private string species;

        private decimal price;

        private int size;

        protected Fish(string name, string species, decimal price)
        {
            this.Name = name;
            this.Species = species;            
            this.Price = price;
        }

        public string Name 
        { 
            get => this.name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.InvalidFishName);
                }

                this.name = value;
            }
        }

        public string Species
        {
            get => this.species;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.InvalidFishSpecies);
                }

                this.species = value;
            }
        }

        public virtual int Size 
        { 
            get => this.size;
            protected set => this.size = value;
        }

        public decimal Price 
        { 
            get => this.price;
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidFishPrice);
                }

                this.price = value;
            }
        }

        public abstract void Eat();        
    }
}
