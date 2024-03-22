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
    public class TagController : Controller
    {
        private readonly ILogger<TagController> _logger;
        private readonly DatabaseContext asd;
        public TagController(DatabaseContext databaseContext, ILogger<TagController> logger){
            asd = databaseContext;
            _logger = logger;
        }
        

        public IActionResult Index(){
            return View(asd.Tags.ToList()!);
        }
        public IActionResult Dodaj(int id = -1)
        {

            if (id != -1)
            {
                var tag = asd.Tags!
                    .FirstOrDefault(a => a.Id == id);
                @ViewBag.Header = "Edytuj tag";
                @ViewBag.ButtonText = "Edytuj";
                return View(tag);
            }
            else
            {
                @ViewBag.Header = "Dodaj tag";
                @ViewBag.ButtonText = "Dodaj";
                return View();
            }
            
        }

        [HttpPost]
        public IActionResult Dodaj(Tag tag)
        {
            if (tag.Id != 0)
            {
                var a = asd.Tags!.FirstOrDefault(a => a.Id == tag.Id);
                if (a != null)
                {
                    a.Name = tag.Name;
                }
            }
            else
            {
                asd.Tags!.Add(tag);
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