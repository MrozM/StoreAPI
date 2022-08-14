using Core.Models;

namespace Core;

public class AccountService : IAccountService
{
    private readonly IAccountRepository _accountRepository;
    
    public AccountService(IAccountRepository accountRepository)
    {
        _accountRepository = accountRepository;
    }
    
    public void RegisterUser(User user)
    {
     _accountRepository.RegisterUser(user);
    }
}