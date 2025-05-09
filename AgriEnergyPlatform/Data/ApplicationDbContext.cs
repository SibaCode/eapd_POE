using Microsoft.EntityFrameworkCore;
using AgriEnergyPlatform.Models;  // Replace with your project namespace
namespace AgriEnergyPlatform.Data
{
public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

    public DbSet<User> Users { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<Content> Contents { get; set; }
}
}
