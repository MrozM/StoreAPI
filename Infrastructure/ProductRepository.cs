using Core;
using Core.Interfaces;
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
    
    public async Task<Product> GetById(long id) => await _context.Products.FirstOrDefaultAsync(p => p.Id == id);
    
    public async Task<Product> CheckIfExist(long id) => await _context.Products.FirstOrDefaultAsync(p => p.Id == id);
    
    public async Task<List<Product>> GetAll() => await _context.Products.ToListAsync();
    
    
    public Task Add(Product product)
    {
        _context.Products.Add(product);
        return _context.SaveChangesAsync();
    }

    public async Task<Product> Update(Product product)
    {
        _context.Products.Update(product);
        await _context.SaveChangesAsync();

        return product;
    }

    public async Task<bool> Delete(long id)
    {
        var product = _context.Products.FirstOrDefault(p => p.Id == id);
        
        if (product is null) return false;

        _context.Products.Remove(product);
        await _context.SaveChangesAsync();

        return true;
    }

   
}