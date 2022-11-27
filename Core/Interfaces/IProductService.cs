using Core.Models;
namespace Core.Interfaces;

public interface IProductService
{
    Task<Product> GetById(long id);
    Task<List<Product>> GetAll();
    Task Add(Product product);
    Task<Product> Update(long id, Product product);
    Task<bool> Delete(long id);
    Task<Product> CheckIfProductExist(long id);
}