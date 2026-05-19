using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Hosting;

namespace Web.Controllers
{
    public class HomeController : BaseController
    {
        public HomeController(IWebHostEnvironment env) : base(env)
        {
        }

        public IActionResult Index() => View();

        public IActionResult Error()
        {
            var feature = HttpContext.Features.Get<IExceptionHandlerPathFeature>();
            var model = CreateErrorViewModel(feature?.Error);
            return View(model);
        }
    }
}