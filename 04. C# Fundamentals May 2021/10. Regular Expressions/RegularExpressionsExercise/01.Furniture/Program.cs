using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace _01.Furniture
{
    class Program
    {
        static void Main(string[] args)
        {
            string pattern = @"\>{2}(?<name>[A-za-z]+)\<{2}(?<price>\d+[\.\d+]*)!(?<quantity>\d+)";

            List<string> itemsBounght = new List<string>();
            double totalPrice = 0;

            string input = Console.ReadLine();

            while (input != "Purchase")
            {
                Match result = Regex.Match(input, pattern);

                if (result.Success)
                {
                    itemsBounght.Add(result.Groups["name"].Value);

                    double currentPrice = double.Parse(result.Groups["price"].Value);
                    int currentQuantity = int.Parse(result.Groups["quantity"].Value);

                    totalPrice += currentPrice * currentQuantity;
                }

                input = Console.ReadLine();
            }

            Console.WriteLine("Bought furniture:");
            
            if (itemsBounght.Count > 0)
            {
                Console.WriteLine(string.Join(Environment.NewLine, itemsBounght));
            }
            
            Console.WriteLine($"Total money spend: {totalPrice:f2}");

        }
    }
}
