using DapperImplementation.BLL.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace DapperImplementation.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productservice;
        public ProductController(IProductService productservice)
        {
            _productservice = productservice;
        }

        [HttpGet]
        [Route("all")]
        public async Task<IActionResult> GetAllProducts()
        {
            var products = await _productservice.GetAll();
            return Ok(products);
        }

        [HttpGet]
        [Route("{id:int}")]
        public async Task<IActionResult> GetProduct(int id)
        {
            var product = await _productservice.Get(id);
            return Ok(product);
        }
    }
}
