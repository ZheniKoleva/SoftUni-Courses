using System.ComponentModel.DataAnnotations;

namespace CarShop.ViewModels
{
    public class UserLoginModel
    {
        [Required]
        [StringLength(20, MinimumLength = 4, ErrorMessage = "{0} should be between {2} and {1} symbols")]
        public string Username { get; set; }       

        [Required]
        [StringLength(20, MinimumLength = 5, ErrorMessage = "{0} should be between {2} and {1} symbols")]
        public string Password { get; set; }
    }
}

//•	Has an Id – a string, Primary Key
//•	Has a Username – a string with min length 4 and max length 20 (required)
//•	Has an Email - a string (required)
//•	Has a Password – a string with min length 5 and max length 20  - hashed in the database (required)
//•	Has а IsMechanic – a bool indicating if the user is a mechanic or a client
