using Core.Models;

namespace Core;


public interface IAccountRepository
{
    void RegisterUser(User user);
    User? CheckIfAccountExist(LoginDto dto);
    User? CheckIfMailExist(string mail);

}