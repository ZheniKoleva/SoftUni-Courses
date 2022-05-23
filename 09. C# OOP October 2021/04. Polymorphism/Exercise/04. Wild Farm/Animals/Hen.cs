namespace _04.WildFarm.Animals
{
    using System;
    using System.Collections.Generic;

    using Foods;

    public class Hen : Bird
    {
        private const double WeightIncreasement = 0.35;

        private readonly List<Type> foodsList = new List<Type>() 
            { typeof(Meat), typeof(Seeds), typeof(Fruit), typeof(Vegetable) };

        public Hen(string name, double weight, double wingsSize)
            : base(name, weight, wingsSize)
        {
        }

        public override double WeightIncreasment => WeightIncreasement;

        public override ICollection<Type> FoodsList => foodsList;                  

        public override string ProduseSound() => "Cluck";       
    }
}
