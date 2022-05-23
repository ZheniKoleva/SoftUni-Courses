using System;
using System.ComponentModel.DataAnnotations;

namespace SMS.ViewModels
{
    public class ProductCreateModel
    {
        [Required]
        [StringLength(20, MinimumLength = 4, ErrorMessage = "Product name should be between {2} and {1} symbols")]
        public string Name { get; set; }

        [Range(typeof(decimal),"0.05", "1000", ErrorMessage = "{0} should be between {1} and {2}", ParseLimitsInInvariantCulture = true)]
        public decimal Price { get; set; }
    }

    //•	Has an Id – a string, Primary Key
    //•	Has a Name – a string with min length 4 and max length 20 (required)
    //•	Has Price – a decimal (in range 0.05 – 1000)
    //•	Has a Cart – a Cart object
}
