using DAL;
using Microsoft.AspNetCore.Mvc;
using Model;

namespace Web.Controllers
{
    public class BuildingController : Controller
    {

        private readonly AppDbContext _context;
        public BuildingController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View(_context.Buildings.ToList());
        }

        public IActionResult Create() => View();

        [HttpPost]
        public IActionResult Create(Building b)
        {
            _context.Buildings.Add(b);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}
