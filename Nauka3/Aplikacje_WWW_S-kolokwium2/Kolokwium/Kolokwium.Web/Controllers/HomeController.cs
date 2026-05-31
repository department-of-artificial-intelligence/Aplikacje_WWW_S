using AutoMapper;
using Kolokwium.Web.ViewModels;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using System.Diagnostics;

namespace Kolokwium.Web.Controllers
{
    public class HomeController : BaseController
    {
        //Te env z tymi errorami znowu chyba nie bedzie potrzebne
        public HomeController(ILogger logger, IMapper mapper, IStringLocalizer localizer,IWebHostEnvironment env) 
            : base(logger, mapper, localizer,env)
        {
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        //Od tego miejsca
       // [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
       // public IActionResult Error()
       // {
          //  var exceptionHandlerPathFeature = HttpContext.Features.Get<IExceptionHandlerPathFeature>();

           // var errorViewModel = CreateErrorViewModel(exceptionHandlerPathFeature?.Error);

           // return View(errorViewModel);
       // }

    }
}
