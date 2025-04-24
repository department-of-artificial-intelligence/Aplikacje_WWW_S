using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using AWWW_lab2_gr3.Models;
using Microsoft.EntityFrameworkCore;

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
            var teams = _dbContext.Teams.Include(t => t.Players).ThenInclude(p=>p.Positions).ToList();
            return View("Index",teams);
        }

        [HttpGet]

        public IActionResult Add()
        {
            var ligi = _dbContext.Leagues.Select(a => new SelectListItem{
                Value = a.Id.ToString(),
                Text = a.Name
            }).ToList();

            var players = _dbContext.Players.Select(p => new SelectListItem{
                Value = p.Id.ToString(),
                Text = p.FirstName + " " + p.LastName
            }).ToList();

            ViewBag.Leagues = ligi;
            ViewBag.Players = players;
            return View(new Team());
        }

        public IActionResult Edit(int id)
        {
            var ligi = _dbContext.Leagues.Select(p => new SelectListItem{
                Value = p.Id.ToString(),
                Text = p.Name
            }).ToList();
            var players = _dbContext.Players.Select(p => new SelectListItem{
                Value = p.Id.ToString(),
                Text = p.FirstName + " " + p.LastName
            }).ToList();

            ViewBag.Players = players;
            ViewBag.Leagues = ligi;
            var team = _dbContext.Teams.FirstOrDefault(p => p.Id == id);
            if(team == null)
            {
                return NotFound();
            }
            ViewBag.Id = id;
            return View(team);
        }

        public IActionResult Delete(int id)
        {
            ViewBag.Id = id;
            return View("Delete");
        }

        [HttpPost]
        public IActionResult Add(Team t, int[] Players)
        {

            var league = _dbContext.Leagues.FirstOrDefault( p=> p.Id == t.LeagueId);
            t.League = league;

            if(Players != null)
            {
                foreach(var pid in Players)
                {
                    var p = _dbContext.Players.FirstOrDefault(p => p.Id == pid);
                    if(p!= null)
                    {
                        t.Players.Add(p);
                    }
                }
            }

            try{
                _dbContext.Teams.Add(t);
                _dbContext.SaveChanges();
            }
            catch(Exception e)
            {
                throw new Exception("Nie udało się dodać drużyny" + e.Message);
            }
            return RedirectToAction("Index");
        }

        [HttpPost] 
        public IActionResult DeleteC(int id)
        {

            var team = _dbContext.Teams.Include(t => t.Players).FirstOrDefault(t => t.Id == id);
    
            if (team == null)
            {
                return NotFound();
            }

            // Zaktualizuj graczy i ustaw ich TeamId na NULL
            foreach (var player in team.Players)
            {
                player.TeamId = null;
                player.Team = null;
            }

            
            if(team != null)
            {
                _dbContext.Teams.Remove(team);
            }

            try{
                _dbContext.SaveChanges();
            }
            catch(Exception e)
            {
                throw new Exception("Nie udało się usunąć drużyny" + e.Message);
            }

            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Edit(int id, [Bind("Id,Name,Country,City,FoundingDate,LeagueId,Players")] Team newTeam, int[] Players)
        {
        
            if(id != newTeam.Id)
            {
                return NotFound();
            }
        
            var team = _dbContext.Teams.Include(t => t.Players).FirstOrDefault(p=> p.Id == id);

            team.Name = newTeam.Name;
            team.Country = newTeam.Country;
            team.City = newTeam.City;
            team.FoundingDate = newTeam.FoundingDate;
            team.LeagueId = newTeam.LeagueId;
            team.League = _dbContext.Leagues.FirstOrDefault(p => p.Id == newTeam.LeagueId);

            if (team.Players != null)
            {
                foreach (var player in team.Players)
                {
                    player.TeamId = null;
                }
            }   
            team.Players.Clear();
            
            if(Players != null)
            {
                foreach(var pid in Players)
                {
                    var p = _dbContext.Players.FirstOrDefault(p => p.Id == pid);
                    if(p!= null)
                    {
                        p.TeamId = team.Id;
                        team.Players.Add(p);
                    }
                }
            }

            try{
                _dbContext.Update(team);
                _dbContext.SaveChanges();
            }
            catch(Exception e)
            {
                throw new Exception("Nie udało się usunąć drużyny" + e.Message);
            }

            return RedirectToAction("Index");
        }

    }

}