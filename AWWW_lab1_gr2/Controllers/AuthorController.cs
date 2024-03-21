using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using AWWW_lab1_gr2.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace AWWW_lab1_gr2.Controllers
{
    public class AuthorController : Controller{
        private readonly DatabaseContext asd;
        public AuthorController(DatabaseContext databaseContext){
            asd = databaseContext;
        }
        public IActionResult Index(){
            return View(asd.Authors.ToList()!);
        }
        public IActionResult Dodaj(int id = -1)
        {

            if (id != -1)
            {
                var author = asd.Authors!
                    .FirstOrDefault(a => a.Id == id);
                @ViewBag.Header = "Edytuj autora";
                @ViewBag.ButtonText = "Edytuj";
                return View(author);
            }
            else
            {
                @ViewBag.Header = "Dodaj autora";
                @ViewBag.ButtonText = "Dodaj";
                return View();
            }
            
        }

        [HttpPost]
        public IActionResult Dodaj(Author author)
        {
            if (author.Id != 0)
            {
                var a = asd.Authors!.FirstOrDefault(a => a.Id == author.Id);
                if (a != null)
                {
                    a.FirstName = author.FirstName;
                    a.LastName = author.LastName;
                }
            }
            else
            {
                asd.Authors!.Add(author);
            }
            asd.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}