using System;
using System.Collections.Generic;
using System.Linq;

namespace _07.TheV_Vlogger3
{
    class Program
    {
        static void Main(string[] args)
        {
            string followers = "followers";
            string followings = "followings";

            Dictionary<string, Vlogger> vloggers = new Dictionary<string, Vlogger>();

            string line;

            while ((line = Console.ReadLine()) != "Statistics")
            {
                string[] vlogerData = line
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);

                string firstVlogger = vlogerData[0];

                if (vlogerData[1].Equals("joined"))
                {
                    if (!vloggers.ContainsKey(firstVlogger))
                    {
                        vloggers.Add(firstVlogger, new Vlogger(firstVlogger));                      
                    }
                }
                else
                {
                    string secondVlogger = vlogerData[2];

                    if (vloggers.ContainsKey(firstVlogger)
                        && vloggers.ContainsKey(secondVlogger)
                        && !firstVlogger.Equals(secondVlogger))
                    {
                        Vlogger first = vloggers[firstVlogger];
                        Vlogger second = vloggers[secondVlogger];

                        first.Followings.Add(second);
                        second.Followers.Add(first);
                    }

                }
            }

            Console.WriteLine($"The V-Logger has a total of {vloggers.Count} vloggers in its logs.");

            vloggers = vloggers
                .OrderByDescending(x => x.Value.Followers.Count)
                .ThenBy(x => x.Value.Followings.Count)
                .ToDictionary(x => x.Key, x => x.Value);

            int count = 1;

            foreach (var (name, vloggerData) in vloggers)
            {
                Console.WriteLine($"{count}. {vloggerData}");

                if (count == 1)
                {
                    foreach (var follower in vloggerData.Followers.OrderBy(x => x.Name))
                    {
                        Console.WriteLine($"*  {follower.Name}");
                    }
                }

                count++;
            }
        }
    }

    public class Vlogger
    {
        public Vlogger(string name)
        {
            Name = name;
            Followers = new HashSet<Vlogger>();
            Followings = new HashSet<Vlogger>();
        }

        public string Name { get; }

        public HashSet<Vlogger> Followers { get; set; }
        
        public HashSet<Vlogger> Followings { get; set; }

        public override string ToString()
        {
            return $"{Name} : {Followers.Count} followers, {Followings.Count} following";
        }

    }
}
