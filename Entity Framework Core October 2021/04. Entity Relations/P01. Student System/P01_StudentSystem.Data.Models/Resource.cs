namespace P01_StudentSystem.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    using Enumerations;

    public class Resource
    {        
        [Key]
        public int ResourceId { get; set; }

        [Required]
        [StringLength(50)]        
        public string Name { get; set; }

        [StringLength(2048)]
        public string Url { get; set; }

        [Required]
        public ResourceType ResourceType  { get; set; }

        [ForeignKey(nameof(Course))]
        public int CourseId { get; set; }

        public virtual Course Course { get; set; }

    }
}
