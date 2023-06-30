namespace Library.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using static Library.Common.EntityValidation.BookEntity;
    public class Book
    {
        public Book()
        {
            UsersBooks = new List<IdentityUserBook>();
        }
        [Key]
        public int Id { get; set; }

        [MaxLength(TitleMaxLength)]
        [Required]
        public string Title { get; set; } = null!;

        [Required]
        [MaxLength(AuthorMaxLength)]
        public string Author { get; set; } = null!;

        [Required]
        [MaxLength(DescriptionMaxLength)]
        public string Description { get; set; } = null!;

        [Required]
        public string ImageUrl { get;set; } = null!;
        public decimal Rating { get; set; }

        [ForeignKey(nameof(Category))]
        public int CategoryId { get; set; }

        [Required]
        public Category Category { get; set; } = null!;
        public ICollection<IdentityUserBook> UsersBooks { get; set; }
    }
}
