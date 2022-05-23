namespace P03_FootballBetting.Data.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Bet
    {
        [Key]
        public int BetId { get; set; }

        [Required]
        public decimal Amount { get; set; }

        [Required]
        public Prediction Prediction { get; set; }

        [Required]
        public DateTime DateTime { get; set; }

        [Required]
        [ForeignKey(nameof(User))]
        public int UserId { get; set; }

        [Required]
        public User User { get; set; }

        [Required]
        [ForeignKey(nameof(Game))]
        public int GameId { get; set; }

        public Game Game { get; set; }

    }
}
