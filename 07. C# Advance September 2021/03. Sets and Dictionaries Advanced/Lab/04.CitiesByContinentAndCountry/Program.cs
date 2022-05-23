using System;
using System.Collections.Generic;

namespace _04.CitiesByContinentAndCountry
{
    class Program
    {
        static void Main(string[] args)
        {
            int lines = int.Parse(Console.ReadLine());

            var cities = new Dictionary<string, Dictionary<string, List<string>>>();


            for (int i = 0; i < lines; i++)
            {
                ExtractData(out string continent, out string country, out string city);

                FillShopData(cities, continent, country, city);
            }

            PrindShopData(cities);
        }

        private static void PrindShopData(Dictionary<string, Dictionary<string, List<string>>> cities)
        {
            foreach (var (continent, countries) in cities)
            {
                Console.WriteLine($"{continent}:");

                foreach (var (country, citiesList) in countries)
                {
                    Console.WriteLine($"  {country} -> {string.Join(", ", citiesList)}");
                }
            }
        }

        private static void FillShopData(Dictionary<string, Dictionary<string, List<string>>> cities, string continent, string country, string city)
        {
            if (!cities.ContainsKey(continent))
            {
                cities.Add(continent, new Dictionary<string, List<string>>());
            }

            if (!cities[continent].ContainsKey(country))
            {
                cities[continent].Add(country, new List<string>());
            }

            cities[continent][country].Add(city);
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
}    
