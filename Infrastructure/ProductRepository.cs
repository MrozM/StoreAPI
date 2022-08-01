using Core;

namespace Infrastructure;

public class ProductRepository : IProductRepository
{
    private readonly StoreContext _context;

    public ProductRepository(StoreContext storeContext)
    {
        _context = storeContext;
    }


    public IEnumerable<Product> GetAll()
    {
        var products = _context.Products.ToList();

        return products;
    }
    public void Add(Product product)
    {
        _context.Products.Add(product);
        _context.SaveChanges();
    }

    public bool Update(int id, string name)
    {
        var product = _context.Products.FirstOrDefault(p => p.Id == id);

        if (product is null) return false;
        
        product.Name = name; 
        _context.SaveChanges();
        return true;
    }

    public bool Delete(int id)
    {
        var product = _context.Products.FirstOrDefault(p => p.Id == id);
        
        if (product is null) return false;

        _context.Products.Remove(product);
        _context.SaveChanges();

        return true;
    }

    public Product GetById(int id)
    {
        var product = _context.Products.FirstOrDefault(p => p.Id == id);

        return product;
    }
}