namespace TaskBoard.Core.Services
{
    using Microsoft.EntityFrameworkCore;
    using System.Security.Claims;
    using TaskBoard.Core.Contracts;
    using TaskBoard.Core.ViewModels.Board;
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

        public async Task<TaskDetailsViewModel> GetTaskDetails(int id)
        {
            TaskDetailsViewModel taskDetailsViewModel = await taskBoardDbContext.Tasks
                 .Where(t => t.Id == id).Select(t => new TaskDetailsViewModel()
                 {
                     Id = t.Id,
                     Title = t.Title,
                     Description = t.Description,
                     CreatedOn = t.CreatedOn.ToString("dd/MM/yyyy HH:mm"),
                     Board = t.Board.Name,
                     Owner = t.Owner.UserName
                 }).FirstOrDefaultAsync();
            if (taskDetailsViewModel == null)
            {
                throw new ArgumentException("Invalid task id");
            }
            return taskDetailsViewModel;
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
        public async Task<TaskFormModel> GetTaskToEdit(int id, string userId)
        {
            Task taskToGet = await GetTaskById(id);
            if (taskToGet.OwnerId != userId)
            {
                throw new InvalidOperationException("User unauthorized");
            }
            TaskFormModel taskFormModel = new TaskFormModel()
            {
                Title = taskToGet.Title,
                Description = taskToGet.Title,
                BoardId = taskToGet.BoardId,
                Boards = taskBoardDbContext.Boards.Select(b => new TaskBoardFormModel()
                {
                    Id = b.Id,
                    Name = b.Name
                })
            };
            return taskFormModel;
        }
        private async Task<Task> GetTaskById(int id)
        {
            Task task = await taskBoardDbContext.Tasks.FirstOrDefaultAsync(t => t.Id == id);
            if (task == null)
            {
                throw new ArgumentException("Invalid task id");
            }
            return task;
        }

        public async System.Threading.Tasks.Task EditTaskById(int id, TaskFormModel taskFormModel)
        {
            Task task = await GetTaskById(id);
            task.Title = taskFormModel.Title;
            task.Description = taskFormModel.Description;
            task.BoardId = taskFormModel.BoardId;
            await taskBoardDbContext.SaveChangesAsync();
        }
    }
}
