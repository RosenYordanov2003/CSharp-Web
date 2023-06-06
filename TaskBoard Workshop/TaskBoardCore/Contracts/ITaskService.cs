using TaskBoard.Core.ViewModels.Task;

namespace TaskBoard.Core.Contracts
{
    public interface ITaskService
    {
        Task AddTask(TaskFormModel taskFormModel, string id);
    }
}
