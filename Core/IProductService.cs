using Core.Models;
using Infrastructure.Models;

namespace Core;

public interface IProductService
{
    Product GetById(long id);
    IEnumerable<Product> GetAll();
    void Add(Product product);
    void Update(long id, Product product);
    bool Delete(long id);
}