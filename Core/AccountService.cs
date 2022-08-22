using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Core.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using Store;

namespace Core;

public class AccountService : IAccountService
{
    private readonly IAccountRepository _accountRepository;
    private readonly IPasswordHasher<User> _passwordHasher;
    private readonly AuthenticationSettings _authenticationSettings;

    public AccountService(IAccountRepository accountRepository, IPasswordHasher<User> passwordHasher, AuthenticationSettings authenticationSettings)
    {
        _accountRepository = accountRepository;
        _passwordHasher = passwordHasher;
        _authenticationSettings = authenticationSettings;
    }

    public User? CheckIfAccountExist(LoginDto dto)
    {
        var user = _accountRepository.CheckIfAccountExist(dto);

        return user;
    }

    public User? CheckIfMailExist(string mail)
    {
        var user = _accountRepository.CheckIfMailExist(mail);

        return user;
    }

    public void RegisterUser(User user, string password)
    {
        var hashedPassword = _passwordHasher.HashPassword(user, password);
        user.PasswordHash = hashedPassword;
     _accountRepository.RegisterUser(user);
    }

    public string GenerateJwt(LoginDto dto)
    {
      var user = _accountRepository.CheckIfAccountExist(dto);
        
      if (user == null)
      {
          throw new BadHttpRequestException("Invalid username or password");
      }

      var result = _passwordHasher.VerifyHashedPassword(user, user.PasswordHash, dto.Password);
      if (result == PasswordVerificationResult.Failed)
      {
          throw new BadHttpRequestException("Invalid username or password");
      }

      var claims = new List<Claim>()
      {
          new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
          new Claim(ClaimTypes.Name, $"{user.Username}"),
          new Claim(ClaimTypes.Role, $"{user.Role.Name}")

      };

      var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_authenticationSettings.JwtKey));
      var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
      var expiringDate = DateTime.Now.AddDays(_authenticationSettings.JwtExpireDays);

      var token = new JwtSecurityToken(_authenticationSettings.JwtIssuer, _authenticationSettings.JwtIssuer, claims, expires: expiringDate ,signingCredentials: credentials);

      var tokenHandler = new JwtSecurityTokenHandler();
      return tokenHandler.WriteToken(token);
    }
}