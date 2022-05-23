using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarShop.ViewModels
{
    public class UserRegisterModel
    {
        [Required]
        [StringLength(20, MinimumLength = 5, ErrorMessage = "{0} should be between {2} and {1} symbols")]
        public string Username { get; set; }

        [Required]
        [EmailAddress(ErrorMessage = "{0} should be a valid email address")]
        [StringLength(50, ErrorMessage = "{0} should be less than {1} symbols")]
        public string Email { get; set; }

        [Required]
        [StringLength(20, MinimumLength = 4, ErrorMessage = "{0} should be between {2} and {1} symbols")]
        public string Password { get; set; }

        [Required]
        [StringLength(20, MinimumLength = 4, ErrorMessage = "{0} should be between {2} and {1} symbols")]
        [Compare(nameof(Password), ErrorMessage = "Confirm Password and Password should match")]
        public string ConfirmPassword { get; set; }

        [Required]
        public string UserType { get; set; }
    }
}

//•	Has an Id – a string, Primary Key
//•	Has a Username – a string with min length 4 and max length 20 (required)
//•	Has an Email - a string (required)
//•	Has a Password – a string with min length 5 and max length 20  - hashed in the database (required)
//•	Has а IsMechanic – a bool indicating if the user is a mechanic or a client
