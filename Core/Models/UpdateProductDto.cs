namespace Infrastructure.Models;

public class UpdateProductDto
{
    public string Description { get; set; }
    public int Quantity { get; set; }
    public decimal Price { get; set; }
}