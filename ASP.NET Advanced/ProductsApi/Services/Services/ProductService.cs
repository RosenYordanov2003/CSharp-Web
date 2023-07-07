namespace ProductsApi.Services.Services
{
    using Microsoft.EntityFrameworkCore;
    using ProductsApi.Data;
    using ProductsApi.Data.Models;
    using ProductsApi.Services.Contracts;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public class ProductService : IProductService
    {
        private readonly ProductDbContext productDbContext;
        public ProductService(ProductDbContext productDbContext)
        {
            this.productDbContext = productDbContext;
        }


        public async Task<IEnumerable<Product>> GetAllproductsAsync()
        {
            return await productDbContext.Products.ToArrayAsync();
        }

        public Product GetProductById(int productId)
        {
            return productDbContext.Products.FirstOrDefault(p => p.Id == productId);
        }
        public Product CreateProduct(string productName, string productDescription)
        {
            Product product = new Product()
            {
                Name = productName,
                Description = productDescription
            };
            productDbContext.Products.Add(product);
            productDbContext.SaveChanges();
            return product;
        }

        public void UpdateProduct(int id, Product product)
        {
            var productToEdit = productDbContext.Products.First(p => p.Id == id);
            productToEdit.Name = product.Name;
            productToEdit.Description = product.Description;
            productDbContext.SaveChanges();
        }

        public void EditProductPartial(int id, Product product)
        {
            Product productToEditPartially = productDbContext.Products.First(p => p.Id == id);
            productToEditPartially.Name = string.IsNullOrWhiteSpace(product.Name) ? productToEditPartially.Name
                  : product.Name;
            productToEditPartially.Description = string.IsNullOrWhiteSpace(product.Description) ? productToEditPartially.Description
                : product.Description;
            productDbContext.SaveChanges();
        }

        public Product DeleteProduct(int productId)
        {
            Product productToDelete = productDbContext.Products.First(p => p.Id == productId);
            productDbContext.Products.Remove(productToDelete);
            productDbContext.SaveChanges();
            return productToDelete;
        }
    }
}
