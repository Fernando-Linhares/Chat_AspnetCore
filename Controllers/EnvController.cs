using Microsoft.AspNetCore.Mvc;
using Chat_AspnetCore.Areas.Identity.Data;
using Chat_AspnetCore;

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
            var connectionString = new ConnectionStringEnvironment();

            return Ok(new
            {
                app=_dotenv.Get("APP_NAME"),
                version=_dotenv.Get("APP_VERSION"),
                connected=context.Database.CanConnect(),
                connectionString=connectionString.ToString()
            });
        }
        catch(Exception exception)
        {
            return StatusCode(500, exception.Message);
        }
    }
}