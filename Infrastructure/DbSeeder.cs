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
        }
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