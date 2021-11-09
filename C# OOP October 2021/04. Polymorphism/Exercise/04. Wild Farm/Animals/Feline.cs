namespace _04.WildFarm.Animals
{
    public abstract class Feline : Mammal
    {
        protected Feline(string name, double weight, string livingRegion, string breed) 
            : base(name, weight, livingRegion)
        {
            Breed = breed;
        }

        public string Breed { get; private set; }

        public override string ToString()
            => $"{GetType().Name} [{Name}, {Breed}, {Weight}, {LivingRegion}, {FoodEaten}]";        
    }
}
