using Infrastructure.Models;

namespace Core;

public interface IProductRepository
{
    bool CheckIfExist(int id);
    IEnumerable<ProductDto> GetAll();
    Product? GetById(int id);
    void Add(CreateProductDto dto);
    bool Update(Product product);
    bool Delete(int id);
}