using Microsoft.AspNetCore.Mvc;
using AWWW_lab2.v2_gr1.Models;
using System.Linq;
using AWWW_lab2.v2_gr1.Data;

namespace AWWW_lab2.v2_gr1.Controllers
{
    public class HomeController : Controller
    {
        private readonly AppDbContext _context;

        public HomeController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var vm = new HomeViewModel
            {
                Categories = _context.Categories.ToList(),
                Addresses = _context.Addresses.ToList(),
                Tags = _context.Tags.ToList()
            };

            return View(vm);
        }
    }
}