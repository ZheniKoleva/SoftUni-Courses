namespace Gym.Models.Athletes
{
    public class Boxer : Athlete
    {
        private const int Default_Initial_Stamina = 60;

        private const int Stamina_Increasment = 15;

        public Boxer(string fullName, string motivation, int numberOfMedals)
            : base(fullName, motivation, numberOfMedals, Default_Initial_Stamina)
        {
        }

        public override void Exercise()
            => Stamina += Stamina_Increasment;
        
    }
}
