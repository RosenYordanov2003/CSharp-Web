using ASP.NET_With_DB_Exercise.Models;
using Core.Contracts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace ASP.NET_With_DB_Exercise.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService productService;
        public ProductController(IProductService productService)
        {
            this.productService = productService;
        }
        public async Task<IActionResult> Index()
        {
            ICollection<ProductViewModel> allProducts = await this.productService.GetAllProductsAsync();
            return View(allProducts);
        }
        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Add(ProductViewModel productViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            await this.productService.AddProductAsync(productViewModel);
            return RedirectToAction(nameof(Index));
        }
        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            await this.productService.DeleteProductAsync(id);
            return RedirectToAction(nameof(Index));
        }
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            ProductViewModel productViewModel = await this.productService.GetProductByIdAsync(id);
            return View(productViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id,ProductViewModel productViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            await productService.UpdateProductAsync(id,productViewModel);
            return RedirectToAction(nameof(Index));
        }
    }
}
