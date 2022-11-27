using Core.Interfaces;
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
    public void CreateAccount(User user)
    {
        _context.Users.Add(user);
        _context.SaveChanges();
    }

    public User CheckIfAccountExist(User user) =>  _context.Users.Include(u => u.Role).FirstOrDefault(u => u.Email == user.Email);
    
    public bool CheckIfMailExist(string mail) => _context.Users.Any(u => u.Email == mail);
}