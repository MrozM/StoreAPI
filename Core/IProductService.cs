using Core.Models;
namespace Core;

public interface IProductService
{
    Task<Product> GetById(long id);
    Task<List<Product>> GetAll();
    Task Add(Product product);
    Task Update(long id, Product product);
    Task<bool> Delete(long id);
    Product CheckIfProductExist(long id);
}