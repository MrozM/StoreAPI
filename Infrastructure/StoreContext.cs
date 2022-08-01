using Core;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure;

public class StoreContext : DbContext
{
    public DbSet<Product> Products { get; set; }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseInMemoryDatabase("test");
    }
}   