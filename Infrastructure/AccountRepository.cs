using Core;
using Core.Models;

namespace Infrastructure;

public class AccountRepository : IAccountRepository
{
    private readonly StoreContext _context;
    public AccountRepository(StoreContext context)
    {
        _context = context;
    }
    public void RegisterUser(User user)
    {
        _context.Users.Add(user);
        _context.SaveChanges();
    }
}