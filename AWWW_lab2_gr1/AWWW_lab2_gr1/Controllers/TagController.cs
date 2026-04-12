using AWWW_lab2_gr1.Models;
using Microsoft.AspNetCore.Mvc;

namespace YourProjectName.Controllers
{
    public class TagController : Controller
    {
        private readonly AppDbContext _context;

        public TagController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var tags = _context.Tags.ToList();
            return View(tags);
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

            _context.Tags.Add(tag);
            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }
    }
}