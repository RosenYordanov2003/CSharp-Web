using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using TaskBoard.Core.Contracts;
using TaskBoard.Core.ViewModels.Home;

namespace TaskBoard.Controllers
{
    public class HomeController : Controller
    {
        private readonly IHomeService homeService;
        public HomeController(IHomeService homeService)
        {
            this.homeService = homeService;
        }
        public async Task<IActionResult> Index()
        {
            int userTaskCount = 0;
            if(User?.Identity?.IsAuthenticated ?? false)
            {
                userTaskCount = await homeService.GetUserTasksCountAsync(GetUserId());
            }
            HomeViewModel homeViewModel = await homeService.ConfigureHomeViewModelAsync();
            homeViewModel.UserTasksCount = userTaskCount;

            return View(homeViewModel);
        }
        private string GetUserId() => User.FindFirstValue(ClaimTypes.NameIdentifier);
    }
}