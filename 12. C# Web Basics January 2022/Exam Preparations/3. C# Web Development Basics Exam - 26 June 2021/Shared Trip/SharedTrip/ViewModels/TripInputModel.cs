using System;
using System.ComponentModel.DataAnnotations;

namespace SharedTrip.ViewModels
{
    public class TripInputModel
    {
        [Required]
        public string StartPoint { get; set; }

        [Required]
        public string EndPoint { get; set; }

        public string DepartureTime { get; set; }

        [Range(2, 6)]
        public int Seats { get; set; }

        [Required]
        [StringLength(80)]
        public string Description { get; set; }

        public string ImagePath { get; set; }
        
    }

    //•	Has an Id – a string, Primary Key
    //•	Has a StartPoint – a string (required)
    //•	Has a EndPoint – a string (required)
    //•	Has a DepartureTime – a datetime (required) 
    //•	Has a Seats – an integer with min value 2 and max value 6 (required)
    //•	Has a Description – a string with max length 80 (required)
    //•	Has a ImagePath – a string
    //•	Has UserTrips collection – a UserTrip type
}
