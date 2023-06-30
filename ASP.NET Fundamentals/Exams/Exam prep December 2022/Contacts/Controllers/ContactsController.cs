namespace Contacts.Controllers
{
    using Contacts.Contracts;
    using Contacts.Models.Contact;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using System.Security.Claims;

    [Authorize]
    public class ContactsController : Controller
    {
        private readonly IContacService contacService;
        public ContactsController(IContacService contacService)
        {
            this.contacService = contacService;
        }
        [HttpGet]
        public async Task<IActionResult> All()
        {
            IEnumerable<ContactAllViewModel> allContacts = await contacService.GetAllAsync();
            return View(allContacts);
        }
        [HttpGet]
        public async Task<IActionResult> Team()
        {
            IEnumerable<ContactAllViewModel> userContact = await contacService.GetUserContactTeamsAsync(GetUserId());
            return View(userContact);
        }
        [HttpGet]
        public IActionResult Add()
        {
            ContactAddViewModel contactAddViewModel = new ContactAddViewModel();
            return View(contactAddViewModel);
        }
        [HttpPost]
        public async Task<IActionResult> Add(ContactAddViewModel contactAddViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(contactAddViewModel);
            }
            await contacService.CreateContactAsync(contactAddViewModel);
            return RedirectToAction(nameof(All));
        }
        [HttpPost]
        public async Task<IActionResult> AddToTeam(int id)
        {
            try
            {
                await contacService.AddContactToUserAsync(id, GetUserId());
                return RedirectToAction(nameof(All));
            }
            catch (InvalidOperationException)
            {
                return RedirectToAction(nameof(All));
            }
        }
        [HttpPost]
        public async Task<IActionResult> RemoveFromTeam(int id)
        {
            try
            {
                await contacService.RemoveContactFromUserAsync(id, GetUserId());
                return RedirectToAction(nameof(Team));
            }
            catch (InvalidOperationException)
            {
                return RedirectToAction(nameof(Team));
            }
        }
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            try
            {
                ContactAddViewModel contact = await contacService.FindContactToEdit(id);
                return View(contact);
            }
            catch (InvalidOperationException)
            {
                return RedirectToAction(nameof(All));
            }
        }
        [HttpPost]
        public async Task<IActionResult> Edit(int id, ContactAddViewModel contactAddViewModel)
        {
            await contacService.EditContactAsync(id, contactAddViewModel);
            return RedirectToAction(nameof(All));
        }
        private string GetUserId() => User.FindFirstValue(ClaimTypes.NameIdentifier);
    }
}
