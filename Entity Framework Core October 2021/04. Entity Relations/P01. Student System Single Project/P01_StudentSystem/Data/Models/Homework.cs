namespace P01_StudentSystem.Data.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    using Enumerations;

    [Table("HomeworkSubmissions")]
    public class Homework
    {
        [Key]
        public int HomeworkId { get; set; }

        [Required]
        [StringLength(2048)]       
        public string Content { get; set; }

        [Required]
        public ContentType ContentType { get; set; }
        
        public DateTime SubmissionTime { get; set; }

        [ForeignKey(nameof(Student))]
        public int StudentId { get; set; }

        public Student Student { get; set; }

        [ForeignKey(nameof(Course))]
        public int CourseId { get; set; }

        public Course Course { get; set; }
    }
}
