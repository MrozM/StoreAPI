using Core.Models;

namespace Core.Interfaces;

public interface IProductRepository
{
    Task<Product> CheckIfExist(long id);
    Task<List<Product>> GetAll();
    Task<Product> GetById(long id);
    Task Add(Product product);
    Task<Product> Update(Product product);
    Task<bool> Delete(long id);
}