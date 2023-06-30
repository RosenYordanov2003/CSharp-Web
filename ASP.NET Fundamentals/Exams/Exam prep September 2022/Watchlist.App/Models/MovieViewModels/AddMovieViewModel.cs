namespace Watchlist.Models.MovieViewModels
{
    using System.ComponentModel.DataAnnotations;
    using static WatchList.Common.EntityValidation.MovieEntity;
    public class AddMovieViewModel
    {
        public AddMovieViewModel()
        {
            Genres = new List<GenreViewModel>();
        }
        [Required]
        [StringLength(MovieTitleMaxLength, MinimumLength = MovieTitleMinLength)]
        public string Title { get; set; } = null!;

        [Required]
        [StringLength (MovieDirectorNameMaxLength, MinimumLength = MovieDirectorNameMinLength)]
        public string Director { get; set; } = null!;
        public string ImageUrl { get; set; } = null!;
        [Range(typeof(decimal), $"{MovieRatingMinValue}", $"{MovieRatingMaxValue}")]
        public decimal Rating { get; set; }
        public int GenreId { get; set; }
        public IEnumerable<GenreViewModel> Genres { get; set; }
    }
}
