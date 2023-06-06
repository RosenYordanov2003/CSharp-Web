namespace TaskBoard.Core.Services
{
    using TaskBoard.Core.Contracts;
    using TaskBoard.Core.ViewModels.Task;
    using TaskBoard.Data;
    using Task = TaskBoard.Data.Models.Task;

    public class TaskService : ITaskService
    {
        private readonly TaskBoardDbContext taskBoardDbContext;
        public TaskService(TaskBoardDbContext taskBoardDbContext)
        {
            this.taskBoardDbContext = taskBoardDbContext;
        }

        async System.Threading.Tasks.Task ITaskService.AddTask(TaskFormModel taskFormModel, string id)
        {
            Task task = new Task()
            {
                Title = taskFormModel.Title,
                Description = taskFormModel.Description,
                CreatedOn = DateTime.Now,
                BoardId = taskFormModel.BoardId,
                OwnerId = id
            };
            await taskBoardDbContext.AddAsync(task);
            await taskBoardDbContext.SaveChangesAsync();
        }
    }
}
