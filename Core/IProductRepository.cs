using Infrastructure.Models;

namespace Core;

public interface IProductRepository
{
    IEnumerable<ProductDto> GetAll();
    Product? GetById(int id);
    void Add(CreateProductDto dto);
    bool Update(int id, UpdateProductDto dto);
    bool Delete(int id);
}