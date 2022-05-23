using System;
using System.Collections.Generic;
using System.Linq;

namespace _09.ForceBook
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<string>> forceSides = new Dictionary<string, List<string>>();
            Dictionary<string, string> users = new Dictionary<string, string>();

            string line = Console.ReadLine();

            while (line != "Lumpawaroo")
            {
                string[] data = null;
                string side = string.Empty;
                string user = string.Empty;

                if (line.Contains(" | "))
                {
                    data = line.Split(" | ", StringSplitOptions.RemoveEmptyEntries);

                    side = data[0];
                    user = data[1];

                    if (IsUserExist(users, user))
                    {
                        line = Console.ReadLine();
                        continue;
                    }

                    if (!IsSideExist(forceSides, side))
                    {
                        forceSides.Add(side, new List<string>());
                    }
                   
                    forceSides[side].Add(user);
                    users.Add(user, side);
                }
                else if (line.Contains(" -> "))
                {
                    data = line.Split(" -> ", StringSplitOptions.RemoveEmptyEntries);

                    user = data[0];
                    side = data[1];

                    if (!IsSideExist(forceSides, side))
                    {
                        forceSides.Add(side, new List<string>());
                    }

                    if (IsUserExist(users, user))
                    {
                        string oldSide = users[user];
                        users[user] = side;

                        forceSides[side].Add(user);
                        forceSides[oldSide].Remove(user);
                    }
                    else
                    {
                        forceSides[side].Add(user);
                        users.Add(user, side);                        
                    }

                    Console.WriteLine($"{user} joins the {side} side!");
                }


                line = Console.ReadLine();
            }

            Dictionary<string, List<string>> filtered = forceSides
                .Where(x => x.Value.Count > 0)
                .OrderByDescending(x => x.Value.Count)
                .ThenBy(x => x.Key)
                .ToDictionary(x => x.Key, x => x.Value);

            Print(filtered);
               
        }

        private static void Print(Dictionary<string, List<string>> filtered)
        {
            foreach (var side in filtered)
            {
                Console.WriteLine($"Side: {side.Key}, Members: {side.Value.Count}");
                side.Value.Sort();                   
                Console.Write("! ");
                Console.WriteLine(string.Join($"\n! ", side.Value));
            }
        }

        private static bool IsSideExist(Dictionary<string, List<string>> forceSides, string side)
        {
            return forceSides.ContainsKey(side);
        }

        private static bool IsUserExist(Dictionary<string, string> users, string user)
        {
            return users.ContainsKey(user);
        }
    }
}
