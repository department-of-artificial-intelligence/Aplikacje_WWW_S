using Microsoft.AspNetCore.Mvc;
using AWWW_lab1_gr1.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace AWWW_lab1_gr1.Controllers;
public class PlayerController : Controller
{
    private readonly MyDbContext _context;

    public PlayerController(MyDbContext context)
    {
        _context = context;
    }
    public IActionResult Index()
    {
        var players = _context.Players.
    Include(player => player.Team).
    Include(player => player.Positions).
    ToList();
        return View(players);


    }

    public IActionResult Add()
    {
        ViewBag.PositionsList = _context.Positions.Select(p => new SelectListItem($"{p.Name}", p.Id.ToString()));
        ViewBag.TeamsList = _context.Teams.Select(tea => new SelectListItem($"{tea.Name}", tea.Id.ToString()));
        
        /*  var teams = _context.Teams.ToList();
         var teamsList = new List<SelectListItem>();
         foreach (var t in teams)
         {
             string text = t.Name + "," + t.Country + "," + t.City + "," + t.FoundingDate + "," + t.League;
             string id = t.Id.ToString();
             teamsList.Add(new SelectListItem(id,text));
         }
         ViewBag.teamsList = teamsList;
          */
        return View();
    }
}

    [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Add(Article article, List<int> selectedTagsIds)
        {
            try
            {
                if (!ModelState.IsValid)
                    return View();
                article.Tags = _dbContext.Tags.Where(t => selectedTagsIds.Contains(t.Id)).ToList();
                _dbContext.Articles.Add(article);
                _dbContext.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                throw;
            }
        }


    



}