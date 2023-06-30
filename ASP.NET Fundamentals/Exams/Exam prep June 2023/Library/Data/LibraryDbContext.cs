using Library.Data.Configurations;
using Library.Data.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Library.Data
{
    public class LibraryDbContext : IdentityDbContext
    {
        public LibraryDbContext(DbContextOptions<LibraryDbContext> options)
            : base(options)
        {
        }
        public DbSet<Book> Books { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<IdentityUserBook> UsersBooks { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<IdentityUserBook>().HasKey(ck => new { ck.BookId, ck.CollectorId });
            builder.ApplyConfiguration(new BookEntityConfiguration());
            builder.ApplyConfiguration(new CategoryEntityConfiguration());
            base.OnModelCreating(builder);
        }
    }
}