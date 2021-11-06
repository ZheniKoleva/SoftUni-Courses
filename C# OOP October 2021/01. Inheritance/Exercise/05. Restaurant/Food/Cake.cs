namespace Restaurant.Food
{
    public class Cake : Dessert
    {
        private const double DefaultGrams = 250;

        private const double DefaultCalories = 1000;

        private const decimal DefaultPrice = 5m;

        public Cake(string name) 
            : base(name, DefaultPrice, DefaultGrams, DefaultCalories)
        {

        }
    }
}
