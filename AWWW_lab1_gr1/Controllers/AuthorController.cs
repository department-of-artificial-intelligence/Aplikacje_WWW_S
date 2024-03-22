using AWWW_lab1_gr1.Data;
using AWWW_lab1_gr1.Models;
using Microsoft.AspNetCore.Mvc;

namespace AWWW_lab1_gr1.Controllers
{
    public class AuthorController : Controller
    {
        private readonly MyDBContext _dbContext;

        public AuthorController(MyDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IActionResult Index()
        {
            List<Author> author = _dbContext.Authors!.ToList();
            return View(author);
        }

        public IActionResult Details(int id) 
        {
            Author? author = _dbContext.Authors!.FirstOrDefault(x => x.Id == id);
            return View(author);
        }
    }
}
