namespace SoftJail.Data.Models
{
    using System;
    using System.Collections.Generic;

    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    
    using Common;

    public class Cell
    {
        public Cell()
        {
            Prisoners = new HashSet<Prisoner>();
        }

        [Key]
        public int Id { get; set; }
        
        [Range(EntityConstants.Cell_CellNumber_Min, EntityConstants.Cell_CellNumber_Max)]
        public int CellNumber { get; set; }
        
        public bool HasWindow { get; set; }
        
        [ForeignKey(nameof(Department))]
        public int DepartmentId { get; set; }
        public Department Department { get; set; }

        public ICollection<Prisoner> Prisoners { get; set; }

    }

}
