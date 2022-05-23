using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace _02.Race
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> participants = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .ToDictionary(x => x, x => 0);

            string namePattern = @"[A-Za-z]";
            string distancePattern = @"\d";         

            string input = Console.ReadLine();

            while (input != "end of race")
            {
                string[] letters = Regex.Matches(input, namePattern)
                    .Cast<Match>()
                    .Select(x => x.Value)                    
                    .ToArray();

                string name = string.Join("", letters);

                //StringBuilder name = new StringBuilder();

                //foreach (var item in letters)
                //{
                //    name.Append(item);
                //}

               int distance = Regex.Matches(input, distancePattern)
                    .Cast<Match>()
                    .Select(x => int.Parse(x.Value))                    
                    .Sum();

                if (participants.ContainsKey(name))
                {
                    participants[name] += distance;
                }

                input = Console.ReadLine();
            }

            string[] result = participants
                .OrderByDescending(x => x.Value)
                .Take(3)
                .Select(x => x.Key)
                .ToArray();

            Console.WriteLine($"1st place: {result[0]}");
            Console.WriteLine($"2nd place: {result[1]}");
            Console.WriteLine($"3rd place: {result[2]}");
            
        }       
    }
}
