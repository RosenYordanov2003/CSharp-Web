using Microsoft.AspNetCore.Mvc;
using Simple_Chat_ASP.NET_Core_MVC_App.Models;

namespace Simple_Chat_ASP.NET_Core_MVC_App.Controllers
{
    public class ChatController : Controller
    {
       //For this exercise only
       private static List<KeyValuePair<string, string>> Messages = new List<KeyValuePair<string, string>>();

        public IActionResult Show()
        {
            if (!Messages.Any())
            {
                return View(new ChatViewModel());
            }
            ChatViewModel chatViewModel = new ChatViewModel()
            {
                Messages = Messages.Select((m) => new MessageViewModel()
                {
                    Sender = m.Key,
                    MessageText = m.Value,
                })
                .ToList()
            };
            return View(chatViewModel);
        }

        [HttpPost]
        public IActionResult Send(ChatViewModel chat)
        {
            MessageViewModel message = chat.CurrentMessage;
            Messages.Add(new KeyValuePair<string, string>(message.Sender, message.MessageText));
            return RedirectToAction("Show");
        }
    }
}
