using Microsoft.AspNetCore.Mvc;
using Kolokwium.Services.Interfaces;

namespace Kolokwium.Web.Controllers;

public class KsiazkaController : Controller
{
    private readonly IKsiazkaService _ksiazkaService;

    public KsiazkaController(IKsiazkaService ksiazkaService)
    {
        _ksiazkaService = ksiazkaService;
    }

    public IActionResult Index()
    {
        var ksiazki = _ksiazkaService.GetKsiazki();
        return View(ksiazki);
    }
}