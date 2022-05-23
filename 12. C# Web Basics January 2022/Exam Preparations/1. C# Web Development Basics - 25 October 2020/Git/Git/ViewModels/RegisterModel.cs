using System.ComponentModel.DataAnnotations;

namespace Git.ViewModels
{
    public class RegisterModel
    {
        [Required]
        [StringLength(20, MinimumLength = 5, ErrorMessage = "{0} should be between {2} and {1} symbols")]
        public string Username { get; set; }

        [Required]
        [StringLength(30, ErrorMessage = "{0} should be less than {1} symbols")]
        [EmailAddress(ErrorMessage = "Email should be valid email")]
        public string Email { get; set; }

        [Required]
        [StringLength(20, MinimumLength = 6, ErrorMessage = "{0} should be between {2} and {1} symbols")]
        public string Password { get; set; }

        [Required]
        [StringLength(20, MinimumLength = 6, ErrorMessage = "Confirm Password should be between {2} and {1} symbols")]
        [Compare(nameof(Password), ErrorMessage = "Confirm Password should be equal to Password")]
        public string ConfirmPassword { get; set; }
    }
}

//•	Has an Id – a string, Primary Key
//•	Has a Username – a string with min length 5 and max length 20 (required)
//•	Has an Email - a string (required)
//•	Has a Password – a string with min length 6 and max length 20  - hashed in the database (required)
//•	Has Repositories collection – a Repository type
//•	Has Commits collection – a Commit type
