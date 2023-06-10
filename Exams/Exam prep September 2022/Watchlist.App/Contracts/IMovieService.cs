using Watchlist.Models.MovieViewModels;

namespace Watchlist.Contracts
{
    public interface IMovieService
    {
        Task<IEnumerable<AllMovieViewModel>> GetAllMoviesAsynv();
        Task AddMovieAsync(AddMovieViewModel movieViewModel);
        Task AddMovieToUserAsync(int movieId, string userId);
        Task<IEnumerable<AllMovieViewModel>> GetAllUserMoviesAsync(string userId);
        Task RemoveUserMovieAsync(int movieId, string userId);
    }
}
