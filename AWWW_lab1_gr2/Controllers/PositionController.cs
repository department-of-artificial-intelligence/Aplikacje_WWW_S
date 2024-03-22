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
    public class PositionController : Controller
    {
        private readonly ILogger<PositionController> _logger;
        private readonly DatabaseContext asd;
        public PositionController(DatabaseContext databaseContext, ILogger<PositionController> logger){
            asd = databaseContext;
            _logger = logger;
        }
        

        public IActionResult Index(){
            return View(asd.Positions.ToList()!);
        }
        public IActionResult Dodaj(int id = -1)
        {

            if (id != -1)
            {
                var position = asd.Positions!
                    .FirstOrDefault(a => a.Id == id);
                @ViewBag.Header = "Edytuj pozycję";
                @ViewBag.ButtonText = "Edytuj";
                return View(position);
            }
            else
            {
                @ViewBag.Header = "Dodaj pozycję";
                @ViewBag.ButtonText = "Dodaj";
                return View();
            }
            
        }

        [HttpPost]
        public IActionResult Dodaj(Position position)
        {
            if (position.Id != 0)
            {
                var a = asd.Positions!.FirstOrDefault(a => a.Id == position.Id);
                if (a != null)
                {
                    a.Name = position.Name;
                }
            }
            else
            {
                asd.Positions!.Add(position);
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