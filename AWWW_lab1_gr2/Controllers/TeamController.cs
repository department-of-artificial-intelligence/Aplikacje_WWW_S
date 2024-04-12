using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using AWWW_lab1_gr2.Models;
using Microsoft.AspNetCore.Mvc.Rendering;


namespace AWWW_lab1_gr2.Controllers
{
    public class TeamController : Controller
    {
        private readonly DatabaseContext asd;

        private readonly ILogger<TeamController> _logger;

        public TeamController(ILogger<TeamController> logger, DatabaseContext _asd)
        {
            _logger = logger;
            asd = _asd;
        }

        public IActionResult Index(){
            return View(asd.Teams.ToList()!);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }

        public IActionResult Dodaj()
        {
            var leagues = asd.Leagues!.ToList();
            var leagueList = new List<SelectListItem>();
            foreach (var a in leagues)
            {
                string text = a.Name;
                string id = a.Id.ToString();
                Console.WriteLine(text);
                leagueList.Add(new SelectListItem(text, id));
            }
            ViewBag.leagueList = leagueList;
            ViewBag.buttonText = "Dodaj";
            return View();
        }

        [HttpPost]
        public IActionResult Dodaj(Team team)
        {
            Console.WriteLine($"Nazwa {team.Name}");

            if (true)
            {
                team.League = asd.Leagues.FirstOrDefault(x=>x.Id == team.LeagueId);
                asd.Teams.Add(team);

                try
                {
                    asd.SaveChanges();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    return View("Error");
                }

                return View("Index");
            }
            Console.WriteLine("nv");
            return View("Error");
        }
    }
}