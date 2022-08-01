using Core;
using Microsoft.AspNetCore.Mvc;

namespace Store;

[Route("api/[controller]")]
[ApiController]
public class ProductController : Controller
{
    private readonly IProductService _productService;
    public ProductController(IProductService productService)
    {
        _productService = productService;
    }

    [HttpGet]
    public ActionResult<IEnumerable<Product>> GetAll()
    {
        var products = _productService.GetAll();

        return Ok(products);
    }

    [HttpGet("{id}")]
    public ActionResult<Product> GetById(int id)
    {
        var product = _productService.GetById(id);

        if (product is null) return NotFound();

        return Ok(product);
    }

    [HttpPost]
    public ActionResult<Product> Add(Product? product)
    {
        if (product == null)
        {
            return BadRequest();
        }
        _productService.Add(product);
        
        return Ok(product.Name);
    }

    [HttpPut("{id}")]
    public ActionResult<Product> Update([FromRoute]int id, [FromBody]string name)
    {
       var updatedProduct = _productService.Update(id, name);
       if (!updatedProduct) return NotFound();
        
       return Ok();
    }

    [HttpDelete("{id}")]
    public ActionResult Delete([FromRoute]int id)
    {
        var isDeleted = _productService.Delete(id);
        if (isDeleted) return NoContent();
        
        return NotFound();
    }
}