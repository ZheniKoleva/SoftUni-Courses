using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SMS.Data.Models
{
    public class Product
    {
        public Product()
        {
            Id = Guid.NewGuid().ToString();
        }

        [Key]
        [StringLength(36)]
        public string Id { get; set; }

        [Required]
        [StringLength(20)]
        public string Name { get; set; }       

        //[Range(0.05, 1000)]
        [Column(TypeName = "money")]
        public decimal Price { get; set; }

       
        [StringLength(36)]
        [ForeignKey(nameof(Cart))]
        public string CartId { get; set; }
        public Cart Cart { get; set; }
    }

//•	Has an Id – a string, Primary Key
//•	Has a Name – a string with min length 4 and max length 20 (required)
//•	Has Price – a decimal (in range 0.05 – 1000)
//•	Has a Cart – a Cart object

}
