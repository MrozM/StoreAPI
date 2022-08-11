using Core;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure;

public class StoreContext : DbContext
{
    public StoreContext(DbContextOptions<StoreContext> options) : base(options) { }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Product>();
        modelBuilder.Entity<Order>();
    }

    public DbSet<Product> Products { get; set; }
    public DbSet<Order> Orders { get; set; }

}