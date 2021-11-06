namespace _04.PizzaCalories
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Pizza
    {
        private const int NameMinLength = 1;

        private const int NameMaxLength = 15;

        private const int ToppingsMinCount = 0;

        private const int ToppingsMaxCount = 10;

        private readonly string PizzaNameExceptionMessage = 
            $"Pizza name should be between {NameMinLength} and {NameMaxLength} symbols.";

        private readonly string ToppingsCountExceptionMessage =
            $"Number of toppings should be in range [{ToppingsMinCount}..{ToppingsMaxCount}].";

        private string name;

        private Dough dough;

        private readonly IList<Topping> topping;

        public Pizza(string name)
        {
            this.Name = name;
            this.topping = new List<Topping>(ToppingsMaxCount);
        }

        public string Name 
        { 
            get => this.name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value) || value.Length < NameMinLength || value.Length > NameMaxLength)
                {
                    throw new ArgumentException(this.PizzaNameExceptionMessage);
                }

                this.name = value;
            }
             
        }

        public Dough Dough
        {
            get => this.dough;
            set => this.dough = value;
        }

        public int ToppingCount => this.topping.Count;

        public double TotalCalories => this.CalculateCalories();       

        public void AddTopping(Topping topping)
        {
            if (this.ToppingCount == ToppingsMaxCount)
            {
                throw new ArgumentException(this.ToppingsCountExceptionMessage);
            }

            this.topping.Add(topping);
        }

        private double CalculateCalories()
        {
            double calories = this.dough.CalculateDoughCalories();

            if (this.topping.Count > 0)
            {
                calories += this.topping.Sum(t => t.CalculateToppingCalories());
            }

            return calories;
        } 

        public override string ToString()
            => $"{this.name} - {this.TotalCalories:f2} Calories."; 
    }
}
