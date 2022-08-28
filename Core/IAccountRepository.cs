using Core.Models;

namespace Core;


public interface IAccountRepository
{
    void CreateAccount(User user);
    User CheckIfAccountExist(LoginDto dto);
    bool CheckIfMailExist(string mail);

}