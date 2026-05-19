using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Web.ViewModels;

namespace Web.Controllers
{
    public class BaseController : Controller
    {
        protected readonly IWebHostEnvironment _env;

        public BaseController(IWebHostEnvironment env)
        {
            _env = env;
        }

        protected void SetNotification(string type, string message)
        {
            TempData[type] = message;
        }

        protected ErrorViewModel CreateErrorViewModel(Exception? exception = null)
        {
            return new ErrorViewModel
            {
                RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier,
                ShowDetails = _env.IsDevelopment(),
                Exception = exception
            };
        }
    }
}
