using TaskBoard.Core.ViewModels.Home;

namespace TaskBoard.Core.Contracts
{
    public interface IHomeService
    {
        Task<int> GetUserTasksCountAsync(string userId);
        Task<HomeViewModel> ConfigureHomeViewModelAsync();
    }
}
