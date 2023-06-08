using Microsoft.EntityFrameworkCore;
using TaskBoard.Core.Contracts;
using TaskBoard.Core.ViewModels.Home;
using TaskBoard.Data;
using TaskBoard.Data.Models;

namespace TaskBoard.Core.Services
{
    public class HomeService : IHomeService
    {
        private readonly TaskBoardDbContext taskBoardDbContext;
        public HomeService(TaskBoardDbContext taskBoardDbContext)
        {
            this.taskBoardDbContext = taskBoardDbContext;
        }

        public async Task<HomeViewModel> ConfigureHomeViewModelAsync()
        {
            List<string> boards = await taskBoardDbContext.Boards
                .Select(b => b.Name)
                .Distinct()
                .ToListAsync();

           List<HomeBoardModel> boardTasks = new List<HomeBoardModel>();

            foreach (string board in boards)
            {
                int tasksInBoard = await taskBoardDbContext.Tasks.Where(t => t.Board.Name == board).CountAsync();
                boardTasks.Add(new HomeBoardModel()
                {
                    BoardName = board,
                    TaskCount = tasksInBoard
                });
            }
            HomeViewModel homeViewModel = new HomeViewModel()
            {
                AllTasksCount = await taskBoardDbContext.Tasks.CountAsync(),
                BoardsWithTasksCount = boardTasks,
            };
            return homeViewModel;
        }

        public async Task<int> GetUserTasksCountAsync(string userId)
        {
            int count = await taskBoardDbContext.Tasks.Where(t => t.OwnerId == userId).CountAsync();
            return count;
        }
    }
}
