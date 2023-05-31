using CoreApp.Models;
using CoreAPP.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace Forum_App.Controllers
{
    public class PostController : Controller
    {
        private readonly IPostService postService;
        public PostController(IPostService postService)
        {
            this.postService = postService;
        }

        public async Task<IActionResult> All()
        {
            List<PostViewModel> posts = await postService.GetAllAsync();
            return View(posts);
        }
        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Add(PostFormModel postFormModel)
        {
            if (!ModelState.IsValid)
            {
                return View(postFormModel);
            }
            await postService.AddPostAsync(postFormModel);
            return RedirectToAction(nameof(All));
        }
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            PostFormModel postFormModel = await postService.FindByIdAsync(id);
            return View(postFormModel);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(int id, PostFormModel postFormModel)
        {
            await postService.EditPostAsync(id, postFormModel);
            return RedirectToAction(nameof(All));
        }
        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            await postService.DeletePostAsync(id);
            return RedirectToAction(nameof(All));
        }
    }
}
