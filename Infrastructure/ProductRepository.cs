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
    
    public Task<Product> GetById(long id) => _context.Products.FirstOrDefaultAsync(p => p.Id == id);
    
    public Product CheckIfExist(long id) => _context.Products.FirstOrDefault(p => p.Id == id);
    
    public Task<List<Product>> GetAll() => _context.Products.ToListAsync();
    
    
    public Task Add(Product product)
    {
        _context.Products.Add(product);
        return _context.SaveChangesAsync();
    }

    public Task Update(Product product)
    {
        _context.Products.Update(product);
        return _context.SaveChangesAsync();
    }

    public Task<bool> Delete(long id)
    {
        var product = _context.Products.FirstOrDefault(p => p.Id == id);
        
        if (product is null) return Task.FromResult(false);

        _context.Products.Remove(product);
        _context.SaveChanges();

        return Task.FromResult(true);
    }

   
}