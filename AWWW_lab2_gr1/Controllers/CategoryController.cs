using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AWWW_lab2_gr1.Models;
using Microsoft.VisualBasic;

namespace AWWW_lab2_gr1.Controllers
{
    public class CategoryController : Controller
    {
        private readonly AppDbContext _db;

        public CategoryController(AppDbContext db)
        {
            _db = db;
        }

        public IActionResult Index() //R
        {
           return View(_db.Categories.ToList());
        }

        [HttpPost]
        public IActionResult Delete(int id) //D
        {
            var category = _db.Categories.Find(id);
            if (category != null)
            {
                _db.Categories.Remove(category);
                _db.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        public IActionResult Create() //C
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateConfirmed(Category category)
        {
            if (category != null)
            {
                _db.Categories.Add(category);
                _db.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        public IActionResult Update(int id) //U
        {
            var category = _db.Categories.Find(id);
            if (category != null)
            {
                return View(category);
            }
             return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult UpdateConfirmed(Category category)
        {
            if (category != null)
            {
                _db.Categories.Update(category);
                _db.SaveChanges();
            }
            return RedirectToAction("Index");
        }
    }
}