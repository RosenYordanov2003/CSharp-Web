using Homies.Models.Event;
using Homies.Models.Type;
using Homies.Services.Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Homies.Controllers
{
    [Authorize]
    public class EventController : Controller
    {
        private readonly IEventService eventService;
        private readonly ITypeService typeService;
        public EventController(IEventService eventService, ITypeService typeService)
        {
            this.eventService = eventService;
            this.typeService = typeService;
        }
        [HttpGet]
        public async Task<IActionResult> All()
        {
            IEnumerable<EventAllViewModel> eventAllViewModels = await eventService.GetAllEventsAsync();
            return View(eventAllViewModels);
        }
        [HttpGet]
        public async Task<IActionResult> Add()
        {
            IEnumerable<TypeViewModel> types = await typeService.GetAllAsync();
            EventAddViewModel addViewModel = new EventAddViewModel()
            {
                Types = types
            };
            return View(addViewModel);
        }
        [HttpPost]
        public async Task<IActionResult> Add(EventAddViewModel eventAddViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(eventAddViewModel);
            }
            await eventService.AddEventAsync(GetUserId(), eventAddViewModel);
            return RedirectToAction(nameof(All));
        }
        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            var model = await eventService.FindEventByIdAsync(id);
            return View(model);
        }
        [HttpGet]
        public async Task<IActionResult> Joined()
        {
            IEnumerable<EventAllViewModel> eventAllViewModels = await eventService.GetUserEventsAsync(GetUserId());
            return View(eventAllViewModels);
        }
        [HttpPost]
        public async Task<IActionResult> Join(int id)
        {
            try
            {
                await eventService.JoinEventToUserAsync(id, GetUserId());
                return RedirectToAction(nameof(Joined));
            }
            catch (Exception)
            {
                return RedirectToAction(nameof(All));
            }
        }
        [HttpPost]
        public async Task<IActionResult> Leave(int id)
        {
            await eventService.LeaveEventAsync(id, GetUserId());
            return RedirectToAction(nameof(All));
        }
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            EventAddViewModel eventToEdit = await eventService.GetEventToEditAsync(id);
            eventToEdit.Types = await typeService.GetAllAsync();
            return View(eventToEdit);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(int id, EventAddViewModel eventAddViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(eventAddViewModel);
            }
            try
            {
                await eventService.EditEventAsync(id, eventAddViewModel);
                return RedirectToAction(nameof(All));
            }
            catch (Exception)
            {
                return RedirectToAction(nameof(All));
            }
        }
        private string GetUserId() => User.FindFirstValue(ClaimTypes.NameIdentifier);
    }
}
