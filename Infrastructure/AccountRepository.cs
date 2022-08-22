using Core;
using Core.Models;
using Microsoft.EntityFrameworkCore;

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

    public User? CheckIfAccountExist(LoginDto dto)
    {
        var user = _context.Users.Include(u => u.Role).FirstOrDefault(u => u.Email == dto.Email);

        return user;
    }

    public User? CheckIfMailExist(string mail)
    {
        var user = _context.Users.FirstOrDefault(u => u.Email == mail);

        return user;
    }
}