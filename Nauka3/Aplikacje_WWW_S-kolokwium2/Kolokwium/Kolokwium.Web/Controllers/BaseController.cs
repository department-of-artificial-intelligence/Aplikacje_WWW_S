using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Kolokwium.Web.ViewModels;

namespace Kolokwium.Web.Controllers
{
    public abstract class BaseController : Controller
    {
        protected readonly IStringLocalizer Localizer;
        protected readonly ILogger Logger;
        protected readonly IMapper Mapper;
        protected readonly IWebHostEnvironment Env;//nie wiem czy to potrzebne bedzie
        public BaseController(ILogger logger, IMapper mapper, IStringLocalizer localizer, IWebHostEnvironment env)
        {
            Localizer = localizer;
            Logger = logger;
            Mapper = mapper;
            Env = env;//

        }

        //To tez
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
