using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using AWWW_lab1_gr2.Models;

namespace AWWW_lab1_gr2.Controllers
{
    public class LeagueController : Controller
    {
        private readonly ILogger<LeagueController> _logger;
        private readonly DatabaseContext asd;
        public LeagueController(DatabaseContext databaseContext, ILogger<LeagueController> logger){
            asd = databaseContext;
            _logger = logger;
        }
        

        public IActionResult Index(){
            return View(asd.Leagues.ToList()!);
        }
        public IActionResult Dodaj(int id = -1)
        {

            if (id != -1)
            {
                var league = asd.Leagues!
                    .FirstOrDefault(a => a.Id == id);
                @ViewBag.Header = "Edytuj ligę";
                @ViewBag.ButtonText = "Edytuj";
                return View(league);
            }
            else
            {
                @ViewBag.Header = "Dodaj ligę";
                @ViewBag.ButtonText = "Dodaj";
                return View();
            }
            
        }

        [HttpPost]
        public IActionResult Dodaj(League league)
        {
            if (league.Id != 0)
            {
                var a = asd.Leagues!.FirstOrDefault(a => a.Id == league.Id);
                if (a != null)
                {
                    a.Name = league.Name;
                }
            }
            else
            {
                asd.Leagues!.Add(league);
            }
            asd.SaveChanges();
            return RedirectToAction("Index");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }
    }
}