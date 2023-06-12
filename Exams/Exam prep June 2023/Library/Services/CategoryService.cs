namespace Library.Services
{
    using Contracts;
    using Library.Data;
    using Microsoft.EntityFrameworkCore;
    using Models.Category;
    public class CategoryService : ICategoryService
    {
        private readonly LibraryDbContext libraryDbContext;
        public CategoryService(LibraryDbContext libraryDbContext)
        {
            this.libraryDbContext = libraryDbContext;
        }
        public async Task<IEnumerable<CategoryViewModel>> GetAllAsync()
        {
            IEnumerable<CategoryViewModel> allCategories = await libraryDbContext.Categories
                .Select(c => new CategoryViewModel()
                {
                    Id = c.Id,
                    Name = c.Name,
                }).ToArrayAsync();
            return allCategories;
        }
    }
}
