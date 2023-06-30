using Microsoft.EntityFrameworkCore;
using TaskBoard.Core.ViewModels.Board;
using TaskBoard.Data;
using TaskBoardCore.Contracts;
using TaskBoardCore.ViewModels.Board;
using TaskBoardCore.ViewModels.Task;

namespace TaskBoard.Core.Services
{
    public class BoardService : IBoardService
    {
        private readonly TaskBoardDbContext taskBoardDbContext;

        public BoardService(TaskBoardDbContext taskBoardDbContext)
        {
            this.taskBoardDbContext = taskBoardDbContext;
        }

        public async Task<IEnumerable<BoardViewModel>> GetAllBoards()
        {
            List<BoardViewModel> boards = await taskBoardDbContext
                .Boards.Select(b => new BoardViewModel()
                {
                    Id = b.Id,
                    Name = b.Name,
                    Tasks = b.Tasks.Select(t => new TaskViewModel()
                    {
                        Id = t.Id,
                        Title = t.Title,
                        Description = t.Description,
                        Owner = t.Owner.NormalizedUserName
                    })
                }).ToListAsync();
            return boards;
        }

        public async Task<IEnumerable<TaskBoardFormModel>> GetExistingBoards()
        {
            IEnumerable<TaskBoardFormModel> existingBoards = await taskBoardDbContext
                .Boards.Select(b => new TaskBoardFormModel()
                {
                    Id = b.Id,
                    Name = b.Name,
                }).ToListAsync();

            return existingBoards;
        }
    }
}
