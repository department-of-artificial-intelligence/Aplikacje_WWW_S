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
    public class TeamController : Controller
    {
        private readonly AppDbContext _dbContext;

        public TeamController(AppDbContext dbContext){ _dbContext = dbContext;}

        public IActionResult Index(){
            return View(_dbContext.Teams.ToList());
        }

        public IActionResult Add(int id = -1){
            if(id != -1){
                var team = _dbContext.Teams!.FirstOrDefault(a=>a.Id == id);
                return View(team);
            }
            else{
                return View();
            }
        }


        [HttpPost]
        public IActionResult Add(Team team){
            if(team.Id != 0){
                var newInstance = _dbContext.Teams!.FirstOrDefault(newInstance => newInstance.Id == team.Id);
                if(newInstance != null){
                    newInstance.Id = team.Id;
                    newInstance.Name = team.Name;
                    newInstance.Country = team.Country;
                    newInstance.City = team.City;
                    newInstance.FoundingDate = team.FoundingDate;
                    newInstance.league = _dbContext.Leagues!.ToList()[0];
                }
            }
            else{
                _dbContext.Teams!.Add(team);
            }
            _dbContext.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}