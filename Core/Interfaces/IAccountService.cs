using Core.Models;

namespace Core.Interfaces;

public interface IAccountService
{ 
    void CreateAccount(User user, string password);
    string GenerateJwt(User user, string userPassword);
    User CheckIfAccountExist(User user);
    bool CheckIfMailExist(string mail);
}