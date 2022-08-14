using Infrastructure.Models;

namespace Core.Models;

public class Product
{
    public long Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public int Quantity { get; set; }
    public decimal Price { get; set; }
    public long? OrderId { get; set; }
    public virtual Order Order { get; set; }

    public void UpdateFromDto(UpdateProductDto dto)
    {
        Description = dto.Description;
        Quantity = dto.Quantity;
        Price = dto.Price;
    }
}