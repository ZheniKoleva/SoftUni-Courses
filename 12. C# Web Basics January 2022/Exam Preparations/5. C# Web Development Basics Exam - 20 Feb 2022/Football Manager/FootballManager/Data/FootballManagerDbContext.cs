namespace FootballManager.Data
{
    using FootballManager.Data.Models;
    using Microsoft.EntityFrameworkCore;
    public class FootballManagerDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(@"Server=.\SQLEXPRESS;Database=FootballManager;Integrated Security=True;");
            }
        }

        public DbSet<User> Users { get; set; }

        public DbSet<Player> Players { get; set; }

        public DbSet<UserPlayers> UserPlayers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserPlayers>()
                .HasKey(x => new { x.UserId, x.PlayerId });
        }
    }
}
