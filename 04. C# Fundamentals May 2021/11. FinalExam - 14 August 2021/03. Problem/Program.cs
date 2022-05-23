using System;
using System.Collections.Generic;
using System.Linq;

namespace _03._Problem
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Guest> guestsList = new Dictionary<string, Guest>();
            int unlikedMealsCount = 0;

            string line = Console.ReadLine();

            while (line != "Stop")
            {
                string[] data = line.Split("-", StringSplitOptions.RemoveEmptyEntries);

                string command = data[0];
                string guestName = data[1];
                string meal = data[2];

                switch (command)
                {
                    case "Like":
                        if (!guestsList.ContainsKey(guestName))
                        {
                            guestsList.Add(guestName, new Guest(guestName));
                        }

                        if (!guestsList[guestName].LikedMeals.Contains(meal))
                        {
                            guestsList[guestName].LikedMeals.Add(meal);
                        }

                        break;

                    case "Unlike":

                        if (!guestsList.ContainsKey(guestName))
                        {
                            Console.WriteLine($"{guestName} is not at the party.");
                            break;
                        }

                        bool isRemoved = guestsList[guestName].LikedMeals.Remove(meal);

                        if (isRemoved)
                        {
                            Console.WriteLine($"{guestName} doesn't like the {meal}.");
                            unlikedMealsCount++;
                        }
                        else
                        {
                            Console.WriteLine($"{guestName} doesn't have the {meal} in his/her collection.");
                        }

                        break;
                }

                line = Console.ReadLine();
            }

            guestsList = guestsList
                .OrderByDescending(g => g.Value.LikedMeals.Count)
                .ThenBy(g => g.Key)
                .ToDictionary(g => g.Key, g => g.Value);

            Print(guestsList);
            Console.WriteLine($"Unliked meals: {unlikedMealsCount}");

        }

        private static void Print(Dictionary<string, Guest> guestsList)
        {
            foreach (var guest in guestsList)
            {
                Console.WriteLine(guest.Value);
            }
        }
    }

    public class Guest 
    {
        public Guest(string name)
        {
            Name = name;
            LikedMeals = new List<string>();            
        }

        public string Name { get; set; }

        public List<string> LikedMeals { get; set; }        

        public override string ToString()
        {
            return $"{Name}: {string.Join(", ", LikedMeals)}";
        }

    }
}
