using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Web.ViewModels;

namespace Web.Controllers {
    public class BaseController : Controller {

        protected readonly IWebHostEnvironment Env;

        protected BaseController(IWebHostEnvironment env) { Env = env; }

        protected ErrorViewModel CreateErrorViewModel(Exception? ex = null) {
            return new ErrorViewModel {
                RequestId = HttpContext.TraceIdentifier,
                ShowDetails = Env.IsDevelopment(),
                Exception = ex
            };
        }

        protected void SetSuccessMessage(string message) {
            TempData["Success"] = message;
        }

        protected void SetErrorMessage(string message) {
            TempData["Error"] = message;
        }
    }
}
