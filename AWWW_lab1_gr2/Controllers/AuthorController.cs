using AWWW_lab1_gr2.Models;
using Microsoft.AspNetCore.Mvc;

namespace AWWW_lab1_gr2.Controllers
{
    public class AuthorController : Controller
    {
        private readonly MyDbContext _dbContext;

        public AuthorController(MyDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IActionResult Index(int id)
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
            _dbContext.Author.Add(author); 
            _dbContext.SaveChanges();
            return View("Added",author); 
        }
    }
}
