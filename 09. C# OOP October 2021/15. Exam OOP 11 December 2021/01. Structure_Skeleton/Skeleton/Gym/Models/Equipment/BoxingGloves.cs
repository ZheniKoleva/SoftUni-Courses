namespace Gym.Models.Equipment
{
    public class BoxingGloves : Equipment
    {
        private const double Default_Weight = 227;

        private const decimal Default_Price = 120m;

        public BoxingGloves()
            : base(Default_Weight, Default_Price)
        {
        }
    }
}
