namespace Easter.Models.Bunnies
{
    public class SleepyBunny : Bunny
    {
        private const int Default_Energy = 50;

        private const int Energy_Decrease = 15;


        public SleepyBunny(string name)
            : base(name, Default_Energy)
        {
        }


        public override void Work()
         => Energy -= Energy_Decrease;
    }
}
