namespace CoreAPP.Contracts
{
    using CoreApp.Models;
    public interface IPostService
    {
        public Task<List<PostViewModel>> GetAllAsync();
        public Task AddPostAsync(PostFormModel postFormModel);
        public Task<PostFormModel> FindByIdAsync(int id);
        public Task EditPostAsync(int id, PostFormModel postFormModel);
        public Task DeletePostAsync(int id);
    }
}
