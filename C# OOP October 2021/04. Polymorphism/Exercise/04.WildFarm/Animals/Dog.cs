namespace _04.WildFarm.Animals
{
    using System;
    using System.Collections.Generic;

    using Foods;

    public class Dog : Mammal
    {
        private const double WeightIncreasement = 0.40;

        private readonly List<Type> foodsList = new List<Type>() { typeof(Meat) };

        public Dog(string name, double weight, string livingRegion) 
            : base(name, weight, livingRegion)
        {
        }

        public override double WeightIncreasment => WeightIncreasement;

        public override ICollection<Type> FoodsList => foodsList;             

        public override string ProduseSound() => "Woof!";
        
    }
}
