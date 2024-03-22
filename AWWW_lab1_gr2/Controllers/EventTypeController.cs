using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using AWWW_lab1_gr2.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace AWWW_lab1_gr2.Controllers
{
    public class EventTypeController : Controller
    {
        private readonly ILogger<EventTypeController> _logger;
        private readonly DatabaseContext asd;
        public EventTypeController(DatabaseContext databaseContext, ILogger<EventTypeController> logger){
            asd = databaseContext;
            _logger = logger;
        }
        

        public IActionResult Index(){
            return View(asd.EventTypes.ToList()!);
        }
        public IActionResult Dodaj(int id = -1)
        {

            if (id != -1)
            {
                var eventType = asd.EventTypes!
                    .FirstOrDefault(a => a.Id == id);
                @ViewBag.Header = "Edytuj typ zdarzenia";
                @ViewBag.ButtonText = "Edytuj";
                return View(eventType);
            }
            else
            {
                @ViewBag.Header = "Dodaj typ zdarzenia";
                @ViewBag.ButtonText = "Dodaj";
                return View();
            }
            
        }

        [HttpPost]
        public IActionResult Dodaj(EventType eventType)
        {
            if (eventType.Id != 0)
            {
                var a = asd.EventTypes!.FirstOrDefault(a => a.Id == eventType.Id);
                if (a != null)
                {
                    a.Name = eventType.Name;
                }
            }
            else
            {
                asd.EventTypes!.Add(eventType);
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