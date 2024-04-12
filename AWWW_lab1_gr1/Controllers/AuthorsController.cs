using AWWW_lab1_gr1.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace AWWW_lab1_gr1.Controllers
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
            var authors = _dbContext.Authors.ToList();
            return View(authors);
        }

        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(Author author)
        {
            _dbContext.Authors.Add(author);
            _dbContext.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
