namespace Watchlist.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using static WatchList.Common.EntityValidation.MovieEntity;
    public class Movie
    {
        public Movie()
        {
            UsersMovies = new List<UserMovie>();
        }
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(MovieTitleMaxLength)]
        public string Title { get; set; } = null!;

        [Required]
        [MaxLength(MovieDirectorNameMaxLength)]
        public string Director { get; set; } = null!;
        [Required]
        public string ImageUrl { get; set; } = null!;
        public decimal Rating { get; set; }
        [ForeignKey(nameof(Genre))]
        public int GenreId { get; set; }

        [Required]
        public Genre Genre { get; set; } = null!;
        public ICollection<UserMovie> UsersMovies { get; set; }
    }
}
