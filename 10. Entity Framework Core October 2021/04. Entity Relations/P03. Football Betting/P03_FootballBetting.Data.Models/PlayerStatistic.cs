namespace P03_FootballBetting.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class PlayerStatistic
    {
        [Required]
        [ForeignKey(nameof(Game))]
        public int GameId { get; set; }

        public Game Game { get; set; }

        [Required]
        [ForeignKey(nameof(Player))]
        public int PlayerId { get; set; }

        public Player Player { get; set; }

        public int ScoredGoals { get; set; }

        public int Assists { get; set; }

        public int MinutesPlayed { get; set; }        

    }
}
