
namespace SpaceStation.Models.Astronauts
{
    public class Meteorologist : Astronaut
    {
        private const int Default_Initial_Oxygen = 90;

        public Meteorologist(string name)
            : base(name, Default_Initial_Oxygen)
        {
        }

    }
}
