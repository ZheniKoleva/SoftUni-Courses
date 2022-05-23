namespace _05.FootballTeamGenerator
{
    using System;

    public class Player
    {
        private const int MinStat = 0;

        private const int MaxStat = 100;

        private string name;

        private int endurance;

        private int sprint;

        private int dribble;

        private int passing;

        private int shooting;

        public Player(string name, int endurance, int sprint, int dribble, int passing, int shooting)
        {
            this.Name = name;
            this.Endurance = endurance;
            this.Sprint = sprint;
            this.Dribble = dribble;
            this.Passing = passing;
            this.Shooting = shooting;
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

        public int Endurance 
        { 
            get => this.endurance;
            private set
            {
                ValidateStatisticData(value, nameof(Endurance));
                this.endurance = value;
            }
        }

        public int Sprint
        {
            get => this.sprint;
            private set
            {
                ValidateStatisticData(value, nameof(Sprint));
                this.sprint = value;
            }
        }

        public int Dribble 
        {
            get => this.dribble;
            private set
            {
                ValidateStatisticData(value, nameof(Dribble));
                this.dribble = value;
            }
        }

        public int Passing
        {
            get => this.passing;
            private set
            {
                ValidateStatisticData(value, nameof(Passing));
                this.passing = value;
            }
        }

        public int Shooting
        {
            get => this.shooting;
            private set
            {
                ValidateStatisticData(value, nameof(Shooting));
                this.shooting = value;
            }
        }

        public double SkillLevel => this.CalculateSkillLevel();

        private int CalculateSkillLevel()
        {
            double playerSkillsCount = 5;

            return (int)Math.Round((this.endurance + this.sprint + this.dribble + this.passing + this.shooting) / playerSkillsCount);
        }
        
        private static void ValidateStatisticData(int value, string stat)
        {
            if (value < MinStat || value > MaxStat)
            {
                throw new ArgumentException($"{stat} should be between {MinStat} and {MaxStat}.");
            }
        }
    }
}
