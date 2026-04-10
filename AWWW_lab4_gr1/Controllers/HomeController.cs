using Microsoft.AspNetCore.Mvc;
using AWWW_lab4_gr1.Models;

namespace AWWW_lab4_gr1.Controllers
{
    public class HomeController : Controller
    {
        private readonly AppDbContext _dbContext;

        public HomeController(AppDbContext context)
        {
            _dbContext = context;
        }

        public IActionResult Index()
        {
            ViewBag.Title = "Home";
            
            var vm = new ViewModel
            {
                Categories = _dbContext.Categories.ToList(),
                Tags = _dbContext.Tags.ToList(),
                Addresses = _dbContext.Addresses.ToList()
            };

            return View(vm);
        }
    }
}