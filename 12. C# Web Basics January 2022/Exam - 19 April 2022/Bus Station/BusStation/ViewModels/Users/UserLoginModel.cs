using System.ComponentModel.DataAnnotations;

namespace BusStation.ViewModels.Users
{
    public class UserLoginModel
    {
        [Required]
        [StringLength(20, MinimumLength = 5, ErrorMessage = "{0} should be between {2} and {1} symbols")]
        public string Username { get; set; }

        [Required]
        [StringLength(20, MinimumLength = 5, ErrorMessage = "{0} should be between {2} and {1} symbols")]
        public string Password { get; set; }
    }
}

//•	Has an Id – an string, Primary Key
//•	Has a Username – a string with min length 5 and max length 20 (unique, required)
//•	Has an Email – a string with min length 10 and max length 60 (unique, required)
//•	Has a Password – a string with min length 5 and max length 20 (before hashed)  -no max length required for a hashed password in the database (required)
//•	Has Tickets collection



