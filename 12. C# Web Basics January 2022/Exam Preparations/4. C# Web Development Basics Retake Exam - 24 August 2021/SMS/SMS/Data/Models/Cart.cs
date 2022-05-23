using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SMS.Data.Models
{
    public class Cart
    {
        public Cart()
        {
            Id = Guid.NewGuid().ToString();
            Products = new HashSet<Product>();
        }

        [Key]
        [StringLength(36)]
        public string Id { get; set; }

        [Required]    
        public User User { get; set; }

        public ICollection<Product> Products { get; set; }
    }

//•	Has an Id – a string, Primary Key
//•	Has User – a User object (required)
//•	Has Products – a collection of Products

}
