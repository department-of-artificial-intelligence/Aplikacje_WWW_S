using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

using AWWW_lab2_gr2.Models;
using AWWW_lab2_gr2.Data;
namespace AWWW_lab2_gr2.Controllers
{
    public class LeagueController : Controller
    {
        private readonly AppDbContext _dbContext;

        public LeagueController(AppDbContext dbContext){ _dbContext = dbContext;}

        public IActionResult Index(){
            return View(_dbContext.Leagues.ToList());
        }

        public IActionResult Add(int id = -1){
            if(id != -1){
                var league = _dbContext.Leagues!.FirstOrDefault(a=>a.Id == id);
                return View(league);
            }
            else{
                return View();
            }
        }


        [HttpPost]
        public IActionResult Add(League league){
            if(league.Id != 0){
                var newInstance = _dbContext.Leagues!.FirstOrDefault(newInstance => newInstance.Id == league.Id);
                if(newInstance != null){
                    newInstance.Name = league.Name;
                    newInstance.Country = league.Country;
                    newInstance.Level = league.Level;
                }
            }
            else{
                _dbContext.Leagues!.Add(league);
            }
            _dbContext.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}