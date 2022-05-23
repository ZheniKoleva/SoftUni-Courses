using System.ComponentModel.DataAnnotations;

namespace BusStation.ViewModels.Destinations
{
    public class DestinationAddModel
    {
        [Required]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "{0} should be between {2} and {1} symbols")]
        public string DestinationName { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "{0} should be between {2} and {1} symbols")]
        public string Origin { get; set; }

        [Required]
        [StringLength(30)]
        public string Date { get; set; }

       
        [Required]
        [StringLength(2048, ErrorMessage = "{0} should be less than {1} symbols")]
        public string ImageUrl { get; set; }

    }
}

//•	Has Id – an int, Primary Key
//•	Has DestinationName – a string with min length 2 and max length 50 (required)
//•	Has Origin – a string with min length 2 and max length 50 (required)
//•	Has Date – a string with max length 30 (required). We recommend using "d" as a date format.The date cannot be smaller than the date of the creation of the destination.
//•	Has Time – a string with max length 30 (required). We recommend using "t" as a time format.
//•	Has ImageUrl – a string (required)
//•	Has Tickets collection

