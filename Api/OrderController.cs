using Core.Models;
using Infrastructure.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Store;

[Route("api/[controller]")]
[ApiController]
[Authorize]
public class OrderController : Controller
{
    [HttpGet("{userId}")]
    public ActionResult<IEnumerable<OrderItem>> GetOrder([FromRoute]long userId)
    {
        //pobieram dane
        return Ok();
    }

    [HttpPost]
    public ActionResult PostOrder()
    {
       

        return NoContent();
    }
}