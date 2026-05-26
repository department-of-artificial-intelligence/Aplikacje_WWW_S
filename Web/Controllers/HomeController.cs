using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Web.ViewModels;

namespace Web.Controllers {
    public class HomeController : BaseController {
        public HomeController(IWebHostEnvironment env) : base(env) { }

        public IActionResult Index() {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error() {
            var feature = HttpContext.Features.Get<IExceptionHandlerPathFeature>();
            var model = CreateErrorViewModel(feature?.Error);
            return View();
        }
    }
}
