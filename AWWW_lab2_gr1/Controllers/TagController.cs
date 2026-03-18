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
    public class TagController : Controller
    {
        private readonly AppDbContext _db;

        public TagController(AppDbContext db)
        {
            _db = db;
        }

        public IActionResult Index() //R
        {
           return View(_db.Tags.ToList());
        }

        [HttpPost]
        public IActionResult Delete(int id) //D
        {
            var tag = _db.Tags.Find(id);
            if (tag != null)
            {
                _db.Tags.Remove(tag);
                _db.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        public IActionResult Create() //C
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateConfirmed(Tag tag)
        {
            if (tag != null)
            {
                _db.Tags.Add(tag);
                _db.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        public IActionResult Update(int id) //U
        {
            var tag = _db.Tags.Find(id);
            if (tag != null)
            {
                return View(tag);
            }
             return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult UpdateConfirmed(Tag tag)
        {
            if (tag != null)
            {
                _db.Tags.Update(tag);
                _db.SaveChanges();
            }
            return RedirectToAction("Index");
        }
    }
}