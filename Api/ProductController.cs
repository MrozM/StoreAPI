using AutoMapper;
using Core;
using Core.Models;
using Infrastructure.Models;
using Microsoft.AspNetCore.Mvc;

namespace Store;

[Route("api/[controller]")]
[ApiController]
public class ProductController : Controller
{
    
    //TODO wdrozyc automappera, zmienic baze na mssql z dockerem, stworzyc koszyk (po stworzeniu bazy)
    private readonly IProductService _productService;
    private readonly IMapper _mapper;
    public ProductController(IProductService productService, IMapper mapper)
    {
        _productService = productService;
        _mapper = mapper;
    }
    
    [HttpGet]
    public ActionResult<IEnumerable<ProductDto>> GetAll()
    {
        var products = _productService.GetAll();
        var productsDtos = _mapper.Map<List<ProductDto>>(products);
        return Ok(productsDtos);
    }

    [HttpGet("{id}")]
    public ActionResult<ProductDto> GetById(long id)
    {
        var product = _productService.GetById(id);

        if (product is null) return NotFound();

       var productDto = _mapper.Map<ProductDto>(product);

        return Ok(productDto);
    }

    [HttpPost]
    public ActionResult<CreateProductDto> Add(CreateProductDto dto)
    {
        if (dto == null)
        {
            return BadRequest();
        }

        var product = _mapper.Map<Product>(dto);
        _productService.Add(product);
        
        return Ok(dto.Name);
    }

    [HttpPut("{id}")]
    public ActionResult<Product> Update([FromRoute]long id, [FromBody]UpdateProductDto dto)
    { 
        
        _productService.Update(id, dto);

        return NoContent();
    }

    [HttpDelete("{id}")]
    public ActionResult Delete([FromRoute]int id)
    {
        var isDeleted = _productService.Delete(id);
        if (isDeleted) return NoContent();
        
        return NotFound();
    }
}