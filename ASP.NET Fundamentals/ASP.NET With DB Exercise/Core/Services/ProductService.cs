namespace Core.Services
{
    using ASP.NET_With_DB_Exercise.Models;
    using Core.Contracts;
    using Infrastructure;
    using Infrastructure.Models;
    using Microsoft.EntityFrameworkCore;

    public class ProductService : IProductService
    {
        private readonly ProductWebShopDbContext context;

        public ProductService(ProductWebShopDbContext context)
        {
            this.context = context;
        }

        public async Task AddProductAsync(ProductViewModel productViewModel)
        {
            Product product = new Product()
            {
                Name = productViewModel.Name,
                Price = productViewModel.Price,
                Quantity = productViewModel.Quantity,
                BarcodeNumber = Guid.NewGuid()
            };
            await context.Products.AddAsync(product);
            await context.SaveChangesAsync();
        }

        public async Task DeleteProductAsync(int productId)
        {
            Product productToDelete = await context.Products.FirstOrDefaultAsync(p => p.Id == productId);
            if (productToDelete != null)
            {
                productToDelete.isDeleted = true;
                await context.SaveChangesAsync();
            }
        }

        public Task<List<ProductViewModel>> GetAllProductsAsync()
        {
            return context.Products
                 .Where(p => p.isDeleted == false)
                .Select(p => new ProductViewModel
                {
                    Id = p.Id,
                    Name = p.Name,
                    Price = p.Price,
                    Quantity = p.Quantity,
                    BarcodeNumber = p.BarcodeNumber
                }).ToListAsync();
        }

        public async Task<ProductViewModel> GetProductByIdAsync(int productId)
        {
            var product = await context.Products.FirstOrDefaultAsync(p => p.Id == productId);
            ProductViewModel productViewModel = new ProductViewModel()
            {
                Id = product.Id,
                Name = product.Name,
                Quantity = product.Quantity,
                Price = product.Price,
                BarcodeNumber = product.BarcodeNumber
            };
            return productViewModel;
        }

        public async Task UpdateProductAsync(int id,ProductViewModel productViewModel)
        {
            Product productToUpdate = await this.context.Products.FirstOrDefaultAsync(p => p.Id == id);
            productToUpdate.Name = productViewModel.Name;
            productToUpdate.Price = productViewModel.Price;
            productToUpdate.Quantity = productViewModel.Quantity;
            productToUpdate.BarcodeNumber = productViewModel.BarcodeNumber;
            await this.context.SaveChangesAsync();
        }
    }
}
