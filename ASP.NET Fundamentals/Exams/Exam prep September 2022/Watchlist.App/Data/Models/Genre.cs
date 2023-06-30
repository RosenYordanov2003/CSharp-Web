namespace Watchlist.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    using static WatchList.Common.EntityValidation.GenreEntity;
    public class Genre
    {
        public Genre()
        {
            Movies = new List<Movie>();
        }
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(GenreMaxLenght)]
        public string Name { get; set; } = null!;
        public ICollection<Movie> Movies { get; set; }
    }
}
