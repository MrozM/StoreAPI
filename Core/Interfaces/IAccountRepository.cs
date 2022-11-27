using Core.Models;

namespace Core.Interfaces;


public interface IAccountRepository
{
    void CreateAccount(User user);
    User CheckIfAccountExist(User user);
    bool CheckIfMailExist(string mail);

}