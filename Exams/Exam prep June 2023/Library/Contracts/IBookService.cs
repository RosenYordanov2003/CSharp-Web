namespace Library.Contracts
{
    using Library.Models.Book;

    public interface IBookService
    {
        Task<IEnumerable<BookAllViewModel>> GetAllAsync();
        Task AddBokAsync(BookAddViewModel bookAddViewModel);
        Task AddBookToUserAsync(int bookId, string userId);
        Task<IEnumerable<MineBookViewModel>> LoadUserBooksAsync(string userId);
        Task RemoveBookFromUserAsync(int bookId, string userId);
    }
}
