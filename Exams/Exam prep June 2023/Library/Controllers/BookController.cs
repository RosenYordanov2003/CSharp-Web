namespace Library.Controllers
{
    using Contracts;
    using Models.Book;
    using Models.Category;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using System.Security.Claims;

    [Authorize]
    public class BookController : Controller
    {
        private readonly IBookService bookService;
        private readonly ICategoryService categoryService;
        public BookController(IBookService bookService, ICategoryService categoryService)
        {
            this.bookService = bookService;
            this.categoryService = categoryService;
        }
        [HttpGet]
        public async Task<IActionResult> All()
        {
            IEnumerable<BookAllViewModel> allBooks = await bookService.GetAllAsync();
            return View(allBooks);
        }
        [HttpGet]
        public async Task<IActionResult> Add()
        {
            IEnumerable<CategoryViewModel> allCategories = await categoryService.GetAllAsync();
            BookAddViewModel bookAddViewModel = new BookAddViewModel()
            {
                Categories = allCategories
            };
            return View(bookAddViewModel);
        }
        [HttpPost]
        public async Task<IActionResult> Add(BookAddViewModel bookAddViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(bookAddViewModel);
            }
            await bookService.AddBokAsync(bookAddViewModel);
            return RedirectToAction(nameof(All));
        }
        [HttpPost]
        public async Task<IActionResult> AddToCollection(int id)
        {
            try
            {
                await bookService.AddBookToUserAsync(id, GetUserId());
                return RedirectToAction(nameof(All));
            }
            catch (InvalidOperationException)
            {
                return RedirectToAction(nameof(All));
            }
        }
        [HttpGet]
        public async Task<IActionResult> Mine()
        {
            IEnumerable<MineBookViewModel> userBooks = await bookService.LoadUserBooksAsync(GetUserId());
            return View(userBooks);
        }
        [HttpPost]
        public async Task<IActionResult> RemoveFromCollection(int id)
        {
            await bookService.RemoveBookFromUserAsync(id, GetUserId());
            return RedirectToAction(nameof(Mine));
        }
        private string GetUserId() => User.FindFirstValue(ClaimTypes.NameIdentifier);
    }
}
