using Microsoft.AspNetCore.Mvc;
using Chat_AspnetCore.Areas.Identity.Data;

namespace Chat_AspnetCore.Controllers;

[ApiController]
[Route("/[controller]/[action]")]
public class EnvController: Controller
{
    private readonly DotEnv _dotenv = new();

    [HttpGet]
    public IActionResult App(ChatContext context)
    {
        try
        {
            return Ok(new
            {
                app=_dotenv.Get("APP_NAME"),
                version=_dotenv.Get("APP_VERSION"),
                connected=context.Database.CanConnect()
            });
        }
        catch(Exception exception)
        {
            return StatusCode(500, exception.Message);
        }
    }
}