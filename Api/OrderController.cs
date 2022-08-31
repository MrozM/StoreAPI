using Core.Models;
using Infrastructure.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Store.Dtos;

namespace Store;

[Route("api/[controller]")]
[ApiController]
[Authorize]
public class OrderController : Controller
{
    [HttpGet("{userId}")]
    public ActionResult<IEnumerable<OrderItem>> GetOrder([FromRoute]long userId)
    {
        
        return Ok();
    }

    [HttpPost]
    public ActionResult PostOrder([FromBody]OrderDto order)
    {
        

        return Ok();
    }
}