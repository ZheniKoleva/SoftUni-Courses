namespace Bakery.Models.Drinks
{
    public class Tea : Drink
    {
        private const decimal TeaPrice = 2.50m;

        public Tea(string name, int portion, string brand) 
            : base(name, portion, TeaPrice, brand)
        {
        }
    }
}
