using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Kolokwium.Models;

public class MatchPlayerController : Controller
{
    private readonly MyDbContext _context;
    public MatchPlayerController(MyDbContext context)
    {
        _context = context;
    }
    public IActionResult Index()
    {
        var matchPlayers = _context.MatchPlayer.ToList();
        return View(matchPlayers);
    }
}