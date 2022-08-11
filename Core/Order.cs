namespace Core;

public class Order
{
    public long Id { get; set; }
    public IEnumerable<Product> Products { get; set; }
}