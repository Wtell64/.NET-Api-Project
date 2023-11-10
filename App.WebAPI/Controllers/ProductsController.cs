using App.Business.Abstract;
using App.Business.Concrete;
using App.DataAccess.Abstract;
using App.DataAccess.Concrete.EntityFramework;
using App.Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace App.WebAPI.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class ProductsController : ControllerBase
  {
    private readonly IProductService _productService;

    public ProductsController(IProductService productService)
    {
      _productService = productService;
    }
    [HttpGet("getall")]
    public IActionResult Get()
    {

      var result = _productService.GetAll();
      if (result.Success)
      {
        return Ok(result);
      }
      return BadRequest(result);
    }

    [HttpGet("getbyid")]
    public IActionResult Get(int id)
    {

      var result = _productService.GetById(id);
      if (result.Success)
      {
        return Ok(result);
      }

      return BadRequest(result);
    }

    [HttpPost("add")]
    public IActionResult Post(Product product)
    {
      var result = _productService.Add(product);

      if (result.Success)
      {
        return Ok(result);
      }
      return BadRequest(result);
    }
  }
}
