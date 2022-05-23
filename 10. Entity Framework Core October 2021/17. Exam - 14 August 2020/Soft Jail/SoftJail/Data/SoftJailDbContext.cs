namespace SoftJail.Data
{
	using Microsoft.EntityFrameworkCore;

    using Models;

    public class SoftJailDbContext : DbContext
	{
		public SoftJailDbContext()
		{
		}

		public SoftJailDbContext(DbContextOptions options)
			: base(options)
		{
		}

        public virtual DbSet<Prisoner> Prisoners { get; set; }
        public virtual DbSet<Officer> Officers { get; set; }
        public virtual DbSet<Cell> Cells { get; set; }
        public virtual DbSet<Mail> Mails { get; set; }
        public virtual DbSet<Department> Departments { get; set; }
        public virtual DbSet<OfficerPrisoner> OfficersPrisoners { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			if (!optionsBuilder.IsConfigured)
			{
				optionsBuilder
					.UseSqlServer(Configuration.ConnectionString);
			}
		}

		protected override void OnModelCreating(ModelBuilder builder)
		{
			builder.Entity<OfficerPrisoner>()
				.HasKey(op => new { op.PrisonerId, op.OfficerId});

			builder.Entity<OfficerPrisoner>()
				.HasOne(op => op.Prisoner)
				.WithMany(op => op.PrisonerOfficers)
				.HasForeignKey(op => op.PrisonerId)
				.OnDelete(DeleteBehavior.Restrict);

			builder.Entity<OfficerPrisoner>()
				.HasOne(op => op.Officer)
				.WithMany(op => op.OfficerPrisoners)
				.HasForeignKey(op => op.OfficerId)
				.OnDelete(DeleteBehavior.Restrict);
		}
	}
}