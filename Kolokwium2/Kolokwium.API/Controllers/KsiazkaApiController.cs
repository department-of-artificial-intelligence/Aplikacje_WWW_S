using Kolokwium.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Kolokwium.ViewModel.VM;
using Kolokwium.Model.DataModels;

[ApiController]
[Route("api/[controller]")]
public class KsiazkiApiController : ControllerBase
{
    private readonly IKsiazkaService _ksiazkaService;
    public KsiazkiApiController(IKsiazkaService ksiazkaService)
    {
        _ksiazkaService = ksiazkaService;
    }

    [HttpGet]
    public IActionResult GetAll() => Ok(_ksiazkaService.GetKsiazki());


    [HttpPost]
    public IActionResult Add([FromBody] AddKsiazkaVm vm)
    {
        var result = _ksiazkaService.AddKsiazka(vm);
        return CreatedAtAction(nameof(GetAll), new { id = result.Id }, result);
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        _ksiazkaService.DeleteKsiazka(id);
        return NoContent();
    }
}