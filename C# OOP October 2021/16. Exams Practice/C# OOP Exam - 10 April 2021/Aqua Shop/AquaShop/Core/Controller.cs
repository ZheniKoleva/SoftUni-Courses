using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;

using AquaShop.Core.Contracts;
using AquaShop.Models.Aquariums;
using AquaShop.Models.Aquariums.Contracts;
using AquaShop.Models.Decorations;
using AquaShop.Models.Decorations.Contracts;
using AquaShop.Models.Fish;
using AquaShop.Models.Fish.Contracts;
using AquaShop.Repositories;
using AquaShop.Utilities.Messages;


namespace AquaShop.Core
{
    public class Controller : IController
    {
        private DecorationRepository decorations;

        private ICollection<IAquarium> aquariums;


        public Controller()
        {
            decorations = new DecorationRepository();
            aquariums = new HashSet<IAquarium>();
        }

        public string AddAquarium(string aquariumType, string aquariumName)
        {
            IAquarium aquarium = CreateAquarium(aquariumType, aquariumName);

            aquariums.Add(aquarium);

            return string.Format(OutputMessages.SuccessfullyAdded, aquarium.GetType().Name);
        }
       

        public string AddDecoration(string decorationType)
        {
            IDecoration decoration = CreateDecoration(decorationType);

            decorations.Add(decoration);

            return string.Format(OutputMessages.SuccessfullyAdded, decoration.GetType().Name);
        }
               

        public string AddFish(string aquariumName, string fishType, string fishName, string fishSpecies, decimal price)
        {
            IAquarium aquarium = GetAquarium(aquariumName);

            IFish fish = CreateFish(fishType, fishName, fishSpecies, price);

            if ((aquarium.GetType().Name == nameof(SaltwaterAquarium) && fish.GetType().Name == nameof(FreshwaterFish))
                || (aquarium.GetType().Name == nameof(FreshwaterAquarium) && fish.GetType().Name == nameof(SaltwaterFish)))
            {
                return OutputMessages.UnsuitableWater;
            }

            aquarium.AddFish(fish);

            return string.Format(OutputMessages.EntityAddedToAquarium, fish.GetType().Name, aquarium.Name);
        }
   

        public string CalculateValue(string aquariumName)
        {
            IAquarium aquarium = GetAquarium(aquariumName);

            decimal aquariumValue = aquarium.Decorations.Sum(x => x.Price) + aquarium.Fish.Sum(x => x.Price);

            return string.Format(OutputMessages.AquariumValue, aquarium.Name, aquariumValue);
        }

        public string FeedFish(string aquariumName)
        {
            IAquarium aquarium = GetAquarium(aquariumName);

            aquarium.Feed();

            return string.Format(OutputMessages.FishFed, aquarium.Fish.Count);
        }

        public string InsertDecoration(string aquariumName, string decorationType)
        {
            IAquarium aquarium = GetAquarium(aquariumName);

            IDecoration decoration = decorations.FindByType(decorationType);

            if (decoration == null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.InexistentDecoration, decorationType));
            }

            aquarium.AddDecoration(decoration);
            decorations.Remove(decoration);

            return string.Format(OutputMessages.EntityAddedToAquarium, decoration.GetType().Name, aquarium.Name);
        }

        public string Report()
        {
            StringBuilder report = new StringBuilder();

            foreach (var aquarium in aquariums)
            {
                report.AppendLine(aquarium.GetInfo());
            }

            return report.ToString().TrimEnd();
        }


        private IAquarium GetAquarium(string aquariumName)
            => aquariums.FirstOrDefault(x => x.Name == aquariumName);


        private IAquarium CreateAquarium(string aquariumType, string aquariumName)
        {
            IAquarium aquarium;

            if (aquariumType == nameof(FreshwaterAquarium))
            {
                aquarium = new FreshwaterAquarium(aquariumName);
            }
            else if (aquariumType == nameof(SaltwaterAquarium))
            {
                aquarium = new SaltwaterAquarium(aquariumName);
            }
            else
            {
                throw new InvalidOperationException(ExceptionMessages.InvalidAquariumType);
            }

            return aquarium;
        }


        private IDecoration CreateDecoration(string decorationType)
        {
            IDecoration decoration;

            if (decorationType == nameof(Ornament))
            {
                decoration = new Ornament();
            }
            else if (decorationType == nameof(Plant))
            {
                decoration = new Plant();
            }
            else
            {
                throw new InvalidOperationException(ExceptionMessages.InvalidDecorationType);
            }

            return decoration;
        }


        private IFish CreateFish(string fishType, string fishName, string fishSpecies, decimal price)
        {
            IFish fish;

            if (fishType == nameof(FreshwaterFish))
            {
                fish = new FreshwaterFish(fishName, fishSpecies, price);
            }
            else if (fishType == nameof(SaltwaterFish))
            {
                fish = new SaltwaterFish(fishName, fishSpecies, price);
            }
            else
            {
                throw new InvalidOperationException(ExceptionMessages.InvalidFishType);
            }

            return fish;
        }
    }
}
