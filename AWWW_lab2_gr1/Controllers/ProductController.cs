using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using AWWW_lab2_gr1.Models;
using Microsoft.AspNetCore.Mvc.ActionConstraints;


namespace AWWW_lab2_gr1
{
    public class ProductController : Controller
    {
        private readonly AppDbContext _db;

        public ProductController(AppDbContext db)
        {
            _db = db;
        }

        //R
        public IActionResult Index()
        {
            return View(_db.Products.ToList());
        }

        //C
        public IActionResult Create()
        {
           ICollection<Category> cats = _db.Categories.ToList();
           ViewData["cats"] = cats;

           return View("Form", new Product());
        }

        [HttpPost]
        public IActionResult CreateConfirm(Product p)
        {
            _db.Products.Add(p);
            _db.SaveChanges();

            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            var prod = _db.Products.Find(id);

            if (prod != null)
            {
                _db.Products.Remove(prod);
                _db.SaveChanges();
            }

            return RedirectToAction("Index");
        }
    }
}