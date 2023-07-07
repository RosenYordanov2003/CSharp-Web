using ProductsApi.Data.Models;

namespace ProductsApi.Services.Contracts
{
    public interface IProductService
    {
        public Task<IEnumerable<Product>> GetAllproductsAsync();
        public Product GetProductById(int productId);
        public Product CreateProduct(string productName, string productDescription);
        public void UpdateProduct(int id, Product product);
        public void EditProductPartial(int id, Product product);
        public Product DeleteProduct(int productId);
    }
}
