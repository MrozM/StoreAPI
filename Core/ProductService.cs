using Infrastructure.Models;
using Microsoft.Extensions.Logging;

namespace Core;

public class ProductService : IProductService 
{
    private readonly IProductRepository _productRepository;
    private readonly ILogger<ProductService> _logger;

    public ProductService(IProductRepository productRepository, ILogger<ProductService> logger)
    {
        _productRepository = productRepository;
        _logger = logger;
    }
    
    public Product? GetById(int id)
    {
        var product = _productRepository.GetById(id);
        return product;
    }
    
    public IEnumerable<ProductDto> GetAll()
    {
        var products = _productRepository.GetAll();
        return products;
    }
    
    public void Add(CreateProductDto createProductDto)
    {
        _productRepository.Add(createProductDto);
    }

    public bool Update(int id, UpdateProductDto dto)
    {
        var product = _productRepository.GetById(id);

        if (product is null) return false;
        product.UpdateFromDto(dto);
        _productRepository.Update(product);
        return true; //zmienić na void
    }

    public bool Delete(int id)
    {
        var product = _productRepository.Delete(id);

        return product;
    }
}