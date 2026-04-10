using Microsoft.AspNetCore.Mvc;
using AWWW_lab4_gr1.Models;

namespace AWWW_lab4_gr1.Controllers
{
    public class AddressController : Controller
    {
        private readonly AppDbContext _dbContext;

        public AddressController(AppDbContext context)
        {
            _dbContext = context;
        }

        public IActionResult Index(int id)
        {
            var address = _dbContext.Addresses.FirstOrDefault(a => a.Id == id);
            return View(address);
        }

        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(Address address)
        {
            _dbContext.Addresses.Add(address);
            _dbContext.SaveChanges();

            return View("Added", address);
        }
    }
}