using Microsoft.AspNetCore.Mvc;
using Kolokwium.Services.Interfaces;

namespace Kolokwium.Web.Controllers;

public class WydawnictwoController : Controller
{
    private readonly IWydawnictwoService _wydawnictwoService;

    public WydawnictwoController(IWydawnictwoService wydawnictwoService)
    {
        _wydawnictwoService = wydawnictwoService;
    }

    public IActionResult Index()
    {
        var wydawnictwa = _wydawnictwoService.GetAll();
        return View(wydawnictwa);
    }

    public IActionResult Details(int id)
    {
        var wydawnictwo = _wydawnictwoService.GetById(id);
        if (wydawnictwo == null)
            return NotFound();

        return View(wydawnictwo);
    }
}