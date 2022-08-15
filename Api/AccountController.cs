using AutoMapper;
using Core;
using Core.Models;
using Microsoft.AspNetCore.Mvc;

namespace Store;

[Route("api/account")]
[ApiController]
public class AccountController : Controller
{
    private readonly IAccountService _accountService;
    private readonly IMapper _mapper;

    public AccountController(IAccountService accountService, IMapper mapper)
    {
        _mapper = mapper;
        _accountService = accountService;
    }
    [HttpPost("register")]
    public ActionResult RegisterUser([FromBody]RegisterUserDto dto)
    {
        var user = _mapper.Map<User>(dto);
        _accountService.RegisterUser(user, dto.Password);
        return Ok();
    }

    [HttpPost("login")]
    public ActionResult Login([FromBody]LoginDto dto)
    {
        string token = _accountService.GenerateJwt(dto);
        return Ok(token);
    }
}