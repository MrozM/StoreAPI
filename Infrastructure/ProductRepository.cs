using Core;
using Core.Models;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure;

public class ProductRepository : IProductRepository
{
    private readonly StoreContext _context;

    public ProductRepository(StoreContext storeContext)
    {
        _context = storeContext;
    }

    public async Task<Product> GetById(long id) => _context.Products.FirstOrDefault(p => p.Id == id);

    public Product CheckIfExist(long id) => _context.Products.FirstOrDefault(p => p.Id == id);
    
    

    
    
    public Task<List<Product>> GetAll() => _context.Products.ToListAsync();
        

    
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