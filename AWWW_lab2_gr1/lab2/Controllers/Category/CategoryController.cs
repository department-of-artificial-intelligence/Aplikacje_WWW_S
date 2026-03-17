using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using lab2.Models;
using lab2.Data;

namespace lab2.Controllers
{
    public class CategoryController : Controller
    {
        public IActionResult Index()
        {
            return View(FakeData.Categories);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Category category)
        {
            if (!ModelState.IsValid)
                return View(category);

            category.Id = FakeData.Categories.Count == 0
                ? 1
                : FakeData.Categories.Max(c => c.Id) + 1;

            FakeData.Categories.Add(category);

            return RedirectToAction(nameof(Index));
        }
    }
}