using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using System;
using Web.ViewModels;

namespace Web.Controllers
{
    public abstract class BaseController : Controller
    {
        protected readonly IWebHostEnvironment Env;

        protected BaseController(IWebHostEnvironment env)
        {
            Env = env;
        }

        protected ErrorViewModel CreateErrorViewModel(Exception? exception = null)
        {
            return new ErrorViewModel
            {
                RequestId = HttpContext.TraceIdentifier,
                ShowDetails = Env.IsDevelopment(),
                Exception = exception
            };
        }

        protected void SetSuccessMessage(string message)
        {
            TempData["Success"] = message;
        }

        protected void SetErrorMessage(string message)
        {
            TempData["Error"] = message;
        }
    }
}

relacja, 2 3 encje gora, migracja, service, z serwisu do kontrolerow, widoki