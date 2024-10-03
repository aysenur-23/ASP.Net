using Microsoft.AspNetCore.Mvc;
using productApp.Models;

namespace productApp.Controllers
{
    [Route("api/products")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly ILogger<ProductsController> _logger;

        public ProductsController(ILogger<ProductsController> logger)
        {
            _logger = logger;
        }

        [HttpGet]

        public IActionResult GetAllProducts()
        {
            var products = new List<Product>()
            {
                new Product() {Id=1, ProductName = "Computer"},
                new Product() {Id=1, ProductName = "Keyboard"},
                new Product() {Id=1, ProductName = "Mouse"}
            };
            _logger.LogInformation("GetAllProducts action been called");
            return Ok(products);
        }

        [HttpPost]

        public IActionResult GetAllProduct([FromBody] Product product)
        {
            _logger.LogWarning("Product has been created.");
            return StatusCode(201); //created 
        }

    }
}
