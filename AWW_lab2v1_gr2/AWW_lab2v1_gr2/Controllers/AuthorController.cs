using Microsoft.AspNetCore.Mvc;

using AWWW_lab2v1_gr2.Models;

namespace AWWW_lab2v1_gr2.Controllers
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
            return View();
        }

        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(Author author)
        {
            _context.Authors.Add(author);
            _context.SaveChanges();
            return View("Added", author);
        }
    }
}