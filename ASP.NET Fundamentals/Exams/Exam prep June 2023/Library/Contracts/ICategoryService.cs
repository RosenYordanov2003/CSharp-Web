namespace Library.Contracts
{
    using Models.Category;
    public interface ICategoryService
    {
        Task<IEnumerable<CategoryViewModel>> GetAllAsync();
    }
}
