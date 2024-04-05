using AWWW_lab1_gr1.Data;
using AWWW_lab1_gr1.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace AWWW_lab1_gr1.Controllers
{
    public class TeamController : Controller
    {
        private readonly MyDBContext _dbContext;
        public TeamController(MyDBContext dBContext)
        {
            _dbContext = dBContext;
        }
        public async Task<IActionResult> Index()
        {
            var teams = await _dbContext.Teams.ToListAsync();
            return View(teams);
        }
        public IActionResult Create()
        {
            ViewData["Leagues"] = _dbContext.Leagues
                .Select(l => new SelectListItem
                {
                    Text = $"ID: {l.Id}, NAME: {l.Name}, COUNTRY: {l.Country}",
                    Value = l.Id.ToString(),
                });
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Team team)
        {
            if (!ModelState.IsValid)
            {
                return View(team);
            }
            _dbContext.Teams.Add(team);
            await _dbContext.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
