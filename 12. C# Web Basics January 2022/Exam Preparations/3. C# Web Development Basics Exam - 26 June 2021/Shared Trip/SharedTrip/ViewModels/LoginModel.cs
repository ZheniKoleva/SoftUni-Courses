using System.ComponentModel.DataAnnotations;

namespace SharedTrip.ViewModels
{
    public class LoginModel
    { 
        [Required]
        [StringLength(20, MinimumLength = 5)]
        public string Username { get; set; }      

        [Required]
        [StringLength(20, MinimumLength = 6)]
        public string Password { get; set; }
    }
}

//•	Has an Id – a string, Primary Key
//•	Has a Username – a string with min length 5 and max length 20 (required)
//•	Has an Email - a string (required)
//•	Has a Password – a string with min length 6 and max length 20  - hashed in the database (required)
//•	Has UserTrips collection – a UserTrip type
