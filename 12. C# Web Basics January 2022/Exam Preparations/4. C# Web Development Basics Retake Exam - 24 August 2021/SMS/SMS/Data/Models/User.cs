using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SMS.Data.Models
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
        [StringLength(30)]
        public string Email { get; set; }

        [Required]
        [StringLength(64)]
        public string Password { get; set; }

        [Required]
        [StringLength(36)]
        [ForeignKey(nameof(Cart))]
        public string CartId { get; set; }
        public Cart Cart { get; set; }
    }

//•	Has an Id – a string, Primary Key
//•	Has a Username – a string with min length 5 and max length 20 (required)
//•	Has an Email – a string, which holds only valid email(required)
//•	Has a Password – a string with min length 6 and max length 20 - hashed in the database(required)
//•	Has a Cart – a Cart object (required)

}
