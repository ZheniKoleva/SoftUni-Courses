namespace Artillery.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    
    using Artillery.Common;

    public class Manufacturer
    {
        public Manufacturer()
        {
            Guns = new HashSet<Gun>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(EntityConstants.Manufacturer_Name_Max_Lenght)] 
        public string ManufacturerName  { get; set; }

        [Required]
        [MaxLength(EntityConstants.Manufacturer_Founded_Max_Lenght)]
        public string Founded  { get; set; }

        public virtual ICollection<Gun> Guns { get; set; }

    }
}
