using Core.Interfaces;
using Core.Models;
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
    
    public async Task<Product> GetById(long id) => await _productRepository.GetById(id);

    public async Task<List<Product>> GetAll()
    {
        _logger.LogInformation("get all orders method invoked!");
        
        return await _productRepository.GetAll();
        
    } 
    public async Task Add(Product product) => await _productRepository.Add(product);

    public async Task<Product> Update(long id, Product product)
    {
         var productToUpdate = await _productRepository.GetById(id);
         var isDescriptionEmpty = string.IsNullOrEmpty(product.Description);
         if (!isDescriptionEmpty)
         {
             productToUpdate.Description = product.Description;
         }

         productToUpdate.Price = product.Price;
         productToUpdate.Quantity = product.Quantity;
         return await _productRepository.Update(productToUpdate);
    }

    public async Task<bool> Delete(long id) => await _productRepository.Delete(id);

    public async Task<Product> CheckIfProductExist(long id) => await _productRepository.CheckIfExist(id);

    
}