using System;

using EasterRaces.Models.Cars.Contracts;
using EasterRaces.Models.Drivers.Contracts;
using EasterRaces.Utilities.Messages;

namespace EasterRaces.Models.Drivers.Entities
{
    public class Driver : IDriver
    {
        private const int Name_Min_Length = 5;

        private string name;

        private ICar car;

        private int numberOfWins;

        private bool canParticipate = false;

        public Driver(string name)
        {
            this.Name = name;
        }

        public string Name
        {
            get => this.name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value) || value.Length < Name_Min_Length)
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.InvalidName, value, Name_Min_Length));
                }

                name = value;
            }

        }

        public ICar Car => this.car;

        public int NumberOfWins => this.numberOfWins;

        public bool CanParticipate => this.canParticipate;

        public void AddCar(ICar car)
        {
            if (car == null)
            {
                throw new ArgumentNullException(string.Format(ExceptionMessages.CarInvalid));
            }

            this.car = car;
            this.canParticipate = true;
        }

        public void WinRace()
            => this.numberOfWins++;       
    }
}
