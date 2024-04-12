using AWWW_lab3_gr2.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace AWWW_lab3_gr2.Controllers
{
    public class AuthorController : Controller
    {
        private readonly MyDbContext _dbContext;

        public AuthorController(MyDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IActionResult Index()
        {
            var authors = _dbContext.Author.ToList();
            return View(authors);
        }

        public IActionResult Details(int id)
        {
            var author = _dbContext.Author.FirstOrDefault(a => a.Id == id);
            if (author != null)
                return View(author);
            return View("Error");
        }
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(Author author)
        {
            if (ModelState.IsValid)
            {
                _dbContext.Author.Add(author);
                _dbContext.SaveChanges();
                return View("Added", author);
            }
            return View();
        }
    }
}