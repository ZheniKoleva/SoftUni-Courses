namespace _05.FootballTeamGenerator
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Team
    {
        private string name;        

        private readonly Dictionary<string, Player> players;

        public Team(string name)
        {
            this.Name = name;
            this.players = new Dictionary<string, Player>();
        }

        public string Name
        {
            get => this.name;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("A name should not be empty.");
                }

                this.name = value;
            }
        }

        public IReadOnlyCollection<Player> Players => this.players.Values;

        public int Rating => this.CalculateRating();
       
        public void AddPlayer(Player player)
        {
            if (!IsPlayerExists(player.Name))
            {
                players.Add(player.Name, player);
            }
        }
      
        public void RemovePlayer(string playerName)
        {
            if (!IsPlayerExists(playerName))
            {
                throw new ArgumentException($"Player {playerName} is not in {this.Name} team.");
            }

            players.Remove(playerName);
        }

        public override string ToString() => $"{this.name} - {this.Rating}";       
        
        private int CalculateRating()
            => this.players.Count == 0 ? 0 :(int)Math.Round((this.players.Average(p => p.Value.SkillLevel)));

        private bool IsPlayerExists(string playerName) => this.players.ContainsKey(playerName);
       
    }
}
