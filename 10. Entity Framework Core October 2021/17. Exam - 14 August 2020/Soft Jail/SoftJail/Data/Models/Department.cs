namespace SoftJail.Data.Models
{
    using System.Collections.Generic;

    using System.ComponentModel.DataAnnotations;

    using Common;

    public class Department
    {
        public Department()
        {
            Cells = new HashSet<Cell>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(EntityConstants.Department_Name_Max_Length)]
        public string Name { get; set; }

        public ICollection<Cell> Cells { get; set; }

    }

}
