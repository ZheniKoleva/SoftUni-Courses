namespace SpaceStation.Models.Astronauts
{
    public class Geodesist : Astronaut
    {
        private const int Default_Initial_Oxygen = 50;
        
        public Geodesist(string name)
            : base(name, Default_Initial_Oxygen)
        {
        }

    }
}
