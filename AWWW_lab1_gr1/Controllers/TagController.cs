using AWWW_lab1_gr1.Data;
using AWWW_lab1_gr1.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AWWW_lab1_gr1.Controllers
{
    public class TagController : Controller
    {
        private readonly MyDBContext _dbContext;

        public TagController(MyDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IActionResult Index()
        {
            List<Tag> tags = _dbContext.Tags!.ToList();
            return View(tags);
        }

        public IActionResult Details(int id)
        {
            Tag? tag = _dbContext.Tags
                .Include(a => a.Articles)
                .FirstOrDefault(a => a.Id == id);
            return View(tag);
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
                _dbContext.Tags.Add(tag);
                _dbContext.SaveChanges();
            }
            return RedirectToAction("Index");
        }
    }
}
