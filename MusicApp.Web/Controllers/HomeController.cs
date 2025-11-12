using Microsoft.AspNetCore.Mvc;
using MusicApp.Application.Users.Handlers;
using MusicApp.Application.Users.Queries;

public class HomeController : Controller
{
    public IActionResult Index() {
        return View();
    }
}
