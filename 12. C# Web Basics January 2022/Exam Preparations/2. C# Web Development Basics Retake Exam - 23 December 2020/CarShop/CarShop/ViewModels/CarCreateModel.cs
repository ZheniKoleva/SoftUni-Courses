using System.ComponentModel.DataAnnotations;

namespace CarShop.ViewModels
{
    public class CarCreateModel
    {
        [Required]
        [StringLength(20, MinimumLength = 5, ErrorMessage = "{0} should be between {2} and {1} symbols")]
        public string Model { get; set; }

        [Required]
        public int Year { get; set; }

        [Required]
        [StringLength(256)]
        public string ImageUrl { get; set; }

        [Required]
        [RegularExpression(@"[A-Z]{2}\d{4}[A-Z]{2}", ErrorMessage = "Invalid Plae number")]
        public string PlateNumber { get; set; }
    }
}

//•	Has an Id – a string, Primary Key
//•	Has a Model – a string with min length 5 and max length 20 (required)
//•	Has a Year – a number (required)
//•	Has a PictureUrl – string (required)
//•	Has a PlateNumber – a string – Must be a valid Plate number (2 Capital English letters, followed by 4 digits, followed by 2 Capital English letters (required)
//•	Has a OwnerId – a string (required)
//•	Has a Owner – a User object
//•	Has Issues collection – an Issue type
