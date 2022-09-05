using Core.Models;

namespace Core;

public class ProductService : IProductService 
{
    private readonly IProductRepository _productRepository;


    public ProductService(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }
    
    public Task<Product> GetById(long id)
    {
        var product =  _productRepository.GetById(id);
        return product;
    }
    
    public Task<List<Product>> GetAll()
    {
        var products = _productRepository.GetAll();

        return products;
    }
    
    public void Add(Product product)
    {
        _productRepository.Add(product);
    }

    public void Update(long id, Product product)
    {
         _productRepository.GetById(id);
         _productRepository.Update(product);
    }

    public bool Delete(long id)
    {
        var product = _productRepository.Delete(id);

        return product;
    }

    public Product CheckIfProductExist(long id) => _productRepository.CheckIfExist(id);

    
}