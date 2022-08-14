using Core;
using Core.Models;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure;

public class StoreContext : DbContext
{
    public StoreContext(DbContextOptions<StoreContext> options) : base(options) { }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Product>()
            .Property(p => p.Name)
            .IsRequired();
        modelBuilder.Entity<Order>();
        modelBuilder.Entity<User>()
            .Property(u => u.Username)
            .IsRequired();
        modelBuilder.Entity<Role>()
            .Property(r => r.Name)
            .IsRequired();
    }

    public DbSet<Product> Products { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<Role> Roles { get; set; }

}