using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using AWWW_lab2_gr3.Models;

namespace AWWW_lab2_gr3.Controllers{
    public class TeamController : Controller
    {
        private readonly AppDbContext _dbContext;

        public TeamController(AppDbContext db)
        {
            _dbContext = db;
        }

        public IActionResult Index()
        {
            ViewBag.Title = "Drużyny";
            var teams = _dbContext.Teams.ToList();
            return View("Index",teams);
        }

        [HttpGet]

        public IActionResult Add()
        {
            var ligi = _dbContext.Leagues.Select(a => new SelectListItem{
                Value = a.Id.ToString(),
                Text = a.Name
            }).ToList();

            ViewBag.Leagues = ligi;

            return View(new Team());
        }

        [HttpPost]

        public IActionResult Add(Team t)
        {
            try{
                _dbContext.Teams.Add(t);
                _dbContext.SaveChanges();
            }
            catch(Exception e)
            {
                throw new Exception("Nie udało się dodać drużyny");
            }
            return RedirectToAction("Index");
        }
    }

}