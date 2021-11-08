namespace P01_StudentSystem.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Student
    {
        public Student()
        {
            this.CourseEnrollments = new HashSet<StudentCourse>();
            this.HomeworkSubmissions = new HashSet<Homework>();
        }

        [Key]
        public int StudentId { get; set; }

        [Required]
        [StringLength(100)]        
        public string Name { get; set; }

        [StringLength(10)]
        public string PhoneNumber  { get; set; }
        
        public DateTime RegisteredOn { get; set; }

        public DateTime? Birthday  { get; set; }                
        
        public virtual ICollection<StudentCourse> CourseEnrollments { get; set; }
        
        public virtual ICollection<Homework> HomeworkSubmissions { get; set; }

    }
}
