
namespace Core.Models;

public class OrderItem
{
    public long Id { get; set; }
    public long ProductId { get; set; }
    public int Quantity { get; set; }

}