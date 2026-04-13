using AWWW_lab3_gr1.Data;
using AWWW_lab3_gr1.Models;
using Microsoft.AspNetCore.Mvc;

namespace AWWW_lab3_gr1.Controllers
{
    public class TagController : Controller
    {
        private readonly AppDbContext _context;
        public TagController(AppDbContext context) 
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View(_context.Tags.ToList());
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]

        public IActionResult Create(Tag tag)
        {
            _context.Tags.Add(tag);
            _context.SaveChanges();

            return RedirectToAction("index");
        }
    }
}
