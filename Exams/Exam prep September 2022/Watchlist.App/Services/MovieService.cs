namespace Watchlist.Services
{
    using Microsoft.EntityFrameworkCore;
    using Watchlist.Contracts;
    using Watchlist.Data;
    using Watchlist.Data.Models;
    using Watchlist.Models.MovieViewModels;
    public class MovieService : IMovieService
    {
        private readonly WatchlistDbContext watchlistDbContext;
        public MovieService(WatchlistDbContext watchlistDbContext)
        {
            this.watchlistDbContext = watchlistDbContext;
        }

        public async Task<IEnumerable<AllMovieViewModel>> GetAllMoviesAsynv()
        {
            IEnumerable<AllMovieViewModel> allMovies = await this.watchlistDbContext
                .Movies.Select(m => new AllMovieViewModel()
                {
                    Id = m.Id,
                    ImageUrl = m.ImageUrl,
                    Director = m.Director,
                    Rating = m.Rating,
                    Title = m.Title,
                    Genre = m.Genre.Name
                }).ToListAsync();
            return allMovies;
        }
        public async Task AddMovieAsync(AddMovieViewModel movieViewModel)
        {
            Movie movie = new Movie()
            {
                Title = movieViewModel.Title,
                Director = movieViewModel.Director,
                ImageUrl = movieViewModel.ImageUrl,
                Rating = movieViewModel.Rating,
                GenreId = movieViewModel.GenreId,
            };
            await watchlistDbContext.Movies.AddAsync(movie);
            await watchlistDbContext.SaveChangesAsync();
        }

        public async Task AddMovieToUserAsync(int movieId, string userId)
        {
            if (await CheckMovieIsAlreadyExistingAsync(movieId, userId))
            {
                throw new InvalidOperationException("Movie is already added");
            }
            UserMovie userMovie = new UserMovie()
            {
                MovieId = movieId,
                UserId = userId
            };
            await watchlistDbContext.UsersMovies.AddAsync(userMovie);
            await watchlistDbContext.SaveChangesAsync();
        }
        public async Task<IEnumerable<AllMovieViewModel>> GetAllUserMoviesAsync(string userId)
        {
            IEnumerable<AllMovieViewModel> userMovies = await watchlistDbContext
                  .UsersMovies.Where(um => um.UserId == userId)
                  .Select(um => new AllMovieViewModel()
                  {
                      Id = um.MovieId,
                      Director = um.Movie.Director,
                      Rating = um.Movie.Rating,
                      Genre = um.Movie.Genre.Name,
                      ImageUrl = um.Movie.ImageUrl,
                      Title = um.Movie.Title,
                  }).ToListAsync();
            return userMovies;
        }

        public async Task RemoveUserMovieAsync(int movieId, string userId)
        {
            UserMovie userMovie = await watchlistDbContext.UsersMovies
                 .FirstOrDefaultAsync(um => um.MovieId == movieId && um.UserId == userId);
            if(userMovie != null)
            {
                watchlistDbContext.UsersMovies.Remove(userMovie);
                await watchlistDbContext.SaveChangesAsync();
            }
            else
            {
                throw new InvalidOperationException("Invalid movie id");
            }
        }
        private async Task<bool> CheckMovieIsAlreadyExistingAsync(int movieId, string userId)
        {
            UserMovie usermovie = await watchlistDbContext.UsersMovies
                .FirstOrDefaultAsync(um => um.UserId == userId && um.MovieId == movieId);

            bool result = usermovie == null ? false : true;
            return result;
        }
    }
}
