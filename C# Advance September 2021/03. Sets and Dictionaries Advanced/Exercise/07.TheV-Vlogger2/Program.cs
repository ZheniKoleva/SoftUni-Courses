using System;
using System.Collections.Generic;
using System.Linq;

namespace _07.TheV_Vlogger2
{
    class Program
    {
        static void Main(string[] args)
        {
            string followers = "followers";
            string followings = "followings";

            var vloggers = new Dictionary<string, Dictionary<string, HashSet<string>>>();

            string line;

            while ((line = Console.ReadLine()) != "Statistics")
            {
                string[] vlogerData = line
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);

                FillVloggersData(followers, followings, vloggers, vlogerData);
            }

            vloggers = vloggers
                .OrderByDescending(x => x.Value[followers].Count)
                .ThenBy(x => x.Value[followings].Count)
                .ToDictionary(x => x.Key, x => x.Value);

            PrintVloggersData(followers, followings, vloggers);
        }

        private static void PrintVloggersData(string followers, string followings, Dictionary<string, Dictionary<string, HashSet<string>>> vloggers)
        {
            Console.WriteLine($"The V-Logger has a total of {vloggers.Count} vloggers in its logs.");

            int count = 1;

            foreach (var vlogger in vloggers)
            {
                Console.WriteLine($"{count}. {vlogger.Key} : {vlogger.Value[followers].Count} followers, {vlogger.Value[followings].Count} following");

                if (count == 1)
                {
                    foreach (var name in vlogger.Value[followers].OrderBy(x => x))
                    {
                        Console.WriteLine($"*  {name}");
                    }
                }

                count++;
            }
        }

        private static void FillVloggersData(string followers, string followings, Dictionary<string, Dictionary<string, HashSet<string>>> vloggers, string[] vlogerData)
        {
            string firstVlogger = vlogerData[0];

            if (vlogerData[1].Equals("joined"))
            {
                if (!vloggers.ContainsKey(firstVlogger))
                {
                    vloggers.Add(firstVlogger, new Dictionary<string, HashSet<string>>());
                    vloggers[firstVlogger].Add(followers, new HashSet<string>());
                    vloggers[firstVlogger].Add(followings, new HashSet<string>());
                }
            }
            else
            {
                string secondVloger = vlogerData[2];

                if (vloggers.ContainsKey(firstVlogger)
                    && vloggers.ContainsKey(secondVloger)
                    && !firstVlogger.Equals(secondVloger))
                {
                    vloggers[firstVlogger][followings].Add(secondVloger);
                    vloggers[secondVloger][followers].Add(firstVlogger);
                }
            }
        }
    }
}
