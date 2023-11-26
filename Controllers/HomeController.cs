using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Chat_AspnetCore.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Chat_AspnetCore.Areas.Identity.Data;

namespace Chat_AspnetCore.Controllers;

[Authorize]
public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    private UserManager<ApplicationUser> _manager;

    private ChatContext _context;

    public HomeController(ChatContext context, ILogger<HomeController> logger, UserManager<ApplicationUser> manager)
    {
        _context = context;
        _manager = manager;
        _logger = logger;
    }

    public async Task<IActionResult> Index()
    {
        ViewBag.ApplicationUser = await  _manager.GetUserAsync(User);

        ViewBag.Messages = _context.Message.ToList();

        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
