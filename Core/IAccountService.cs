using Core.Models;

namespace Core;

public interface IAccountService
{ 
    void RegisterUser(User user, string password);
    string GenerateJwt(LoginDto dto);
}