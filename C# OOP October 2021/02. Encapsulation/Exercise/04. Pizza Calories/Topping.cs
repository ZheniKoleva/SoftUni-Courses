namespace _04.PizzaCalories
{
    using System;
    using System.Collections.Generic;    
    using System.Globalization;

    public class Topping
    {
        private const double DefaultCaloriesPerGram = 2;

        private const double MinWeight = 1;

        private const double MaxWeight = 50;        

        private readonly Dictionary<string, double> DefaultToppingType = new Dictionary<string, double>()
        {
            { "meat", 1.2},
            { "veggies", 0.8},
            { "cheese", 1.1},
            { "sauce", 0.9}
        };

        private string toppingType;

        private double weight;

        public Topping(string toppingType, double weight)
        {
            this.ToppingType = toppingType.ToLower();
            this.Weight = weight;
        }

        public string ToppingType 
        { 
            get => this.toppingType;
            private set
            {
                if (!DefaultToppingType.ContainsKey(value))
                {                   
                    string topping = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(value);
                    throw new ArgumentException($"Cannot place {topping} on top of your pizza.");
                }

                this.toppingType = value;
            } 
        }

        public double Weight 
        { 
            get => this.weight;
            private set
            {
                if (value < MinWeight || value > MaxWeight)
                {                    
                    string topping = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(this.toppingType);
                    throw new ArgumentException($"{topping} weight should be in the range [{MinWeight}..{MaxWeight}].");
                }

                this.weight = value;            
            }
        }

        public double CalculateToppingCalories()
            => (this.weight * DefaultCaloriesPerGram) * DefaultToppingType[this.toppingType];                

    }
}
