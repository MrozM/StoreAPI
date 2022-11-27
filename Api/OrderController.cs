using AutoMapper;
using Core;
using Core.Interfaces;
using Core.Models;
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
    public async Task<ActionResult<IEnumerable<OrderItem>>> GetOrders([FromRoute]long userId)
    {
        var orders = await _orderService.GetOrders(userId);
        return Ok(orders);
    }

    [HttpPost]
    public async Task<ActionResult> PostOrder([FromBody]OrderDto orderDto)
    {
        var order = _mapper.Map<Order>(orderDto);
        await _orderService.PostOrder(order);
        
        return NoContent();
    }
}