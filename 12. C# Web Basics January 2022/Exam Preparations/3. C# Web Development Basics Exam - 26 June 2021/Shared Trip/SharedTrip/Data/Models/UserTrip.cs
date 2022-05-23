using System.ComponentModel.DataAnnotations.Schema;

namespace SharedTrip.Data.Models
{
    public class UserTrip
    {
        [ForeignKey(nameof(User))]
        public string UserId { get; set; }

        public User User { get; set; }


        [ForeignKey(nameof(Trip))]
        public string TripId { get; set; }

        public Trip Trip { get; set; }
    }
}

//•	Has UserId – a string
//•	Has User – a User object
//•	Has TripId– a string
//•	Has Trip – a Trip object
