using Infrastructure.Models;

namespace Core;

public class ProductService : IProductService 
{
    private readonly IProductRepository _productRepository;


    public ProductService(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }
    
    public Product? GetById(long id)
    {
        var product = _productRepository.GetById(id);
        return product;
    }
    
    public IEnumerable<Product> GetAll()
    {
        var products = _productRepository.GetAll();

        return products;
    }
    
    public void Add(Product product)
    {
        _productRepository.Add(product);
    }

    public void Update(long id, UpdateProductDto dto)
    {
        var product = _productRepository.GetById(id);
        product.UpdateFromDto(dto);

        _productRepository.Update(product);
    }

    public bool Delete(long id)
    {
        var product = _productRepository.Delete(id);

        return product;
    }
}