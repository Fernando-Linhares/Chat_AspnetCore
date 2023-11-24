using Chat_AspnetCore.Areas.Identity.Data;
using Chat_AspnetCore.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;

namespace Chat_AspnetCore.Controllers;

[ApiController]
[Route("api/[controller]")]
public class MessageController: Controller
{
    private ChatContext _context;

    private UserManager<ApplicationUser> _manager;

    public MessageController(ChatContext context, UserManager<ApplicationUser> manager)
    {
        _context = context;
        _manager = manager;
    }

    [HttpPost]
    public async Task<IActionResult> SendMessage([FromBody] Dictionary<string, string> message)
    {
        Message messageRegister = new Message
        {
            Content = message["Content"],

            CreatedAt = DateTime.UtcNow,

            ApplicationUser = await _manager.GetUserAsync(User)
        };

        _context.Add(messageRegister);

        await _context.SaveChangesAsync();

        return Ok(message);   
    }
}