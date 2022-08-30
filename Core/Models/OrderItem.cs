using Infrastructure.Models;

namespace Core.Models;

public class OrderItem
{
    public long Id { get; set; }
    public Product Product { get; set; }
    public int Quantity { get; set; }

    public long ProductId { get; set; }
}

