namespace _04.WildFarm.Animals
{
    public abstract class Mammal : Animal
    {
        protected Mammal(string name, double weight, string livingRegion) 
            : base(name, weight)
        {
            LivingRegion = livingRegion;
        }
        public string LivingRegion { get; private set; }

        public override string ToString()
            => $"{GetType().Name} [{Name}, {Weight}, {LivingRegion}, {FoodEaten}]";
    }
}
