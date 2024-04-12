using Microsoft.AspNetCore.Mvc;
using AWWW_lab1_gr1.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace AWWW_lab1_gr1.Controllers;
public class TeamController : Controller
{
    private readonly LabDbContext _dbContext;

    public TeamController(LabDbContext context)
    {
        _dbContext = context;
    }
    public IActionResult Index()
    {
        var teams = _dbContext.Teams.
    Include(team => team.League).
    ToList();
        return View(teams);


    }

    public IActionResult Add()
    {
        ViewBag.LeaguesList = _dbContext.Leagues.Select(t => new SelectListItem($"{t.Name}", t.Id.ToString()));
       
        return View();
    }

    [HttpPost]
    public IActionResult Add(Team team)
    {
        try
            {
        if (ModelState.IsValid)
        {
            _dbContext.Teams.Add(team);

            
                _dbContext.SaveChanges();
        
            


            return RedirectToAction("Index");
        } }catch (Exception expt)
            {

                return View("Error");
            }

        return View(team);
    }

}