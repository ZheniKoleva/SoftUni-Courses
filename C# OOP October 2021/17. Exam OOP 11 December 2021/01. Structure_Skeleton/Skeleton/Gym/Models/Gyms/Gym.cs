using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;

using Gym.Models.Gyms.Contracts;
using Gym.Models.Athletes.Contracts;
using Gym.Models.Equipment.Contracts;
using Gym.Utilities.Messages;

namespace Gym.Models.Gyms
{
    public abstract class Gym : IGym
    {
        private string name;

        private int capacity;
     
        private readonly ICollection<IEquipment> equipment;
  
        private readonly ICollection<IAthlete> athletes;

        protected Gym(string name, int capacity)
        {
            Name = name;
            Capacity = capacity;
            equipment = new List<IEquipment>();
            athletes = new List<IAthlete>();
        }

        public string Name
        {
            get => name;
            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException(ExceptionMessages.InvalidGymName);
                }

                name = value;
            }
        }

        public int Capacity 
        { 
            get => capacity; 
            private set => capacity = value; 
        }        

        public double EquipmentWeight => equipment.Sum(x => x.Weight);

        public ICollection<IEquipment> Equipment => equipment;

        public ICollection<IAthlete> Athletes => athletes;

        public void AddAthlete(IAthlete athlete)
        {
            if (athletes.Count == Capacity)
            {
                throw new InvalidOperationException(ExceptionMessages.NotEnoughSize);
            }

            athletes.Add(athlete);
        }

        public bool RemoveAthlete(IAthlete athlete)
           => athletes.Remove(athlete);

        public void AddEquipment(IEquipment equipment)
            => this.equipment.Add(equipment);
        

        public void Exercise()
        {
            foreach (var athlete in athletes)
            {
                athlete.Exercise();
            }
        }

        public string GymInfo()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"{Name} is a {GetType().Name}:")
                .AppendLine($"Athletes: {(athletes.Any() ? string.Join(", ", athletes.Select(x => x.FullName)) : "No athletes")}")
                .AppendLine($"Equipment total count: {equipment.Count}")
                .Append($"Equipment total weight: {EquipmentWeight:f2} grams");

            return sb.ToString();
        }
       
    }
}
