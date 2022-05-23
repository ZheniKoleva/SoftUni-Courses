using System.ComponentModel.DataAnnotations;

namespace FootballManager.ViewModels
{
    public class UserRegisterModel
    {
        [Required]
        [StringLength(20, MinimumLength = 5, ErrorMessage = "{0} should be between {2} and {1} symbols")]
        public string Username { get; set; }

        [Required]
        [EmailAddress(ErrorMessage = "{0} should be a valid email address")]
        [StringLength(60, MinimumLength = 10, ErrorMessage = "{0} should be between {2} and {1} symbols")]
        public string Email { get; set; }

        [Required]
        [StringLength(20, MinimumLength = 5, ErrorMessage = "{0} should be between {2} and {1} symbols")]
        public string Password { get; set; }

        [Required]
        [StringLength(20, MinimumLength = 5, ErrorMessage = "{0} should be between {2} and {1} symbols")]
        [Compare(nameof(Password), ErrorMessage = "Confirm Password and Password should match")]
        public string ConfirmPassword { get; set; }
        
    }
}

//•	Has an Id – a string, Primary Key
//•	Has a Username – a string with min length 5 and max length 20 (required)
//•	Has an Email – a string with min length 10 and max length 60 (required)
//•	Has a Password – a string with min length 5 and max length 20 (before hashed)  -no max length required for a hashed password in the database (required)
//•	Has UserPlayers collection

