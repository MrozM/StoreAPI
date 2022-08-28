using Core.Models;

namespace Core;

public interface IProductRepository
{
    bool CheckIfExist(long id);
    IEnumerable<Product> GetAll();
    Product GetById(long id);
    void Add(Product product);
    void Update(Product product);
    bool Delete(long id);
}