using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;

using AquaShop.Utilities.Messages;
using AquaShop.Models.Fish.Contracts;
using AquaShop.Models.Aquariums.Contracts;
using AquaShop.Models.Decorations.Contracts;


namespace AquaShop.Models.Aquariums
{
    public abstract class Aquarium : IAquarium
    {
        private string name;

        private int capacity;

        private ICollection<IDecoration> decorations;

        private ICollection<IFish> fish;

        protected Aquarium(string name, int capacity)
        {
            this.Name = name;
            this.Capacity = capacity;
            this.decorations = new List<IDecoration>();
            this.fish = new List<IFish>();
        }

        public string Name 
        { 
            get => this.name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.InvalidAquariumName);
                }
                
                this.name = value;
            }
        }

        public int Capacity 
        { 
            get => this.capacity; 
            private set => this.capacity = value; 
        }

        public int Comfort => this.decorations.Any() ? this.decorations.Sum(x => x.Comfort) : 0;

        public ICollection<IDecoration> Decorations => this.decorations;

        public ICollection<IFish> Fish => this.fish;

        public void AddDecoration(IDecoration decoration)
            => this.decorations.Add(decoration);
      

        public void AddFish(IFish fish)
        {
            if (this.fish.Count == this.capacity)
            {
                throw new InvalidOperationException(ExceptionMessages.NotEnoughCapacity);
            }

            this.fish.Add(fish);
        }


        public void Feed()
        {
            foreach (var currentFish in this.fish)
            {
                currentFish.Eat();
            }
        }


        public string GetInfo()
        {
            StringBuilder output = new StringBuilder();

            string result = this.fish.Any() 
                ? string.Join(", ", this.fish.Select(x => x.Name)) 
                : "none";

            output.AppendLine($"{this.Name} ({this.GetType().Name}):")
                .AppendLine($"Fish: {result}")
                .AppendLine($"Decorations: {this.decorations.Count}")
                .Append($"Comfort: {this.Comfort}");

            return output.ToString();
        }


        public bool RemoveFish(IFish fish) 
            => this.fish.Remove(fish);
       
    }
}
