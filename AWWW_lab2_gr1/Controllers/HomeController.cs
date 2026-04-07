using Microsoft.AspNetCore.Mvc;
using AWWW_lab2_gr1.Models;

namespace AWWW_lab2_gr1.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.Title = "Home";
            
            var vm = new ViewModel
            {
                Categories = Repository.Categories.ToList(),
                Tags = Repository.Tags.ToList(),
                Addresses = Repository.Addresses.ToList()
            };

            return View(vm);
        }
    }
}