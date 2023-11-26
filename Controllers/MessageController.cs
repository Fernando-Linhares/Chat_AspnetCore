using Chat_AspnetCore.Areas.Identity.Data;
using Chat_AspnetCore.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.SignalR;
using Chat_AspnetCore.Hubs;
using Newtonsoft.Json;

namespace Chat_AspnetCore.Controllers;

[ApiController]
[Route("api/[controller]")]
public class MessageController: Controller
{
    private ChatContext _context;

    private UserManager<ApplicationUser> _manager;

    private IHubContext<ChatHub> _chatContext;

    public MessageController(IHubContext<ChatHub> chatContext, ChatContext context, UserManager<ApplicationUser> manager)
    {
        _context = context;
        _manager = manager;
        _chatContext = chatContext;
    }

    [HttpPost]
    public async Task<IActionResult> SendMessage([FromBody] Dictionary<string, string> message)
    {
        Message messageRegister = new Message
        {
            Content = message["Content"],

            CreatedAt = DateTime.UtcNow,

            UserId =  _manager.GetUserId(User) ?? "",

            UserName = _manager.GetUserName(User) ?? ""
        };

        _context.Add(messageRegister);

        await _context.SaveChangesAsync();

        var dataMessage = new {
            Content = messageRegister.Content,
            UserName = messageRegister.UserName,
            UserId = messageRegister.UserId,
            CreatedAt = messageRegister.CreatedAt,
        };

        string jsonMessage = JsonConvert.SerializeObject(dataMessage);

        await _chatContext.Clients.All.SendAsync("ReceiveMessage", jsonMessage);

        return Ok(dataMessage);
    }
}