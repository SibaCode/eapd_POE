
using Microsoft.EntityFrameworkCore;
using AgriEnergyConnect.Models;  // Make sure to import your models

namespace AgriEnergyConnect.Data
{
public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) {}

    public DbSet<Farmer> Farmers { get; set; }
    public DbSet<Employee> Employees { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<MarketplaceItem> MarketplaceItems { get; set; }
    public DbSet<Resource> Resources { get; set; }
}
}
