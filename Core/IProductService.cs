using Core.Models;
namespace Core;

public interface IProductService
{
    Task<Product> GetById(long id);
    Task<List<Product>> GetAll();
    void Add(Product product);
    void Update(long id, Product product);
    bool Delete(long id);
    Product CheckIfProductExist(long id);
}