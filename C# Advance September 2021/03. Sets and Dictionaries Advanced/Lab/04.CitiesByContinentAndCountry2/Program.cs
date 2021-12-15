using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _04.CitiesByContinentAndCountry2
{
    class Program
    {
        static void Main(string[] args)
        {
            int lines = int.Parse(Console.ReadLine());

            var cities = new Dictionary<string, List<Country>>();

            for (int i = 0; i < lines; i++)
            {
                ExtractData(out string continent, out string country, out string city);

                FillShopData(cities, continent, country, city);
            }

            PrindShopData(cities);
        }

        private static void PrindShopData(Dictionary<string, List<Country>> cities)
        {
            foreach (var (continent, countries) in cities)
            {
                Console.WriteLine($"{continent}:");
                Console.WriteLine(string.Join(Environment.NewLine, countries));                
            }
        }

        private static void FillShopData(Dictionary<string, List<Country>> cities, string continent, string country, string city)
        {
            if (!cities.ContainsKey(continent))
            {
                cities.Add(continent, new List<Country>());
            }

            if (!cities[continent].Any(x => x.Name == country))
            {
                cities[continent].Add(new Country(country));
            }

            Country current = cities[continent].First(x => x.Name == country);
            current.Cities.Add(city);
        }

        private static void ExtractData(out string continent, out string country, out string city)
        {
            string[] cityData = Console.ReadLine()
                                .Split(' ', StringSplitOptions.RemoveEmptyEntries);

            continent = cityData[0];
            country = cityData[1];
            city = cityData[2];
        }
    }

    public class Country
    {
        public Country(string name)
        {
            Name = name;
            Cities = new List<string>();
        }

        public string Name { get; }

        public List<string> Cities { get; set; }

        public override string ToString()
        {
            return $"  {Name} -> {string.Join(", ", Cities)}";
        }

    }
}
