using Core;
using Core.Models;
using Microsoft.AspNetCore.Identity;

namespace Infrastructure;

public class AccountRepository : IAccountRepository
{
    private readonly StoreContext _context;
    private readonly IPasswordHasher<User> _passwordHasher;

    public AccountRepository(StoreContext context, IPasswordHasher<User> passwordHasher)
    {
        _context = context;
        _passwordHasher = passwordHasher;
    }
    public void RegisterUser(User user, string password)
    {
        var hashedPassword = _passwordHasher.HashPassword(user, password);
        user.PasswordHash = hashedPassword;
        _context.Users.Add(user);
        _context.SaveChanges();
    }
}