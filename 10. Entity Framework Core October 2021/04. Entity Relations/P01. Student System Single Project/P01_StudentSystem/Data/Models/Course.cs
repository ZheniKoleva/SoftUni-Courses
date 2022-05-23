namespace P01_StudentSystem.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Course
    {       
        public Course()
        {
            this.StudentsEnrolled = new HashSet<StudentCourse>();
            this.Resources = new HashSet<Resource>();
            this.HomeworkSubmissions = new HashSet<Homework>();
        }


        [Key]
        public int CourseId { get; set; }

        [Required]
        [StringLength(80)]       
        public string Name { get; set; }
        
        public string Description  { get; set; }        
             
        public DateTime StartDate { get; set; }
                
        public DateTime EndDate { get; set; }
              
        public decimal Price { get; set; }     
        
        public virtual ICollection<StudentCourse> StudentsEnrolled { get; set; }
       
        public virtual ICollection<Resource> Resources { get; set; }
                
        public virtual ICollection<Homework> HomeworkSubmissions { get; set; }

    }
}
