namespace _04.WildFarm.Animals
{
    public abstract class Bird : Animal
    {
        protected Bird(string name, double weight, double wingsSize) 
            : base(name, weight)
        {
            WingsSize = wingsSize;
        }
        public double WingsSize { get; }

        public override string ToString()
            => $"{GetType().Name} [{Name}, {WingsSize}, {Weight}, {FoodEaten}]";        
    }
}
