namespace Library.Models.Book
{
    using Library.Models.Category;
    using System.ComponentModel.DataAnnotations;
    using static Library.Common.EntityValidation.BookEntity;
    public class BookAddViewModel
    {
        public BookAddViewModel()
        {
            Categories = new List<CategoryViewModel>();
        }
        [Required]
        [StringLength(TitleMaxLength, MinimumLength = TitleMinLength)]
        public string Title { get; set; } = null!;

        [Required]
        [StringLength(AuthorMaxLength, MinimumLength = AuthorMinLength)]
        public string Author { get; set; } = null!;
        [Required]
        [StringLength(DescriptionMaxLength, MinimumLength = DescriptionMinLength)]
        public string Description { get; set; } = null!;
        public string Url { get; set; } = null!;
        [Range(typeof(decimal), $"{RatingMinValue}", $"{RatingMaxValue}")]
        public decimal Rating { get; set; }
        public int CategoryId { get;set; }

        public IEnumerable<CategoryViewModel> Categories { get; set; }
    }
}
