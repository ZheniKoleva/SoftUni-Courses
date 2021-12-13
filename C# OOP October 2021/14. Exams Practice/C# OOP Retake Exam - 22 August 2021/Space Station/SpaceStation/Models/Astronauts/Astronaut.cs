using System;
using System.Text;

using SpaceStation.Models.Bags;
using SpaceStation.Utilities.Messages;
using SpaceStation.Models.Bags.Contracts;
using SpaceStation.Models.Astronauts.Contracts;


namespace SpaceStation.Models.Astronauts
{
    public abstract class Astronaut : IAstronaut
    {
        private const int Default_Oxygen_Decreasment = 10;

        private string name;

        private double oxygen;

        private readonly IBag bag;

        protected Astronaut(string name, double oxygen)
        {
            Name = name;
            Oxygen = oxygen;
            bag = new Backpack();
            
        }

        public string Name 
        { 
            get => name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException(nameof(Name), ExceptionMessages.InvalidAstronautName);
                }
            
                name = value;            
            } 
        }

        public double Oxygen 
        { 
            get => oxygen;
            protected set
            {
                if (value < 0)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidOxygen);
                }

                oxygen = value;
            }
        }

        public bool CanBreath
            => oxygen > 0;

        public IBag Bag => bag;

        public virtual void Breath()
        {
            if (Oxygen - Default_Oxygen_Decreasment < 0)
            {
                Oxygen = 0;
            }
            else
            {
                Oxygen -= Default_Oxygen_Decreasment;
            }
        }

        public override string ToString()
        {
            StringBuilder output = new StringBuilder();
            output.AppendLine($"Name: {Name}")
                .AppendLine($"Oxygen: {Oxygen}")
                .Append($"Bag items: {Bag}");

            return output.ToString();
        }
    }
}
