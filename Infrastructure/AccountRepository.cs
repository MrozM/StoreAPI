using System.Security.Claims;
using System.Text;
using Core;
using Core.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Store;

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
    public void RegisterUser(User user)
    {
        _context.Users.Add(user);
        _context.SaveChanges();
    }
    

    public User CheckIfExist(LoginDto dto)
    {
        var user = _context.Users.Include(u => u.Role).FirstOrDefault(u => u.Email == dto.Email);

        return user;
    }
}