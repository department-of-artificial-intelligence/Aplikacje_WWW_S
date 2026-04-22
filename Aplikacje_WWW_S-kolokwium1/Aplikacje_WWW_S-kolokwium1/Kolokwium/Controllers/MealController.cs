using Kolokwium.Models;
using Microsoft.AspNetCore.Mvc;

namespace Kolokwium.Controllers
{
    public class MealController : Controller
    {
        private readonly AppDbContext _context;

        public MealController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var meals = _context.Meals.ToList();
            return View(meals);
        }
    }
}
