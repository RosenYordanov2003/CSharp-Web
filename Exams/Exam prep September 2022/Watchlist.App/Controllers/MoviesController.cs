using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Watchlist.Contracts;
using Watchlist.Models.MovieViewModels;

namespace Watchlist.Controllers
{
    [Authorize]
    public class MoviesController : Controller
    {
        private readonly IMovieService movieService;
        private readonly IGenreService genreService;
        public MoviesController(IMovieService movieService, IGenreService genreService)
        {
            this.movieService = movieService;
            this.genreService = genreService;
        }
        [HttpGet]
        public async Task<IActionResult> All()
        {
            IEnumerable<AllMovieViewModel> movieViewModels = await movieService.GetAllMoviesAsynv();

            return View(movieViewModels);
        }
        [HttpGet]
        public async Task<IActionResult> Add()
        {
            AddMovieViewModel model = new AddMovieViewModel();
            model.Genres = await genreService.GetAllGenresAsync();
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> Add(AddMovieViewModel addMovieViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(addMovieViewModel);
            }
            await movieService.AddMovieAsync(addMovieViewModel);
            return RedirectToAction(nameof(All));
        }
        [HttpPost]
        public async Task<IActionResult> AddToCollection(int movieId)
        {
            try
            {
                await movieService.AddMovieToUserAsync(movieId, GetUserId());
                return RedirectToAction(nameof(All));
            }
            catch (InvalidOperationException)
            {
                return RedirectToAction(nameof(All));
            }
        }
        [HttpGet]
        public async Task<IActionResult> Watched()
        {
            IEnumerable<AllMovieViewModel> userMovies = await movieService.GetAllUserMoviesAsync(GetUserId());
            return View(userMovies);
        }
        [HttpPost]
        public async Task<IActionResult> RemoveFromCollection(int movieId)
        {
            try
            {
                await movieService.RemoveUserMovieAsync(movieId, GetUserId());
                return RedirectToAction(nameof(All));
            }
            catch (InvalidOperationException)
            {
                return RedirectToAction(nameof(All));
            }
        }
        private string GetUserId() => User.FindFirstValue(ClaimTypes.NameIdentifier);
    }
}
