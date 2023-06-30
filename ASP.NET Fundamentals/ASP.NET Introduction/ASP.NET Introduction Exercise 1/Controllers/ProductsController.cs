using ASP.NET_Introduction_Exercise.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Net.Http.Headers;
using System.Text;
using System.Text.Json;

namespace ASP.NET_Introduction_Exercise.Controllers
{
    public class ProductsController : Controller
    {
        private IEnumerable<ProductViewModel> products = new List<ProductViewModel>()
        {
            new ProductViewModel()
            {
                Id = 1,
                Name = "Cheese",
                Price = 6.00
            },
            new ProductViewModel()
            {
                Id = 2,
                Name = "Milk",
                Price = 3.00
            },
            new ProductViewModel()
            {
                Id = 3,
                Name = "Bread",
                Price = 1.50
            }
        };
        [ActionName("My-Products")]
        public IActionResult All(string keyword)
        {
            if (keyword != null)
            {
                List<ProductViewModel> filteredProducts = this.products.Where((p) => p.Name.ToLower().Contains(keyword.ToLower())).ToList();
                return View(filteredProducts);
            }
            return View(this.products);
        }
        public IActionResult ById(int id)
        {
            ProductViewModel productToFind = this.products.FirstOrDefault((p) => p.Id == id);
            if (productToFind == null)
            {
                return BadRequest();
            }
            return View(productToFind);
        }
        public IActionResult AllAsJson()
        {
            JsonSerializerOptions options = new JsonSerializerOptions()
            {
                WriteIndented = true
            };
            return Json(this.products, options);
        }
        public IActionResult AllAsTextFile()
        {
            string newLine = "\r\n";
            StringBuilder sb = new StringBuilder();
            foreach (ProductViewModel product in this.products)
            {
                sb.Append($"Product Id: {product.Id} - {product.Name} - {product.Price:F2}lv.");
                sb.Append(newLine);
            }
            Response.Headers.Add(HeaderNames.ContentDisposition, @"attachment;filename=products.txt");
            return File(Encoding.UTF8.GetBytes(sb.ToString().TrimEnd()), "text/plain");
        }
        public IActionResult AllAsText()
        {
            string newLine = "\r\n";
            StringBuilder sb = new StringBuilder();
            foreach (ProductViewModel product in this.products)
            {
                sb.Append($"Product Id: {product.Id} - {product.Name} - {product.Price:F2}lv.");
                sb.Append(newLine);
            }
            return Content(sb.ToString().TrimEnd());
        }
    }
}
