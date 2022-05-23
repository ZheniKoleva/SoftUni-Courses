namespace Gym.Models.Equipment
{
    public class Kettlebell : Equipment
    {
        private const double Default_Weight = 10000;

        private const decimal Default_Price = 80m;

        public Kettlebell()
            : base(Default_Weight, Default_Price)
        {
        }
    }
}
