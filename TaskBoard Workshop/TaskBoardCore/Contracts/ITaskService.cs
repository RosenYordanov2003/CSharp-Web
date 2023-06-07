using TaskBoard.Core.ViewModels.Task;

namespace TaskBoard.Core.Contracts
{
    public interface ITaskService
    {
        Task AddTask(TaskFormModel taskFormModel, string id);
        Task<TaskDetailsViewModel> GetTaskDetails(int id);
        Task<TaskFormModel> GetTaskToEdit(int id, string userId);
        Task EditTaskById(int id, TaskFormModel taskFormModel);
    }
}
