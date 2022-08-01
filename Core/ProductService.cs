namespace Core;

public class ProductService : IProductService
{
    private readonly IProductRepository _productRepository;
    
    public ProductService(IProductRepository productRepository)
    {
        _productRepository = productRepository;
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