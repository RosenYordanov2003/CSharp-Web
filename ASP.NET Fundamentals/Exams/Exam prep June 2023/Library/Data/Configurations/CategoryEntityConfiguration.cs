namespace Library.Data.Configurations
{
    using Library.Data.Models;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class CategoryEntityConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasData(CreateCategories());
        }
        private ICollection<Category> CreateCategories()
        {
            List<Category> categories = new List<Category>()
            {
                new Category()
                {
                    Id = 1,
                    Name = "Action"
                },
                new Category()
                {
                    Id = 2,
                    Name = "Biography"
                },
                new Category()
                {
                    Id = 3,
                    Name = "Children"
                },
                new Category()
                {
                    Id = 4,
                    Name = "Crime"
                },
                new Category()
                {
                    Id = 5,
                    Name = "Fantasy"
                }
            };
            return categories;
        }
    }
}
