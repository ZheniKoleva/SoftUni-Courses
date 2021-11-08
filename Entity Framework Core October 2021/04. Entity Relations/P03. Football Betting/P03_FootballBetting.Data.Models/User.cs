namespace P03_FootballBetting.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class User
    {
        public User()
        {
            this.Bets = new HashSet<Bet>();
        }
        [Key]
        public int UserId { get; set; }

        [Required]
        [Column(TypeName = "varchar(20)")]
        public string Username { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(120)")]
        public string Password { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(30)")]
        public string Email { get; set; }

        [Required]
        [Column(TypeName = "varchar(50)")]
        public string Name { get; set; }
                
        public decimal Balance { get; set; }

        public virtual ICollection<Bet> Bets { get; set; }

    }
}
