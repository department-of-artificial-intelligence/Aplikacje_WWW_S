using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Diagnostics;
using Web.Models;

namespace Web.Controllers;

public class HomeController : BaseController
{
    public HomeController(IWebHostEnvironment env) : base(env)
    {
    }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        var feature = HttpContext.Features.Get<IExceptionHandlerPathFeature>();
        var model = CreateErrorViewModel(feature?.Error);

        return View(model);
    }
}