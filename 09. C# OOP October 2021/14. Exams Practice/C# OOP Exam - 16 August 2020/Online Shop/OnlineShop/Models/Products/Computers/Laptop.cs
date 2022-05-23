namespace OnlineShop.Models.Products.Computers
{
    public class Laptop : Computer
    {
        private const double Default_OverallPerformance = 10;
        public Laptop(
            int id,
            string manufacturer,
            string model,
            decimal price)
            : base(id, manufacturer, model, price, Default_OverallPerformance)
        {
        }
    }
}
