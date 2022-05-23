using System.ComponentModel.DataAnnotations;

namespace FootballManager.Data.Models
{
    public class Player
    {
        public Player()
        {
            UserPlayers = new HashSet<UserPlayers>();
        }

        [Key]       
        public int Id { get; set; }

        [Required]
        [StringLength(80)]
        public string FullName { get; set; }

        [Required]
        [StringLength(2048)]
        public string ImageUrl { get; set; }

        [Required]
        [StringLength(20)]
        public string Position { get; set; }

        public byte Speed { get; set; }

        public byte Endurance { get; set; }

        [Required]
        [StringLength(200)]
        public string Description { get; set; }

        public ICollection<UserPlayers> UserPlayers { get; set; }
    }
}

//•	Has Id – an int, Primary Key
//•	Has FullName – a string (required); min.length: 5, max.length: 80
//•	Has ImageUrl – a string (required)
//•	Has Position – a string (required); min.length: 5, max.length: 20
//•	Has Speed – a byte (required); cannot be negative or bigger than 10
//•	Has Endurance – a byte (required); cannot be negative or bigger than 10
//•	Has a Description – a string with max length 200 (required)
//•	Has UserPlayers collection

