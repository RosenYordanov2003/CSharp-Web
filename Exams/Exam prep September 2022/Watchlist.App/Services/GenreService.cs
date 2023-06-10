namespace Watchlist.Services
{
    using Microsoft.EntityFrameworkCore;
    using Watchlist.Contracts;
    using Watchlist.Data;
    using Watchlist.Models.MovieViewModels;

    public class GenreService : IGenreService
    {
        private readonly WatchlistDbContext watchlistDbContext;
        public GenreService(WatchlistDbContext watchlistDbContext)
        {
            this.watchlistDbContext = watchlistDbContext;
        }
        public async Task<IEnumerable<GenreViewModel>> GetAllGenresAsync()
        {
            IEnumerable<GenreViewModel> genres = await watchlistDbContext.Genres
                .Select(g => new GenreViewModel()
                {
                    Id = g.Id,
                    Name = g.Name
                }).ToListAsync();
            return genres;
        }
    }
}
