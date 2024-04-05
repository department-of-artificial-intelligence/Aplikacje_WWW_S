
using AWWW_lab1_gr1.Models;
using Microsoft.AspNetCore.Mvc;


namespace AWWW_lab1_gr1.Controllers
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
            var tags = _dbContext.Tags!.ToList(); 
            return View(tags);
        }

        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(Tag tag)
        {
            _dbContext.Tags!.Add(tag); 
            _dbContext.SaveChanges();
            return RedirectToAction("Index");
        }


        


    }
}