namespace TeisterMask.Data.Models
{
    using System;
    using System.Collections.Generic;

    using System.ComponentModel.DataAnnotations;

    using Common;

    public class Project
    {
        public Project()
        {
            Tasks = new HashSet<Task>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(EntityConstants.PROJECT_NAME_MAX_LENGTH)]
        public string Name { get; set; }
        
        public DateTime OpenDate { get; set; }

        public DateTime? DueDate { get; set; }

        public virtual ICollection<Task> Tasks { get; set; }

    }
}
