using Core.Models;

namespace Core;

public interface IProductRepository
{
    Product CheckIfExist(long id);
    Task<List<Product>> GetAll();
    Task<Product> GetById(long id);
    void Add(Product product);
    void Update(Product product);
    bool Delete(long id);
}