namespace _04.PizzaCalories
{
    using System;
    using System.Collections.Generic;    

    public class Dough
    {
        private const double DefaultCaloriesPerGram = 2;

        private const double MinWeight = 1;

        private const double MaxWeight = 200;

        private readonly string InvalidDoughExceptionMessage = "Invalid type of dough.";

        private readonly string InvalidWeightExceptionMessage = 
            $"Dough weight should be in the range [{MinWeight}..{MaxWeight}].";              

        private readonly Dictionary<string, double> DefaultFlourType = new Dictionary<string, double>()
        {
            { "white", 1.5},
            { "wholegrain", 1.0}           
        };

        private readonly Dictionary<string, double> DefaultBackingTechnique = new Dictionary<string, double>()
        {            
            { "crispy", 0.9},
            { "chewy", 1.1},
            { "homemade", 1.0}
        };

        private string flourType;

        private string bakingTechnique;

        private double weight;

        public Dough(string flourType, string bakingTechnique, double weight)
        {
            this.FlourType = flourType.ToLower();
            this.BakingTechnique = bakingTechnique.ToLower();
            this.Weight = weight;
        }

        public string FlourType 
        { 
            get => this.flourType;
            private set
            {
                if (!DefaultFlourType.ContainsKey(value))
                {
                    throw new ArgumentException(this.InvalidDoughExceptionMessage);
                }

                this.flourType = value;            
            }
        }

        public string BakingTechnique
        {
            get => this.bakingTechnique;
            private set
            {
                if (!DefaultBackingTechnique.ContainsKey(value))
                {
                    throw new ArgumentException(this.InvalidDoughExceptionMessage);
                }

                this.bakingTechnique = value;
            }
        }

        public double Weight
        {
            get => this.weight;
            private set 
            {
                if (value < MinWeight || value > MaxWeight)
                {
                    throw new ArgumentException(this.InvalidWeightExceptionMessage);
                }

                this.weight = value;
            }        
        
        }

        public double CalculateDoughCalories()
            => ((this.weight * DefaultCaloriesPerGram)
                * DefaultFlourType[this.flourType]
                * DefaultBackingTechnique[this.bakingTechnique]);

    }
}
