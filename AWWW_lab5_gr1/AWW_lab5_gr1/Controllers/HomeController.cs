using System.Diagnostics;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Web.Controllers;

namespace AWW_lab5_gr1.Controllers
{
    public class HomeController : BaseController
    {
        public HomeController(IWebHostEnvironment env) : base(env) { }

        public IActionResult Index()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            var exceptionHandlerPathFeature = HttpContext.Features.Get<IExceptionHandlerPathFeature>();

            var errorViewModel = CreateErrorViewModel(exceptionHandlerPathFeature?.Error);

            return View(errorViewModel);
        }
    }
}
