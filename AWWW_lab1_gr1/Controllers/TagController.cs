using Microsoft.AspNetCore.Mvc;
using AWWW_lab1_gr1.Models;

namespace AWWW_lab1_gr1.Controllers
{
    public class TagController : Controller
    {
        private readonly LabDbContext _dbContext;

        public TagController(LabDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public IActionResult Index()
        {
            var tag = _dbContext.Tags!.ToList(); 
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
                return View("Added", tag);
            }
            return View("Error");
        }
    }
}