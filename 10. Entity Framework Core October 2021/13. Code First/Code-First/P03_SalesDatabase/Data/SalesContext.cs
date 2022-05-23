using Microsoft.EntityFrameworkCore;

using P03_SalesDatabase.Common;
using P03_SalesDatabase.Data.Models;

namespace P03_SalesDatabase.Data
{
    public class SalesContext : DbContext
    {
        public SalesContext()
        {
        }

        public SalesContext(DbContextOptions options) 
            : base(options)
        {
        }

        public virtual DbSet<Product> Products { get; set; }

        public virtual DbSet<Customer> Customers { get; set; }

        public virtual DbSet<Store> Stores { get; set; }

        public virtual DbSet<Sale> Sales { get; set; }

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

            builder.Entity<Product>(p =>
            {
                p.HasKey(p => p.ProductId);

                p.Property(p => p.Name)
                 .IsRequired(true)
                 .HasMaxLength(EntityConstants.PRODUCT_NAME_MAX_LENGTH)
                 .IsUnicode(true);

                p.Property(p => p.Quantity)
                 .IsRequired(true);

                p.Property(p => p.Price)
                 .IsRequired(true);

                // 04. Product Migration
                p.Property(p => p.Description)
                 .IsRequired(false)
                 .HasMaxLength(EntityConstants.PRODUCT_DESCRIPTION_MAX_LENGTH)
                 .HasDefaultValue(EntityConstants.PRODUCT_DESCRIPTION_DEFAULT_MESSAGE)
                 .IsUnicode(true);

            });

            builder.Entity<Customer>(c =>
            {
                c.HasKey(c => c.CustomerId);

                c.Property(c => c.Name)
                 .IsRequired(true)
                 .HasMaxLength(EntityConstants.CUSTOMER_NAME_MAX_LENGTH)
                 .IsUnicode(true);

                c.Property(c => c.Email)
                 .IsRequired(false)
                 .HasMaxLength(EntityConstants.CUSTOMER_EMAIL_MAX_LENGTH)
                 .IsUnicode(false);

                c.Property(c => c.CreditCardNumber)
                 .IsRequired(true)
                 .IsUnicode(true); 

            });

            builder.Entity<Store>(s =>
            {
                s.HasKey(s => s.StoreId);

                s.Property(s => s.Name)
                 .IsRequired(true)
                 .HasMaxLength(EntityConstants.STORE_NAME_MAX_LENGTH)
                 .IsUnicode(true);
                
            });

            builder.Entity<Sale>(s =>
            {
                s.HasKey(s => s.SaleId);

                s.Property(s => s.Date)
                 .IsRequired(true)
                 .HasColumnType("DATETIME2")           // 05. Sales Migration
                 .HasDefaultValueSql("GETDATE()");     //  05. Sales Migration          

                s.HasOne(s => s.Product)
                 .WithMany(s => s.Sales)
                 .HasForeignKey(s => s.ProductId);

                s.HasOne(s => s.Customer)
                 .WithMany(s => s.Sales)
                 .HasForeignKey(s => s.CustomerId);

                s.HasOne(s => s.Store)
                .WithMany(s => s.Sales)
                .HasForeignKey(s => s.StoreId);

            });  

        }
    }
}
