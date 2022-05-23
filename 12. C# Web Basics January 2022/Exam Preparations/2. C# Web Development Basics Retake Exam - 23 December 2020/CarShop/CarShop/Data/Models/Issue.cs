using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarShop.Data.Models
{
    public class Issue
    {
        public Issue()
        {
            Id = Guid.NewGuid().ToString();
        }

        [Key]
        [StringLength(36)]
        public string Id { get; set; }

        [Required]
        [StringLength(1024)]
        public string Description { get; set; }
           
        public bool IsFixed { get; set; }


        [Required]
        [ForeignKey(nameof(Car))]
        public string CarId { get; set; }
        public Car Car { get; set; }
    }
}

//•	Has an Id – a string, Primary Key
//•	Has a Description – a string with min length 5 (required)
//•	Has a IsFixed – a bool indicating if the issue has been fixed or not (required)
//•	Has a CarId – a string (required)
//•	Has Car – a Car object

