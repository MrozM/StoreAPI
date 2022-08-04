using Core;
using Infrastructure.Models;
using Microsoft.AspNetCore.Mvc;

namespace Store;

[Route("api/[controller]")]
[ApiController]
public class ProductController : Controller
{
    
    //TODO wdrozyc automappera, zmienic baze na mssql z dockerem, stworzyc koszyk (po stworzeniu bazy)
    private readonly IProductService _productService;
    public ProductController(IProductService productService)
    {
        _productService = productService;
    }
    
    [HttpGet]
    public ActionResult<IEnumerable<ProductDto>> GetAll()
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
    public ActionResult<CreateProductDto> Add(CreateProductDto dto)
    {
        if (dto == null)
        {
            return BadRequest();
        }
        _productService.Add(dto);
        
        return Ok(dto.Name);
    }

    [HttpPut("{id}")]
    public ActionResult<Product> Update([FromRoute]int id, [FromBody]UpdateProductDto dto)
    {
       var updatedProduct = _productService.Update(id, dto);
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