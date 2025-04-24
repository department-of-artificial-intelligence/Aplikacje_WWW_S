using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using AWWW_lab2_gr3.Models;
using Microsoft.EntityFrameworkCore;

namespace AWWW_lab2_gr3.Controllers{

    public class PlayerController : Controller{

        private readonly AppDbContext _dbContext;

        public PlayerController(AppDbContext db)
        {
            _dbContext = db;
        }

        public IActionResult Index()
        {
            ViewBag.Title = "Gracze";
            var players = _dbContext.Players.ToList();
            return View("Index",players);
        }

        [HttpGet]
        public IActionResult Add()
        {
            var positions = _dbContext.Positions.Select(p => new SelectListItem {
                Value = p.Id.ToString(),
                Text = p.Name
            }).ToList();
            var team = _dbContext.Teams.Select(t => new SelectListItem {
                Value = t.Id.ToString(),
                Text = t.Name
            }).ToList();
            ViewBag.Teams = team;
            ViewBag.Positions = positions;
            return View(new Player());
        }

        public IActionResult Edit(int id)
        {
        var player = _dbContext.Players.FirstOrDefault(p => p.Id == id);
        
        if (player == null)
        {
            return NotFound();
        }

        ViewBag.PositionId = _dbContext.Positions.Select(p => new SelectListItem {
                Value = p.Id.ToString(),
                Text = p.Name
            }).ToList();
        var team = _dbContext.Teams.Select(t => new SelectListItem {
                Value = t.Id.ToString(),
                Text = t.Name
            }).ToList();
            ViewBag.Teams = team;
        return View("Edit",player);
        }

        public IActionResult Delete(int id)
        {
            var player = _dbContext.Players.FirstOrDefault(p => p.Id == id);
            if(player == null)
            {
                return NotFound();
            }
            @ViewBag.Id = id;
            return View();
        }

        [HttpPost]
        public IActionResult Add(Player p, int[] Positions)
        {
                p.Positions = [];
                p.Team = _dbContext.Teams.FirstOrDefault(t => t.Id == p.TeamId);
                if(Positions != null)
                {
                    foreach(var pl in Positions)
                    {
                        var po = _dbContext.Positions.FirstOrDefault(pid => pid.Id == pl);
                        if(po!= null)
                        {
                            p.Positions.Add(po);
                        }
                    }
                }
                try
                {
                    _dbContext.Players.Add(p);
                }
                catch (Exception e)
                {
                    throw new Exception("Nie udało się dodać gracza: " + e.Message);
                }
                _dbContext.SaveChanges();

                return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Edit(int id, [Bind("Id,FirstName,LastName,Country,BirthDate,TeamId,Positions")] Player newPlayer, int[] Positions )
        {
            
            if(id != newPlayer.Id)
            {
                return NotFound();
            }

            var player = _dbContext.Players.Include(p => p.Positions).FirstOrDefault(t => t.Id == id);

            player.FirstName = newPlayer.FirstName;
            player.LastName = newPlayer.LastName;
            player.Country = newPlayer.Country;
            player.BirthDate = newPlayer.BirthDate;
            player.TeamId = newPlayer.TeamId;
            player.Team = _dbContext.Teams.FirstOrDefault(t => t.Id == newPlayer.TeamId);
            
            foreach(var position in player.Positions)
            {
                position.PlayerId = null;
            }
            player.Positions.Clear();
            if(Positions != null)
                {
                    foreach(var pl in Positions)
                    {
                        var po = _dbContext.Positions.FirstOrDefault(pid => pid.Id == pl);
                        if(po!= null)
                        {
                            player.Positions.Add(po);
                        }
                    }
                }
            try{
                _dbContext.Update(player);
                _dbContext.SaveChanges();
            }
            catch(Exception e)
            {
                throw new Exception("Nie udało się zmienić gracza: " + e.Message);
            }
            return RedirectToAction("Index");

        }

        [HttpPost]
        public IActionResult DeleteC(int id)
        {
            var player = _dbContext.Players.Include(p => p.Positions).FirstOrDefault(t => t.Id == id);


            if(player != null)
            {
                foreach (var position in player.Positions)
                {
                    position.PlayerId = null;
                }
                _dbContext.Players.Remove(player);
            }
            try{
                _dbContext.SaveChanges();
            }
            catch(Exception e)
            {
                throw new Exception("Nie udało się usunąć gracza: " + e.Message);
            }
            return RedirectToAction("Index");
        }

    }
}


/*

 if (ModelState.IsValid)
            {
                var selectedPositions = _dbContext.Positions
                    .Where(a => PositionIds.Contains(a.Id))
                    .ToList();
                p.Positions = selectedPositions;
                try
                {
                    _dbContext.Players.Add(p);
                }
                catch (Exception e)
                {
                    throw new Exception("Nie udało się dodać gracza: " + e.Message);
                }
                _dbContext.SaveChanges();

                return RedirectToAction("Index");
            }
            else
            {
                var selectedPositions = p.Positions.Select(a => a.Id).ToList();

                var positions = _dbContext.Positions.Select(a => new SelectListItem
                {
                    Value = a.Id.ToString(),
                    Text = a.Name,
                    Selected = selectedPositions.Contains(a.Id)
                });

                ViewBag.Positions = positions;
                return View(p);
            }

*/