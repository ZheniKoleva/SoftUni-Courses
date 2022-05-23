namespace _04.WildFarm.Animals
{
    using System;
    using System.Collections.Generic;

    using Foods;

    public abstract class Animal : IAnimal
    {
        protected Animal(string name, double weight)
        {
            Name = name;
            Weight = weight;
            FoodEaten = 0;            
        }

        public string Name { get; private set; }

        public double Weight { get; private set; }

        public int FoodEaten { get; private set; }

        public abstract double WeightIncreasment { get; }

        public abstract ICollection<Type> FoodsList { get; }

        public abstract string ProduseSound();

        public void Eat(IFood food)
        {
            ValidateFood(food);

            FoodEaten += food.Quantity;
            Weight += WeightIncreasment * food.Quantity;
        }

        private void ValidateFood(IFood food)
        {
            if (FoodsList.Contains(food.GetType()))
            {
                throw new ArgumentException($"{this.GetType().Name} does not eat {food.GetType().Name}!");
            }
        }       
    }  
   
}
