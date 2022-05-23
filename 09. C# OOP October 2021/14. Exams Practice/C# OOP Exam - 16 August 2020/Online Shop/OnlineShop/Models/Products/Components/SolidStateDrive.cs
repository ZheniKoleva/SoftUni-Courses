namespace OnlineShop.Models.Products.Components
{
    public class SolidStateDrive : Component
    {
        private const double Default_Multiplier = 1.20;

        public SolidStateDrive(
            int id,
            string manufacturer,
            string model,
            decimal price,
            double overallPerformance,
            int generation)
            : base(id, manufacturer, model, price, overallPerformance, generation)
        {
        }

        public override double OverallPerformance
            => base.OverallPerformance * Default_Multiplier;

    }
}
