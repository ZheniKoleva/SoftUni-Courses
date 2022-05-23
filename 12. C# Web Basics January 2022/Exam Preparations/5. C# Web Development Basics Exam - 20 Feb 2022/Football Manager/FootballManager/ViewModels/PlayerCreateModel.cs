using System.ComponentModel.DataAnnotations;

namespace FootballManager.ViewModels
{
    public class PlayerCreateModel
    {
        [Required]
        [StringLength(80, MinimumLength = 5, ErrorMessage = "Full name should be between {2} and {1} symbols")]
        public string FullName { get; set; }

        [Required]
        [StringLength(2048, ErrorMessage = "Image Url should be less than {1} symbols")]
        public string ImageUrl { get; set; }

        [Required]
        [StringLength(20, MinimumLength = 5, ErrorMessage = "{0} should be between {2} and {1} symbols")]
        public string Position { get; set; }

        [Required]
        [Range(0, 10, ErrorMessage = "{0} should be between {1} and {2}")]
        public byte Speed { get; set; }

        [Required]
        [Range(0, 10, ErrorMessage = "{0} should be between {1} and {2}")]
        public byte Endurance { get; set; }

        [Required]
        [StringLength(200, ErrorMessage = "{0} should be less than {1} symbols")]
        public string Description { get; set; }
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
