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
    public class PositionController : Controller
    {
        private readonly AppDbContext _dbContext;

        public PositionController(AppDbContext dbContext){ _dbContext = dbContext;}

        public IActionResult Index(){
            return View(_dbContext.Positions.ToList());
        }

        public IActionResult Add(int id = -1){
            if(id != -1){
                var position = _dbContext.Positions!.FirstOrDefault(a=>a.Id == id);
                return View(position);
            }
            else{
                return View();
            }
        }


        [HttpPost]
        public IActionResult Add(Position position){
            if(position.Id != 0){
                var newInstance = _dbContext.Positions!.FirstOrDefault(newInstance => newInstance.Id == position.Id);
                if(newInstance != null){
                    newInstance.Name = position.Name;
                }
            }
            else{
                _dbContext.Positions!.Add(position);
            }
            _dbContext.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}