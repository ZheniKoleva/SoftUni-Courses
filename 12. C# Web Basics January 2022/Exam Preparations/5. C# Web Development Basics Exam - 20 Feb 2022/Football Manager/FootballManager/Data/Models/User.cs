using System.ComponentModel.DataAnnotations;

namespace FootballManager.Data.Models
{
    public class User
    {
        public User()
        {
            Id = Guid.NewGuid().ToString();
            UserPlayers = new HashSet<UserPlayers>();
        }

        [Key]   
        [StringLength(36)]
        public string Id { get; set; }

        [Required]
        [StringLength(20)]
        public string Username { get; set; }

        [Required]
        [StringLength(60)]
        public string Email { get; set; }

        [Required]
        [StringLength(64)]
        public string Password { get; set; }

        public ICollection<UserPlayers> UserPlayers { get; set; }

    }
}

//•	Has an Id – a string, Primary Key
//•	Has a Username – a string with min length 5 and max length 20 (required)
//•	Has an Email – a string with min length 10 and max length 60 (required)
//•	Has a Password – a string with min length 5 and max length 20 (before hashed)  -no max length required for a hashed password in the database (required)
//•	Has UserPlayers collection

