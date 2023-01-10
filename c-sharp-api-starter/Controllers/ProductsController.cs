using c_sharp_api_starter.Helpers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using models;
using services.Products;

namespace c_sharp_api_starter.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : BaseController
    {
        private readonly IProductsService _productsService;

        public ProductsController(IProductsService productsService)
        {
           _productsService = productsService;
        }

        [Authorize]
        [HttpGet("")]
        public ResponseResult<List<Product>> GetProducts() 
        {
          List<Product> result = _productsService.GetProducts();
          return ResponseResult<List<Product>>.Success(result);
        }
    }
}
