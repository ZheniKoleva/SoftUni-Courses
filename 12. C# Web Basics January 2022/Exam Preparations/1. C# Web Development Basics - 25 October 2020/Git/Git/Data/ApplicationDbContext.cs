using Git.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Git.Data
{
    public class ApplicationDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(@"Server=.\SQLEXPRESS;Database=Git;Integrated Security=true;");
            }
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Commit>()
                .HasOne(x => x.Creator)  
                .WithMany(x => x.Commits)
                .OnDelete(DeleteBehavior.Restrict);                
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Commit> Commits { get; set; }
        public DbSet<Repository> Repositories { get; set; }
    }
}
