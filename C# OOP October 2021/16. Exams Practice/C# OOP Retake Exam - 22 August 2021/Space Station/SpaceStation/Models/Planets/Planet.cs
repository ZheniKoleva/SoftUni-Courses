using System;
using System.Collections.Generic;

using SpaceStation.Utilities.Messages;
using SpaceStation.Models.Planets.Contracts;

namespace SpaceStation.Models.Planets
{
    public class Planet : IPlanet
    {
        public string name;

        private readonly ICollection<string> items;

        public Planet(string name)
        {
            Name = name;
            items = new List<string>();
        }

        public string Name
        {
            get => name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException(nameof(Name), ExceptionMessages.InvalidPlanetName);
                }

                name = value;
            }
        }

        public ICollection<string> Items => items;
    }
}
