using Core.Models;

namespace Core;

public class ProductService : IProductService 
{
    private readonly IProductRepository _productRepository;


    public ProductService(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }
    
    public Task<Product> GetById(long id) => _productRepository.GetById(id);
    
    public Task<List<Product>> GetAll() => _productRepository.GetAll();

    public Task Add(Product product) => _productRepository.Add(product);

    public Task Update(long id, Product product)
    {
         var productToUpdate = _productRepository.GetById(id);
         var isDescriptionEmpty = string.IsNullOrEmpty(product.Description);
         if (!isDescriptionEmpty)
         {
             productToUpdate.Result.Description = product.Description;
         }

         productToUpdate.Result.Price = product.Price;
         productToUpdate.Result.Quantity = product.Quantity;
         return _productRepository.Update(productToUpdate.Result);
    }

    public Task<bool> Delete(long id) => _productRepository.Delete(id);

    public Product CheckIfProductExist(long id) => _productRepository.CheckIfExist(id);

    
}