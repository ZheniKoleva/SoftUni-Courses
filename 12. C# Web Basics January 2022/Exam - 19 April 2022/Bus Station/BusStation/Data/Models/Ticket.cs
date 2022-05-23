using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BusStation.Data.Models
{
    public class Ticket
    {
        [Key]
        public int Id { get; set; }

        [Column(TypeName = "money")]
        public decimal Price { get; set; }

        [Required] 
        //[ForeignKey(nameof(User))]
        public string UserId { get; set; }
        //public User User { get; set; }

        [Required]
        //[ForeignKey(nameof(Destination))]
        public int DestinationId { get; set; }
        //public Destination Destination { get; set; }
    }
}

//•	Has Id – an int, Primary Key
//•	Has Price – a decimal, between 10 and 90
//•	Has UserId – an int
//•	Has DestinationId – an int

