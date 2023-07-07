namespace ProductsApi.Data
{
    using Microsoft.EntityFrameworkCore;
    using ProductsApi.Data.Models;

    public class ProductDbContext : DbContext
    {
        public ProductDbContext(DbContextOptions<ProductDbContext> options) :base(options)
        {
        }
        public DbSet<Product> Products { get; set; }
    }
}
