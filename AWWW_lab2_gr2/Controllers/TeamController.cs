using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using AWWW_lab2_gr2.Models;
using System.Collections;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace AWWW_lab2_gr2.Controllers
{

    public class TeamController : Controller
    {

        private readonly MyDbContext _dbContext;

        public TeamController(MyDbContext dbContext){
            _dbContext = dbContext;
        }

        public IActionResult Index(){
            var teams = _dbContext.Teams!.ToList();
            return View(teams);
        }

        public IActionResult Add(int id = -1){
            ViewBag.LeagueList =  new SelectList(_dbContext.Leagues!, "LeagueId", "LeagueName");
            if (id != -1){
                var tag = _dbContext.Teams!.FirstOrDefault(x=>x.Id==id);
                return View(tag);
            }else{
                return View();
            }
        }

        [HttpPost]
        public IActionResult Add(Team team){
            bool err = false;
            ViewBag.LeagueList =  new SelectList(_dbContext.Leagues!.ToList(), "LeagueId", "LeagueName");
            if(team.Name == null){
               ViewBag.ErrorName = "Pole nazwa jest wymagane";
               err = true;
               //return View(); 
            }
            if(team.Country == null){
                ViewBag.ErrorCountry = "Pole kraj jest wymagane";
                err = true;
                //return View();
            }
            if(team.City == null){
                ViewBag.ErrorCity = "Pole miasto jest wymagane";
                err = true;
                //return View();
            }
            if(team.League == null){
                ViewBag.ErrorLeague = "Proszę wybrać ligę";
                err = true;
                //return View();
            }
            if(err == true){
                return View();
            }

            if(team.Id != 0){
                var x = _dbContext.Teams!.FirstOrDefault(x=>x.Id == team.Id);
                if(x != null){
                    x.Name = team.Name;
                    x.Country = team.Country;
                    x.City = team.City;
                    x.FoundingDate = team.FoundingDate;
                    x.League = team.League;
                }
            }else{
                _dbContext.Teams!.Add(team);
            }
            _dbContext.SaveChanges();
            return RedirectToAction("Index");
        }
        
    }
}