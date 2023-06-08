using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using TaskBoard.Core.Contracts;
using TaskBoard.Core.ViewModels.Board;
using TaskBoard.Core.ViewModels.Task;
using TaskBoardCore.Contracts;
using TaskBoardCore.ViewModels.Task;

namespace TaskBoard.Controllers
{
    [Authorize]
    public class TaskController : Controller
    {
        private readonly IBoardService boardService;
        private readonly ITaskService taskService;
        public
            TaskController(IBoardService boardService, ITaskService taskService)
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
            string currentUserId = GetUserId();
            if (!ModelState.IsValid)
            {
                taskFormModel.Boards = existingBoards;
                return View(taskFormModel);
            }
            await taskService.AddTaskAsync(taskFormModel, currentUserId);

            return RedirectToAction("All", "Board");
        }
        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            try
            {
                TaskDetailsViewModel model = await taskService.GetTaskDetailsAsync(id);
                return View(model);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            try
            {
                TaskFormModel taskFormModel = await taskService.GetTaskToEditAsync(id, GetUserId());
                return View(taskFormModel);
            }
            catch (ArgumentException)
            {
                return BadRequest();
            }
            catch (InvalidOperationException)
            {
                return Unauthorized();
            }

        }
        [HttpPost]
        public async Task<IActionResult> Edit(int id, TaskFormModel taskFormModel)
        {
            await taskService.EditTaskByIdAsync(id, taskFormModel);
            return RedirectToAction("All", "Board");
        }
        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                TaskViewModel taskViewModel = await taskService.GetTaskToDeleteAsync(id, GetUserId());
                return View(taskViewModel);
            }
            catch (ArgumentException)
            {
                return BadRequest();
            }
            catch (InvalidOperationException)
            {
                return Unauthorized();
            }
        }
        [HttpPost]
        public async Task<IActionResult> Delete(TaskViewModel taskViewModel)
        {
            try
            {
                await taskService.DeleteTaskAsync(taskViewModel, GetUserId());
                return RedirectToAction("All", "Board");
            }
            catch (ArgumentException)
            {
                return BadRequest();
            }
            catch (InvalidOperationException)
            {
                return Unauthorized();
            }
        }
        private string GetUserId() => User.FindFirstValue(ClaimTypes.NameIdentifier);

    }
}
