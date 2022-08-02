using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Core;

public class ProductService : IProductService 
{
    private readonly IProductRepository _productRepository;
    private readonly ILogger<ProductService> _logger;
    private Timer? _timer = null;

    public ProductService(IProductRepository productRepository, ILogger<ProductService> logger)
    {
        _productRepository = productRepository;
        _logger = logger;
    }

    public Product GetById(int id)
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

    public bool Update(int id, string name)
    {
        var product = _productRepository.Update(id, name);

        return product;
    }

    public bool Delete(int id)
    {
        var product = _productRepository.Delete(id);

        return product;
    }
}