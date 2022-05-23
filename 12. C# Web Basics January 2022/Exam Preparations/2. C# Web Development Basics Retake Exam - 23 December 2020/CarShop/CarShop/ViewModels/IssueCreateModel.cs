using System.ComponentModel.DataAnnotations;

namespace CarShop.ViewModels
{
    public class IssueCreateModel
    {
        [Required]
        [StringLength(1024, MinimumLength = 5, ErrorMessage = "{0} should be between {2} and {1} symbols")]
        public string Description { get; set; }        


        [Required]        
        public string CarId { get; set; }
    }
}

//•	Has an Id – a string, Primary Key
//•	Has a Description – a string with min length 5 (required)
//•	Has a IsFixed – a bool indicating if the issue has been fixed or not (required)
//•	Has a CarId – a string (required)
//•	Has Car – a Car object
