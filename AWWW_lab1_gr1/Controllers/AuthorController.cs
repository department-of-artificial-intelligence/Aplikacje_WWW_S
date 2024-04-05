using Microsoft.AspNetCore.Mvc;
using AWWW_lab1_gr1.Models;

namespace AWWW_lab1_gr1.Controllers
{
    public class AuthorController : Controller
    {
        private readonly LabDbContext _dbContext;

        public AuthorController(LabDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public IActionResult Index()
        {
            var author = _dbContext.Authors!.ToList(); 
            return View(author);
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
                _dbContext.Authors.Add(author);
                _dbContext.SaveChanges();
                return View("Added", author);
            }
            return View("Error");
        }
    }
}