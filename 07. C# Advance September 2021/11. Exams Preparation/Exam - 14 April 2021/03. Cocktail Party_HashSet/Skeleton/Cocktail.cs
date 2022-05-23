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
            Ingredients = new HashSet<Ingredient>(capacity);
        }

        public string Name { get; set; }

        public int Capacity { get; set; }
         
        public int MaxAlcoholLevel { get; set; } 

        public int CurrentAlcoholLevel => Ingredients.Sum(x => x.Alcohol); 
        
        public HashSet<Ingredient> Ingredients { get; set; }

        public void Add(Ingredient ingredient)
        {
            if (Ingredients.Count + 1 <= Capacity
                && CurrentAlcoholLevel + ingredient.Alcohol <= MaxAlcoholLevel )
            {
                Ingredients.Add(ingredient);
            }
        }

        public bool Remove(string name) 
            => Ingredients.RemoveWhere(x => x.Name == name) > 0;

        public Ingredient FindIngredient(string name) 
            => Ingredients.FirstOrDefault(x => x.Name == name);

        public Ingredient GetMostAlcoholicIngredient()
            => Ingredients.OrderByDescending(x => x.Alcohol).FirstOrDefault();

        public string Report()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Cocktail: {Name} - Current Alcohol Level: {CurrentAlcoholLevel}");

            foreach (var item in Ingredients)
            {
                sb.AppendLine(item.ToString().TrimEnd());
            }

            return sb.ToString().TrimEnd();
        }

    }
}
