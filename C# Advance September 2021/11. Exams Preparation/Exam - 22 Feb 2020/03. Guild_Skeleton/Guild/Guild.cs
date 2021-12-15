using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Guild
{
    public class Guild
    {
        private Dictionary<string, Player> roster;

        public Guild(string name, int capacity)
        {
            Name = name;
            Capacity = capacity;
            roster = new Dictionary<string, Player>(capacity);
        }

        public string Name { get; set; }

        public int Capacity { get; set; }

        public int Count => roster.Count;

        public void AddPlayer(Player player)
        {
            if (!roster.ContainsKey(player.Name)
                && Count + 1 <= Capacity)
            {
                roster.Add(player.Name, player);
            }
        }

        public bool RemovePlayer(string name) => roster.Remove(name);

        public void PromotePlayer(string name)
        {
            Player player = roster[name];

            if (player.Rank.Equals("Trial"))
            {
                player.Rank = "Member";
            }
        }

        public void DemotePlayer(string name)
        {
            Player player = roster[name];

            if (player.Rank.Equals("Member"))
            {
                player.Rank = "Trial";
            }
        }

        public Player[] KickPlayersByClass(string @class)
        {
            Player[] playersToKick = roster.Values.Where(x => x.Class == @class).ToArray();

            foreach (var player in playersToKick)
            {
                roster.Remove(player.Name);
            }

            return playersToKick;
        }

        public string Report()
        {
            StringBuilder output = new StringBuilder();
            output.AppendLine($"Players in the guild: {Name}");

            foreach (var (_, data) in roster)
            {
                output.AppendLine(data.ToString().TrimEnd());
            }

            return output.ToString().TrimEnd();
        }

    }
}
