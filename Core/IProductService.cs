using Infrastructure.Models;

namespace Core;

public interface IProductService
{
    Product? GetById(int id);
    IEnumerable<ProductDto> GetAll();
    void Add(CreateProductDto dto);
    bool Update(int id, UpdateProductDto dto);
    bool Delete(int id);
}