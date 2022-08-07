using Core;

namespace Infrastructure;

public class ProductRepository : IProductRepository
{
    private readonly StoreContext _context;

    public ProductRepository(StoreContext storeContext)
    {
        _context = storeContext;
    }


    public bool CheckIfExist(long id)
    {
        return _context.Products.Any(p => p.Id == id);
    }
    
    public Product? GetById(long id)
    {
        var product = _context.Products.FirstOrDefault(p => p.Id == id);

        return product;
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

    public void Update(Product product)
    {
        _context.Products.Update(product);
        _context.SaveChanges();
    }

    public bool Delete(long id)
    {
        var product = _context.Products.FirstOrDefault(p => p.Id == id);
        
        if (product is null) return false;

        _context.Products.Remove(product);
        _context.SaveChanges();

        return true;
    }

   
}