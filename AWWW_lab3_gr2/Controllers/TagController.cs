using AWWW_lab3_gr2.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace AWWW_lab3_gr2.Controllers
{
    public class TagController : Controller
    {
        private readonly MyDbContext _dbContext;

        public TagController(MyDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IActionResult Index()
        {
            var tags = _dbContext.Tag.ToList();
            return View(tags);
        }

        public IActionResult Details(int id)
        {
            var tag = _dbContext.Tag.FirstOrDefault(a => a.Id == id);
            if (tag != null)
                return View(tag);
            return View("Error");
        }
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(Tag tag)
        {
            if (ModelState.IsValid)
            {
                _dbContext.Tag.Add(tag);
                _dbContext.SaveChanges();
                return View("Added", tag);
            }
            return View();
        }
    }
}