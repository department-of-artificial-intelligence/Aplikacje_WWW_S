using AWWW_lab1_gr5.Models;
using Microsoft.AspNetCore.Mvc;



namespace AWWW_lab1_gr5.Controllers
{
    public class AuthorController : Controller
    {
        private readonly MyDbContext _context;

        public AuthorController(MyDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var authors = _context.Authors.ToList();
            return View(authors);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Author author)
        {
            _context.Authors.Add(author);
            _context.SaveChanges();
            return View("Added", author);
        }
    }
}
