using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TaskBoard.Data;
using TaskBoardCore.Contracts;

namespace TaskBoard.Controllers
{
    [Authorize]
    public class BoardController : Controller
    {
        private readonly IBoardService boardService;
        public BoardController(IBoardService boardService)
        {
           this.boardService = boardService;
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> All()
        {
            var boards = await this.boardService.GetAllBoards();
            return View(boards);
        }
    }
}
