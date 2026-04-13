using Kolokwium.Data;
using Kolokwium.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Kolokwium.Controllers
{
    public class LibraryController : Controller
    {

        private readonly AppDbContext _context;

        public LibraryController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View(_context.Libraries.ToList());
        }

        public IActionResult Create()
        {
            ViewBag.Authors = new SelectList(_context.Authors, "Id", "Name");
            return View();
        }

        public IActionResult Details(int id)
        {
            var library = _context.Libraries.Include(l => l.Books).FirstOrDefault(l => l.Id == id);
            //var library = _context.Libraries.Include(l => l.Books).Include(l => l.Author).FirstOrDefault(l => l.Id == id);

            return View(library);
        }

        [HttpPost]
        public IActionResult Create(Library library)
        {
            _context.Libraries.Add(library);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
