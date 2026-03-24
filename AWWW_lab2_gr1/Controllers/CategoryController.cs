using Microsoft.AspNetCore.Mvc;
using AWWW_lab2_gr1.Models;

namespace AWWW_lab2_gr1.Controllers
{
    public class CategoryController : Controller
    {
        public IActionResult Index(int id)
        {
            var category = Repository.Categories.ToList()[id];
            return View(category);
        }

        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(Category category)
        {
            Repository.AddCategory(category);
            return View("Added", category);
        }
    }
}
