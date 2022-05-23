namespace _04.WildFarm.Animals
{
    using System;
    using System.Collections.Generic;

    using Foods;

    internal class Owl : Bird
    {
        private const double WeightIncreasement = 0.25;

        private readonly List<Type> foodsList = new List<Type>() { typeof(Meat) };

        public Owl(string name, double weight, double wingsSize)
            : base(name, weight, wingsSize)
        {
        }

        public override double WeightIncreasment => WeightIncreasement;

        public override ICollection<Type> FoodsList => foodsList;            

        public override string ProduseSound() 
            => "Hoot Hoot";        
    }
}
