using System;
using System.Collections.Generic;

using EasterRaces.Models.Drivers.Contracts;
using EasterRaces.Models.Races.Contracts;
using EasterRaces.Utilities.Messages;

namespace EasterRaces.Models.Races.Entities
{
    public class Race : IRace
    {
        private const int Name_Min_Length = 5;

        private const int Laps_Min = 1;

        private string name;

        private int laps;

        private readonly ICollection<IDriver> drivers;

        public Race(string name, int laps)
        {
            Name = name;
            Laps = laps;
            drivers = new HashSet<IDriver>();
        }
        public string Name
        { 
            get => name;
            private set 
            {
                if (string.IsNullOrEmpty(value) || value.Length < Name_Min_Length)
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.InvalidName, value, Name_Min_Length));
                }

                name = value;
            }
        
        }

        public int Laps
        {
            get => laps;
            private set 
            {
                if (value < Laps_Min)
                {
                    throw new ArgumentException(String.Format(ExceptionMessages.InvalidNumberOfLaps, Laps_Min));
                }
            
                laps = value;
            }
        }

        public IReadOnlyCollection<IDriver> Drivers => (IReadOnlyCollection<IDriver>)drivers;

        public void AddDriver(IDriver driver)
        {
            if (driver == null)
            {
                throw new ArgumentNullException(ExceptionMessages.DriverInvalid);
            }

            if (driver.Car == null)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.DriverNotParticipate, driver.Name));
            }

            if (drivers.Contains(driver))
            {
                throw new ArgumentNullException(string.Format(ExceptionMessages.DriverAlreadyAdded, driver.Name, this.Name));
            }

            drivers.Add(driver);
        }
    }
}
