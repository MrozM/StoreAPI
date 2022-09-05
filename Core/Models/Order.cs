namespace Core.Models;

public class Order
{
    public long Id { get; set; }
    public IEnumerable<OrderItem> Items { get; set; }
    public long UserId { get; set; }
}