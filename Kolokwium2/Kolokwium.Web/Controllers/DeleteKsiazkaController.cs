using Microsoft.AspNetCore.Mvc;
using Kolokwium.Services.Interfaces;
using Kolokwium.ViewModel.VM;

namespace Kolokwium.Web.Controllers;

public class DeleteKsiazkaController : Controller
{
    private readonly IKsiazkaService _ksiazkaService;

    public DeleteKsiazkaController(IKsiazkaService ksiazkaService)
    {
        _ksiazkaService = ksiazkaService;
    }

    [HttpPost]
    public IActionResult Delete(int id)
    {
        var ksiazka = _ksiazkaService.DeleteKsiazka(id);
        if (ksiazka == null)
        {
            return NotFound();
        }
        return RedirectToAction("Index", "Ksiazka");
    }

 
}