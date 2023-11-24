using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Chat_AspnetCore.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;

namespace Chat_AspnetCore.Controllers;

[Authorize]
public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    private UserManager<Chat_AspnetCore.Areas.Identity.Data.ApplicationUser> _manager;

    public HomeController(ILogger<HomeController> logger, UserManager<Chat_AspnetCore.Areas.Identity.Data.ApplicationUser> manager)
    {
        _manager = manager;
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
