using Core.Models;

namespace Core;


public interface IAccountRepository
{
    void CreateAccount(User user);
    User CheckIfAccountExist(User user);
    bool CheckIfMailExist(string mail);

}