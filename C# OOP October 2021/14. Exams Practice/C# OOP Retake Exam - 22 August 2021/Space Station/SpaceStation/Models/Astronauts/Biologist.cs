namespace SpaceStation.Models.Astronauts
{
    public class Biologist : Astronaut
    {
        private const int Default_Initial_Oxygen = 70;

        private const int Oxygen_Decreasment = 5;

        public Biologist(string name) 
            : base(name, Default_Initial_Oxygen)
        {
        }

        public override void Breath()
        {
            if (Oxygen - Oxygen_Decreasment < 0)
            {
                Oxygen = 0;
            }
            else
            {
                Oxygen -= Oxygen_Decreasment;
            }
        }
    }
}
