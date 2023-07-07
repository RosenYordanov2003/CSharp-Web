namespace ProductsApi.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using ProductsApi.Data.Models;
    using ProductsApi.Services.Contracts;

    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : Controller
    {
        private readonly IProductService productService;
        public ProductController(IProductService productService)
        {
            this.productService = productService;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product>>> GetProducts()
        {
            var products = await productService.GetAllproductsAsync();
            return Json(products);
        }
        [HttpGet("{id}")]
        public ActionResult<Product> GetProduct(int id)
        {
            var product = productService.GetProductById(id);
            if (product == null)
            {
                return NotFound();
            }
            return product;
        }
        [HttpPost]
        public ActionResult<Product> PostProduct(Product product)
        {
            product = productService.CreateProduct(product.Name, product.Description);
            return product;
        }
        [HttpPut("{id}")]
        public IActionResult PutProduct(int id, Product product)
        {
            if (id != product.Id)
            {
                return BadRequest();
            }
            if (this.productService.GetProductById(id) == null)
            {
                return NotFound();
            }
            this.productService.UpdateProduct(id, product);
            return NoContent();
        }
        [HttpPatch("{id}")]
        public IActionResult PatchProduct(int id, Product product)
        {
            if(this.productService.GetProductById(id) == null)
            {
                return NotFound();
            }
            productService.EditProductPartial(id, product);
            return NoContent();
        }
        [HttpDelete("{id}")]
        public ActionResult<Product> DeleteProduct(int id)
        {
            if(productService.GetProductById(id) == null)
            {
                return NotFound();
            }
            Product product = this.productService.GetProductById(id);
            return product;
        }
    }
}
