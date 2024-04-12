using AWWW_lab1_gr1.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace AWWW_lab1_gr1.Controllers
{
    public class TeamController : Controller
    {
        private readonly MyDbContext _dbContext;

        public TeamController(MyDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IActionResult Index()
        {
            var teams = _dbContext.Teams!.ToList(); 
            return View(teams);
        }

        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(Team team)
        {
            _dbContext.Teams!.Add(team); 
            _dbContext.SaveChanges();
            return RedirectToAction("Index");
        }


        


    }
}