using Chat_AspnetCore.Areas.Identity.Data;
using Chat_AspnetCore.Models;
using Microsoft.AspNetCore.Mvc;

namespace Chat_AspnetCore.Controllers;

[ApiController]
[Route("api/[controller]")]
public class MessageController: Controller
{
    private ChatContext _context;

    public MessageController(ChatContext context)
    {
        _context = context;
    }

    [HttpPost]
    public async Task<IActionResult> SendMessage([FromBody] dynamic message)
    {
        Message messageRegister = new Message
        {
            Content = message.Content
        };

        // _context.Add(messageRegister);

        // await _context.SaveChangesAsync();

        return Ok(messageRegister);   
    }
}