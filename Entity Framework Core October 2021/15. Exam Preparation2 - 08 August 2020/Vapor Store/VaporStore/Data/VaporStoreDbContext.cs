namespace VaporStore.Data
{
	using Microsoft.EntityFrameworkCore;
    using VaporStore.Data.Models;

    public class VaporStoreDbContext : DbContext
	{
		public VaporStoreDbContext()
		{
		}

		public VaporStoreDbContext(DbContextOptions options)
			: base(options)
		{
		}

		public virtual DbSet<Game> Games { get; set; }
		public virtual DbSet<Developer> Developers { get; set; }
		public virtual DbSet<Genre> Genres { get; set; }
		public virtual DbSet<Tag> Tags { get; set; }
		public virtual DbSet<GameTag> GameTags { get; set; }
		public virtual DbSet<User> Users { get; set; }
		public virtual DbSet<Card> Cards { get; set; }
		public virtual DbSet<Purchase> Purchases { get; set; }

		protected override void OnConfiguring(DbContextOptionsBuilder options)
		{
			if (!options.IsConfigured)
			{
				options
					.UseSqlServer(Configuration.ConnectionString);
			}
		}

		protected override void OnModelCreating(ModelBuilder model)
		{
			model.Entity<GameTag>()
				.HasKey(gt => new { gt.GameId, gt.TagId});
		}
	}
}