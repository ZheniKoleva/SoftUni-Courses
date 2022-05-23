using System.Linq;
using System.Collections.Generic;

using SpaceStation.Models.Mission.Contracts;
using SpaceStation.Models.Planets.Contracts;
using SpaceStation.Models.Astronauts.Contracts;


namespace SpaceStation.Models.Mission
{
    public class Mission : IMission
    {
        public void Explore(IPlanet planet, ICollection<IAstronaut> astronauts)
        {
            foreach (var astronaut in astronauts)
            {
                while (astronaut.CanBreath && planet.Items.Any())
                {
                    string item = planet.Items.First();

                    astronaut.Breath();
                    astronaut.Bag.Items.Add(item);

                    planet.Items.Remove(item);
                }

                if (!planet.Items.Any())
                {
                    break;
                }
            }

        }
    }
}
