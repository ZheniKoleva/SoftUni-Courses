namespace Gym.Models.Athletes
{
    public class Weightlifter : Athlete
    {
        private const int Default_Initial_Stamina = 50;

        private const int Stamina_Increasment = 10;

        public Weightlifter(string fullName, string motivation, int numberOfMedals)
            : base(fullName, motivation, numberOfMedals, Default_Initial_Stamina)
        {
        }


        public override void Exercise()
            => Stamina += Stamina_Increasment;       
        
    }
}
