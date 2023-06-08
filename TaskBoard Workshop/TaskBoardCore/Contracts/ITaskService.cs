using TaskBoard.Core.ViewModels.Task;
using TaskBoardCore.ViewModels.Task;

namespace TaskBoard.Core.Contracts
{
    public interface ITaskService
    {
        Task AddTaskAsync(TaskFormModel taskFormModel, string id);
        Task<TaskDetailsViewModel> GetTaskDetailsAsync(int id);
        Task<TaskFormModel> GetTaskToEditAsync(int id, string userId);
        Task EditTaskByIdAsync(int id, TaskFormModel taskFormModel);
        Task<TaskViewModel> GetTaskToDeleteAsync(int id, string userId);
        Task DeleteTaskAsync(TaskViewModel taskViewModel, string userId);
    }
}
