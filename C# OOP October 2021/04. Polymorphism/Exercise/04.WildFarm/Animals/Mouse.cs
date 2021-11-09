namespace _04.WildFarm.Animals
{
    using System;
    using System.Collections.Generic;

    using Foods;

    public class Mouse : Mammal
    {
        private const double WeightIncreasement = 0.10;

        private readonly List<Type> foodsList = new List<Type>() { typeof(Fruit), typeof(Vegetable) };

        public Mouse(string name, double weight, string livingRegion) 
            : base(name, weight, livingRegion)
        {
        }

        public override double WeightIncreasment => WeightIncreasement;

        public override ICollection<Type> FoodsList => foodsList;           

        public override string ProduseSound() => "Squeak";        
    }
}
