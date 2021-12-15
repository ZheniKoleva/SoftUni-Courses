using System;
using System.Collections.Generic;
using System.Text;

namespace CocktailParty
{
    public class Ingredient
    {
        public Ingredient(string name, int alcohol, int quantity)
        {
            Name = name;
            Alcohol = alcohol;
            Quantity = quantity;
        }

        public string  Name { get; set; }

        public int Alcohol { get; set; }

        public int Quantity { get; set; }

        public override string ToString()
        {
            StringBuilder output = new StringBuilder();
            output.AppendLine($"Ingredient: {Name}");
            output.AppendLine($"Quantity: {Quantity}");
            output.Append($"Alcohol: {Alcohol}");

            return output.ToString();
        }



    }
}
