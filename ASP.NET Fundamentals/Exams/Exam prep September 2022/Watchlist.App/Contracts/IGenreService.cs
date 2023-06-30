namespace Watchlist.Contracts
{
    using Watchlist.Models.MovieViewModels;
    public interface IGenreService
    {
        Task<IEnumerable<GenreViewModel>> GetAllGenresAsync();
    }
}
