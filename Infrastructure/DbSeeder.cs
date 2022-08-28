using Core.Models;

namespace Infrastructure;

public class DbSeeder
{
    private readonly StoreContext _context;

    public DbSeeder(StoreContext context)
    {
        _context = context;
    }

    public void Seed()
    {
        if (_context.Database.CanConnect())
        {
            if (!_context.Roles.Any())
            {
                var roles = GetRoles();
                _context.Roles.AddRange(roles);
                _context.SaveChanges();
            }

            if (!_context.Products.Any())
            {
                var products = GetProducts();
                _context.Products.AddRange(products);
                _context.SaveChanges();
            }
        }
    }

    private IEnumerable<Product> GetProducts()
    {
        var products = new List<Product>()
        {
            new Product()
            {
                Name = "flour",
                Description = "high quality flour",
                Price = 3.21m,
                Quantity = 2300
            },
            new Product()
            {
                Name = "bread",
                Description = "tasty bread",
                Price = 4.50m,
                Quantity = 250
            },
            new Product()
            {
                Name = "Soup",
                Description = "Soup with lots of flavour",
                Price = 7.3m,
                Quantity = 700
            }
        };

        return products;
    }
    private IEnumerable<Role> GetRoles()
    {
        var roles = new List<Role>()
        {
            new Role()
            {
                Name = "User"
            },
            new Role()
            {
                Name = "Admin"
            },
            new Role()
            {
                Name = "Manager"
            }
        };
        
        return roles;
    }
}