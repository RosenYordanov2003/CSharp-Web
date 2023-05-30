namespace Infrastructure
{
    using Infrastructure.Models;
    using Microsoft.EntityFrameworkCore;
    public class ProductWebShopDbContext : DbContext
    {
        public ProductWebShopDbContext(DbContextOptions<ProductWebShopDbContext> options)
            : base(options)
        {

        }
        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().Property(p => p.Price)
                 .HasPrecision(18, 2);
        }
    }
}
