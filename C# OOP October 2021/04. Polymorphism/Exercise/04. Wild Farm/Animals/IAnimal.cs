namespace _04.WildFarm.Animals
{
    using System;
    using System.Collections.Generic;

    using Foods;

    public interface IAnimal
    {
        public string Name { get; }

        public double Weight { get; }

        public int FoodEaten { get; }

        public double WeightIncreasment { get; }

        public ICollection<Type> FoodsList { get; }

        public void Eat(IFood food);

        public string ProduseSound();
    }
}
