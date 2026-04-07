using Microsoft.AspNetCore.Mvc;
using AWWW_lab2_gr1.Models;

namespace AWWW_lab2_gr1.Controllers
{
    public class TagController : Controller
    {
        public IActionResult Index(int id)
        {
            var tag = Repository.Tags.ToList()[id];
            return View(tag);
        }

        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(Tag tag)
        {
            Repository.AddTag(tag);
            return View("Added", tag);
        }
    }
}
