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
    public class AddressController : Controller
    {
        private readonly AppDbContext _db;

        public AddressController(AppDbContext db)
        {
            _db = db;
        }

        public IActionResult Index() //R
        {
           return View(_db.Addresses.ToList());
        }

        [HttpPost]
        public IActionResult Delete(int id) //D
        {
            var address = _db.Addresses.Find(id);
            if (address != null)
            {
                _db.Addresses.Remove(address);
                _db.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        public IActionResult Create() //C
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateConfirmed(Address address)
        {
            if (address != null)
            {
                _db.Addresses.Add(address);
                _db.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        public IActionResult Update(int id) //U
        {
            var address = _db.Addresses.Find(id);
            if (address != null)
            {
                return View(address);
            }
             return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult UpdateConfirmed(Address address)
        {
            if (address != null)
            {
                _db.Addresses.Update(address);
                _db.SaveChanges();
            }
            return RedirectToAction("Index");
        }
    }
}