using System;

using SpaceStation.Repositories;
using SpaceStation.Core.Contracts;
using SpaceStation.Models.Planets;
using SpaceStation.Models.Astronauts;
using SpaceStation.Models.Planets.Contracts;
using SpaceStation.Models.Astronauts.Contracts;
using SpaceStation.Utilities.Messages;
using System.Text;
using SpaceStation.Models.Mission;
using SpaceStation.Models.Mission.Contracts;
using System.Linq;
using System.Collections.Generic;

namespace SpaceStation.Core
{
    public class Controller : IController
    {
        private readonly AstronautRepository astronautRepo;

        private readonly PlanetRepository planetRepo;

        private int exploredPlanetsCount;

        public Controller()
        {
            astronautRepo = new AstronautRepository();
            planetRepo = new PlanetRepository();
        }


        public string AddAstronaut(string type, string astronautName)
        {
            IAstronaut astronaut = CreateAustronaut(type, astronautName);

            astronautRepo.Add(astronaut);

            return string.Format(OutputMessages.AstronautAdded, astronaut.GetType().Name, astronaut.Name);
        }


        public string AddPlanet(string planetName, params string[] items)
        {
            IPlanet planet = new Planet(planetName);

            foreach (var item in items)
            {
                planet.Items.Add(item);
            }

            planetRepo.Add(planet);

            return string.Format(OutputMessages.PlanetAdded, planet.Name);
        }    


        public string ExplorePlanet(string planetName)
        {
            int oxygenLevelNeeded = 60;

            IMission mission = new Mission();

            IPlanet planetToExplore = planetRepo.FindByName(planetName);

            ICollection<IAstronaut> astronautsOnMission = astronautRepo.Models
               .Where(x => x.Oxygen > oxygenLevelNeeded)
               .ToList();

            if (!astronautsOnMission.Any())
            {
                throw new InvalidOperationException(ExceptionMessages.InvalidAstronautCount);
            }

            mission.Explore(planetToExplore, astronautsOnMission);

            exploredPlanetsCount++;
            int deadAstronauts = astronautsOnMission.Count(x => x.Oxygen == 0);


            return string.Format(OutputMessages.PlanetExplored, planetToExplore.Name, deadAstronauts);
        }


        public string Report()
        {
            StringBuilder report = new StringBuilder();

            report.AppendLine($"{exploredPlanetsCount} planets were explored!")
                .AppendLine("Astronauts info:");

            foreach (var astronaut in astronautRepo.Models)
            {
                report.AppendLine(astronaut.ToString());
            }

            return report.ToString().TrimEnd();
        }

        public string RetireAstronaut(string astronautName)
        {
            IAstronaut astronautToRetire = astronautRepo.FindByName(astronautName);

            if (astronautToRetire == null)
            {
                throw new InvalidOperationException(
                    string.Format(ExceptionMessages.InvalidRetiredAstronaut, astronautName));
            }

            astronautRepo.Remove(astronautToRetire);

            return string.Format(OutputMessages.AstronautRetired, astronautToRetire.Name);
        }

        private IAstronaut CreateAustronaut(string type, string astronautName)
        {
            IAstronaut astronaut = type switch
            {
                nameof(Biologist) => new Biologist(astronautName),
                nameof(Geodesist) => new Geodesist(astronautName),
                nameof(Meteorologist) => new Meteorologist(astronautName),
                _ => throw new InvalidOperationException(ExceptionMessages.InvalidAstronautType),
            };

            return astronaut;
        }
    }
}
