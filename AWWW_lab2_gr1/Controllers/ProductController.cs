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

           ICollection<Tag> tags = _db.Tags.ToList();
           ViewData["tags"] = tags;

           return View("Form", new Product());
        }

        [HttpPost]
        public IActionResult Save(Product p, List<int> selectedTags)
        {
            Product product;

            if (p.Id == 0)
            {
                product = new Product();
                _db.Products.Add(product);
            }
            else
            {
                product = _db.Products
                    .Include(x => x.Tags)
                    .FirstOrDefault(x => x.Id == p.Id);

                if (product == null)
                    return RedirectToAction("Index");
            }

            product.Name = p.Name;
            product.Price = p.Price;
            product.CategoryId = p.CategoryId;

            product.Tags.Clear();

            if (selectedTags != null)
            {
                var tags = _db.Tags
                    .Where(t => selectedTags.Contains(t.Id))
                    .ToList();

                foreach (var tag in tags)
                    product.Tags.Add(tag);
            }

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

        public IActionResult Update(int id)
        {
            var prod = _db.Products.Find(id);

            ICollection<Category> cats = _db.Categories.ToList();
            ViewData["cats"] = cats;

            ICollection<Tag> tags = _db.Tags.ToList();
            ViewData["tags"] = tags;

            if (prod != null)
            {
                return View("Form", prod);
            }
            return RedirectToAction("Index");
        }
    }
}