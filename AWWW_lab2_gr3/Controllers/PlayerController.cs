using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using AWWW_lab2_gr3.Models;

namespace AWWW_lab2_gr3.Controllers {

    public class PlayerController : Controller {
        MyDbContext _dbContext;

        public PlayerController(MyDbContext context) {
            _dbContext = context;
        }

        public IActionResult Index() {
            var players = _dbContext.Players.ToList();
            return View(players);
        }

        public IActionResult Add(){
            var teams = _dbContext.Teams.Select( t=> new SelectListItem {
                Value = t.Id.ToString(),
                Text = t.Name
            });
            var positions = _dbContext.Positions.Select(p=> new SelectListItem{
                Value = p.Id.ToString(),
                Text= p.Name
            });
            ViewBag.Teams = teams.ToList();
            ViewBag.Positions = positions.ToList();
            return View("Add");
        }
        
        
        public IActionResult Delete(int id) {
            var player = _dbContext.Players.FirstOrDefault(p=>p.Id==id);
            ViewBag.id = id;
            return View("Delete", player);
        }

        public IActionResult Edit(int id) {
            var player = _dbContext.Players.FirstOrDefault(p=>p.Id==id);
            var teams = _dbContext.Teams.Select( t=> new SelectListItem {
                Value = t.Id.ToString(),
                Text = t.Name
            });
            var positions = _dbContext.Positions.Select(p=> new SelectListItem{
                Value = p.Id.ToString(),
                Text= p.Name
            });
            ViewBag.Teams = teams.ToList();
            ViewBag.Positions = positions.ToList();
            return View("Edit", player);
        }

        [HttpPost]
        public IActionResult Add(Player player) {
            if (ModelState.IsValid) {
                if (player == null)
                    return View("PlayerNull");
                
                _dbContext.Players.Add(player);

                try {
                    _dbContext.SaveChanges();
                } catch (Exception e) {
                    return View("DbContextError");
                }

                return RedirectToAction("Index");
            }
            else
                return View("Problemo");
            
        }

        [HttpPost]
        public IActionResult Edit(int id, [Bind("Id,FirstName,LastName,Country,BirthDate,TeamId,Positions")] Player player) {
             if (ModelState.IsValid) {
                if (player == null)
                    return View("PlayerNull");
                
                _dbContext.Update(player);

                try {
                    _dbContext.SaveChanges();
                } catch (Exception e) {
                    return View("DbContextError");
                }

                return RedirectToAction("Index");
            }
            else
                return View("Problemo");
        }

        [HttpPost]
        public IActionResult DeletePost(int id) {
            if (ModelState.IsValid) {
                if (id == null)
                    return View("PlayerNull");
                var player = _dbContext.Players.Find(id);
            
                _dbContext.Players.Remove(player);

                try {
                    _dbContext.SaveChanges();
                } catch (Exception e) {
                    return View("DbContextError");
                }

                return RedirectToAction("Index");
            }
            else
                return View("Problemo");
        }
    }
}