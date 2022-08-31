using Core.Models;

namespace Store.Dtos;

public class OrderDto
{
    public IEnumerable<OrderItem> Items { get; set; }
    public User User { get; set; }
}