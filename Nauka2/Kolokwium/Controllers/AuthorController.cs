using Kolokwium.Data;
using Kolokwium.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Kolokwium.Controllers
{
    public class AuthorController : Controller
    {

        private readonly AppDbContext _context;

        public AuthorController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View(_context.Authors.ToList());
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Author author)
        {

            if (!ModelState.IsValid)
            {
                return View(author);
            }

            _context.Authors.Add(author);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
