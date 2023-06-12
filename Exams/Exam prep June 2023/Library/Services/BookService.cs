namespace Library.Services
{
    using Library.Contracts;
    using Data;
    using Data.Models;
    using Models.Book;
    using Microsoft.EntityFrameworkCore;

    public class BookService : IBookService
    {
        private readonly LibraryDbContext libraryDbContext;
        public BookService(LibraryDbContext libraryDbContext)
        {
            this.libraryDbContext = libraryDbContext;
        }

        public async Task<IEnumerable<BookAllViewModel>> GetAllAsync()
        {
            IEnumerable<BookAllViewModel> allBooks = await libraryDbContext
                  .Books.Select(b => new BookAllViewModel()
                  {
                      Id = b.Id,
                      ImageUrl = b.ImageUrl,
                      Title = b.Title,
                      Author = b.Author,
                      Rating = b.Rating,
                      Category = b.Category.Name
                  }).ToArrayAsync();
            return allBooks;
        }
        public async Task AddBokAsync(BookAddViewModel bookAddViewModel)
        {
            Book book = new Book()
            {
                Title = bookAddViewModel.Title,
                ImageUrl = bookAddViewModel.Url,
                Author = bookAddViewModel.Author,
                Description = bookAddViewModel.Description,
                CategoryId = bookAddViewModel.CategoryId,
                Rating = bookAddViewModel.Rating,
            };
            await libraryDbContext.Books.AddAsync(book);
            await libraryDbContext.SaveChangesAsync();
        }

        public async Task AddBookToUserAsync(int bookId, string userId)
        {
            if (IsExist(bookId, userId))
            {
                throw new InvalidOperationException("Book is already exist");
            }
            else
            {
                IdentityUserBook userBook = new IdentityUserBook()
                {
                    BookId = bookId,
                    CollectorId = userId
                };
                await libraryDbContext.UsersBooks.AddAsync(userBook);
                await libraryDbContext.SaveChangesAsync();
            }
        }
        public async Task<IEnumerable<MineBookViewModel>> LoadUserBooksAsync(string userId)
        {
            IEnumerable<MineBookViewModel> userBooks = await libraryDbContext.UsersBooks
                .Where(ub => ub.CollectorId == userId)
                .Select(ub => new MineBookViewModel()
                {
                    Id = ub.BookId,
                    ImageUrl = ub.Book.ImageUrl,
                    Title = ub.Book.Title,
                    Author = ub.Book.Author,
                    Description = ub.Book.Description,
                    Category = ub.Book.Category.Name,

                }).ToArrayAsync();
            return userBooks;
        }
        public async Task RemoveBookFromUserAsync(int bookId, string userId)
        {
            if (IsExist(bookId, userId))
            {
                IdentityUserBook userBook = await libraryDbContext.UsersBooks
                    .FirstAsync(ub => ub.CollectorId == userId && ub.BookId == bookId);
                libraryDbContext.UsersBooks.Remove(userBook);
                await libraryDbContext.SaveChangesAsync();
            }
        }
        private bool IsExist(int bookId, string userId) => libraryDbContext.UsersBooks.Any(ub => ub.CollectorId == userId && ub.BookId == bookId);

    }
}
