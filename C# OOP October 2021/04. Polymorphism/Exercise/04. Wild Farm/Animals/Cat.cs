namespace _04.WildFarm.Animals
{
    using System;
    using System.Collections.Generic;

    using Foods;

    public class Cat : Feline
    {
        private const double WeightIncreasement = 0.30;

        private readonly List<Type> foodsList = new List<Type>() { typeof(Meat), typeof(Vegetable) };

        public Cat(string name, double weight, string livingRegion, string breed) 
            : base(name, weight, livingRegion, breed)
        {
        }

        public override double WeightIncreasment => WeightIncreasement;

        public override ICollection<Type> FoodsList => foodsList;            

        public override string ProduseSound() => "Meow";        
    }
}
