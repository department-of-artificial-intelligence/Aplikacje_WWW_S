using Microsoft.AspNetCore.Mvc;
using AWWW_lab2_gr1.Models;

namespace AWWW_lab2_gr1.Controllers
{
    public class AddressController : Controller
    {
        public IActionResult Index(int id)
        {
            var address = Repository.Addresses.ToList()[id];
            return View(address);
        }

        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(Address address)
        {
            Repository.AddAddress(address);
            return View("Added", address);
        }
    }
}