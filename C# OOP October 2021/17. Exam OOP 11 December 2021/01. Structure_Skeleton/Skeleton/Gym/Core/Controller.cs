using System;
using System.Text;
using System.Collections.Generic;

using Gym.Core.Contracts;
using Gym.Repositories;
using Gym.Models.Athletes;
using Gym.Models.Athletes.Contracts;
using Gym.Models.Equipment;
using Gym.Models.Equipment.Contracts;
using Gym.Models.Gyms;
using Gym.Models.Gyms.Contracts;
using Gym.Utilities.Messages;

namespace Gym.Core
{
    public class Controller : IController
    {
        private readonly EquipmentRepository equipment;

        private readonly IDictionary<string, IGym> gyms;

        public Controller()
        {
            equipment  = new EquipmentRepository();
            gyms = new Dictionary<string, IGym>();
        }


        public string AddAthlete(string gymName, string athleteType, string athleteName, string motivation, int numberOfMedals)
        {
            IGym gym = GetGym(gymName);

            IAthlete athlete = CreateAthlete(athleteType, athleteName, motivation, numberOfMedals);

            if ((gym.GetType().Name == nameof(BoxingGym) && athlete.GetType().Name == nameof(Weightlifter))
                || (gym.GetType().Name == nameof(WeightliftingGym) && athlete.GetType().Name == nameof(Boxer)))
            {
                return OutputMessages.InappropriateGym;
            }

            gym.AddAthlete(athlete);

            return string.Format(OutputMessages.EntityAddedToGym, athlete.GetType().Name, gym.Name);
        }

   
        public string AddEquipment(string equipmentType)
        {
            IEquipment equipment = CreateEquipment(equipmentType);

            this.equipment.Add(equipment);

            return string.Format(OutputMessages.SuccessfullyAdded, equipment.GetType().Name);
        }       


        public string AddGym(string gymType, string gymName)
        {
            IGym gymToAdd = CreateGym(gymType, gymName);

            gyms.Add(gymToAdd.Name, gymToAdd);

            return string.Format(OutputMessages.SuccessfullyAdded, gymToAdd.GetType().Name);
        }
        

        public string EquipmentWeight(string gymName)
        {
            IGym gym = GetGym(gymName);

            double weight = gym.EquipmentWeight;

            return string.Format(OutputMessages.EquipmentTotalWeight, gym.Name, weight);
        }

        public string InsertEquipment(string gymName, string equipmentType)
        {
            IGym gym = GetGym(gymName);

            IEquipment equipmentToAdd = this.equipment.FindByType(equipmentType);

            if (equipmentToAdd == null)
            {
                throw new InvalidOperationException(
                    string.Format(ExceptionMessages.InexistentEquipment, equipmentType));
            }

            gym.AddEquipment(equipmentToAdd);

            this.equipment.Remove(equipmentToAdd);

            return string.Format(OutputMessages.EntityAddedToGym, equipmentToAdd.GetType().Name, gym.Name);

        }

        public string Report()
        {
            StringBuilder report = new StringBuilder();

            foreach (var gym in gyms.Values)
            {
                report.AppendLine(gym.GymInfo());
            }

            return report.ToString().TrimEnd();
        }

        public string TrainAthletes(string gymName)
        {
            IGym gym = GetGym(gymName);

            gym.Exercise();

            return string.Format(OutputMessages.AthleteExercise, gym.Athletes.Count);
        }

        private IGym GetGym(string gymname)
            => gyms.ContainsKey(gymname) ? gyms[gymname] : null;

        private IGym CreateGym(string gymType, string gymName)
        {
            IGym gym = gymType switch
            {
                nameof(BoxingGym) => new BoxingGym(gymName),
                nameof(WeightliftingGym) => new WeightliftingGym(gymName),
                _ => throw new InvalidOperationException(ExceptionMessages.InvalidGymType),
            };

            return gym;
        }


        private IEquipment CreateEquipment(string equipmentType)
        {
            IEquipment equipment = equipmentType switch
            {
                nameof(BoxingGloves) => new BoxingGloves(),
                nameof(Kettlebell) => new Kettlebell(),
                _ => throw new InvalidOperationException(ExceptionMessages.InvalidEquipmentType),
            };

            return equipment;
        }


        private IAthlete CreateAthlete(string athleteType, string athleteName, string motivation, int numberOfMedals)
        {
            IAthlete athlete = athleteType switch
            {
                nameof(Boxer) => new Boxer(athleteName, motivation, numberOfMedals),
                nameof(Weightlifter) => new Weightlifter(athleteName, motivation, numberOfMedals),
                _ => throw new InvalidOperationException(ExceptionMessages.InvalidAthleteType),
            };

            return athlete;
        }
    }

}
