using AutoMapper;
using Core;
using Core.Models;
using Infrastructure.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Store.Dtos;

namespace Store;

[Route("api/[controller]")]
[ApiController]
[Authorize]
public class ProductController : Controller
{
    
    private readonly IProductService _productService;
    private readonly IMapper _mapper;
    public ProductController(IProductService productService, IMapper mapper)
    {
        _productService = productService;
        _mapper = mapper;
    }
    
    [HttpGet]
    [AllowAnonymous]
    public ActionResult<IEnumerable<ProductDto>> GetAll()
    {
        var products = _productService.GetAll();
        var productsDtos = _mapper.Map<List<ProductDto>>(products);
        return Ok(productsDtos);
    }

    [HttpGet("{id}")]
    [AllowAnonymous]
    public ActionResult<ProductDto> GetById(long id)
    {
        var product = _productService.GetById(id);

        if (product is null)
        {
            return NotFound();
        }

       var productDto = _mapper.Map<ProductDto>(product);

        return Ok(productDto);
    }

    [HttpPost]
    [Authorize(Roles = "Admin,Manager")]
    public ActionResult<CreateProductDto> Add(CreateProductDto dto)
    {

        var product = _mapper.Map<Product>(dto);
        _productService.Add(product);
        
        return Ok(dto.Name);
    }

    [HttpPut("{id}")]
    [Authorize(Roles = "Admin,Manager")]
    public ActionResult<Product> Update([FromRoute]long id, [FromBody]UpdateProductDto dto)
    {
        var product = _mapper.Map<Product>(dto);  
        _productService.Update(id, product);

        return NoContent();
    }

    [HttpDelete("{id}")]
    [Authorize(Roles = "Admin,Manager")]
    public ActionResult Delete([FromRoute]int id)
    {
        var isDeleted = _productService.Delete(id);
        if (isDeleted) return NoContent();
        
        return NotFound();
    }
}