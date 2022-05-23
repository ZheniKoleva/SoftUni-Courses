using System.ComponentModel.DataAnnotations;

namespace BusStation.ViewModels.Tickets
{
    public class TicketCreateModel
    {
        [Required]
        [Range(typeof(decimal), "10", "90", ErrorMessage = "{0} should be between {1} and {2} euros")]
        public decimal Price { get; set; }

        [Required]
        [Range(1, 10, ErrorMessage = "Tickets count should be between 1 and 10")]
        public int TicketsCount { get; set; }
    }
}

//•	Has Id – an int, Primary Key
//•	Has Price – a decimal, between 10 and 90
//•	Has UserId – an int
//•	Has DestinationId – an int

