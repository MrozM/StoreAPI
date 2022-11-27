using AutoMapper;
using Core;
using Core.Interfaces;
using Core.Models;
using Microsoft.AspNetCore.Mvc;
using Store.Dtos;

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
    public ActionResult CreateAccount([FromBody]RegisterUserDto dto)
    {
        var user = _mapper.Map<User>(dto);
        _accountService.CreateAccount(user, dto.Password);
        return Ok();
    }

    [HttpPost("login")]
    public ActionResult Login([FromBody]LoginDto dto)
    {
        var userPassword = dto.Password;
        var user = _mapper.Map<User>(dto);
        string token = _accountService.GenerateJwt(user, userPassword);
        return Ok(token);
    }
}