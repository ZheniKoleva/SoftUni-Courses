using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CocktailParty
{
    public class Cocktail
    {
        public Cocktail(string name, int capacity, int maxAlcoholLevel)
        {
            Name = name;
            Capacity = capacity;
            MaxAlcoholLevel = maxAlcoholLevel;
            Ingredients = new Dictionary<string, Ingredient>(capacity);
        }

        public string Name { get; set; }

        public int Capacity { get; set; }

        public int MaxAlcoholLevel { get; set; }

        public Dictionary<string, Ingredient> Ingredients { get; set; }

        public int CurrentAlcoholLevel => Ingredients.Values.Sum(x => x.Alcohol);

        public void Add(Ingredient ingredient)
        {
            if (!IsExists(ingredient.Name)
                && CurrentAlcoholLevel + ingredient.Alcohol <= MaxAlcoholLevel
                && Ingredients.Count + 1 <= Capacity)
            {
                Ingredients.Add(ingredient.Name, ingredient);
            }        
        }

        public bool Remove(string name) => Ingredients.Remove(name);

        public Ingredient FindIngredient(string name)
        {
            if (IsExists(name))
            {
                return Ingredients[name];
            }

            return null;
        }

        public Ingredient GetMostAlcoholicIngredient()
            => Ingredients.Values.OrderByDescending(x => x.Alcohol).FirstOrDefault();

        public string Report()
        {
            StringBuilder output = new StringBuilder();
            output.AppendLine($"Cocktail: {Name} - Current Alcohol Level: {CurrentAlcoholLevel}");

            foreach (var (_, ingredient) in Ingredients)
            {
                output.AppendLine(ingredient.ToString().TrimEnd());
            }

            return output.ToString().TrimEnd();
        }


        private bool IsExists(string ingredientName) => Ingredients.ContainsKey(ingredientName);
        
    }
}
