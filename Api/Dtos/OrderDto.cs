using Core.Models;

namespace Store.Dtos;

public class OrderDto
{
    public IEnumerable<OrderItemDto> Items { get; set; }
    public long UserId { get; set; }
}