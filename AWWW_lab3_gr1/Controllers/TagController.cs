using Microsoft.AspNetCore.Mvc;
using AWWW_lab3_gr1.Models;

namespace AWWW_lab3_gr1.Controllers
{
    public class TagController : Controller
    {
        private readonly AppDbContext _dbContext;

        public TagController(AppDbContext context)
        {
            _dbContext = context;
        }

        public IActionResult Index(int id)
        {
            var tag = _dbContext.Tags.FirstOrDefault(t => t.Id == id);
            return View(tag);
        }

        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(Tag tag)
        {
            _dbContext.Tags.Add(tag);
            _dbContext.SaveChanges();

            return View("Added", tag);
        }
    }
}