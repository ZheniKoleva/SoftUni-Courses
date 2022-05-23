namespace SoftJail.Data.Models
{
    using System;
    using System.Collections.Generic;

    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    using Common;
    using Enums;

    public class Officer
    {
        public Officer()
        {
            OfficerPrisoners = new HashSet<OfficerPrisoner>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(EntityConstants.Officer_FullName_Max_Length)]
        public string FullName { get; set; }
        
        [Range(typeof(decimal),EntityConstants.Officer_Salary_Min, EntityConstants.Officer_Salary_Max)]
        public decimal Salary { get; set; }

        public Position Position { get; set; }

        public Weapon Weapon { get; set; }
        
        [ForeignKey(nameof(Department))]
        public int DepartmentId { get; set; }
        public virtual Department Department { get; set; }

        public ICollection<OfficerPrisoner> OfficerPrisoners { get; set; }
    }
}
