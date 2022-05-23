namespace P01_StudentSystem.Data
{
    using Microsoft.EntityFrameworkCore;

    using Models;

    public class StudentSystemContext : DbContext
    {
        public StudentSystemContext()
        {
        }

        public StudentSystemContext(DbContextOptions options)
            : base(options)
        {
        }

        public virtual DbSet<Course> Courses { get; set; }

        public virtual DbSet<Homework> HomeworkSubmissions { get; set; }

        public virtual DbSet<Resource> Resources { get; set; }

        public virtual DbSet<Student> Students { get; set; }

        public virtual DbSet<StudentCourse> StudentCourses { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(Connection.CONNECTION);
            }
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<StudentCourse>(sc => sc.HasKey(sc => new { sc.StudentId, sc.CourseId }));           

            builder.Entity<Student>(s =>
            {
                s.Property(s => s.Name).IsUnicode(true);
                s.Property(s => s.PhoneNumber).IsUnicode(false);
            });

            builder.Entity<Course>(c =>
            {
                c.Property(c => c.Name).IsUnicode(true);
                c.Property(c => c.Description).IsUnicode(true);
            });

            builder.Entity<Resource>(r =>
            {
                r.Property(r => r.Name).IsUnicode(true);
                r.Property(r => r.Url).IsUnicode(false);
            });

            builder.Entity<Homework>(h =>
            {
                h.Property(h => h.Content).IsUnicode(false);
            });

        }

    }
}
