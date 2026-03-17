using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using lab2.Models;
using lab2.Data;


namespace lab2.Controllers.Address
{
    public class AddressController : Controller
    {
        public IActionResult Index()
        {
            return View(FakeData.Addresses);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
    }
}