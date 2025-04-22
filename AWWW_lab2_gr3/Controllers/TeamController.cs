using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using AWWW_lab2_gr3.Models;

namespace AWWW_lab2_gr3.Controllers {
    public class TeamController : Controller {

        private readonly MyDbContext _dbContext;

        public TeamController(MyDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public IActionResult Index() {
            var teams = _dbContext.Teams.ToList();
            return View(teams);
        }

        public IActionResult Add()
        {
            var leagues = _dbContext.Leagues.Select(l=> new SelectListItem{
                Value = l.Id.ToString(),
                Text = l.Name
            }).ToList();
            ViewBag.Leagues = leagues;
            return View("Add");
        }

        public IActionResult Edit(int id)
        {
            var team = _dbContext.Teams.FirstOrDefault(t=>t.Id==id);
            var leagues = _dbContext.Leagues.Select(l=> new SelectListItem{
                Value = l.Id.ToString(),
                Text = l.Name
            }).ToList();
            ViewBag.Leagues = leagues;
            return View("Edit", team);
        }

        public IActionResult Delete(int id)
        {
            ViewBag.id = id;
            return View("Delete");
        }

        [HttpPost]
        public IActionResult Add(Team team)
        {
            if (ModelState.IsValid)
            {
                if (team == null) //można wykonać takie sprawdzenie, w razie braku - błąd na etapie "SaveChanges"
                {
                    return View("TeamNull");

                }
                
                _dbContext.Teams.Add(team);

                try
                {
                    _dbContext.SaveChanges();
                }
                catch (Exception ex)
                {
                    return View("DbContextError");
                }

                return RedirectToAction("Index");
            }
            foreach (var modelState in ModelState)
            {
                var key = modelState.Key;
                var errors = modelState.Value.Errors;
                foreach (var error in errors)
                {
                    Console.WriteLine($"Pole: {key}, Błąd: {error.ErrorMessage}");
                }
            }
            return View("Notvalid");
        }

        [HttpPost]
        public IActionResult Edit(int id, [Bind("Id,Name,Country,City,FoundingDate,LeagueId")] Team team)
        {
            if (ModelState.IsValid)
            {

                if (id != team.Id) {
                    return View("IdNieRowneTeamId");
                }
                
                _dbContext.Update(team);

                try
                {
                    _dbContext.SaveChanges();
                }
                catch (Exception ex)
                {
                    return View("DbContextError");
                }

                return RedirectToAction("Index");
            }
            foreach (var modelState in ModelState)
            {
                var key = modelState.Key;
                var errors = modelState.Value.Errors;
                foreach (var error in errors)
                {
                    Console.WriteLine($"Pole: {key}, Błąd: {error.ErrorMessage}");
                }
            }
            return View("Notvalid");
        }

        [HttpPost]
        public IActionResult DeleteConfirm(int id)
        {
            Console.WriteLine("DeleteConfirm: " + id);
            if (ModelState.IsValid)
            {
                var team = _dbContext.Teams.Find(id);
                
                if (team == null) {
                    return View("TeamNull");
                }
                
                _dbContext.Teams.Remove(team);

                try
                {
                    _dbContext.SaveChanges();
                }
                catch (Exception ex)
                {
                    return View("DbContextError");
                }

                return RedirectToAction("Index");
            }
            return View("Notvalid");
        }
    }
}
