using Microsoft.AspNetCore.Mvc;
using AWWW_lab1_gr1.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace AWWW_lab1_gr1.Controllers;
public class TeamController : Controller
{
    private readonly MyDbContext bdContext;

    public TeamController(MyDbContext bdContext)
    {
        this.bdContext = bdContext;
    }
    public IActionResult Index()
    {
        var teams = bdContext.Teams.Include(team => team.League).ToList();
        return View(teams);


    }

    public IActionResult Add()
    {
        ViewBag.LeaguesList = bdContext.Leagues.Select(t => new SelectListItem($"{t.Name}", t.Id.ToString()));
     
        return View();
    }

    [HttpPost]
    public IActionResult Add(Team team)
    {
        try
            {
        if (ModelState.IsValid)
        {
            bdContext.Teams.Add(team);

            
                bdContext.SaveChanges();
        
            


            return RedirectToAction("Index");
        } }catch (Exception ex)
            {

                return View("Error");
            }

        return View(team);
    }

}