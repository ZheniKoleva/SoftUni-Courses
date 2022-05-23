namespace P03_FootballBetting.Data
{
    using Microsoft.EntityFrameworkCore;
    using Models;

    public class FootballBettingContext : DbContext
    {
        public FootballBettingContext()
        {
        }

        public FootballBettingContext(DbContextOptions options)
            :base(options)
        {
        }

        public virtual DbSet<Bet> Bets { get; set; }

        public virtual DbSet<Color> Colors { get; set; }

        public virtual DbSet<Country> Countries { get; set; }

        public virtual DbSet<Game> Games { get; set; }

        public virtual DbSet<Player> Players { get; set; }

        public virtual DbSet<PlayerStatistic> PlayerStatistics { get; set; }

        public virtual DbSet<Position> Positions { get; set; }

        public virtual DbSet<Team> Teams { get; set; }

        public virtual DbSet<Town> Towns { get; set; }

        public virtual DbSet<User> Users { get; set; }


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

            builder.Entity<PlayerStatistic>(ps => ps.HasKey(ps => new { ps.PlayerId, ps.GameId }));
            builder.Entity<Team>(x =>
            {
                x.HasOne(e => e.PrimaryKitColor)
                .WithMany(c => c.PrimaryKitTeams)
                .HasForeignKey(e => e.PrimaryKitColorId)
                .OnDelete(DeleteBehavior.Restrict);

                x.HasOne(e => e.SecondaryKitColor)
                .WithMany(c => c.SecondaryKitTeams)
                .HasForeignKey(e => e.SecondaryKitColorId)
                .OnDelete(DeleteBehavior.Restrict);

                x.HasOne(e => e.Town)
               .WithMany(t => t.Teams)
               .HasForeignKey(e => e.TownId)
               .OnDelete(DeleteBehavior.Restrict);

            });           

            builder.Entity<Game>(x =>
            {

                x.HasOne(g => g.HomeTeam)
                 .WithMany(ht => ht.HomeGames)
                 .HasForeignKey(g => g.HomeTeamId)
                 .OnDelete(DeleteBehavior.Restrict);

                x.HasOne(g => g.AwayTeam)
                 .WithMany(at => at.AwayGames)
                 .HasForeignKey(g => g.AwayTeamId)
                .OnDelete(DeleteBehavior.Restrict);
            });

        }
    }
}
