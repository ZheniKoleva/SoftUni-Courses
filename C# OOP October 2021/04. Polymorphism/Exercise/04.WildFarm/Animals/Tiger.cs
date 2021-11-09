namespace _04.WildFarm.Animals
{
    using System;
    using System.Collections.Generic;

    using Foods;

    internal class Tiger : Feline
    {
        private const double WeightIncreasement = 1.00;

        private readonly List<Type> foodsList = new List<Type>() { typeof(Meat) };
        
        public Tiger(string name, double weight, string livingRegion, string breed) 
            : base(name, weight, livingRegion, breed)
        {
        }

        public override double WeightIncreasment => WeightIncreasement;

        public override ICollection<Type> FoodsList => foodsList;
           
        public override string ProduseSound() => "ROAR!!!";
       
    }
}
