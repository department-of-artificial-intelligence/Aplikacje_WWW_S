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
    public class EventTypeController : Controller
    {
        private readonly AppDbContext _dbContext;

        public EventTypeController(AppDbContext dbContext){ _dbContext = dbContext;}

        public IActionResult Index(){
            return View(_dbContext.EventTypes.ToList());
        }

        public IActionResult Add(int id = -1){
            if(id != -1){
                var eventType = _dbContext.EventTypes!.FirstOrDefault(a=>a.Id == id);
                return View(eventType);
            }
            else{
                return View();
            }
        }


        [HttpPost]
        public IActionResult Add(EventType eventType){
            if(eventType.Id != 0){
                var newInstance = _dbContext.EventTypes!.FirstOrDefault(newInstance => newInstance.Id == eventType.Id);
                if(newInstance != null){
                    newInstance.Name = eventType.Name;
                }
            }
            else{
                _dbContext.EventTypes!.Add(eventType);
            }
            _dbContext.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}