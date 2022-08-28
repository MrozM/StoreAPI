using Core.Models;

namespace Core;

public interface IAccountService
{ 
    void CreateAccount(User user, string password);
    string GenerateJwt(LoginDto dto);
    User CheckIfAccountExist(LoginDto dto);
    bool CheckIfMailExist(string mail);
}