using Core.Models;

namespace Core;

public interface IProductRepository
{
    Product CheckIfExist(long id);
    Task<List<Product>> GetAll();
    Task<Product> GetById(long id);
    Task Add(Product product);
    Task Update(Product product);
    Task<bool> Delete(long id);
}