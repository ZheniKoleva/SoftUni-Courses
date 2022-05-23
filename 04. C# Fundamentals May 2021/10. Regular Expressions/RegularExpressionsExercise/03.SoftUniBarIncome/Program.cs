using System;
using System.Text.RegularExpressions;

namespace _03.SoftUniBarIncome
{
    class Program
    {
        static void Main(string[] args)
        {
            string pattern = @"%(?<name>[A-Z][a-z]+)%[^\|\$%\.]*<(?<item>\w+)>[^\|\$%\.]*\|(?<count>\d+)\|[^\|\$%\.]*?(?<price>\d+[\.|,\d+]*)\$";
            //@"^%([A-Z]{1}[a-z]{1,})%.*<(\w+)>.*\|([0-9]+)\|.*?([0-9.]+)\$$";

            double totalSum = 0.0;

            string line = Console.ReadLine();

            while (line != "end of shift")
            {
                Match matched = Regex.Match(line, pattern);

                if (matched.Success)
                {
                    string name = matched.Groups["name"].Value;
                    string product = matched.Groups["item"].Value;
                    int amount = int.Parse(matched.Groups["count"].Value);
                    double price = double.Parse(matched.Groups["price"].Value);

                    double currentSum = amount * price;
                    totalSum += currentSum;

                    Console.WriteLine($"{name}: {product} - {currentSum:f2}");
                }

                line = Console.ReadLine();
            }

            Console.WriteLine($"Total income: {totalSum:f2}");
        }
    }
}
