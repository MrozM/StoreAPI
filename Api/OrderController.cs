using AutoMapper;
using Core;
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
    private readonly IMapper _mapper;
    private readonly IOrderService _orderService;

    public OrderController(IMapper mapper, IOrderService orderService)
    {
        _mapper = mapper;
        _orderService = orderService;
    }
    [HttpGet("{userId}")]
    public ActionResult<IEnumerable<OrderItem>> GetOrder([FromRoute]long userId)
    {
        //pobieram dane
        return Ok();
    }

    [HttpPost]
    public ActionResult PostOrder([FromBody]OrderDto orderDto)
    {
        var order = _mapper.Map<Order>(orderDto);
        _orderService.PostOrder(order);
        
        return NoContent();
    }
}