using Core;
using Infrastructure.Models;

namespace Infrastructure;

public class ProductRepository : IProductRepository
{
    private readonly StoreContext _context;

    public ProductRepository(StoreContext storeContext)
    {
        _context = storeContext;
    }


    public bool CheckIfExist(int id)
    {
        return _context.Products.Any(p => p.Id == id);
    }
    
    public IEnumerable<ProductDto> GetAll()
    {
        var products = _context.Products.ToList();

        var productDto = products.Select(r => new ProductDto()
        {
            Name = r.Name,
            Description = r.Description,
            Quantity = r.Quantity,
            Price = r.Price
        });

        return productDto;
    }
    public void Add(CreateProductDto dto)
    {
        var product = new Product()
        {
            Name = dto.Name,
            Description = dto.Description,
            Quantity = dto.Quantity,
            Price = dto.Price,
        };
        _context.Products.Add(product);
        _context.SaveChanges();
    }

    public bool Update(Product product)
    {
        _context.Products.Update(product);
        _context.SaveChanges();
        return true; //zmienić na void
    }

    public bool Delete(int id)
    {
        var product = _context.Products.FirstOrDefault(p => p.Id == id);
        
        if (product is null) return false;

        _context.Products.Remove(product);
        _context.SaveChanges();

        return true;
    }

    public Product? GetById(int id)
    {
        var product = _context.Products.FirstOrDefault(p => p.Id == id);

        return product;
    }
}