namespace Core.Contracts
{
    using ASP.NET_With_DB_Exercise.Models;
    public interface IProductService
    {
        Task<List<ProductViewModel>> GetAllProductsAsync();

        Task AddProductAsync(ProductViewModel productViewModel);
        Task UpdateProductAsync(int id, ProductViewModel productViewModel);

        Task DeleteProductAsync(int productId);

        Task<ProductViewModel> GetProductByIdAsync(int productId);

    }
}
