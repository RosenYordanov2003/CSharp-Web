using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using TaskBoard.Core.Contracts;
using TaskBoard.Core.ViewModels.Board;
using TaskBoard.Core.ViewModels.Task;
using TaskBoardCore.Contracts;

namespace TaskBoard.Controllers
{
    public class TaskController : Controller
    {
        private readonly UserManager<IdentityBuilder> _userManager;
        private readonly IBoardService boardService;
        private readonly ITaskService taskService;
        public TaskController(IBoardService boardService, ITaskService taskService)
        {
            this.boardService = boardService;
            this.taskService = taskService;
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            TaskFormModel taskFormModel = new TaskFormModel()
            {
                Boards = await this.boardService.GetExistingBoards()
            };

            return View(taskFormModel);
        }
        [HttpPost]
        public async Task<IActionResult> Create(TaskFormModel taskFormModel)
        {
            IEnumerable<TaskBoardFormModel> existingBoards = await boardService.GetExistingBoards();
            if (!existingBoards.Any(b => b.Id == taskFormModel.BoardId))
            {
                ModelState.AddModelError(nameof(taskFormModel.BoardId), "Board does not exist");
            }
            string currentUserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (!ModelState.IsValid)
            {
                taskFormModel.Boards = existingBoards;
                return View(taskFormModel);
            }
            await taskService.AddTask(taskFormModel, currentUserId);

            return RedirectToAction("All", "Board");
        }
    }
}
