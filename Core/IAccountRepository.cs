using Core.Models;

namespace Core;


public interface IAccountRepository
{
    void RegisterUser(User user);
    User CheckIfExist(LoginDto dto);
}