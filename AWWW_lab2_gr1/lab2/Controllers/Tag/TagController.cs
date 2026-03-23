using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using lab2.Models;
using lab2.Data;

namespace lab2.Controllers
{
    public class TagController : Controller
    {
        public IActionResult Index()
        {
            return View(FakeData.Tags);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Tag tag)
        {
            if (!ModelState.IsValid)
                return View(tag);

            tag.Id = FakeData.Tags.Count == 0
                ? 1
                : FakeData.Tags.Max(c => c.Id) + 1;

            FakeData.Tags.Add(tag);

            return RedirectToAction(nameof(Index));
        }
    }
}