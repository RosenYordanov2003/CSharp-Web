namespace TaskBoard.Core.Services
{
    using Microsoft.EntityFrameworkCore;
    using System.Security.Claims;
    using TaskBoard.Core.Contracts;
    using TaskBoard.Core.ViewModels.Board;
    using TaskBoard.Core.ViewModels.Task;
    using TaskBoard.Data;
    using TaskBoardCore.ViewModels.Task;
    using Task = TaskBoard.Data.Models.Task;

    public class TaskService : ITaskService
    {
        private readonly TaskBoardDbContext taskBoardDbContext;
        public TaskService(TaskBoardDbContext taskBoardDbContext)
        {
            this.taskBoardDbContext = taskBoardDbContext;
        }

        public async Task<TaskDetailsViewModel> GetTaskDetailsAsync(int id)
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

        async System.Threading.Tasks.Task ITaskService.AddTaskAsync(TaskFormModel taskFormModel, string id)
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
        public async Task<TaskFormModel> GetTaskToEditAsync(int id, string userId)
        {
            Task taskToGet = await GetTaskByIdAsync(id);
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
        public async System.Threading.Tasks.Task EditTaskByIdAsync(int id, TaskFormModel taskFormModel)
        {
            Task task = await GetTaskByIdAsync(id);
            task.Title = taskFormModel.Title;
            task.Description = taskFormModel.Description;
            task.BoardId = taskFormModel.BoardId;
            await taskBoardDbContext.SaveChangesAsync();
        }

        public async Task<TaskViewModel> GetTaskToDeleteAsync(int id, string userId)
        {
            Task task = await GetTaskByIdAsync(id);
            if (!CheckUserId(task.OwnerId, userId))
            {
                throw new InvalidOperationException("User unauthorized");
            }
            TaskViewModel taskViewModel = new TaskViewModel()
            {
                Id = task.Id,
                Title = task.Title,
                Description = task.Description,
            };
            return taskViewModel;
        }
        public async System.Threading.Tasks.Task DeleteTaskAsync(TaskViewModel taskViewModel, string userId)
        {
            Task task = await GetTaskByIdAsync(taskViewModel.Id);
            if (!CheckUserId(task.OwnerId, userId))
            {
                throw new InvalidOperationException("User unauthorized");
            }
            taskBoardDbContext.Tasks.Remove(task);
            await taskBoardDbContext.SaveChangesAsync();
        }

        private async Task<Task> GetTaskByIdAsync(int id)
        {
            Task task = await taskBoardDbContext.Tasks.FirstOrDefaultAsync(t => t.Id == id);
            if (task == null)
            {
                throw new ArgumentException("Invalid task id");
            }
            return task;
        }
        private bool CheckUserId(string ownerId, string userId) => ownerId == userId;

    }
}
