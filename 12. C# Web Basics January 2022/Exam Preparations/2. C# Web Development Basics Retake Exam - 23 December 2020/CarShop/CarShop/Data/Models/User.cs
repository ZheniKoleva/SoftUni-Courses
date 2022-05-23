using System.ComponentModel.DataAnnotations;

namespace CarShop.Data.Models
{
    public class User
    {
        public User()
        {
            Id = Guid.NewGuid().ToString();            
        }

        [Key]
        [StringLength(36)]
        public string Id { get; set; }

        [Required]
        [StringLength(20)]
        public string Username { get; set; }

        [Required]
        [StringLength(50)]
        public string Email { get; set; }

        [Required]
        [StringLength(64)]
        public string Password { get; set; }

        public bool IsMechanic { get; set; }
    }
}

//•	Has an Id – a string, Primary Key
//•	Has a Username – a string with min length 4 and max length 20 (required)
//•	Has an Email - a string (required)
//•	Has a Password – a string with min length 5 and max length 20  - hashed in the database (required)
//•	Has а IsMechanic – a bool indicating if the user is a mechanic or a client

