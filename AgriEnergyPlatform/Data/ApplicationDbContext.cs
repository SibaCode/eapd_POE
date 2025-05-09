using Microsoft.EntityFrameworkCore;
using AgriEnergyPlatform.Models;

namespace AgriEnergyPlatform.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Farm> Farms { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<People> Peoples { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // // Configuring the relationship between Product and Farm
            // modelBuilder.Entity<Product>()
            //     .HasOne(p => p.Farm)  // Each Product has one Farm
            //     .WithMany(f => f.Products)  // Each Farm has many Products
            //     .HasForeignKey(p => p.FarmId)  // Foreign key in Product
            //     .OnDelete(DeleteBehavior.Restrict); // Prevent cascading delete

            // Configuring the relationship between Product and People (if this exists)
            modelBuilder.Entity<Product>()
                .HasOne(p => p.People)  // Each Product is linked to a People (Farmer)
                .WithMany()  // People have many Products
                .HasForeignKey(p => p.PeopleId)  // Foreign key in Product
                .OnDelete(DeleteBehavior.Restrict); // Prevent cascading delete (or use NoAction)

            // Additional relationships can be added here
        }
    }
}
