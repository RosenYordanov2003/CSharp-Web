namespace Library.Data.Configurations
{
    using Library.Data.Models;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class BookEntityConfiguration : IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> builder)
        {
            Book bookEntity = new Book()
            {
                Id = 5,
                Title = "Lorem Ipsum",
                Author = "Dolor Sit",
                ImageUrl = "https://img.freepik.com/free-psd/book-cover-mock-up-arrangement_23-2148622888.jpg?w=826&t=st=1666106877~exp=1666107477~hmac=5dea3e5634804683bccfebeffdbde98371db37bc2d1a208f074292c862775e1b",
                Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit.",
                CategoryId = 1,
                Rating = 9.5m
            };
            builder.HasData(bookEntity);
        }
    }
}
