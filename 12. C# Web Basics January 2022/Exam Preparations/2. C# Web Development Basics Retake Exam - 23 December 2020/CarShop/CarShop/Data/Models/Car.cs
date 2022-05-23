using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarShop.Data.Models
{
    public class Car
    {
        public Car()
        {
            Id = Guid.NewGuid().ToString();
        }

        [Key]
        [StringLength(36)]
        public string Id { get; set; }

        [Required]
        [StringLength(20)]
        public string Model { get; set; }
       
        public int Year { get; set; }


        [Required]
        [StringLength(256)]
        public string PictureUrl { get; set; }


        [Required]
        [StringLength(8)]
        public string PlateNumber { get; set; }


        [Required]
        [ForeignKey(nameof(Owner))]
        public string OwnerId { get; set; }
        public User Owner { get; set; }

        public ICollection<Issue> Issues { get; set; }
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

