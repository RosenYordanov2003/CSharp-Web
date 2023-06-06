using Microsoft.AspNetCore.Mvc;
using TaskBoard.Data;

namespace TaskBoard.Controllers
{
    public class BoardController : Controller
    {
        private readonly TaskBoardDbContext taskBoardDbContext;
        public BoardController(TaskBoardDbContext taskBoardDbContext)
        {
            this.taskBoardDbContext = taskBoardDbContext;
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
