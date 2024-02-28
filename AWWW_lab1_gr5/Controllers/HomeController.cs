using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace AWWW_lab1_gr5.Controllers
{
        public class HomeController : Controller
    {        public IActionResult Index()
        {
            ViewBag.Title = "Home"
            return View();
        }
    }
}